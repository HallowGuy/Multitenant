# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ./Multitenant.Api/*.csproj ./Multitenant.Api/
RUN dotnet restore ./Multitenant.Api/Multitenant.Api.csproj

COPY . .
WORKDIR /src/Multitenant.Api
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Multitenant.Api.dll"]
