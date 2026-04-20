# Configuration

## Application Settings

All configuration is managed through `appsettings.json`.

## Basic Configuration

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## Database Configuration

### SQLite (Default)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=app.db"
  }
}
```

### SQL Server

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MyDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### PostgreSQL

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=MyDb;Username=postgres;Password=secret"
  }
}
```

## Authentication Configuration

### Cookie Settings

Configure in `Program.cs`:

```csharp
builder.Services.AddAuthentication()
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "MyApp.Auth";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.LoginPath = "/login";
        options.LogoutPath = "/logout";
    });
```

### JWT Settings (Optional)

```json
{
  "Jwt": {
    "Key": "your-256-bit-secret-key-here-min-32-chars",
    "Issuer": "MyApp",
    "Audience": "MyApp.Users",
    "ExpiryDays": 7
  }
}
```

## MudBlazor Theme

Customize in `Program.cs`:

```csharp
builder.Services.AddMudServices();
builder.Services.AddBlazorWebAssembly();

var theme = new MudTheme
{
    PaletteLight = new PaletteLight(),
    PaletteDark = new PaletteDark(),
    LayoutProperties = new LayoutProperties()
};
```

## Environment-Specific Settings

Create `appsettings.Development.json` for development:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.AspNetCore": "Information"
    }
  }
}
```

## See Also

- [Authentication](authentication.md)
- [API Reference](api.md)
- [Introduction](introduction.md)