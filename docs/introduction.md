# Introduction

## Overview

**BlazorServer With Identity Template** is a production-ready project template that combines Blazor Server with a Web API layer to solve the authentication challenges inherent to SignalR-based applications.

## Key Components

| Component | Technology | Purpose |
|-----------|------------|---------|
| Frontend | Blazor Server | Interactive UI components |
| API | ASP.NET Core Web API | Authentication & data endpoints |
| Database | EF Core + SQLite | Data persistence |
| UI Library | MudBlazor | Responsive component design |
| Auth | ASP.NET Core Identity | User management & authentication |

## The Problem

Blazor Server communicates over SignalR - there's no traditional HTTP request-response for component interactions. This makes cookie-based authentication impossible through normal Blazor channels.

## The Solution

This template implements a dual-layer approach:

1. **Blazor Components** - Handle UI and business logic
2. **Web API Controllers** - Handle authentication (login/logout)
3. **JavaScript Interop** - Bridge Blazor and API for auth operations

```
User Action → Blazor Component → JS Interop → API Controller → Set-Cookie → Response
```

## Project Structure

```
YourProject/
├── Controllers/
│   └── AuthController.cs      # Login/Logout endpoints
├── Data/
│   └── ApplicationDbContext.cs
├── Pages/
│   ├── Login.razor
│   ├── Logout.razor
│   └── *.razor
├── Program.cs
└── appsettings.json
```

## Default Configuration

- **Database**: SQLite (`app.db`)
- **Auth Mode**: Cookie-based
- **UI Theme**: MudBlazor (dark/light mode support)
- **Server Mode**: Server-side global interactivity

## Next Steps

- [Getting Started](getting-started.md) - Install and run
- [Configuration](configuration.md) - Customize settings