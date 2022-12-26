FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY AuthenAPI/AuthenAPI.csproj AuthenAPI/
RUN dotnet restore AuthenAPI/AuthenAPI.csproj

COPY AuthenAPI/ AuthenAPI/
WORKDIR /src/AuthenAPI
RUN dotnet build AuthenAPI.csproj -c release -o /app/build

FROM build as publish
RUN dotnet publish AuthenAPI.csproj -c release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthenAPI.dll" ]