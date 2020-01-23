FROM microsoft/dotnet:2.2-sdk AS build
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
FROM microsoft/dotnet:2.2-runtime AS runtime
WORKDIR /app
COPY --from=build /app/src/Bugtracker.Api/out ./
ENTRYPOINT ["dotnet", "BugTracker.Api.dll"]