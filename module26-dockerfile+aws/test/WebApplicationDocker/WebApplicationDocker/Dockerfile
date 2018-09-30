FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WebApplicationDocker/WebApplicationDocker.csproj", "WebApplicationDocker/"]
RUN dotnet restore "WebApplicationDocker/WebApplicationDocker.csproj"
COPY . .
WORKDIR "/src/WebApplicationDocker"
RUN dotnet build "WebApplicationDocker.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApplicationDocker.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApplicationDocker.dll"]