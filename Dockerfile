FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetCoreApiSample/NetCoreApiSample.csproj", "NetCoreApiSample/"]
RUN dotnet restore "NetCoreApiSample/NetCoreApiSample.csproj"
COPY . .
WORKDIR "/src/NetCoreApiSample"
RUN dotnet build "NetCoreApiSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreApiSample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet NetCoreApiSample.dll