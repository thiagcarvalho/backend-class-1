# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PetShop.Manager.WebApi/PetShop.Manager.WebApi.csproj", "PetShop.Manager.WebApi/"]
COPY ["PetShop.Manager.Application/PetShop.Manager.Application.csproj", "PetShop.Manager.Application/"]
COPY ["PetShop.Manager.Infrastructure.Email/PetShop.Manager.Infrastructure.Email.csproj", "PetShop.Manager.Infrastructure.Email/"]
COPY ["PetShop.Manager.Application.Contracts/PetShop.Manager.Application.Contracts.csproj", "PetShop.Manager.Application.Contracts/"]
COPY ["PetShop.Manager.Persistence.Command/PetShop.Manager.Persistence.Command.csproj", "PetShop.Manager.Persistence.Command/"]
COPY ["PetShop.Manager.Persistence.DataModels/PetShop.Manager.Persistence.DataModels.csproj", "PetShop.Manager.Persistence.DataModels/"]
COPY ["PetShop.Manager.Persistence.Query/PetShop.Manager.Persistence.Query.csproj", "PetShop.Manager.Persistence.Query/"]
RUN dotnet restore "./PetShop.Manager.WebApi/PetShop.Manager.WebApi.csproj"
COPY . .
WORKDIR "/src/PetShop.Manager.WebApi"
RUN dotnet build "./PetShop.Manager.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PetShop.Manager.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetShop.Manager.WebApi.dll"]