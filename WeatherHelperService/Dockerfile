FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WeatherHelperService/WeatherHelperService.csproj", "WeatherHelperService/"]
RUN dotnet restore "WeatherHelperService/WeatherHelperService.csproj"
COPY . .
WORKDIR "/src/WeatherHelperService"
RUN dotnet build "WeatherHelperService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherHelperService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherHelperService.dll"]