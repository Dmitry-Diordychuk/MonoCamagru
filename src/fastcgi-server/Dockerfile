FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/fastcgi-server/fastcgi-server.csproj", "src/fastcgi-server/"]
RUN dotnet restore "fastcgi-server/fastcgi-server.csproj"
COPY . .
WORKDIR "/src/fastcgi-server"
RUN dotnet build "fastcgi-server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "fastcgi-server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fastcgi-server.dll"]
