FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY Bugtracker.Core/*.Core.csproj ./src/Bugtracker.Core/
COPY Bugtracker.MongoStore/*.csproj ./src/Bugtracker.MongoStore/
COPY Bugtracker.Api/*.csproj ./src/Bugtracker.Api/
WORKDIR /app/src/Bugtracker.Core
RUN dotnet restore
WORKDIR /app/src/Bugtracker.MongoStore
RUN dotnet restore
WORKDIR /app/src/Bugtracker.Api
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/
COPY . ./src/
WORKDIR /app/src/Bugtracker.Api
RUN dotnet publish -c Release -o out

# copy build artifacts into runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/src/Bugtracker.Api/out ./
ENTRYPOINT ["dotnet", "Bugtracker.Api.dll"]