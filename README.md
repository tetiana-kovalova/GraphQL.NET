# GraphQL.NET

Contains source code with GraphQL .NET

To try Rest API endpoints run application using 'dotnet run' command and open https://localhost:5001/swagger/index.html.

To try GraphQL queries run application using 'dotnet run' command and open https://localhost:5001/ui/playground.

# RestSharpTest

Contains xUnit test project with RestSharp tests for RestAPI endpoints of GraphQL.NET project.

Tests instantiate the API application using Microsoft.AspNetCore.Mvc.Testing and use an application code against it, so they can simply be run from the IDE.

# SpecFlowTest

Demonstrates the implementation of BDD test using SpecFlow.NUnit and Ghirkin style. 

Before tests running it is needed to run the application by navigating to ..\GraphQL.NET and running 'dotnet run' command.

# GraphQLTest

Contains xUnit test project with tests for GraphQL client of GraphQL.NET project.

Before tests running it is needed to run the application by navigating to ..\GraphQL.NET and running 'dotnet run --launch-profile GraphQL'- to work around SSL issue.