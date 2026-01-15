# DocsGen

---

## Purpose

DocsGen is a **phase-gated documentation generation plugin** that produces complete, implementation-ready plugin documentation from structured inputs.

It is designed for environments where documentation must be **auditable**, **reproducible**, and **safe to approve**, even when large language models are used for drafting. DocsGen enforces this by separating concerns into clear planes (UI, orchestration, intelligence, deterministic validation) and by treating every generated file as an immutable artifact that must pass validation gates before the run can continue.

DocsGen is intended to document other plugins (and itself) using a fixed 43-file docset structure and a six-phase execution model (Preflight + Phases 1–5).

---

## Glossary

**Run**  
One end-to-end execution of the documentation pipeline for a single plugin, producing immutable artifacts.

**Phase**  
A bounded generation step with explicit inputs, outputs, and a deterministic validation gate.

**Gate**  
A deterministic checkpoint that must pass (or be explicitly approved) before moving to the next phase.

**Artifact**  
Any stored output created during a run (core documentation files, validation reports, planned file lists, bundles).

**Core Documentation File**  
One of the 43 numbered Markdown files that constitute the deliverable documentation set.

**Generation Artifact**  
A supporting file produced during generation (planned file list, terminology index, validation reports). These are not part of the deliverable bundle.

**Strictness**  
A validation policy mode: strict requires full enforcement; lenient relaxes specific non-core rules while keeping core guarantees.

**Review Mode**  
A run mode: interactive stops after each phase for approval; batch runs all phases without stopping.

**Orchestrator**  
The control-plane service that owns the run state machine, artifact registry, and validation decisions.

**Agent**  
A Foundry-hosted LLM worker that generates Markdown content under orchestrator control.

---

## Tech Split

| Layer / Plane | Owns | Must Not Own |
|---|---|---|
| Experience Plane (Blazor UI) | Uploads, run configuration, progress display, approvals, downloads | LLM calls, file generation, validation logic |
| Control Plane (Orchestrator API) | Phase state machine, gates, artifact registry, validator execution, streaming events | UI rendering, LLM reasoning, non-deterministic judgment |
| Intelligence Plane (Foundry Agents) | Drafting Markdown content, optional narrative issue summaries | Phase control, artifact overwrite decisions, truth authority |
| Deterministic Plane (Validators + Storage) | Link checks, placeholder scans, schema enforcement, scoring, bundling, artifact persistence | LLM judgment, implicit regeneration |

---

## Guiding Principle

LLMs generate content. Deterministic systems decide truth.

---

## Scope Definition

### In Scope
- Structured, phase-based documentation generation
- Deterministic validation gates between phases
- Artifact immutability and run auditability
- Interactive approvals and partial regeneration
- Tool/API surface for deterministic operations (read/write artifacts, validate, bundle)

### Out of Scope
- Publishing documentation to external portals
- Collaborative multi-user editing and merge conflict resolution
- Runtime business logic for unrelated plugins
- Replacing deterministic validators with LLM judgment

---

## Non-Goals

DocsGen is intentionally designed to avoid “silent correctness.”

- DocsGen **does not** auto-fix validation failures by regenerating prior approved content.
- DocsGen **does not** treat an LLM response as valid documentation unless deterministic gates pass.
- DocsGen **does not** execute or validate host application runtime behavior (it validates documentation only).
- DocsGen **does not** require the UI to understand file semantics; it only renders orchestrator state.

---

## Success Criteria

DocsGen is considered successful when:

- A strict run produces **43 core documentation files** with **0 broken internal links**.
- No placeholder strings remain in any core file.
- Terminology is consistent across Base, Architecture, UI, Appendix, and Diagrams.
- A failed phase generates an issues report and stops without overwriting approved artifacts.
- Partial regeneration can target only the affected files and re-run gates deterministically.

---

## DocsGen – Documentation Index

This document is the canonical entry point for the DocsGen documentation set.

1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas  
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries  
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules  
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist  
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences  
