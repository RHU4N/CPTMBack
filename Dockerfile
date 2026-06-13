# Multi-stage build for .NET 9
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["CPTMBack.csproj", "."]
RUN dotnet restore "CPTMBack.csproj"

COPY . .
RUN dotnet publish "CPTMBack.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5000

ENV ASPNETCORE_ENVIRONMENT=Production
# Limpa o padrão do base image (8080) para evitar o warning "Overriding HTTP_PORTS".
# A porta é controlada pelo Kestrel programático em Program.cs (ListenAnyIP 5000).
ENV ASPNETCORE_HTTP_PORTS=""
ENV DOTNET_RUNNING_IN_CONTAINER=true

HEALTHCHECK --interval=30s --timeout=10s --start-period=40s --retries=5 \
    CMD bash -c 'echo > /dev/tcp/localhost/5000' 2>/dev/null || exit 1

ENTRYPOINT ["dotnet", "CPTMBack.dll"]
