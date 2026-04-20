# API Reference

## Authentication Endpoints

All auth endpoints are under `/api/auth/`.

### Login

**POST** `/api/auth/login`

Authenticate user and set auth cookie.

| Parameter | Type | Required | Description |
|-----------|------|----------|-------------|
| username | string | Yes | User's email or username |
| password | string | Yes | User's password |

**Response Codes:**
- `200 OK` - Login successful
- `401 Unauthorized` - Invalid credentials

---

### Logout

**POST** `/api/auth/logout`

Sign out current user and clear auth cookie.

**Response Codes:**
- `200 OK` - Logout successful

---

### Get Current User

**GET** `/api/auth/currentuser`

Get info about the currently authenticated user.

**Response:**
```json
{
  "isAuthenticated": true,
  "username": "user@example.com"
}
```

## Data Endpoints

### Example Protected Endpoint

```csharp
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }
}
```

## Request/Response Format

All API requests and responses use JSON format.

**Headers:**
```
Content-Type: application/json
```

## Error Responses

Standard error response format:

```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
  "title": "Not Found",
  "status": 404,
  "detail": "Resource not found"
}
```

## CORS Configuration

CORS is configured in `Program.cs` if you need to access APIs from other origins:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy => policy.WithOrigins("https://localhost:5001")
                       .AllowAnyHeader()
                       .AllowAnyMethod());
});
```

## See Also

- [Authentication](authentication.md)
- [Configuration](configuration.md)
- [Getting Started](getting-started.md)