FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
LABEL version="1.0" description="API para obtenção da Taxa de Juros"
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WebApi.TaxaDeJuros/WebApi.TaxaDeJuros.csproj", "WebApi.TaxaDeJuros/"]
RUN dotnet restore "WebApi.TaxaDeJuros/WebApi.TaxaDeJuros.csproj"
COPY . .
WORKDIR "/src/WebApi.TaxaDeJuros"
RUN dotnet build "WebApi.TaxaDeJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.TaxaDeJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.TaxaDeJuros.dll"]