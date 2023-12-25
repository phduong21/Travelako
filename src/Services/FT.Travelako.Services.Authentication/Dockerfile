#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/FT.Travelako.Services.Authentication/FT.Travelako.Services.Authentication.csproj", "Services/FT.Travelako.Services.Authentication/"]
COPY ["Common/FT.Travelako.Common.Logging/FT.Travelako.Common.Logging.csproj", "Common/FT.Travelako.Common.Logging/"]
COPY ["Common/FT.Travelako.Common/FT.Travelako.Common.csproj", "Common/FT.Travelako.Common/"]
COPY ["Common/FT.Travelako.Service.Core/FT.Travelako.Service.Core.csproj", "Common/FT.Travelako.Service.Core/"]
RUN dotnet restore "./Services/FT.Travelako.Services.Authentication/./FT.Travelako.Services.Authentication.csproj"
COPY . .
WORKDIR "/src/Services/FT.Travelako.Services.Authentication"
RUN dotnet build "./FT.Travelako.Services.Authentication.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FT.Travelako.Services.Authentication.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FT.Travelako.Services.Authentication.dll"]