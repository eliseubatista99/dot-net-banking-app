# .NET Banking App

## Installing and running the project

How to start project:

1.  Make sure you have .NET installed. You can download it from https://dotnet.microsoft.com/en-us/download
2.  Execute the dotNetBankingApp.sh script (If you are on Windows, use a tool like Git Bash to run the script: https://git-scm.com/download/win) with the command:

        sh ./dotNetBankingApp.sh

    If you only want to test/run the Api, run the following command

        sh ./dotNetBankingAppApiOnly.sh

## About the project

This project is organized into two solutions:

1. Api(DotNetBankingAppApi)
2. Client application (DotNetBankingAppClient)

The Api contains client application support services (login, obtaining cards, transferring money, etc.) and can be executed and tested in isolation, using the dotNetBankingAppApiOnly.sh script.

The Api uses the EntityFramework to store data in a SQL Database, and use the JWTBearer authentication to generate a token and secure the endpoints.

The client application was developed using Blazor.

## Project structure

1. Initially, the client application makes a request to the login/register service sending the user's credentials. These services check whether the data is valid, perform the necessary actions and return a session token to the client application.

2. The client application stores this token in a sessionStorage, and sends this token to other services, in order to identify the client.
