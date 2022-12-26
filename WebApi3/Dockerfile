FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY WebApi3/WebApi3.csproj WebApi3/
RUN dotnet restore WebApi3/WebApi3.csproj

COPY WebApi3/ WebApi3/
WORKDIR /src/WebApi3
RUN dotnet build WebApi3.csproj -c release -o /app/build

FROM build as publish
RUN dotnet publish WebApi3.csproj -c release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi3.dll" ]