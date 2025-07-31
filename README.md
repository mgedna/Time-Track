# ⏱️ Time-Track

A modular **time tracking and leave management application** built with **.NET 9**, **Clean Architecture**, **PostgreSQL**, and **Firebase Authentication**.  
This project is currently under development and aims to provide a scalable solution for managing employee attendance, leave requests, overtime tracking, and holiday schedules.

---

## 🚀 Features Implemented

- ✅ **Clean Architecture** structure (`Domain`, `Application`, `Persistence`, `Infrastructure`, `WebApi`)  
- ✅ **Entity Framework Core** with PostgreSQL database  
- ✅ **Firebase Authentication** with custom JWT handler  
- ✅ **Entities & DbContext**:  
  - `User` with Roles (`Admin`, `Manager`, `TeamLead`, `Employee`, `HR`)  
  - `TimeEntry` for clock-in/out  
  - `LeaveRequest` with `Pending/Approved/Rejected` status  
  - `OvertimeRequest` with status  
  - `Holiday` for public holidays  
- ✅ **Swagger / OpenAPI** integration with JWT Bearer support  
- ✅ **Database migrations** successfully applied  

---

## 🏗️ Clean Architecture Overview

```
+-------------------------------------------------------+
|                    WebApi Layer                       |
|   (Controllers, Swagger, Dependency Injection Setup)   |
+---------------------------+---------------------------+
                            ↓
+-------------------------------------------------------+
|                Infrastructure Layer                   |
|     (Firebase Auth Service, External Providers)        |
+---------------------------+---------------------------+
                            ↓
+-------------------------------------------------------+
|                Application Layer                      |
|   (Business Logic, Services, Interfaces, DTOs)         |
+---------------------------+---------------------------+
                            ↓
+-------------------------------------------------------+
|                Persistence Layer                      |
|   (EF Core DbContext, Repositories, PostgreSQL)        |
+---------------------------+---------------------------+
                            ↓
+-------------------------------------------------------+
|                    Domain Layer                       |
|   (Entities, Enums, Core Models, Base Classes)         |
+-------------------------------------------------------+
```

---

## 📂 Project Structure

```
src/
 ├── TimeTrack.Domain           # Entities, Enums, Core Models
 ├── TimeTrack.Application      # Business logic, Interfaces, Services
 ├── TimeTrack.Persistence      # EF Core, DbContext, Repositories
 ├── TimeTrack.Infrastructure   # External services (Firebase, etc.)
 ├── TimeTrack.WebApi            # API layer, DI setup, Swagger
tests/
 ├── TimeTrack.Tests.UnitTests
 ├── TimeTrack.Tests.IntegrationTests
```

---

## 🛠️ Technologies

- **.NET 9** (C#)
- **Entity Framework Core** with **PostgreSQL**
- **Firebase Admin SDK**
- **Swagger / OpenAPI**
- **Clean Architecture**
- **Docker** (planned for deployment)

---

## ⚡ Getting Started

### 1️⃣ Clone the repository
```bash
git clone https://github.com/mgedna/Time-Track.git
cd Time-Track
```

### 2️⃣ Restore and build
```bash
dotnet restore
dotnet build
```

### 3️⃣ Setup PostgreSQL
Ensure you have a running PostgreSQL instance. Update your connection string in:
```
src/TimeTrack.WebApi/appsettings.json
```

Example:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=db;Username=user;Password=pass"
}
```

### 4️⃣ Apply migrations
```bash
dotnet ef database update --project ./src/TimeTrack.Persistence --startup-project ./src/TimeTrack.WebApi
```

### 5️⃣ Run the API
```bash
dotnet run --project ./src/TimeTrack.WebApi
```

### 6️⃣ Access Swagger UI
- Navigate to: [https://localhost:5001](https://localhost:5001)

---

## 🔑 Authentication

This API uses **Firebase Authentication**.  
To test protected endpoints:

1. Obtain a Firebase **ID Token** (JWT) via:
   - Frontend SDK: `auth.currentUser.getIdToken()`
   - Firebase REST API (Password Sign-In)
2. Click **Authorize** in Swagger and paste:
```
Bearer {your_firebase_id_token}
```

---

## 🧩 Roadmap / Next Steps

- [ ] Implement **Repositories** for all entities  
- [ ] Add **Application Services** (business logic)  
- [ ] Build **Controllers** for User, TimeEntry, Leave, Overtime, Holiday  
- [ ] Add **DTOs, AutoMapper, FluentValidation**  
- [ ] Implement **Global Error Handling Middleware**  
- [ ] Add **Unit and Integration Tests**  
- [ ] Docker Compose setup for API + PostgreSQL  
- [ ] Deployment to cloud (Azure/AWS/Render)  

---

## 👤 Author

**Edna Memedula**  
📫 [LinkedIn](https://www.linkedin.com/in/edna-memedula-24b519245) • [GitHub](https://github.com/mgedna)
