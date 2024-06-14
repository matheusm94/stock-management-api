FROM mcr.microsoft.com/dotnet/runtime-deps:8.0-alpine

ENV COMPlus_EnableDiagnostics=0

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    LC_ALL=pt_BR.UTF-8 \
    LANG=pt_BR.UTF-8

ENV ASPNETCORE_URLS http://+:5000

EXPOSE 5000

RUN apk add --no-cache icu-libs icu-data-full tzdata

RUN addgroup -g 2000 dotnet && \
    adduser -G dotnet -u 1000 dotnet -D \
  --disabled-password \
  --home /app \
  --gecos '' dotnet && chown -R dotnet /app

RUN chown dotnet:dotnet /app /tmp
USER dotnet

WORKDIR /app
COPY dist .

ENTRYPOINT ["./Stock.Management.Api"]