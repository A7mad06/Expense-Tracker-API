# Expense Tracker API

This project is an implementation of the [Expense Tracker API](https://roadmap.sh/projects/expense-tracker-api) project from roadmap.sh.

## Table of Contents

- [Project Description](#project-description)
- [Technologies Used](#technologies-used)
- [Features](#features)
- [Constraints](#constraints)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [API Usage](#api-usage)

## Project Description

Build an API for an expense tracker application. This API allows users to create, read, update, and delete expenses. Users are able to sign up and log in to the application. Each user has their own set of expenses.

## Technologies Used

- **Framework**: .NET
- **Language**: C#
- **Architecture**: Clean Architecture

## Features

- Sign up as a new user.
- Generate and validate JWTs for handling authentication and user session.
- List and filter past expenses by:
    - Past week
    - Past month
    - Last 3 months
    - Custom date range
- Add a new expense
- Remove existing expenses
- Update existing expenses

## Constraints

- Use JWT (JSON Web Token) to protect endpoints and identify the requester.
- Expenses should be categorized (e.g., Groceries, Leisure, Electronics, Utilities, Clothing, Health, Others).

## Project Structure

This project follows a clean architecture approach with the following structure:

- **Expense Tracker API**: Main entry point of the application.
- **Presentation**: API controllers and endpoints definition.
- **Services**: Implementation of the business logic.
- **Services.Abstraction**: Abstractions and interfaces for the services layer.
- **Persistence**: Database access layer.
- **Domain**: Domain entities and core logic.
- **Shared**: Data Transfer Objects (DTOs) and shared models used across layers.

## Getting Started

### Prerequisites

- .NET SDK (e.g., .NET 10.0 based on project files)

### Installation

1. Clone the repository.
2. Open the solution `Expense Tracker API.slnx` in your preferred IDE (e.g., Visual Studio, VS Code with C# Dev Kit).
3. Restore NuGet packages and build the project.

### Running the Application

1. Navigate to the `Expense Tracker API` directory.
2. Run the application using `dotnet run`.

## API Usage

- Base URL: `http://localhost:<port>` (Check `launchSettings.json` for details).
- All API requests (except login/registration) require a valid JWT token in the Authorization header: `Authorization: Bearer <your_jwt_token>`.
