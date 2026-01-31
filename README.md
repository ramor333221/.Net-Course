# .NET Course – Layered Architecture Project

This repository contains a .NET solution built as part of a course, demonstrating a **Layered Architecture** design.  
The project is structured into multiple projects, each with a single responsibility, following best practices for maintainability, scalability, and testability.

---

## 📌 Solution Overview

**Architecture Type:** Layered / N-Tier  
**Purpose:** Learning and practicing clean architecture principles in .NET

---

## 🧱 Solution Structure

| Project Name | Layer | Responsibility |
|-------------|-------|----------------|
| `MeusicRuchama.Core` | Core | Domain models, entities, interfaces |
| `MeusicRuchama.Data` | Data | Database access and persistence |
| `MeusicRuchama.Service` | Service | Business logic and validations |
| `MeusicRuchama` | API | HTTP endpoints and request handling |
| `MusicRuchamaTest` | Tests | Unit and logic testing |

---

## 📦 Project Breakdown

### 🔹 MeusicRuchama.Core (Core Layer)
- Domain entities and models
- Interfaces and abstractions
- Shared types used across the solution
- Independent of external frameworks

---

### 🔹 MeusicRuchama.Data (Data Layer)
- Handles database access
- Entity Framework DbContext
- Entity configurations
- CRUD operations and repositories
- Responsible only for **data persistence**

---

### 🔹 MeusicRuchama.Service (Service Layer)
- Core business logic
- Validations and business rules
- Implements use cases
- Communicates with the Data layer
- Acts as the bridge between API and Data

---

### 🔹 MeusicRuchama (API / Presentation Layer)
- ASP.NET Core Web API
- Controllers and endpoints
- Handles HTTP requests and responses
- Calls the Service layer only
- Does **not** access the database directly

---

### 🔹 MusicRuchamaTest (Tests Layer)
- Unit tests for services and logic
- Ensures correctness and stability
- Uses testing frameworks such as xUnit or NUnit
- Helps prevent regressions

---

## 🔁 Application Flow

Client
↓
Controller (API)
↓
Service (Business Logic)
↓
Data (Database Access)
↓
Database

---

## 🌐 API Endpoints (Example)

> Endpoints depend on the implemented controllers, but follow REST principles.

Examples:
- `GET /api/items` – Retrieve data
- `POST /api/items` – Create new data
- `PUT /api/items/{id}` – Update existing data
- `DELETE /api/items/{id}` – Remove data

---

## ▶️ How to Run the Project

### 1️⃣ Clone the repository
```bash
git clone https://github.com/ramor333221/.Net-Course.gitgit clone https://github.com/ramor333221/.Net-Course.git
### 2️⃣ Open the solution
Open: MeusicRuchama.sln
### 3️⃣ Restore dependencies
dotnet restore
### 4️⃣ Run the API project
dotnet run --project MeusicRuchama
### 5️⃣ Access the API
The API will run locally, usually at:
https://localhost:5001

🛠 Technologies Used

C#

.NET / ASP.NET Core
Entity Framework
REST API
Unit Testing (xUnit / NUnit)
