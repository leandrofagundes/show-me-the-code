FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
LABEL version="1.0" description="API para Cálculo de Juros"
ENV ASPNETCORE_ENVIRONMENT Release
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WebApi.CalculadoraDeJuros/WebApi.CalculadoraDeJuros.csproj", "WebApi.CalculadoraDeJuros/"]
RUN dotnet restore "WebApi.CalculadoraDeJuros/WebApi.CalculadoraDeJuros.csproj"
COPY . .
WORKDIR "/src/WebApi.CalculadoraDeJuros"
RUN dotnet build "WebApi.CalculadoraDeJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.CalculadoraDeJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.CalculadoraDeJuros.dll"]