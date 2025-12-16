# Appendix – UI Technical Notes

This appendix captures implementation-focused UI notes that are useful during build-out.

---

## State Management (Guidance)

DocsGen UI state should be derived from orchestrator DTOs.

Recommended approach:
- keep a `RunSnapshot` DTO model
- keep a list of `RunEvent` entries for the current view
- recompute timeline rows from snapshot + latest event data

Avoid:
- duplicating the orchestrator’s state machine in the UI

---

## Markdown Rendering

Two acceptable strategies:

1. Server-side rendering of Markdown into HTML
2. Client-side rendering using a small JS helper

Rules:
- never rewrite report content
- display content exactly as stored in artifacts

---

## Large File Handling

Artifact previews should:
- stream content where possible
- avoid loading very large files into the DOM all at once
- provide “download instead” for oversized files

---

## Component Testability

Components should be testable by:
- injecting a fake API client
- feeding static snapshots and events
- verifying correct rendering of statuses and issues

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
