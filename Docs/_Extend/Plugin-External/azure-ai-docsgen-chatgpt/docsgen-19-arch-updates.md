# Updates & Events (Run Streaming)

---

## Overview

DocsGen exposes run progress via an event stream so the UI can update in real time.

Two common transport options:
- SignalR (native for server-side Blazor)
- Server-Sent Events (SSE)

The transport is not the authority; the orchestrator state is.

---

## Event Design Goals

- Events are append-only and ordered per run.
- Events are sufficient to render progress, but the UI can also fetch snapshots.
- Events include enough data to diagnose what happened without reading logs.

---

## Canonical Event Types

- `run.created`
- `phase.started`
- `artifact.written`
- `validation.started`
- `validation.passed`
- `validation.failed`
- `approval.required`
- `approval.recorded`
- `run.completed`
- `run.failed`
- `run.canceled`

---

## Example Event Payload

```json
{
  "runId": "run_2025_12_14_0001",
  "type": "validation.failed",
  "phase": 3,
  "message": "Phase 3 gate failed: 2 broken links",
  "utc": "2025-12-14T00:48:10Z",
  "data": {
    "issuesReportArtifact": "run_2025_12_14_0001/phase3/03-phase3-issues.md",
    "issueCount": 2
  }
}
```

---

## UI Synchronization Strategy

Recommended UI strategy:

1. Subscribe to events
2. Maintain a local event list for the run view
3. Periodically fetch the run snapshot to handle reconnects and missed events
4. Render timeline and reports from authoritative snapshot data

---

## Reconnect / Replay

If the UI reconnects:
- it should request events since the last seen timestamp or sequence number
- or fallback to snapshot-only rendering

The orchestrator should support replay by storing events in the manifest store.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
