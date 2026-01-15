# Configuration

---

## Application Settings

### appsettings.json

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

### appsettings.Development.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.AspNetCore": "Information"
    }
  },
  "Airtable": {
    "ApiKey": "key***",
    "BaseId": "app***"
  }
}
```

---

## Airtable Configuration

Configured via `AirtableConfig.Initialize()` in `Program.cs`:

```csharp
public static class AirtableConfig
{
    public static string ApiKey { get; private set; }
    public static string BaseId { get; private set; }
    
    public static void Initialize(IConfiguration configuration)
    {
        ApiKey = configuration["Airtable:ApiKey"];
        BaseId = configuration["Airtable:BaseId"];
    }
}
```

---

## Environment Variables

Support for environment-based configuration:

```bash
export AIRTABLE__APIKEY="your-key"
export AIRTABLE__BASEID="your-base"
```

---

## User Secrets (Development)

For sensitive data in development:

```bash
dotnet user-secrets init
dotnet user-secrets set "Airtable:ApiKey" "your-key"
dotnet user-secrets set "Airtable:BaseId" "your-base"
```

---

---

**Navigation**

- **[← Service Layer](rootserver-09-service-layer.md)**
- **[Deployment →](rootserver-11-deployment.md)**
- **[Home](rootserver.md)**

---
