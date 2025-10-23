## What is LionTrackd?

LionTrackd is a simple, easy-to-use lost & found platform. It helps students and campus visitors report and find lost items quickly by connecting finders and owners directly, optionally with a monetary reward to encourage returns.

- A modern lost-&-found web application (C# .NET backend • React frontend • MongoDB Atlas).
- A concise guide to run, configure, and extend the project for development and testing.

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
 
   ✅ Backend running at: http://localhost:5000
   📚 Swagger docs at: http://localhost:5000/swagger

## Testing:

1. Backend runs at http://localhost:5000
2. Swagger docs at: http://localhost:5000/swagger
3. Frontend at Open http://localhost:5173

## Common Commands:

### Backend:
- `dotnet restore` - Restore NuGet packages
- `dotnet build` - Build the project
- `dotnet run` - Run the application
- `dotnet watch run` - Run with hot reload

### Frontend:
- `npm install` - Install dependencies
- `npm.cmd run dev` - Start dev server
- `npm run build` - Build for production
- `npm run preview` - Preview production build

## Quick start (development)

Prerequisites:

- .NET 9.0 SDK (`dotnet --version`)
- Node.js 18+ and npm (`node --version`, `npm --version`)
- MongoDB Atlas cluster (or local MongoDB)

1. Start the program

```powershell
cd Frontend
npm.cmd install
npm.cmd start
```

2. Open the program

Open: `http://localhost:5173` (Front end Vite dev server).
Open: `http://localhost:5000` (Backend).
Open: `http://localhost:5000/swagger` (Swagger documentation).

> PowerShell tip: If `npm` is blocked by execution policy, run `npm.cmd` or run:

```powershell
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```