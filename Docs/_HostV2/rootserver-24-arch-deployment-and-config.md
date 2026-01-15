# Deployment and Configuration

Where configuration lives and how deployment should be documented and hardened.

---
## Deployment targets

Deployment target is **not explicitly declared** in inventory.

Common candidates:
- Azure App Service (Blazor Server)
- Containerized deployment

Investigation steps:
- Search for Dockerfiles or Azure-specific configs.


## Configuration

Configuration is present via:
- `appsettings.json`
- `appsettings.Development.json`

Do not store real secrets in these files.


## Feature flags

Feature flags are **unknown** in this scan.

Investigation steps:
- Search config for flag-like keys (`Feature:`, `Flags:`).


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
