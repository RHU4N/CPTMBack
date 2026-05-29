# Multi-stage build for .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["CPTMBack.csproj", "."]

# Restore dependencies
RUN dotnet restore "CPTMBack.csproj"

# Copy source code
COPY . .

# Build application
RUN dotnet build "CPTMBack.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "CPTMBack.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Install Oracle client libraries (optional, if needed for specific features)
# RUN apt-get update && apt-get install -y libaio1 && rm -rf /var/lib/apt/lists/*

# Copy published app
COPY --from=publish /app/publish .

# Expose ports
EXPOSE 5000 5001

# Environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:5000;https://+:5001

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD dotnet /app/CPTMBack.dll --version || exit 1

# Start application
ENTRYPOINT ["dotnet", "CPTMBack.dll"]
