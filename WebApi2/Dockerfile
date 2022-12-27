FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install prerequisites
RUN apt-get update && apt-get install -y \
curl

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY WebApi2/WebApi2.csproj WebApi2/
RUN dotnet restore WebApi2/WebApi2.csproj

COPY WebApi2/ WebApi2/
WORKDIR /src/WebApi2
RUN dotnet build WebApi2.csproj -c release -o /app/build

FROM build as publish
RUN dotnet publish WebApi2.csproj -c release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi2.dll" ]