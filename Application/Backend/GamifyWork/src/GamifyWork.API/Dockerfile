#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/GamifyWork.API/GamifyWork.API.csproj", "src/GamifyWork.API/"]
COPY ["src/GamifyWork.ContractLayer/GamifyWork.ContractLayer.csproj", "src/GamifyWork.ContractLayer/"]
COPY ["src/GamifyWork.DataAccessLibrary/GamifyWork.DataAccessLibrary.csproj", "src/GamifyWork.DataAccessLibrary/"]
COPY ["src/GamifyWork.MapperLayer/GamifyWork.MapperLayer.csproj", "src/GamifyWork.MapperLayer/"]
COPY ["src/GamifyWork.ServiceLibrary/GamifyWork.ServiceLibrary.csproj", "src/GamifyWork.ServiceLibrary/"]
RUN dotnet restore "src/GamifyWork.API/GamifyWork.API.csproj"
COPY . .
WORKDIR "/src/src/GamifyWork.API"
RUN dotnet build "GamifyWork.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GamifyWork.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GamifyWork.API.dll"]