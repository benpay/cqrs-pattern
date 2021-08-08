# CQRS design pattern
## _User and addresses history gestor_


[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

This is a simple CRUD application with CQRS and MediatR. It have 2 entities, one is for user and another for addresses. Codefirst is used on this application for DDD (Domain Driven Design). It contains two sample usage of XUnit (more in the future).

- .NET 5
- Dependency Injection
- SQLite
- XUnit
- CQRS
- Migrations
- Swagger

## Features
An ASP.NET Core API with the features below, containing users, and their addresses history.

- Basic CRUD operations for ALL entities.
- An endpoint, with pagination and search features, that returns a list of users, with at least one direction each.

## How to run

For run this application you can clone it and execute the following command (the firsts could be not needed):

```sh
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef database update
```

It is important to execute the last command to create the database, the route for it is _C:\temp_ but you can change it updating the _Context.cs_ file.

```sh
optionsBuilder.UseSqlite(@"Data source=C:\\temp\\ProjectWithCqrsDatabase.db");
```

## How to use

Running the application it will open directly Swagger page, on it you can see two section, one for Addresses and another for Users, both of them can be used.

**Addresses** - is the most simple, it contains the CRUD operations for _Addresses_ model.
**Users** - is the most complete, it cotains the CRUD operations with his model and Addresses, so the operations are related and any change can be shown in both

For **Addesses** you can update an address, but it is not possible updating **User** because it is needed to have a history about the addresses for a user.

![alt text](https://i.ibb.co/Z1kYJgs/imagen-2021-08-09-011753.png)

## Dependencies

Some packages are instaled and them could be needed:

| Package | Version |
| ------ | ------ |
| MediatR | 9.0.0 |
| MediatR.Extensions.Microsoft.DependencyInjection | 9.0.0 |
| Microsoft.Data.Sqlite | 5.0.8 |
| Microsoft.EntityFrameworkCore | 5.0.8 |
| Microsoft.EntityFrameworkCore.Design | 5.0.8 |
| Microsoft.EntityFrameworkCore.Sqlite.Core | 5.0.8 |
| Microsoft.NET.Test.Sdk | 16.9.4 |
| Moq | 4.16.1 |
| Swashbuckle.AspNetCore | 6.1.5 |
| Swashbuckle.AspNetCore.Swagger | 6.1.5 |
| Swashbuckle.AspNetCore.SwaggerGen | 6.1.5 |
| Swashbuckle.AspNetCore.SwaggerUI | 6.1.5 |
| xunit | 2.4.1 |
| xunit.runner.visualstudio | 2.4.3 |

