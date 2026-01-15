# Deployment

---

## Local Development

```bash
dotnet run
```

Application runs at `https://localhost:5001`

---

## Production Build

```bash
dotnet publish -c Release -o ./publish
```

---

## Deployment Targets

### Azure App Service
- Configure app settings for `Airtable` credentials
- Enable WebSockets for SignalR
- Set `SCM_DO_BUILD_DURING_DEPLOYMENT=true`

### Docker
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "RootServer.dll"]
```

### IIS
- Install `.NET 10.0 Hosting Bundle`
- Configure application pool for .NET Core
- Enable WebSocket Protocol

---

## Environment Configuration

Production `appsettings.Production.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "Airtable": {
    "ApiKey": "${AIRTABLE_API_KEY}",
    "BaseId": "${AIRTABLE_BASE_ID}"
  }
}
```

---

---

**Navigation**

- **[← Configuration](rootserver-10-configuration.md)**
- **[Module System →](rootserver-13-arch-modules.md)**
- **[Home](rootserver.md)**

---
