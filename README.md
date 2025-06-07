# 🏥 Oseredok Management System

A full-stack web application designed to manage the operations of a kinesiotherapy rehabilitation center. This system helps clients, administrators, and coaches interact effectively while streamlining session scheduling, payments, and user role management.

---

## 📌 Overview

This project was developed as part of my bachelor’s thesis at the National University of Ostroh Academy. It addresses the real-world need for digitization in small rehabilitation centers, replacing manual tracking (e.g., notebooks) with a robust and user-friendly system.

---

## ⚙️ Tech Stack

### Backend
- **Language:** C#
- **Framework:** ASP.NET Core 6
- **Architecture:** Clean Architecture + CQRS
- **ORM:** Entity Framework Core (Code-First)
- **Security:** JWT Authentication, Role-based Authorization
- **Error Handling:** [ErrorOr](https://github.com/amantinband/error-or)
- **Object Mapping:** Mapster
- **API Testing & Docs:** Swagger (OpenAPI)
- **Patterns:** Repository Pattern, Dependency Injection
- **Mediator:** MediatR

### Frontend
- **Language:** JavaScript
- **Framework:** React
- **UI Library:** Material UI (MUI)
- **HTTP Client:** Axios

---

## 👥 User Roles & Features

- **Client**
  - Book sessions with trainers
  - View session history and payment balance
- **Trainer**
  - View client schedules
  - Suggest sessions and confirm bookings
  - Track completed sessions
- **Administrator**
  - Manage user roles (e.g., assign trainer/admin rights)
  - Monitor payments and calculate trainer wages

---

## 🔐 Authentication & Authorization

- Secure login and registration using JWT
- New users are assigned a default "noRole"
- Admins have exclusive access to assign roles
- Protected routes (e.g., `/admin`, `/coach`) based on roles

---

## 🏗️ Project Architecture

The solution follows **Clean Architecture**, organizing code into:
- `Domain` — Entity definitions and core logic
- `Application` — Use cases, handlers, and interfaces
- `Infrastructure` — Data access, external services, token generation
- `Contracts` & `Shared` — DTOs and shared logic
- `API` — Entry point with controllers and middleware

The **CQRS pattern** is implemented using **MediatR**, separating read and write operations for clarity and scalability.

---

## 🎓 Project Purpose

This system was created to:
- Automate a real business problem
- Demonstrate understanding of Clean Architecture and modern web practices
- Develop a secure, modular, and testable codebase for real-world use

---

## 📁 Features Implemented

- ✅ Modular CQRS backend with robust domain layer
- ✅ Secure authentication and role-based authorization
- ✅ Automated error responses and validation
- ✅ Interactive Swagger UI for API testing
- ✅ React frontend with role-specific interfaces
- ✅ Seamless server-client integration with Axios
- ✅ Code-first database design with EF Core

---

## 📜 License

This project is created for academic purposes and is open for educational use.

---

## 🙋‍♂️ Author

**Nazar Sachuk**  
.NET Backend Developer  
[GitHub Profile](https://github.com/nzrjed-git)
