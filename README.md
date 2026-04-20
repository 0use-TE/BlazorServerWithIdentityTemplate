# BlazorServer With Identity Template

A production-ready Blazor Server project template with built-in Web API authentication, Entity Framework Core, and MudBlazor UI.

## Features

- **Web API Integration** - REST API endpoints for authentication
- **Identity Authentication** - Complete user management with cookie-based auth
- **Entity Framework Core** - SQLite by default, easily swappable
- **MudBlazor UI** - Modern, responsive component library
- **JWT Support** - Token-based authentication for API access

## Quick Start

```bash
# Install the template
dotnet new install BlazorServerWithIdentityTemplate

# Create a new project
dotnet new blazorserverwithidentity -n YourProjectName

# Navigate to project
cd YourProjectName

# Run the project
dotnet run
```

## Documentation

- [Introduction](docs/introduction.md) - Overview and architecture
- [Getting Started](docs/getting-started.md) - Installation and setup guide
- [Configuration](docs/configuration.md) - Customizing the template
- [API Reference](docs/api.md) - Web API endpoints
- [Authentication](docs/authentication.md) - Auth system details

## Architecture

```
┌─────────────────────────────────────────────────────────┐
│                    Blazor Server                         │
│  ┌─────────────┐  ┌─────────────┐  ┌─────────────────┐  │
│  │ Components  │  │  Pages      │  │ JavaScript      │  │
│  └──────┬──────┘  └──────┬──────┘  └────────┬────────┘  │
│         │                │                   │           │
│         └────────────────┼───────────────────┘           │
│                          │ SignalR                       │
├──────────────────────────┼───────────────────────────────┤
│                    Program.cs                            │
│  ┌─────────────────┐  ┌─────────────────────────────┐  │
│  │ API Controllers  │  │ Authentication Service        │  │
│  └────────┬────────┘  └──────────────┬──────────────┘  │
│           │                           │                  │
│           ▼                           ▼                  │
│  ┌─────────────────┐  ┌─────────────────────────────┐  │
│  │ EF Core         │  │ Identity                     │  │
│  │ SQLite          │  │ Cookie Authentication        │  │
│  └─────────────────┘  └─────────────────────────────┘  │
└─────────────────────────────────────────────────────────┘
```

## Why This Template?

Blazor Server uses SignalR for real-time communication. Unlike traditional MVC, there's no HTTP request-response cycle for component interactions, making cookie-based authentication challenging.

This template solves this by:
1. Integrating a Web API layer for auth operations
2. Using `NavigationManager` or JS interop for API calls
3. Setting auth cookies via API responses

## License

MIT