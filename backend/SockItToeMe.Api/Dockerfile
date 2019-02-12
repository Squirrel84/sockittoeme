FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY SockItToeMe.API/SockItToeMe.API.csproj SockItToeMe.API/
RUN dotnet restore SockItToeMe.API/SockItToeMe.API.csproj --source https://api.nuget.org/v3/index.json
COPY . .
WORKDIR /src/SockItToeMe.API
RUN dotnet build SockItToeMe.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SockItToeMe.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "SockItToeMe.API.dll"]
