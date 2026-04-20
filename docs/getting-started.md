# Getting Started

## Prerequisites

- [.NET 8.0+ SDK](https://dotnet.microsoft.com/download)
- A code editor (VS Code, Visual Studio, Rider)

## Installation

### Step 1: Install the Template

```bash
dotnet new install BlazorServerWithIdentityTemplate
```

### Step 2: Create a New Project

```bash
dotnet new blazorserverwithidentity -n MyProject
cd MyProject
```

### Step 3: Run the Application

```bash
dotnet run
```

The application will start at `https://localhost:5001` or `http://localhost:5000`.

## First Run

On first run, the database is automatically created and migrations are applied. Navigate to the login page to create your first user account.

## Project Files Overview

| File | Description |
|------|-------------|
| `Program.cs` | Application entry point, service registration |
| `appsettings.json` | Configuration settings |
| `Controllers/AuthController.cs` | Authentication API endpoints |
| `Data/ApplicationDbContext.cs` | EF Core database context |
| `Pages/Login.razor` | Login page component |
| `Pages/_Host.cshtml` | Blazor host page |

## Customizing the Project

### Change Database

Modify `Program.cs` to use a different database provider:

```csharp
// SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
```

### Add Connection String

In `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  }
}
```

## Troubleshooting

### Port Already in Use

```bash
dotnet run --urls "http://localhost:5000"
```

### Database Reset

Delete `app.db` and restart the application - it will recreate automatically.

### Clear Build Cache

```bash
dotnet clean
dotnet build
```