# Utiliza la imagen base con el SDK de .NET para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia los archivos del proyecto al contenedor y restaura las dependencias
COPY ["MiAspnetProject.csproj", "./"]
RUN dotnet restore "MiAspnetProject.csproj"

# Copia el resto del código y compila la aplicación
COPY . .
RUN dotnet build "MiAspnetProject.csproj" -c Release -o /app/build

# Publica la aplicación en una imagen más ligera
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .

# Configura las variables de entorno para configuración adicional
ENV ENDPOINT=mysql-net-pre
ENV DATABASE=proyecto
ENV USERD=user
ENV PASSD=u00947hyASPdfkl_111NEThs-pa44s55w--?

# Expone el puerto utilizado por la aplicación
EXPOSE 80

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "MiAspnetProject.dll"]


