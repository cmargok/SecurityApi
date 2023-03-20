#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["Security.API/Security.API.csproj", "Security.API/"]
RUN dotnet restore "Security.API/Security.API.csproj"
COPY . .
WORKDIR "/src/Security.API"
RUN dotnet build "Security.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Security.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Security.API.dll"]