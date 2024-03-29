#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Coupon/FT.Travelako.Services.CouponAPI/FT.Travelako.Services.CouponAPI.csproj", "Services/Coupon/FT.Travelako.Services.CouponAPI/"]
COPY ["Common/FT.Travelako.Common.Logging/FT.Travelako.Common.Logging.csproj", "Common/FT.Travelako.Common.Logging/"]
COPY ["Common/FT.Travelako.Common/FT.Travelako.Common.csproj", "Common/FT.Travelako.Common/"]
COPY ["Common/FT.Travelako.Service.Core/FT.Travelako.Service.Core.csproj", "Common/FT.Travelako.Service.Core/"]
RUN dotnet restore "./Services/Coupon/FT.Travelako.Services.CouponAPI/./FT.Travelako.Services.CouponAPI.csproj"
COPY . .
WORKDIR "/src/Services/Coupon/FT.Travelako.Services.CouponAPI"
RUN dotnet build "./FT.Travelako.Services.CouponAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FT.Travelako.Services.CouponAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FT.Travelako.Services.CouponAPI.dll"]