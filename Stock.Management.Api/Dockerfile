# Use the official SDK image como base para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copie csproj e restaurar dependências
COPY *.csproj ./
RUN dotnet restore

# Copie todo o código-fonte e build do aplicativo
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expor a porta utilizada pelo aplicativo
EXPOSE 80

# Comando de entrada para iniciar o aplicativo
ENTRYPOINT ["dotnet", "Stock.Management.Api.dll"]
