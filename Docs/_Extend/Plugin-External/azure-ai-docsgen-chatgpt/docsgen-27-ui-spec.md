# UI Specification

---

## Overview

DocsGen’s UI is a workflow tool, not a document editor.

It exists to:
- collect inputs
- display run progress
- display deterministic validation results
- record approvals
- provide downloads

The UI does not decide truth; it renders orchestrator truth.

---

## Primary Screens

### 1) New Run Wizard
**Goal**: start a run with correct inputs.

Inputs:
- plugin requirements JSON
- host project zip or structure reference
- example docset zip (structure conventions)
- documentation formula
- review mode (interactive/batch)
- validation strictness (strict/lenient)

Outputs:
- creates a run
- shows a run dashboard immediately

---

### 2) Run Dashboard
**Goal**: monitor a run and take gate actions.

Must show:
- phase timeline
- current phase status
- latest validation report link
- approval control (interactive mode)
- cancel action
- download artifacts (partial or final)

---

### 3) Validation Report Viewer
**Goal**: make failures actionable.

Must show:
- Markdown report (pass report or issues report)
- structured issues table
  - file
  - rule ID
  - severity
  - message
  - jump to preview

---

### 4) Artifact Browser
**Goal**: let users inspect generated outputs.

Must support:
- browse by phase
- filter by artifact type
- preview Markdown
- download single artifact

---

## Optional Screens

- Diff viewer (compare artifact versions)
- Settings page (default strictness, storage selection)
- Run history (list runs by plugin slug)

---

## UX Principles

- “Why did we stop?” must be visible without scrolling.
- “What should I do next?” must be explicit.
- The UI must never paraphrase deterministic error messages.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
