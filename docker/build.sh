#!/usr/bin/env bash

# ensure running bash
if [ -z "$BASH_VERSION" ]; then
  echo "this is not bash, calling self with bash....";
  SCRIPT=$(readlink -f "$0")
  /bin/bash "$SCRIPT"
  exit "$?"
fi

set -eu

SERVICE_NAME=orchestrator
NEXUS_REGISTRY=nexus-pace.prjdmz.luxoft.com

SCRIPT=$(realpath $0)
SCRIPT_PATH=$(dirname $SCRIPT)
SERVICE_DIR=$(dirname $SCRIPT_PATH)
SERVICE_DIR_NAME=$(basename $SERVICE_DIR)

cd $SCRIPT_PATH

REPO_ROOT_DIR=$(git rev-parse --show-toplevel 2>/dev/null || echo '')
if [ ! -n "$REPO_ROOT_DIR" ] ; then
  echo -e "\nThe script is not placed in its repo directory."
  echo -e "Please return it back and run again."
  echo -e "Aborting...\n"
  exit 1
fi

if [ ! `pwd` == $REPO_ROOT_DIR ] ; then
  echo -e "\nChanging to service root directory: $SERVICE_DIR"
  cd $SERVICE_DIR
fi

#set up sudo for Linux
sudo=sudo

if groups $(whoami) | grep -q 'docker\|root'; then
  sudo=
elif [ "$(uname)" == "Darwin" ]; then
  sudo=
fi

function throwError() {
  echo -e "\n\n$(
    tput setaf 1
    tput setab 7
  )$1$(tput sgr 0)\n\n"
  exit 1
}

function clients-n-contracts() {
  while read -r cnc
  do
    cncs+=("$cnc")
  done < <( grep 'COPY' "$CC_Dockerfile" | awk -F ' ' '{print "!" $2 "/*"}' )
}

function buildBaseImage() {
  CC_Dockerfile="../.tools/docker-build/DockerInit/Dockerfile.base"
  echo "If you are adding a new client or contract project, remember to add them to $CC_Dockerfile"
  
  if ! $sudo docker images --format "{{.Repository}}:{{.Tag}}" | grep -q "clients-n-contracts:$commitHash"; then

    declare -a cncs=()
    clients-n-contracts

    mv ../.dockerignore ../.dockerignore.orig
    echo '*' > ../.dockerignore

    for path in "${cncs[@]}"
    do
      echo $path >> ../.dockerignore
    done

    LABEL=$SERVICE_NAME
    echo -e "Building clients-n-contracts image...\n"
    $sudo docker build \
           --label "app=$LABEL" \
           --no-cache \
           --force-rm \
           --rm \
           -t "clients-n-contracts:$commitHash" -f "$CC_Dockerfile" ../ || \
    (mv -f ../.dockerignore.orig ../.dockerignore && \
      throwError "Clients-n-contracts image building process shows error! Aborting.") && \
    mv -f ../.dockerignore.orig ../.dockerignore
  fi
}

function buildImage() {
  
  if [ -z "${2:-}" ]
  then Dockerfile=""
  else Dockerfile="-f $2"
  fi

#  LABEL=$(echo "$1" | awk -F '/' '{print $2}')
  LABEL=$SERVICE_NAME

  if $sudo docker images | grep -q "$1"; then
    echo -e "Purging old images.\n"
    $sudo docker image prune -a --filter "label=app=$LABEL" --filter "until=2h" -f
#    $sudo docker images | grep "$1" | awk '{print $3}' | xargs -r $sudo docker rmi -f 2>/dev/null
  fi

  buildBaseImage || throwError "Job failed!"

  echo -e "Building new $LABEL image...\n"
  $sudo docker build \
         --build-arg InformationalVersion="$VERSION_INFO" \
         --build-arg CNC_IMAGE="clients-n-contracts:$commitHash" \
         --build-arg SERVICE_DIR_NAME="$SERVICE_DIR_NAME" \
         --build-arg commitHash="$commitHash" \
         --label "app=$LABEL" \
         --no-cache \
         --force-rm \
         --rm \
         -t "$1:$commitHash" $Dockerfile . || throwError "Service image building process shows error! Aborting."

  if [ -z "${BUILD_TAG:-}" ]; then
    BUILD_TAG="$PACE_VERSION.$commitHash"  
    if [ -n "${BUILD_VERSION:-}" ]; then
      BUILD_TAG="$PACE_VERSION.$BUILD_VERSION"
    fi
  fi

  $sudo docker tag "$1:$commitHash" "$1:$BUILD_TAG"
  echo Additionally tagged built image as "$1:$BUILD_TAG"
}

echo -e "Starting at $(date)\n"

commitHash=$(git rev-parse --short HEAD)
echo "Commit hash: $commitHash"

longopts='local-build,docker-registry:'
OPTS=$(getopt -o '' -l $longopts -n "$0" -- "$@" || throwError "Failed parsing options!")
eval set -- "$OPTS"

while true; do
  case "$1" in 
    --local-build)
      LOCAL_BUILD=true
      shift
      ;;
    --docker-registry)
      DOCKER_REGISTRY=$2
      shift 2
      ;;
    --)
      shift
      break
      ;;
  esac
done

if [ -z "${LOCAL_BUILD:-}" ]; then
  source "${REPO_ROOT_DIR}/scripts/getenv.sh"
  DOCKER_IMAGE="${NEXUS_REGISTRY}/${SERVICE_NAME}"
else
  if [ -z "${DOCKER_REGISTRY:-}" ]; then
    DOCKER_IMAGE=$SERVICE_NAME
  else
    DOCKER_IMAGE="${DOCKER_REGISTRY}/${SERVICE_NAME}"
  fi
  source "${REPO_ROOT_DIR}/scripts/getenv.sh" --local-build
fi

declare -a images=(
  "$DOCKER_IMAGE Dockerfile"
)

#echo "InformationalVersion: $VERSION_INFO"

for image in "${images[@]}"
do
  buildImage $image || throwError "Image building process shows error! Aborting."
  sleep 5
#  $sudo docker images -q -f "dangling=true" | xargs -r $sudo docker rmi &>/dev/null
done

echo -e "\nDONE!\n"
echo -e "Finish at $(date)\n"
echo "RUN TIME: $(($SECONDS / 60))m $(($SECONDS % 60))s"
