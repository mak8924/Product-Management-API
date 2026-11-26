# ASP.NET Core Web API – Product Management System

## Project Overview

A secure ASP.NET Core Web API for product management, featuring user registration, authentication, JWT-based authorization, and complete CRUD operations.

The application uses Entity Framework Core and Microsoft SQL Server for database management, with ASP.NET Core Identity for user authentication.

## Technologies Used

- ASP.NET Core Web API (.NET 10)
- C#
- Entity Framework Core 10
- Microsoft SQL Server
- ASP.NET Core Identity
- JWT Authentication
- Swagger / OpenAPI
- Git and GitHub

## Features

### 1. Authentication and Authorization

- User registration.
- User login.
- Password validation using ASP.NET Core Identity.
- JWT token generation.
- Protected API endpoints using JWT authentication.

### 2. Product Management

The API provides complete CRUD functionality:

| HTTP Method | Endpoint | Description |
|---|---|---|
| GET | `/api/Products` | Retrieve all products |
| GET | `/api/Products/{id}` | Retrieve a product by ID |
| POST | `/api/Products` | Create a new product |
| PUT | `/api/Products/{id}` | Update an existing product |
| DELETE | `/api/Products/{id}` | Delete a product |

All product endpoints require JWT authentication.

### 3. Authentication Endpoints

| HTTP Method | Endpoint | Description |
|---|---|---|
| POST | `/api/Auth/register` | Register a new user |
| POST | `/api/Auth/login` | Authenticate a user and generate a JWT token |

### 4. Database Integration

- Microsoft SQL Server integration.
- Entity Framework Core for database operations.
- Code-First database development.
- EF Core Migrations.
- ASP.NET Core Identity database tables.
- Products database table.

## Project Structure

```text
API/
│
├── Controllers/
│   ├── AuthController.cs
│   └── ProductsController.cs
│
├── Data/
│   ├── AppDbContext.cs
│   └── Migrations/
│
├── DTOs/
│   ├── LoginDto.cs
│   ├── RegisterDto.cs
│   └── ProductDto.cs
│
├── Models/
│   ├── ApplicationUser.cs
│   └── Product.cs
│
├── Services/
│   ├── ITokenService.cs
│   └── TokenService.cs
│
├── Settings/
│
├── Properties/
├── Program.cs
├── API.csproj
├── appsettings.json
├── .gitignore
└── README.md
```

## Prerequisites

Install the following tools before running the project:

- .NET 10 SDK
- Visual Studio Code
- C# Dev Kit extension
- Microsoft SQL Server
- SQL Server Management Studio (SSMS), recommended for database management

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/mak8924/Product-Management-API.git
cd Product-Management-API
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Install Entity Framework Core CLI

```powershell
dotnet tool install --global dotnet-ef --version 10.0.15
```

If the tool is already installed, update it when necessary:

```powershell
dotnet tool update --global dotnet-ef --version 10.0.15
```

### 4. Configure User Secrets

The project uses .NET User Secrets to store sensitive configuration values outside the source code.

The project already includes a `UserSecretsId` in its project file.

#### A. Configure the Database Connection

Make sure SQL Server is installed and running.

Configure your own SQL Server connection string:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "YOUR_CONNECTION_STRING"
```

For example, a local SQL Server Express connection may look like:

```text
Server=localhost\SQLEXPRESS;Database=ProductManagementDb;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True;
```

Replace the example with the connection string appropriate for your SQL Server installation.

#### B. Configure the JWT Secret Key

Generate a secure random JWT signing key using PowerShell:

```powershell
$keyBytes = New-Object byte[] 64
$rng = [System.Security.Cryptography.RandomNumberGenerator]::Create()
$rng.GetBytes($keyBytes)
$key = [Convert]::ToBase64String($keyBytes)
$rng.Dispose()
```

Save the generated key:

```powershell
dotnet user-secrets set "Jwt:Key" "$key"
```

#### C. Configure JWT Issuer and Audience

```powershell
dotnet user-secrets set "Jwt:Issuer" "Assignment5.API"
dotnet user-secrets set "Jwt:Audience" "Assignment5.Client"
```

**Security Note:** Never commit database passwords, connection strings, JWT signing keys, or other sensitive credentials to GitHub.

### 5. Apply Database Migrations

After configuring the database connection:

```powershell
dotnet ef database update
```

This applies the existing EF Core migrations to the configured SQL Server database.

### 6. Run the Application

```powershell
dotnet run
```

Open the Swagger interface using the local URL displayed in the terminal, for example:

```text
https://localhost:YOUR_PORT/swagger
```

Replace `YOUR_PORT` with the port displayed when the application starts.

## Authentication and Authorization

To test the API using Swagger:

1. Register a new account using `/api/Auth/register`.
2. Log in using `/api/Auth/login`.
3. Copy the generated JWT token.
4. Click the **Authorize** button in Swagger.
5. Enter the JWT token.
6. Execute the protected Products endpoints.

## Testing

The following functionality has been tested successfully in the local development environment:

- User registration.
- User login and JWT token generation.
- Swagger JWT authorization.
- Retrieving all products.
- Retrieving a product by ID.
- Creating products.
- Updating products.
- Deleting products.
- Rejecting unauthenticated requests with `401 Unauthorized`.

## Deployment

The application is being prepared for deployment using MonsterASP.NET.

The public Swagger URL and deployment details will be added after deployment is completed.

## Project Status

- Local development: Completed.
- Database integration: Completed.
- Authentication and authorization: Tested successfully.
- CRUD operations: Tested successfully.
- Online deployment: In progress.

## Author

Developed by [mak8924](https://github.com/mak8924)