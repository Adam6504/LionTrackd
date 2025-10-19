# LionTrackd

- A modern lost-&-found web application (C# .NET backend • React frontend • MongoDB Atlas).
- A concise guide to run, configure, and extend the project for development and testing.

---

## What is LionTrackd?

LionTrackd is a simple, easy-to-use lost & found platform. It helps students and campus visitors report and find lost items quickly by connecting finders and owners directly, optionally with a monetary reward to encourage returns.

---

## Key features

- Create / Read / Update / Delete (CRUD) operations for lost/found items
- Search and filter by category and location
- Optional reward field when posting items
- Responsive React UI (mobile-first)
- MongoDB Atlas backend with a service layer
- Swagger/OpenAPI for interactive API docs

---

## Tech stack

- Backend: .NET 9.0, ASP.NET Core Web API
- Database: MongoDB Atlas (official driver)
- Frontend: React 18 + Vite
- Tools: Swagger (Swashbuckle), Axios, ESLint, Prettier

---

## Quick start (development)

Prerequisites:

- .NET 9.0 SDK (`dotnet --version`)
- Node.js 18+ and npm (`node --version`, `npm --version`)
- MongoDB Atlas cluster (or local MongoDB)

1. Start the backend

```powershell
cd Backend
# Restore, build and run
dotnet restore
dotnet build
dotnet run
```

The backend prints listening URLs (e.g. `http://localhost:5000`). Open Swagger at `http://localhost:5000/swagger` while running in Development.

2. Start the frontend (new terminal)

```powershell
cd Frontend
# On Windows powershell use npm.cmd if npm shims are blocked
npm.cmd install
npm.cmd run dev
```

Open: `http://localhost:5173` (Vite dev server).

> PowerShell tip: If `npm` is blocked by execution policy, run `npm.cmd` or run:

```powershell
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```