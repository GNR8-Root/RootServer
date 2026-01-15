# Appendix – Plugin Folder Structure Mapping (Blazor / .NET)

This appendix explains how a DocsGen plugin can be placed into the **standard plugin folder structure**
used by RootServer (similar to existing plugins).

The goal is to keep responsibilities clean and predictable:
- **00_Core** = foundations and contracts
- **Displays / Fields** = UI primitives
- **Pointers / Actions** = navigation + commands
- **Components / Widgets / View / Panels** = composition layers

Static assets (JS/CSS/images) belong in:
- `wwwroot/` (hosted by RootServer)

---

## Standard Folder Responsibilities (RootServer Convention)

### `00_Core/`
Foundational code used everywhere.
- records/models (Run, Artifact, Issue, Policy)
- enums (status, phase numbers)
- interfaces (artifact store, validators, API clients)
- serialization helpers and DTOs

### `01_Displays/`
View-only UI (no user input).
- status badges
- read-only phase row renderer
- artifact metadata displays

### `02_Fields/`
Interactive UI inputs.
- upload controls
- strictness / mode selectors
- filters for issues table

### `03_Pointers/`
Navigation and selection primitives.
- run picker
- breadcrumb controls
- deep-link helpers

### `04_Actions/`
Commands and side effects.
- start run action
- approve action
- cancel action
- download action
- any orchestration API client calls

### `05_Nodes/` (Optional for DocsGen)
DocsGen is not a graph domain, but keeping the folder can preserve convention.

Suggested use:
- domain-specific UI models for run timeline nodes (pure view models)
- helper mappers between DTOs and UI presentation

### `06_Components/`
Composable UI building blocks.
- RunWizard form component
- PhaseTimeline component
- IssuesTable component
- ArtifactBrowser component
- ReportViewer component

### `07_Widgets/`
Medium/large layout compositions.
- RunDashboard widget (timeline + summary + actions)
- ValidationViewer widget (report + issues table)

### `08_View/`
Full screen views.
- `V_DocsGenRuns.razor`
- `V_DocsGenRunDashboard.razor`
- `V_DocsGenReportViewer.razor`

### `09_Panels/`
Host-level containers.
- optional if DocsGen lives inside a broader editor shell

---

## Suggested DocsGen Plugin Tree

```text
RootServer/Shared/Plugins/DocsGen
├── 00_Core
│   ├── Models
│   │   ├── Run.cs
│   │   ├── PhaseExecution.cs
│   │   ├── ArtifactInfo.cs
│   │   ├── ValidationIssue.cs
│   │   └── ValidationResult.cs
│   ├── Policies
│   │   ├── ValidationProfile.cs
│   │   └── RegenerationPolicy.cs
│   ├── Services
│   │   ├── IDocsGenApiClient.cs
│   │   ├── DocsGenApiClient.cs
│   │   ├── IRunEventsClient.cs
│   │   └── RunEventsClient.cs
│   └── Validation
│       ├── IValidator.cs
│       ├── LinkValidator.cs
│       ├── PlaceholderValidator.cs
│       └── TerminologyValidator.cs
├── 01_Displays
│   ├── D_StatusBadge.razor
│   └── D_PhaseBadge.razor
├── 02_Fields
│   ├── F_FileUpload.razor
│   ├── F_StrictnessSelect.razor
│   └── F_ReviewModeSelect.razor
├── 03_Pointers
│   ├── P_RunBreadcrumbs.razor
│   └── P_RunPicker.razor
├── 04_Actions
│   ├── A_StartRun.razor
│   ├── A_ApproveRun.razor
│   ├── A_CancelRun.razor
│   └── A_DownloadBundle.razor
├── 06_Components
│   ├── C_RunWizard.razor
│   ├── C_PhaseTimeline.razor
│   ├── C_ArtifactBrowser.razor
│   ├── C_ReportViewer.razor
│   └── C_IssuesTable.razor
├── 07_Widgets
│   ├── W_RunDashboard.razor
│   └── W_ValidationViewer.razor
└── 08_View
    ├── V_DocsGenRuns.razor
    ├── V_DocsGenRunDashboard.razor
    └── V_DocsGenReportViewer.razor
```

---

## Documentation Placement (RootServer Docs)

To match existing patterns, store the Markdown docset under:

```text
RootServer/Docs/Extend/Module-Internal/DocsGen/
```

This mirrors the NodeEditor documentation placement and keeps internal module docs grouped consistently.

---

## Mapping Documentation to Implementation

This section links key docs to the code you typically create.

### Orchestrator + Planes
- Architecture overview: **[docsgen-13-arch.md](docsgen-13-arch.md)**
- Validation architecture: **[docsgen-21-arch-validation.md](docsgen-21-arch-validation.md)**
- Storage architecture: **[docsgen-15-arch-data.md](docsgen-15-arch-data.md)**

### UI Workflows
- UI specification: **[docsgen-27-ui-spec.md](docsgen-27-ui-spec.md)**
- UI components: **[docsgen-32-ui-components.md](docsgen-32-ui-components.md)**

### Operational Controls
- Deployment: **[docsgen-24-arch-deployment.md](docsgen-24-arch-deployment.md)**
- Task reference: **[docsgen-42-appendix-task-reference.md](docsgen-42-appendix-task-reference.md)**

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
