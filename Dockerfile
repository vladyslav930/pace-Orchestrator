ARG CNC_IMAGE
FROM $CNC_IMAGE as clients-and-contracts

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine as builder 

COPY --from=clients-and-contracts / /

ARG SERVICE_DIR_NAME
COPY . /$SERVICE_DIR_NAME

WORKDIR /$SERVICE_DIR_NAME

RUN dotnet publish ./src/Dxc.Pace.Orchestrator.Host/Dxc.Pace.Orchestrator.Host.csproj \
    -c release -o /published/web --runtime linux-x64

FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.1

WORKDIR /published

COPY --from=builder /published/web ./web

ARG InformationalVersion="1.0.0"
ENV INFORMATIONAL_VERSION_INFO=$InformationalVersion

WORKDIR ./web
CMD ["./Dxc.Pace.Orchestrator.Host"]
