#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./services/NSE.Pedidos.API/NSE.Pedidos.API.csproj", "services/NSE.Pedidos.API/"]
COPY ["./buildingblocks/NSE.Core/NSE.Core.csproj", "buildingblocks/NSE.WebAPI.Core/"]
COPY ["./buildingblocks/NSE.WebAPI.Core/NSE.WebAPI.Core.csproj", "buildingblocks/NSE.WebAPI.Core/"]
COPY ["./buildingblocks/NSE.MessageBus/NSE.MessageBus.csproj", "buildingblocks/NSE.MessageBus/"]

RUN dotnet restore "services/NSE.Pedidos.API/NSE.Pedidos.API.csproj"
COPY . .
WORKDIR "services/NSE.Pedidos.API"
RUN dotnet build "NSE.Pedidos.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Pedidos.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Pedidos.API.dll"]
