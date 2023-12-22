#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FT.Travelako.Services.CouponAPI/FT.Travelako.Services.CouponAPI.csproj", "FT.Travelako.Services.CouponAPI/"]
COPY ["FT.Travelako.Base/FT.Travelako.Base.csproj", "FT.Travelako.Base/"]
COPY ["Service.Core/Service.Core.csproj", "Service.Core/"]
RUN dotnet restore "./FT.Travelako.Services.CouponAPI/./FT.Travelako.Services.CouponAPI.csproj"
COPY . .
WORKDIR "/src/FT.Travelako.Services.CouponAPI"
RUN dotnet build "./FT.Travelako.Services.CouponAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FT.Travelako.Services.CouponAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FT.Travelako.Services.CouponAPI.dll"]