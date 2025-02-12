FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["FestivalShoppingApi.sln", "./"]
COPY ["FestivalShoppingApi/FestivalShoppingApi.csproj", "FestivalShoppingApi/"]
COPY ["FestivalShoppingApi.Business/FestivalShoppingApi.Business.csproj", "FestivalShoppingApi.Business/"]
COPY ["FestivalShoppingApi.Common/FestivalShoppingApi.Common.csproj", "FestivalShoppingApi.Common/"]
COPY ["FestivalShoppingApi.Data/FestivalShoppingApi.Data.csproj", "FestivalShoppingApi.Data/"]
COPY ["FestivalShoppingApi.Test/FestivalShoppingApi.Test.csproj", "FestivalShoppingApi.Test/"]

RUN dotnet restore "FestivalShoppingApi/FestivalShoppingApi.csproj"

COPY . .

WORKDIR "/src/FestivalShoppingApi"
RUN dotnet publish "FestivalShoppingApi.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

RUN mkdir -p /app/sqlite

COPY --from=build /app .

EXPOSE 8080

ENTRYPOINT ["dotnet", "FestivalShoppingApi.dll"]
