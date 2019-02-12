FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY SockItToeMe.Database/SockItToeMe.Database.csproj SockItToeMe.Database/
RUN dotnet restore SockItToeMe.Database/SockItToeMe.Database.csproj
COPY . .
WORKDIR /src/SockItToeMe.Database
RUN dotnet build SockItToeMe.Database.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SockItToeMe.Database.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SockItToeMe.Database.dll"]
