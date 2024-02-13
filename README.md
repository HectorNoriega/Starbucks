# Starbucks Solution

This is a solution following the principles of Clean Architecture, Domain Driven Design and Clean Code.

## Patterns

CQRS
Repository
Mediator

## Technologies

* [ASP.NET Core 6](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)
* [Entity Framework Core 8](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew)
* [MediatR](https://github.com/jbogard/MediatR)
* [FluentValidation](https://fluentvalidation.net/)
* [Serilog](https://serilog.net/)
* [xUnit](https://nunit.org/)
* [FluentAssertions](https://fluentassertions.com/)
* [FluentValidation](https://docs.fluentvalidation.net/en/latest/)
* [Moq](https://github.com/moq)

  
### Database Configuration
The solution is configured to use in-memory database. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### Presentation

This layer is a .NET CORE API on ASP.NET Core 8. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Program.cs* should reference Infrastructure.
