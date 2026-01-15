# Blazor UI Architecture (Experience Plane)

---

## Overview

DocsGen’s UI is a Blazor experience that exposes the documentation generation workflow without owning any generation logic.

The UI has four jobs:

1. Collect inputs
2. Configure run mode and strictness
3. Display progress and validation results
4. Record approvals and download outputs

All decisions about phases, artifacts, and gate outcomes belong to the orchestrator API.

---

## Page / Screen Set

A minimal DocsGen UI typically includes:

- **New Run Wizard**
  - upload inputs
  - configure review mode and strictness
  - start run

- **Run Dashboard**
  - phase timeline
  - current phase status
  - approve / cancel actions
  - download artifacts (partial or final)

- **Validation Report Viewer**
  - show pass/fail report Markdown
  - show structured issue table (filterable)

- **Artifact Browser**
  - list core files
  - open Markdown preview

---

## Component Responsibilities

### RunWizard
- accepts file uploads and configuration
- performs only client-side sanity checks (file present, size)
- calls API to create a run

### RunDashboard
- subscribes to run events (SignalR/SSE)
- renders phase status and gate outcomes
- exposes approval and cancellation actions

### ValidationViewer
- renders the latest report for a phase
- shows structured issues with “open file” shortcuts

### ArtifactBrowser
- lists artifacts grouped by phase
- previews Markdown artifacts
- provides download links for single files or bundles

---

## UI-to-API Contract (Conceptual)

DocsGen’s UI calls a small set of endpoints:

```text
POST   /api/runs                                   -> create run + upload inputs
GET    /api/runs/run_2025_12_14_0001               -> read run state
GET    /api/runs/run_2025_12_14_0001/events        -> SSE or SignalR stream
POST   /api/runs/run_2025_12_14_0001/approve       -> approve current gate
POST   /api/runs/run_2025_12_14_0001/cancel        -> cancel run
GET    /api/runs/run_2025_12_14_0001/artifacts     -> list artifacts
GET    /api/runs/run_2025_12_14_0001/artifact      -> download single artifact (by path/id)
GET    /api/runs/run_2025_12_14_0001/download      -> download final bundle
```

The UI does not call validator endpoints directly; validation is orchestrator-owned.

---

## Suggested Blazor Patterns (Server-Side)

RootServer is server-side Blazor. DocsGen should follow the same model.

### State Handling
- keep view state small and derived from API DTOs
- avoid local “phase state machine” logic
- treat the orchestrator’s `Run.Status` and `Run.CurrentPhase` as authoritative

### Streaming Updates
Prefer server push (SignalR/SSE) so progress updates are immediate and do not require aggressive polling.

---

## Example: Run Event Handling (Conceptual)

```csharp
public record RunEvent(
    string RunId,
    string Type,
    int? Phase,
    string Message,
    DateTimeOffset Utc);

public class RunDashboardState
{
    public string RunId { get; init; } = "";
    public int CurrentPhase { get; set; }
    public string Status { get; set; } = "running";
    public List<RunEvent> Events { get; } = new();
}
```

The UI updates purely from events and periodic run snapshots.

---

## UI Guardrails

The UI must not:
- decide whether a gate “should pass”
- generate or rewrite documentation files
- call agents directly
- bypass orchestrator policies

If the UI needs additional actions, the orchestrator API should expose them explicitly.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
