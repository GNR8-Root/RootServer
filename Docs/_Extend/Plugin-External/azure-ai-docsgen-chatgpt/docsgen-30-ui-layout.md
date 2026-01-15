# UI Layout

---

## Layout Goals

DocsGen’s UI layout must optimize for:

- scanability (phase state is visible immediately)
- actionable failure handling (issues visible without hunting)
- predictable navigation between runs and artifacts

---

## Recommended Dashboard Layout

```text
+--------------------------------------------------------------+
| Header: DocsGen / Run ID / Status / Mode / Download Button   |
+-----------------------------+--------------------------------+
| Phase Timeline              | Main Panel                     |
| (vertical list)             | - Current phase summary        |
| - Phase 0                   | - Report preview link          |
| - Phase 1                   | - Approval controls (if any)   |
| - Phase 2                   | - Failure banner (if failed)   |
| ...                         |                                |
+-----------------------------+--------------------------------+
| Artifact Browser (optional docked region)                    |
+--------------------------------------------------------------+
```

---

## Validation Viewer Layout

```text
+--------------------------------------------------------------+
| Header: Phase / Status / Back to Dashboard                   |
+-----------------------------+--------------------------------+
| Markdown Report (left)      | Structured Issues Table (right)|
| - narrative summary         | - file, rule, severity, msg    |
| - sections                  | - filter + search              |
+-----------------------------+--------------------------------+
```

This dual-pane approach supports both “read the summary” and “fix the issues.”

---

## Artifact Browser Layout

Artifact browsing benefits from grouping:

- by phase
- by artifact type
- by last modified time

Provide a preview panel for Markdown and a download button per artifact.

---

## Responsive Behavior

On narrow viewports:
- timeline collapses to a horizontal stepper
- validation viewer becomes stacked (report then issues table)
- artifact browser becomes a separate route or drawer

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
