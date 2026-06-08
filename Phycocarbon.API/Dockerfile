FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Phycocarbon.API/Phycocarbon.API.csproj", "Phycocarbon.API/"]
COPY ["Phycocarbon.Infrastructure/Phycocarbon.Infrastructure.csproj", "Phycocarbon.Infrastructure/"]
COPY ["Phycocarbon.Application/Phycocarbon.Application.csproj", "Phycocarbon.Application/"]
COPY ["Phycocarbon.Domain/Phycocarbon.Domain.csproj", "Phycocarbon.Domain/"]
RUN dotnet restore "Phycocarbon.API/Phycocarbon.API.csproj"
COPY . .
WORKDIR "/src/Phycocarbon.API"
RUN dotnet build "./Phycocarbon.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Phycocarbon.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Phycocarbon.API.dll"]
