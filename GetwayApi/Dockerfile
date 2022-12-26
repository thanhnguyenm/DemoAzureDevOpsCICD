FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY GetwayApi/GetwayApi.csproj GetwayApi/
RUN dotnet restore GetwayApi/GetwayApi.csproj

COPY GetwayApi/ GetwayApi/
WORKDIR /src/GetwayApi
RUN dotnet build GetwayApi.csproj -c release -o /app/build

FROM build as publish
RUN dotnet publish GetwayApi.csproj -c release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GetwayApi.dll" ]