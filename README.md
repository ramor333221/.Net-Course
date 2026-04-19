# MusicRuchama Management System

MusicRuchama is a robust, enterprise-grade Backend API built with **.NET 8.0**. It is designed to manage a music education center, handling user authentication, teacher-student workflows, and lesson scheduling using a clean, maintainable Layered Architecture.

## 🏛 Architecture & Layer Explanation

The project follows a **Layered Architecture** to ensure separation of concerns, scalability, and ease of testing.

### 1. MeusicRuchama (API Layer)
This is the entry point of the application. It handles the communication between the client and the server.
* **Controllers:** Manage HTTP requests (GET, POST, PUT, DELETE) and return appropriate HTTP status codes.
* **Middleware:** Includes JWT Authentication, Authorization policies, and CORS configurations.
* **Configuration:** contains `appsettings.json` for environment-specific settings like Database Connection Strings and JWT Secret Keys.

### 2. MeusicRuchama.Service (Business Logic Layer)
This layer acts as the bridge between the data and the API. 
* **Business Logic:** Contains the core logic of the application (e.g., validating lesson times, processing user roles).
* **Services:** Implements the interfaces defined in the Core layer to process data before it is sent back to the controller.

### 3. MeusicRuchama.Core (Domain Layer)
The heart of the application. This layer is independent of other layers and contains the fundamental building blocks.
* **Entities:** Database models representing the tables in SQL Server (Users, Teachers, Students, Lessons).
* **DTOs (Data Transfer Objects):** Optimized objects for transferring data through the API without exposing sensitive entity details.
* **Interfaces:** Definitions for services and repositories to ensure Dependency Injection (DI) compliance.
* **Mappings:** AutoMapper profiles for seamless conversion between Entities and DTOs.

### 4. MeusicRuchama.Data (Data Access Layer)
Responsible for all interactions with the **SQL Server** database.
* **DbContext:** The Entity Framework Core context that manages the database connection and model configurations.
* **Migrations:** Tracks version history of the database schema.
* **Repositories:** (If applicable) Implements direct data CRUD operations.

### 5. MusicRuchamaTest (Testing Layer)
A dedicated project for ensuring system reliability.
* **Unit Tests:** Testing individual components (like Services) in isolation.
* **Integration Tests:** Validating the flow between different layers to ensure the API behaves as expected under various scenarios.

---

## 🚀 Tech Stack
* **Framework:** .NET 8.0
* **Database:** SQL Server
* **ORM:** Entity Framework Core
* **Authentication:** JWT (JSON Web Token)
* **Mapping:** AutoMapper
* **Documentation:** Swagger (OpenAPI)

---

## 🛠️ Getting Started

### Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* SQL Server Instance

### Installation
1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/your-username/MusicRuchama.git](https://github.com/your-username/MusicRuchama.git)
    ```
2.  **Configure Database:** Update the connection string in `MeusicRuchama/appsettings.json`.
3.  **Apply Migrations:**
    ```bash
    dotnet ef database update --project MeusicRuchama.Data --startup-project MeusicRuchama
    ```
4.  **Run the Application:**
    ```bash
    dotnet run --project MeusicRuchama
    ```

---

## 🔒 Security
The API is secured using **Role-Based Access Control (RBAC)**. 
* Endpoints are decorated with `[Authorize(Roles = "teacher")]` or `[Authorize(Roles = "student")]` to ensure data privacy and system integrity.

---
**Developed by [Your Name]** *Building professional solutions for music education management.*
