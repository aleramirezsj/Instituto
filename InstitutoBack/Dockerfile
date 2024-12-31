# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar archivos de la solución y proyectos
COPY ["../Instituto.sln", "./"]
COPY ["InstitutoBack.csproj", "./InstitutoBack/"]
COPY ["../InstitutoServices/InstitutoServices.csproj", "./InstitutoServices/"]

# Restaurar dependencias
RUN dotnet restore "InstitutoBack/InstitutoBack.csproj"

# Copiar todo el código fuente
COPY ["../InstitutoServices/", "./InstitutoServices/"]
COPY ["./" , "./InstitutoBack/"]

# Compilar y publicar
WORKDIR "/src/InstitutoBack"
RUN dotnet publish "InstitutoBack.csproj" -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
ENV IS_CONTAINER=true

# Copiar la aplicación publicada
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "InstitutoBack.dll"]