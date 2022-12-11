FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /fastcgi-server
COPY . .
RUN dotnet build
RUN mkdir /var/www && mkdir /var/www/site
ENTRYPOINT ["dotnet", "run", "--", "--listen", "127.0.0.1:9000", "--app", "/var/www/site"]
