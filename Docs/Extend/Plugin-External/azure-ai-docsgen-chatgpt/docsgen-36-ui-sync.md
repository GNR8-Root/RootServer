# UI Synchronization

---

## Overview

DocsGen UI synchronization is event-driven.

The UI should subscribe to a run’s event stream and also be able to fetch a snapshot if:

- it reconnects
- it missed events
- it is opened via a deep link

---

## Recommended Strategy

1. Subscribe to events for the run
2. Append events to an in-memory list for display
3. When a “phase completed” or “validation completed” event arrives, fetch the latest snapshot for correctness
4. On reconnect, fetch snapshot first, then request recent events (if supported)

---

## Polling Fallback

If streaming is unavailable:
- poll the run snapshot endpoint on a modest interval
- keep polling slower during idle states (awaiting approval)
- keep polling faster during running phases

Polling must not become the primary architecture unless required by the host.

---

## Idempotency

UI actions must be idempotent-safe:

- approval should handle double-click without advancing twice
- cancellation should handle repeated clicks without error
- downloads should be repeatable

The orchestrator is responsible for idempotency, but the UI should also disable buttons while calls are in flight.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
