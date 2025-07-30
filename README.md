# Techorama 2025

## Overview
This repository was created as a demonstration for a topic given at the Techorama 2025 conference.

I've chosen a subject where you want to explain developers how you can use the latest technologies to create isolated tests where you use an actual database, rather than using an in-memory database or mocking the database context.

On the side, I've also experimented with Aspire, so that you can start the application with all its dependencies with a single action. 

## Technologies Used
- .NET 9
- ASP.NET Core
- Entity Framework Core
- MS-SQL Server
- Microsoft.Aspire
- xUnit.v3
- Microsoft Testing Platform

### Aspire setup
During experimentation with Aspire, I used the template provided by Visual Studio 2022. I've added the necessary configuration to run the application with its dependencies, such as MSSQL Server. With that, I've linked the database to the application and pushed the database connection string to the application.

### Actual goal of this demonstration
The session was named "Databases, EF, and testing your applications - making sense of all the confusion" given by Shay Rojansky - who works for Microsoft and is part of the .NET data access team.

The goal of this demonstration is to show how you can use the latest technologies to create isolated tests that interact with an actual database, rather than relying on in-memory databases or mocking the database context.

When using an in-memory database (or mocking the database context), you often miss out on testing the actual interactions with the database, which can lead to discrepancies between your tests and real-world scenarios.

Examples
- An example is where certain EF Core features, such as lazy loading or complex queries, behave differently in an in-memory context compared to a real database.
- When certain translations have to occur (case sensitivity, etc.) that are not handled in the same way in an in-memory database.
- Transactions (so how the database handles transactions) are not the same in an in-memory database compared to a real database. Also, each database can handle it differently.
- Running raw SQL queries that are not supported by the in-memory database. So those can be a real pain when you want to test those queries.

You would think - well ok, lets use SQLLite or mocking the DbSet, but even then, you can run into issues. SQLLite is a great option for many scenarios, but it does not support all the features of a full SQL Server instance, and mocking the DbSet can lead to tests that do not accurately reflect the behavior of your application in production.

Microsoft or rather the datateam gets a lot of requests to improve the in-memory database, but they are not going to do that. Period. They hate it themselves, and rather than figuring out how to improve it - they give recomendations to use a real database for testing instead.

Now, you can do some mocking tests in some scenarios where you aren't really that intereseted in the database behaviour. You expect that the database works.
In order to make it easier to mock, you use the repository pattern, which allows you to abstract the database interactions and make it easier to test your application without relying on the actual database.


### Using test containers
Now, the session was heavily focused on unit testing with testcontainers, but knowing that not everyone has the same setup for databases (seperate code structure, Database first instead of Code first, etc.), I wanted a proof of concept on isolating integration tests with an actual database - where every test can run in isolation and does not depend on the state of the database.

I'm using the testcontainers library to create a containerized SQL Server instance for each test run. This allows me to have a fresh database for each test, ensuring that tests do not interfere with each other and that the database state is consistent. I've also setup the api using WebApplicationFactory, which allows me to create an in-memory server that can be used to test the API endpoints without needing to run the actual application. This ensures that i can create tests using the API endpoints without needing to run the actual application, which can be useful for testing the API in isolation.

Now, he mentions that you can use transactions and roll them back after each test, but that is not always the best solution. Databases save their stuff once you commit the transaction, so if you insert something and it works perfectly without transactions, you could get some issues when you have it running in your production code, where transactions actually occur. Usually happens when you have tables that are deferred or when you have triggers that are executed after the commit. So, I prefer to use a fresh database for each test run, which ensures that the database state is consistent and that tests do not interfere with each other.

### Improvements with this repository
In the tests, I need to call the Client that I've created in the WebApplicationFactory to get the API client. This could be somewhat annoying, as you have to define the path inside the test itself. This could be improved by using HttpClient generation like Nswag or Refit, which would allow you to define the API client in a more structured way and avoid hardcoding the paths in the tests.
Furthermore, that same client could be used for your client itself (either also in C# code or a different language) to ensure that the API client is consistent across your application and tests.