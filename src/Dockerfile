FROM microsoft/dotnet:sdk AS build-env

WORKDIR /app/Shared
COPY Shared/BitTorrentFileServer.Common.CSharp/ ./BitTorrentFileServer.Common.CSharp/
COPY Shared/BitTorrentFileServer.Common.FSharp/ ./BitTorrentFileServer.Common.FSharp/

WORKDIR /app/Web/Vue
# Copy csproj and restore as distinct layers
COPY Web/BitTorrentFileServer.Vue/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY Web/BitTorrentFileServer.Vue ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app/
COPY --from=build-env /app/Web/Vue/out .
ENTRYPOINT ["dotnet", "BitTorrentFileServer.Vue.dll"]
