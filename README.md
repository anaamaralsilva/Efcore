# Product Management API

REST API developed with C# and ASP.NET Core for product and order management.

This project was originally developed as an academic project during my **Technical Course in Systems Development at SENAI** and demonstrates backend concepts such as REST APIs, Entity Framework Core, SQL Server, Repository Pattern, file uploads and external API integration.

## About the Project

Product Management API provides endpoints for managing products, including creation, listing, search, update and deletion.

The project also contains domain models for orders and order items, establishing relationships between products and orders through Entity Framework Core.

One of the project's features is the integration with an external currency API to retrieve the USD/BRL exchange rate and calculate product values in US dollars.

## Features

- Product CRUD operations
- Search products by ID
- Search products by name
- Product image upload
- Order and order item domain modeling
- SQL Server database integration
- Entity Framework Core
- Repository Pattern
- Dependency Injection
- External API integration for USD/BRL exchange rates
- Swagger/OpenAPI documentation
- Error handling

## Technologies

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- REST API
- Swagger / OpenAPI
- Newtonsoft.Json
- HttpClient
- Git & GitHub

## Architecture

The project is organized into different layers and responsibilities:

```text
Controllers
   ↓
Interfaces
   ↓
Repositories
   ↓
Entity Framework Core
   ↓
SQL Server
```

Main project folders:

```text
Contexts       → Database context
Controllers    → API endpoints
Domains        → Domain entities
Interfaces     → Repository contracts
Migrations     → Entity Framework migrations
Repositories   → Data access layer
Utils          → File upload and external API utilities
```

## Data Model

The project contains three main entities:

### Product

Represents a product with information such as name, price and image.

### Order

Represents an order with status and creation date.

### Order Item

Creates the relationship between products and orders and stores the quantity of each product.

```text
Order
  │
  └── OrderItem ── Product
```

## External API Integration

The application consumes an external exchange-rate API using `HttpClient`.

The USD/BRL exchange rate is retrieved and used to calculate the corresponding product value in US dollars.

## Image Upload

The API supports product image uploads.

Uploaded files receive a unique name generated with `Guid` and are stored in the application's static files directory.

## API Documentation

Swagger/OpenAPI is configured in the project to provide interactive API documentation and facilitate endpoint testing.

## Project Status

This is an academic project originally developed during my **Technical Course in Systems Development at SENAI**, using **.NET Core 3.1**.

The project has been preserved and organized as part of my software development portfolio to demonstrate my technical development and progression in backend development.

> Note: .NET Core 3.1 is no longer supported and is maintained here for historical and educational purposes.

## Author

**Ana Carolina Amaral**

Software Developer focused on Backend and Full Stack development.

GitHub: [anaamaralsilva](https://github.com/anaamaralsilva)
