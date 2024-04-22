# Use the official Microsoft ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Set ulimit for open files
RUN ulimit -n 4096

# Use the official Microsoft SDK image to build the project files
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HelloWorld.csproj", "./"]
RUN dotnet restore "HelloWorld.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "HelloWorld.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "HelloWorld.csproj" -c Release -o /app/publish

# Configure the environment variables for additional configuration
ENV ENDPOINT=mysql-net 
ENV DATABASE=proyecto
ENV USERD=user
ENV PASSD=psswrd-p1f0dsd-user!

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWorld.dll"]

