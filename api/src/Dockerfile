FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Hackaton.sln", "Hackaton.sln"]
COPY ["Hackaton.Api/Api.csproj", "Hackaton.Api/"]
COPY ["Hackaton.Application/Application.csproj", "Hackaton.Application/"]
COPY ["Hackaton.Core/Core.csproj", "Hackaton.Core/"]
COPY ["Hackaton.Domain/Domain.csproj", "Hackaton.Domain/"]
COPY ["Hackaton.Infra.CrossCutting/CrossCutting.csproj", "Hackaton.Infra.CrossCutting/"]
COPY ["Hackaton.Infra.Data/Data.csproj", "Hackaton.Infra.Data/"]
RUN dotnet restore "Hackaton.Api/Api.csproj"
COPY . .
WORKDIR "/src/Hackaton.Api"
RUN dotnet build "Hackaton.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hackaton.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hackaton.Api.dll"]