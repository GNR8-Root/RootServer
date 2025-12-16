# JSON Contracts & Source of Truth

---

## Overview

DocsGen is designed to treat structured JSON as canonical truth, and prose as explanatory.

This file describes the JSON inputs and outputs that form the deterministic backbone of the system.

---

## Primary Input: Plugin Requirements JSON

The plugin requirements document is the highest authority for generation.

It typically contains:
- plugin identity (name, slug, summary)
- entities (schemas, invariants, validation rules)
- user flows (primary flows and roles)
- host integration constraints
- error codes and UI messages
- performance and audit requirements

DocsGen assumes that if the JSON says something, it must be reflected in the documentation without paraphrasing.

---

## Supporting Input: Host Project Structure Reference

DocsGen may ingest:
- a zip of the host project
- a file tree listing
- a curated “structure reference” document

This input is used to:
- map docs to real folders in appendix outputs
- respect host runtime patterns (server-side Blazor, DI conventions)
- avoid documenting forbidden dependencies

---

## Supporting Input: Documentation Formula

DocsGen accepts a documentation formula that defines:
- global rules and constraints
- file templates and required sections
- validation profiles
- regeneration policy

DocsGen treats this as a system configuration input, not a plugin-specific truth source.

---

## Generation Output: Planned File List

The planned file list defines which files exist in the docset and becomes the link authority.

- created before Phase 1 output is generated
- used by link validators in every gate

---

## Generation Output: Terminology Index

DocsGen can extract a terminology index after Base Concepts to enforce consistency across later phases.

This is useful for:
- catching drift (“pipeline step” vs “phase”)
- preventing multiple definitions for the same term

---

## Validation Outputs

Validation outputs exist in two forms:

1. **Human-readable Markdown**
   - pass reports
   - issues reports

2. **Structured issue lists**
   - stored in manifests
   - used by the UI for filtering and deep links

---

## Source-of-Truth Precedence (Enforced)

When inputs conflict:

1. plugin requirements JSON wins
2. host architecture constraints win over example docsets
3. example docsets win only for structure conventions
4. prose instructions are context only

This is a deterministic policy enforced by the orchestrator and validators.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
