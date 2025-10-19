# Quick Start Guide for LionTrackd

## For the Backend (.NET API):

1. **Configure MongoDB** (First time only):
   - Open `Backend/appsettings.json`
   - Add your MongoDB Atlas connection string (see MONGODB_CONFIG.md)

2. **Run the Backend**:
   ```powershell
   cd Backend
   dotnet run
   ```
   
   ✅ Backend running at: http://localhost:5000
   📚 Swagger docs at: http://localhost:5000/swagger

## For the Frontend (React):

1. **Install Dependencies** (First time only):
   ```powershell
   cd Frontend
   npm install
   ```

2. **Run the Frontend**:
   ```powershell
   npm run dev
   ```
   
   ✅ Frontend running at: http://localhost:5173

## Testing:

1. Open http://localhost:5173 in your browser
2. Add, edit, and delete items through the UI
3. Or test APIs directly at http://localhost:5000/swagger

## Common Commands:

### Backend:
- `dotnet restore` - Restore NuGet packages
- `dotnet build` - Build the project
- `dotnet run` - Run the application
- `dotnet watch run` - Run with hot reload

### Frontend:
- `npm install` - Install dependencies
- `npm run dev` - Start dev server
- `npm run build` - Build for production
- `npm run preview` - Preview production build

## PowerShell Execution Policy Fix:

If you get script execution errors, run PowerShell as Administrator:
```powershell
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```

## Need Help?

- Check the main README.md for detailed instructions
- Backend MongoDB setup: See MONGODB_CONFIG.md
- API documentation: http://localhost:5000/swagger (when backend is running)
