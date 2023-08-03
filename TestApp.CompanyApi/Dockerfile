FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app

COPY bin/Debug/netcoreapp3.1/ .

EXPOSE 6000/tcp

ENTRYPOINT ["dotnet", "TestApp.CompanyApi.dll"]