FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY WebAPI4/WebAPI4.csproj WebAPI4/
RUN dotnet restore WebAPI4/WebAPI4.csproj

COPY WebAPI4/ WebAPI4/
WORKDIR /src/WebAPI4
RUN dotnet build WebAPI4.csproj -c release -o /app/build

FROM build as publish
RUN dotnet publish WebAPI4.csproj -c release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI4.dll" ]