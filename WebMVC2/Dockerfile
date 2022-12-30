FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install prerequisites
RUN apt-get update && apt-get install -y \
curl

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY WebMVC2.csproj WebMVC2/
RUN dotnet restore WebMVC2/WebMVC2.csproj

COPY . WebMVC2/
WORKDIR /src/WebMVC2
RUN dotnet build WebMVC2.csproj -c release -o /app/build

FROM build as publish
RUN dotnet publish WebMVC2.csproj -c release -o /app/publish
COPY ./wwwroot /app/publish/wwwroot


FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebMVC2.dll" ]