#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Stock.Management.Api.csproj", "."]
RUN dotnet restore "./Stock.Management.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Stock.Management.Api" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stock.Management.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stock.Management.Api.dll"]