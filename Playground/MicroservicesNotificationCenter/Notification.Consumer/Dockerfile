FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Notification.Consumer/Notification.Consumer.csproj", "Notification.Consumer/"]
RUN dotnet restore "./Notification.Consumer/Notification.Consumer.csproj"
COPY . .
WORKDIR "/src/Notification.Consumer"
RUN dotnet build "./Notification.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Notification.Consumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notification.Consumer.dll"]