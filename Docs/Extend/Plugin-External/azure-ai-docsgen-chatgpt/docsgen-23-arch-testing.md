# Testing Strategy

---

## Overview

DocsGen must be trustworthy. Testing focuses on determinism, not model quality.

The system should be testable without invoking a real LLM by using:
- stub agents
- golden docsets
- deterministic validator tests

---

## Unit Tests

### Validators
- placeholder scanning catches forbidden strings
- link validation resolves all planned file references
- terminology enforcement flags forbidden and undefined terms
- schema checks detect drift between JSON and docs
- completeness scoring is stable

### Orchestrator State Machine
- phase progression rules
- stop-on-fail behavior
- approval required behavior in interactive mode
- idempotent approval handling
- cancellation behavior

---

## Integration Tests

### Artifact Store
- writes and reads preserve content and hash
- immutability guard prevents overwrite
- list by run/phase returns expected results

### API Surface
- run creation with uploads
- event stream returns ordered events
- download bundle returns correct files

---

## Golden Docset Regression

Maintain a golden docset for a known plugin:

- run the validators against it as a regression test
- ensure that validator rule changes are intentional
- diff reports between versions

Golden docsets are a key defense against validator drift.

---

## Agent Testing (Bounded)

Agents are non-deterministic; test them via:
- prompt template tests (static)
- schema-based output validation (deterministic)
- small “smoke runs” in CI (optional)

The orchestrator must remain correct even if agents behave inconsistently.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
