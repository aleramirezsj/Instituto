# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

# Copiar archivos de la solución y proyectos
COPY ["../Instituto.sln", "./"]
COPY ["InstitutoWeb.csproj", "./InstitutoWeb/"]
COPY ["../InstitutoServices/InstitutoServices.csproj", "./InstitutoServices/"]

# Restaurar dependencias
RUN dotnet restore "InstitutoWeb/InstitutoWeb.csproj"
RUN dotnet restore "InstitutoServices/InstitutoServices.csproj"

# Copiar todo el código fuente
COPY ["../InstitutoServices/", "./InstitutoServices/"]
COPY ["./" , "./InstitutoWeb/"]

# Publicar
WORKDIR "/app/InstitutoWeb"
RUN dotnet publish "InstitutoWeb.csproj" -c Release -o /app/publish

# Etapa 2: Runtime
FROM nginx:alpine
WORKDIR /usr/share/nginx/html

# Copiar los archivos publicados
COPY --from=build /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/conf.d/default.conf

RUN mkdir -p _framework && \
    chmod -R 755 . && \
    chmod -R 644 _framework/*

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]