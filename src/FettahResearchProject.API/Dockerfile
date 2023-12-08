#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/FettahResearchProject.API/FettahResearchProject.API.csproj", "src/FettahResearchProject.API/"]
COPY ["src/FettahResearchProject.Application/FettahResearchProject.Application.csproj", "src/FettahResearchProject.Application/"]
COPY ["src/FettahResearchProject.Utilities/FettahResearchProject.Utilities.csproj", "src/FettahResearchProject.Utilities/"]
COPY ["src/FettahResearchProject.Models/FettahResearchProject.Models.csproj", "src/FettahResearchProject.Models/"]
COPY ["src/FettahResearchProject.DTO/FettahResearchProject.DTO.csproj", "src/FettahResearchProject.DTO/"]
COPY ["src/FettahResearchProject.Infrastructure/FettahResearchProject.Infrastructure.csproj", "src/FettahResearchProject.Infrastructure/"]
COPY ["src/FettahResearchProject.Domain/FettahResearchProject.Domain.csproj", "src/FettahResearchProject.Domain/"]
COPY ["src/FettahResearchProject.Common/FettahResearchProject.Common.csproj", "src/FettahResearchProject.Common/"]
COPY ["src/FettahResearchProject.Enums/FettahResearchProject.Enums.csproj", "src/FettahResearchProject.Enums/"]
RUN dotnet restore "./src/FettahResearchProject.API/./FettahResearchProject.API.csproj"
COPY . .
WORKDIR "/src/src/FettahResearchProject.API"
RUN dotnet build "./FettahResearchProject.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FettahResearchProject.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FettahResearchProject.API.dll"]