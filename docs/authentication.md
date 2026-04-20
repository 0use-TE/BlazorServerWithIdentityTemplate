# Authentication

## Overview

This template uses cookie-based authentication with a Web API layer to handle the unique constraints of Blazor Server's SignalR connection.

## Architecture

```
┌──────────────┐    JS Interop    ┌──────────────┐
│ Blazor Page  │ ───────────────► │ AuthController│
│ (Login.razor)│                  │              │
└──────────────┘                  └──────┬───────┘
                                         │
                                    Set-Cookie
                                         │
                                         ▼
                                  Browser Cookie
```

## How It Works

1. User submits credentials on Login page
2. Blazor JS interop calls `/api/auth/login`
3. API controller validates credentials
4. API sets authentication cookie in response
5. Cookie is stored in browser
6. Subsequent requests include the cookie automatically

## API Endpoints

### POST /api/auth/login

Login with username and password.

**Request:**
```json
{
  "username": "user@example.com",
  "password": "SecurePassword123!"
}
```

**Response (Success):**
```json
{
  "success": true,
  "username": "user@example.com"
}
```

**Response (Failure):**
```json
{
  "success": false,
  "message": "Invalid credentials"
}
```

### POST /api/auth/logout

Logout the current user.

**Response:**
```json
{
  "success": true
}
```

### GET /api/auth/currentuser

Get current authenticated user info.

**Response:**
```json
{
  "isAuthenticated": true,
  "username": "user@example.com"
}
```

## Protected Endpoints

Controllers or actions requiring authentication use `[Authorize]` attribute:

```csharp
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    // Protected code here
}
```

## Checking Authentication in Blazor

```csharp
@inject AuthenticationStateProvider AuthStateProvider

@if (authState.User.Identity.IsAuthenticated)
{
    <p>Welcome, @authState.User.Identity.Name!</p>
}
```

## Logout Flow

1. Blazor calls `/api/auth/logout` via JS interop
2. API calls `SignOutAsync()` on the authentication scheme
3. Response clears the auth cookie
4. Client redirects to public page

## Security Considerations

- **HttpOnly Cookies** - Prevents JavaScript access to auth cookies
- **Secure Policy** - Cookie only sent over HTTPS in production
- **CSRF Protection** - Built-in ASP.NET Core protection
- **Password Hashing** - Identity uses secure hashing algorithms

## See Also

- [Configuration](configuration.md)
- [API Reference](api.md)
- [Getting Started](getting-started.md)