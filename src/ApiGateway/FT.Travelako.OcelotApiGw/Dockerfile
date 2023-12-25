#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ApiGateway/FT.Travelako.OcelotApiGw/FT.Travelako.OcelotApiGw.csproj", "ApiGateway/FT.Travelako.OcelotApiGw/"]
COPY ["Common/FT.Travelako.Common.Logging/FT.Travelako.Common.Logging.csproj", "Common/FT.Travelako.Common.Logging/"]
RUN dotnet restore "./ApiGateway/FT.Travelako.OcelotApiGw/./FT.Travelako.OcelotApiGw.csproj"
COPY . .
WORKDIR "/src/ApiGateway/FT.Travelako.OcelotApiGw"
RUN dotnet build "./FT.Travelako.OcelotApiGw.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FT.Travelako.OcelotApiGw.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FT.Travelako.OcelotApiGw.dll"]