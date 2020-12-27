#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["DotNet5_Session3_Exercise/DotNet5_Session3_Exercise.csproj", "DotNet5_Session3_Exercise/"]
RUN dotnet restore "DotNet5_Session3_Exercise/DotNet5_Session3_Exercise.csproj"
COPY . .
WORKDIR "/src/DotNet5_Session3_Exercise"
RUN dotnet build "DotNet5_Session3_Exercise.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNet5_Session3_Exercise.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNet5_Session3_Exercise.dll"]