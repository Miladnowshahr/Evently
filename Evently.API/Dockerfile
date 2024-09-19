# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["Evently.API/Evently.API.csproj", "Evently.API/"]
COPY ["Evently.Module.Events.Infrastructure/Evently.Modules.Events.Infrastructure.csproj", "Evently.Module.Events.Infrastructure/"]
COPY ["Evently.Module.Event.Application/Evently.Modules.Event.Application.csproj", "Evently.Module.Event.Application/"]
COPY ["Evently.Modules.Events.Domain/Evently.Modules.Events.Domain.csproj", "Evently.Modules.Events.Domain/"]
COPY ["Evently.Module.Events.Presentation/Evently.Modules.Events.Presentation.csproj", "Evently.Module.Events.Presentation/"]
RUN dotnet restore "./Evently.API/Evently.API.csproj"
COPY . .
WORKDIR "/src/Evently.API"
RUN dotnet build "./Evently.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Evently.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Evently.API.dll"]