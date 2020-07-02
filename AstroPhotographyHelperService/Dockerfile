FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN apt-get update && apt-get install -y libgdiplus
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AstroPhotographyHelperService/AstroPhotographyHelperService.csproj", "AstroPhotographyHelperService/"]
RUN dotnet restore "AstroPhotographyHelperService/AstroPhotographyHelperService.csproj"
COPY . .
WORKDIR "/src/AstroPhotographyHelperService"
RUN dotnet build "AstroPhotographyHelperService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AstroPhotographyHelperService.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["AstroPhotographyHelperService/Data/", "./Data/"]
ENTRYPOINT ["dotnet", "AstroPhotographyHelperService.dll"]