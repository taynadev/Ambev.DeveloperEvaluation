# Ambev Developer Evaluation - Backend

This repository contains the backend solution for the C#/.NET developer evaluation challenge, following the architecture requirements, business rules, and RESTful standards described in the test manual.

---

## Table of Contents

- [Overview](#overview)
- [Prerequisites](#prerequisites)
- [Environment Setup](#environment-setup)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [Testing](#testing)
- [API Documentation](#api-documentation)
- [Project Structure](#project-structure)
- [Notes](#notes)

---

## Overview

The application implements a RESTful API for sales management using .NET 8, C#, Entity Framework Core, MediatR, AutoMapper, xUnit, JWT authentication, and PostgreSQL. The project follows principles of DDD, External Identities, and description denormalization.

---

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL 14+](https://www.postgresql.org/download/)
- [Docker](https://www.docker.com/) 
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code

---

## Environment Setup

1. **Clone the repository:**

```bash
git clone https://github.com/taynadev/Ambev.DeveloperEvaluation.git
cd your-repository-folder
```

2. **Environment variables setup:**

- Modify the `appsettings.Development.json` file located at `src/Ambev.DeveloperEvaluation.WebApi/` with the PostgreSQL connection string:

  ```json
  {
    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Port=5432;Database=ambev_dev_eval;Username=postgres;Password=YourPassword"
    }
  }
  ```

3. **Database setup:**

- To apply the migrations and create the tables, make sure you're in the `src` directory and run:

  ```bash
  dotnet ef database update --project src/Ambev.DeveloperEvaluation.ORM --startup-project Ambev.DeveloperEvaluation.WebApi
  ```

---

## Running the Application

### Using Visual Studio

1. Open the solution in Visual Studio.
2. Set the `Ambev.DeveloperEvaluation.WebApi` project as the startup project.
3. Press `F5` to run in Debug mode.

### Using Command Line
```bash
cd src/Ambev.DeveloperEvaluation.WebApi
dotnet run
```

### Using Docker

1. Make sure Docker is installed and running.
2. Run:
```bash
docker-compose up --build
```
This will start the API, a PostgreSQL container, and any other services defined in `docker-compose.yaml`.

---

## Testing

### Unit and Functional Tests

1. To run all tests:
```bash
dotnet test
```
2. Tests are located in `tests/Ambev.DeveloperEvaluation.Unit`, `tests/Ambev.DeveloperEvaluation.Functional`, and `tests/Ambev.DeveloperEvaluation.Integration`.

---

## API Documentation

- The interactive documentation (Swagger) will be available at:
```bash
localhost:44312/swagger (if running with IIS Express on WebApi) or according to the container port if running with Docker
```

- Use Swagger to explore and test the API endpoints.

---

## Project Structure

```text
root
├── src/ 
│   ├── Ambev.DeveloperEvaluation.WebApi/      # ASP.NET Core API 
│   ├── Ambev.DeveloperEvaluation.Application/ # Application Layer (Use Cases, Handlers) 
│   ├── Ambev.DeveloperEvaluation.Domain/      # Domain entities and business rules 
│   ├── Ambev.DeveloperEvaluation.ORM/         # Persistence infrastructure (EF Core) 
│   └── Ambev.DeveloperEvaluation.Common/      # Crosscutting (validation, logging, security) 
├── tests/  
│   ├── Ambev.DeveloperEvaluation.Unit/        # Unit tests 
│   └── Ambev.DeveloperEvaluation.Functional/  # Functional/integration tests 
└── README.md
```

---

## Notes

- The project uses JWT authentication. To access protected endpoints, obtain a token via `/auth/login`.