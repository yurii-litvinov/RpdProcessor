FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env
WORKDIR /app

RUN apk add --update npm

COPY . ./

RUN npm install

# See https://thorsten-hans.com/how-to-build-smaller-and-secure-docker-images-for-net5
RUN dotnet publish -c Release -o out --runtime alpine-x64 --self-contained true /p:PublishTrimmed=true

FROM mcr.microsoft.com/dotnet/runtime-deps:5.0-alpine

RUN adduser --disabled-password \
  --home /app \
  --gecos '' dotnetuser && chown -R dotnetuser /app

RUN apk upgrade musl

USER dotnetuser
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

COPY --from=build-env /app/out/ .
ENTRYPOINT ["./RpdProcessor"]