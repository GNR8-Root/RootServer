# Base Vision

---

## What DocsGen Is

DocsGen is a documentation system designed for environments where documentation must be:

- **Reviewable** (humans can approve at phase gates)
- **Deterministically validated** (pass/fail rules are code, not LLM judgment)
- **Reproducible** (runs can be replayed, compared, and audited)
- **Safe to iterate** (partial regeneration without content drift)

DocsGen assumes that large language models can draft content quickly, but it refuses to treat drafts as final until deterministic validators prove that constraints are satisfied.

---

## The Problem It Solves

AI-generated documentation often fails in predictable ways:

- Links drift and break as the docset grows
- Terms change between sections, causing ambiguous implementation requirements
- Early outputs get overwritten silently while later phases are being generated
- Validation is informal (“looks good”) instead of deterministic
- The UI becomes the de facto state machine, creating hidden behavior

DocsGen solves these by making the orchestrator the single source of truth, enforcing immutability, and requiring explicit user approvals when configured.

---

## Design Philosophy

### Deterministic Gates as the Authority
The only thing that can advance a phase is a passing validation gate (or a recorded override when the policy allows it). The orchestrator records why each gate passed.

### No Silent Regeneration
Once a phase has been approved (explicitly or implicitly, depending on mode), its core documentation artifacts must not be overwritten without an explicit regeneration action.

### Short, Chunked Agent Work
Agents must be invoked in bounded steps (plan, then generate file-by-file), rather than producing multi-file monoliths that are more likely to time out and drift.

### Inputs Win Over Prose
Structured inputs (plugin requirements JSON) outrank all other sources, and must be treated as the canonical truth when there is conflict.

---

## Boundaries (What DocsGen Must Not Become)

DocsGen is not:

- A free-form “documentation writer” without structure
- A monolithic agent loop that decides correctness
- A system where a UI click triggers regeneration of previously approved files
- A platform that depends on human memory for which rules were enforced

---

## Success Definition

DocsGen succeeds when it produces documentation that is:

- Strict-mode valid (no broken internal links, no placeholders, terminology consistent)
- Implementation-grade (engineers can build from it without guessing)
- Traceable (every file can be traced to a run + phase + inputs + validation results)

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
