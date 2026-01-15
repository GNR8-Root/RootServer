# Deployment and Configuration

---

## Local Development Setup

### Prerequisites

- .NET 8 SDK
- JetBrains Rider (preferred) or Visual Studio
- Airtable API key (contact arnold@znzr.io)

### Running Locally

```bash
# Clone repository
git clone https://github.com/GNR8-Root/RootServer.git

# Navigate to project
cd RootServer

# Restore dependencies
dotnet restore

# Run application
dotnet run

# Navigate to https://localhost:5001
```

---

## Configuration

### appsettings.json

Minimal configuration:
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

Development-specific settings (content unknown from inspection).

---

## Airtable Configuration

**API Key Management:** Expected in configuration but not committed to repository (good practice).

**Initialization:** `AirtableConfig.Initialize(builder.Configuration)`

**Recommended Pattern:**
```json
{
  "Airtable": {
    "ApiKey": "keyXXXXXXXXXXXXXX",
    "BaseId": "appXXXXXXXXXXXXXX"
  }
}
```

Store secrets in:
- Local: User Secrets (dotnet user-secrets)
- Production: Azure Key Vault, AWS Secrets Manager, or environment variables

---

## Deployment Models

### Self-Hosted

**Current assumed target:** Local development machine

**Requirements:**
- .NET 8 Runtime
- Web server (Kestrel)
- Persistent storage for JSON cache

---

### Azure App Service

**Recommended for production:**

```bash
# Publish
dotnet publish -c Release -o ./publish

# Deploy to Azure
az webapp deployment source config-zip \
  --resource-group myResourceGroup \
  --name myAppName \
  --src ./publish.zip
```

**Configuration:**
- App Settings for Airtable keys
- Application Insights for monitoring
- Azure Blob Storage for JSON cache (optional)

---

### Docker Container

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY publish/ .
ENTRYPOINT ["dotnet", "RootServer.dll"]
```

---

## Environment Configuration

### Development
- Local JSON cache
- Detailed logging
- No authentication

### Production (Recommended)
- Azure Blob Storage for JSON cache
- Minimal logging
- Authentication/Authorization
- HTTPS enforced
- Rate limiting

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
