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

cd $SCRIPT_PATH

REPO_ROOT_DIR=$(git rev-parse --show-toplevel 2>/dev/null || echo '')
if [ ! -n "$REPO_ROOT_DIR" ] ; then
  echo -e "\nThe script is not placed in its repo directory."
  echo -e "Please return it back and run again."
  echo -e "Aborting...\n"
  exit 1
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

function pushToRegistry {
  if [ -z "${BUILD_TAG:-}" ]; then
    BUILD_TAG="$PACE_VERSION.$commitHash"  
    if [ -n "${BUILD_VERSION:-}" ]; then
      BUILD_TAG="$PACE_VERSION.$BUILD_VERSION"
    fi
  fi

  if $sudo docker images --format "{{.Repository}}:{{.Tag}}" | grep "${1}:${BUILD_TAG}"; then
    echo -e "Pushing ${1}:${BUILD_TAG} image...\n"
    $sudo docker push "${1}:${BUILD_TAG}"
  else
    echo -e "Docker image ${1}:${BUILD_TAG} not found!\n"
    echo -e "Please, build one first!\n"
    exit 1
  fi
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
  "$DOCKER_IMAGE"
)

#echo "InformationalVersion: $VERSION_INFO"

for image in "${images[@]}"
do
  pushToRegistry $image || throwError "Image pushing shows error! Aborting."
done

echo -e "\nDONE!\n"
echo -e "Finish at $(date)\n"
echo "RUN TIME: $(($SECONDS / 60))m $(($SECONDS % 60))s"
