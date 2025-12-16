# Integrations Overview — RootServer Host

High-level view of external systems coordinated by the Host. Details live in module/plugin documentation; Host documents contracts, policies, and boundaries.

---

## Integration Inventory (Host Scope)
- Airtable: data retrieval and updates aligned to Base → Table → Row → Field
- HTTP/SDK clients: used by modules/plugins; Host defines retries/backoff defaults where applicable
- Static assets and external services: delivered via `wwwroot` and configured endpoints

---

## Failure Policies (Strict)
- Timeouts: must be defined for all remote calls
- Retries: bounded with backoff; avoid thundering herds
- Circuit breakers: recommended for persistent failures
- Idempotency: required for retryable operations

---

## Authentication & Authorization (Host View)
- Authentication configured at Host; modules/plugins consume context
- Authorization model: prefer simple RBAC at Host boundary; enforce least privilege

---

## Observability Requirements
- Structured logs with correlation IDs for cross-service flows
- Metrics for latency, error rates, cache hit ratios
- Tracing across Host → Module → Plugin calls when feasible

---

**Back navigation:** **[Architecture Index](./docsgen-12-arch-index.md)** · **[Root Index](./RootServer.md)**

---



