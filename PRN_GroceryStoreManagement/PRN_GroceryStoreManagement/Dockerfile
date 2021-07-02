#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 6001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PRN_GroceryStoreManagement.csproj", "PRN_GroceryStoreManagement/"]
RUN dotnet restore "PRN_GroceryStoreManagement/PRN_GroceryStoreManagement.csproj"
COPY . .
WORKDIR "/src/PRN_GroceryStoreManagement"
RUN dotnet build "PRN_GroceryStoreManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PRN_GroceryStoreManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:6001
ENTRYPOINT ["dotnet", "PRN_GroceryStoreManagement.dll"]