# Bugtracker

## Introduction

This project is a simple bugtracker application, created as a tech demo. It comprises of 3 parts

- A dotnet core (2.2) web api
- A MongoDB NoSql database
- A SPA web application written with Vue

# How to run with docker

If you have docker installed on your computer you can run the entire application with a single command. From the root folder of the project type

`docker-compose up`

This will build and run all parts of the application. Once running you can visit the web application at 

`http://localhost:8080`

You can also find swagger documentation for the API at

`http://localhost:5000/swagger`

# Testing

The project also includes some different types of automated testing. These have been included as a demonstration of testing principles and contain only a few sample tests in each case. If this were a production system then the tests would be more comprehensive and would be included as part of the CI/CD pipeline and would likely use a coverage/quality tool such a Sonar Cloud to monitor.

## Unit Testing

Unit tests for the .net code can be found in the api folder. For the tests have been written against the MongoStore assembly. They demonstrate the application of a unit test framework (xUnit) and mocking framework (Moq). If you have the correct framework installed you can run the tests by going to the folder

`/api/Bugtracker.MongoStore.Tests`

and running

`dotnet test`


