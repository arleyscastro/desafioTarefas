FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Desafio/Tarefas/tarefas.API/", "Desafio/Tarefas/tarefas.API/"]
RUN dotnet restore "./Desafio/Tarefas/tarefas.API/./IFood.Jobs.csproj"
COPY . .
WORKDIR "/Desafio/Tarefas/tarefas.API"

Desafio\Tarefas\tarefas.API
RUN dotnet build "./tarefas.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./tarefas.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IFood.Jobs.dll"]