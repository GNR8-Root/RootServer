# Visual System Architecture

---

## Overview

DocsGen’s UI is centered around making the run state machine legible.

The UI must make it obvious:

- what phase we are in
- what outputs exist
- why we stopped (pass/fail/awaiting approval)
- what needs human action next

This file describes how those visuals map to deterministic orchestrator state.

---

## Phase Timeline

A timeline is the primary run visualization.

Each phase displays:
- status: not started, running, passed, failed, awaiting approval
- latest report link (validation or issues)
- artifact count and size summary (optional)

Key rule:
- the timeline is derived from orchestrator state and events
- the UI never infers phase success

---

## Validation Report Viewer

The validation viewer renders two complementary views:

1. **Markdown report**
   - pass summary or issues summary
   - human-readable context

2. **Structured issues table**
   - file
   - rule ID
   - severity
   - message
   - jump-to-preview action

This pairing is crucial because Markdown alone is not filterable, and structured issues alone lack narrative.

---

## Artifact Browser

Artifact browsing should support:

- list by phase
- filter by type (core docs vs reports vs inputs)
- preview Markdown artifacts
- download individual artifacts
- download “artifacts so far” zip (optional)

Artifacts shown must match the manifest index.

---

## Approval Gate Visual

If review mode is interactive:

- show a clear “Awaiting Approval” state
- show what passed and what was validated
- show an explicit “Approve & Continue” action

Approval must be recorded through the orchestrator API and reflected in the run history.

---

## Failure Visual

When a phase fails:

- show “Failed” state in timeline
- link to issues report
- show top issues in a summary panel
- offer actions:
  - download artifacts so far
  - regenerate phase (explicit action)
  - cancel run

The UI must not automatically retry or regenerate.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
