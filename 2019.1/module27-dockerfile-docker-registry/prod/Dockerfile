FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
EXPOSE 5000
EXPOSE 80

WORKDIR /app

COPY ./TrueWebApi/pub .

ENTRYPOINT ["dotnet", "TrueWebApi.dll"]