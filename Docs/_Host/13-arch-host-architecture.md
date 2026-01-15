# Host Architecture — RootServer

Detailed architecture of the RootServer Host, focusing on boundaries, flows, and runtime coordination.

---

## Responsibilities & Composition
- Composition root: `Program.cs` configures DI, logging, and environment
- Module orchestration: Host initializes modules and exposes host-level services
- Plugin accommodation: Host exposes extension points; avoids depending on plugin types

---

## Boundaries
- Host ↔ Modules: strong dependencies allowed; modules always active
- Host ↔ Plugins: Host provides contracts; plugins reference Host, not vice versa
- Plugin ↔ Plugin: planned via Node system (experimental; see `Docs/Extend/Module-Internal/NodeEditor`)

---

## Runtime Flows
- Startup: read configuration → build DI container → initialize modules → discover/activate plugins (optional) → initialize UI routes
- Shutdown: graceful service disposal → flush logs/metrics → complete in-flight tasks

---

## Configuration Sources
- `appsettings.json` + `appsettings.<Environment>.json`
- Environment variables and user secrets (development)
- Command-line overrides (optional)

---

## Logging & Telemetry
- Structured logging with context (request/operation IDs)
- Metrics: latency, throughput, error rates, cache hit ratios
- Traces: Host → Module → Plugin spans where feasible

---

**Back navigation:** **[Architecture Index](./docsgen-12-arch-index.md)** · **[Root Index](./RootServer.md)**

---
