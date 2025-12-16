# Deployment & Configuration — RootServer Host

Deployment approach, configuration management, and environment handling.

---

## Environments
- Development, Staging, Production (at minimum)
- `appsettings.<Environment>.json` overrides

---

## Secrets & Sensitive Configuration
- Do not commit secrets; use Secret Manager (local) or managed secret stores
- Reference via environment variables or managed identities

---

## Feature Flags
- Host-level toggles for modules/plugins
- Rollout strategies: gradual enablement, safe defaults

---

## CI/CD Hooks (Recommended)
- Build/test gates, docs link checker, configuration schema validation
- Optional: security scanning for accidental secret commits

---

**Back navigation:** **[Architecture Index](./docsgen-12-arch-index.md)** · **[Root Index](./RootServer.md)**

---



