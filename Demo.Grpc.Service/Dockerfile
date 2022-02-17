#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Demo.Grpc.Service/Demo.Grpc.Service.csproj", "Demo.Grpc.Service/"]
RUN dotnet restore "Demo.Grpc.Service/Demo.Grpc.Service.csproj"
COPY . .
WORKDIR "/src/Demo.Grpc.Service"
RUN dotnet build "Demo.Grpc.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.Grpc.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.Grpc.Service.dll"]