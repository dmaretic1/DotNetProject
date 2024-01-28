FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY InventoryMVC/*.csproj .
RUN dotnet restore --use-current-runtime  

# copy everything else and build app
COPY InventoryMVC/. .
RUN dotnet publish -c Release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

EXPOSE 80

COPY --from=build /app .

ENTRYPOINT ["dotnet", "InventoryMVC.dll"]