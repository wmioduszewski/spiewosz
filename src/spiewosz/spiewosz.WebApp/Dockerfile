# Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["spiewosz.WebApp/spiewosz.WebApp.csproj", "spiewosz.WebApp/"]
COPY ["spiewosz.ServiceDefaults/spiewosz.ServiceDefaults.csproj", "spiewosz.ServiceDefaults/"]
COPY ["spiewosz.Data/spiewosz.Data.csproj", "spiewosz.Data/"]

# 2. Restore
RUN dotnet restore "spiewosz.WebApp/spiewosz.WebApp.csproj"

# 3. Copy solution
COPY . .

# 4. Dotnet Build
WORKDIR "/src/spiewosz.WebApp"
RUN dotnet build "spiewosz.WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 2: publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

WORKDIR "/src/spiewosz.WebApp"
RUN dotnet publish "spiewosz.WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 3: final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Copy published app from publish stage
COPY --from=publish /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "spiewosz.WebApp.dll"]
