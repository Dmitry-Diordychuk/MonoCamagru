FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
RUN apt-get update && apt-get install -y dnsutils
WORKDIR /fastcgi-server
COPY . .
COPY ./docker-entrypoint.sh		.
RUN dotnet build
RUN mkdir /var/www && mkdir /var/www/site
ENTRYPOINT [ "/bin/sh", "docker-entrypoint.sh" ]
