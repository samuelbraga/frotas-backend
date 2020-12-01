FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /app

COPY *.sln .
COPY Frota.API/*.csproj ./Frota.API/
RUN dotnet restore

COPY Frota.API/. ./Frota.API/
WORKDIR /app/Frota.API
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

WORKDIR /app
COPY --from=build /app/Frota.API/out ./
ENTRYPOINT ["dotnet", "Frota.API.dll"]