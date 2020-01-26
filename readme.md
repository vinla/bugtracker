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

# Building changes

You can build any changes to the application by running

`docker-compose build web` or `docker-compose build api`

Once the build has completed you can relaunch the application with

`docker-compose up --force-recreate`

Note that data is persisted to the local storage of the mongo container, if you want to clear the data then you should stop and remove the mongo containter. You can stop and remove all running containers with

`docker rn -f $(docker ps -aq)`

# Testing

The project also includes some different types of automated testing. These have been included as a demonstration of testing principles and contain only a few sample tests in each case. If this were a production system then the tests would be more comprehensive and would be included as part of the CI/CD pipeline and would likely use a coverage/quality tool such a Sonar Cloud to monitor.

## Unit Testing

Unit tests for the .net code can be found in the api folder. For the tests have been written against the MongoStore assembly. They demonstrate the application of a unit test framework (xUnit) and mocking framework (Moq). If you have the correct framework installed you can run the tests by going to the folder

`/api/Bugtracker.MongoStore.Tests`

and running

`dotnet test`

# End to end testing with Selenium

End to end tests can provide a full system integration test by using Selenium web driver to interact with the front end. For these tests to run the full system must be running. These test can be difficult to write and maintain and expensive to run, therefore it is best to only maintain a small suite of these covering core functionaltiy.

A very simple sample has been provided and can be run by first running the application and then running the .net unit tests from the /e2e/E2ETests folder. In this case I have used .net and xunit to drive the tests but there are many other frameworks available to power these kinds of tests.

NOTE: You will need to install chromedriver to the folder c:\chromedriver\ for these tests to run (although it should be possible to get these tests running in a more generic way) 

# Vue component testing
...