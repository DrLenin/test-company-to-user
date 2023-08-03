#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app

COPY bin/Debug/netcoreapp3.1/ .

EXPOSE 5000/tcp

ENTRYPOINT ["dotnet", "TestApp.UsersApi.dll"]


#FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
#WORKDIR /src
#COPY ["UsersApp.PostFIOFirstService.csproj", "UsersApp.PostFIOFirstService/"]
#RUN dotnet restore "UsersApp.PostFIOFirstService/UsersApp.PostFIOFirstService.csproj"
#COPY . .
#WORKDIR "/src/UsersApp.PostFIOFirstService"
#RUN dotnet build "UsersApp.PostFIOFirstService.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "UsersApp.PostFIOFirstService.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "UsersApp.PostFIOFirstService.dll"]