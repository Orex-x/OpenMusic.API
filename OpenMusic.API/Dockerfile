FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OpenMusic.API/OpenMusic.API.csproj", "OpenMusic.API/"]
RUN dotnet restore "OpenMusic.API/OpenMusic.API.csproj"
COPY . .
WORKDIR "/src/OpenMusic.API"
RUN dotnet build "OpenMusic.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenMusic.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenMusic.API.dll"]
