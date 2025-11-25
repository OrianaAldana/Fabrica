#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base final para el runtime de la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Fase de Build: Usamos el SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia solo el archivo de proyecto para la restauración de dependencias
COPY ["FabricaNube.csproj", "."]
RUN dotnet restore "./FabricaNube.csproj"

# Copia TODOS los archivos restantes. ESTO INCLUYE las carpetas 'Data', 'Controllers', etc.
# Aseguramos que la estructura completa de C# esté en /src
COPY . .

# Construye el proyecto completo. 
# NOTA: Eliminamos la línea WORKDIR "/src/." que era innecesaria.
RUN dotnet build "FabricaNube.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Fase de Publicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FabricaNube.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Fase Final: Ejecución
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FabricaNube.dll"]