FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WikiMediaHelperService/WikiMediaHelperService.csproj", "WikiMediaHelperService/"]
RUN dotnet restore "WikiMediaHelperService/WikiMediaHelperService.csproj"
COPY . .
WORKDIR "/src/WikiMediaHelperService"
RUN dotnet build "WikiMediaHelperService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WikiMediaHelperService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WikiMediaHelperService.dll"]