# Base Runtime Execution

How the host starts, what it wires, and where runtime ownership lives.

---
## Runtime overview

The host application boots from `Program.cs` and wires services through standard .NET dependency injection.


## Startup / boot

Evidence:
- `Program.cs`
- `RootServer.csproj`

What to look for:
- Service registrations
- Configuration loading (appsettings)
- Middleware/pipeline configuration (if present)


## Key services

Service inventory is **partially unknown** without deeper DI parsing.

Investigation steps:
- Search `Program.cs` for `AddSingleton`, `AddScoped`, `AddTransient`.
- Record core service types into `01-inventory-index.json` in a follow-up pass.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
