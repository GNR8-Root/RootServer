# UI Validation

---

## Principle: No Paraphrasing

DocsGen’s UI must never paraphrase deterministic validation output.

If a validator emits:
- rule ID
- message
- location

The UI displays those fields as-is.

This prevents “helpful rewriting” from causing confusion or hiding the real rule that failed.

---

## Validation Presentation Model

Each phase presents validation in two layers:

1. **Report Markdown**
   - summary and narrative context
2. **Structured Issues**
   - actionable rows for fix/regeneration decisions

---

## Severity Handling

### Error
- gate fails
- run stops
- UI shows failure banner and issues table

### Warning
- gate may pass depending on strictness profile
- UI should still show warnings (collapsed by default is acceptable)

---

## Common Validation UI Patterns

### Failure Banner
A persistent banner at the top of the dashboard should include:
- phase number
- short summary (counts)
- link to issues report

### Issue Table Filters
Support filtering by:
- severity
- file
- rule ID

---

## Copy Rules

The UI may add a very small amount of additional copy such as:

- “This run is awaiting approval.”
- “Phase 3 gate failed.”

But it must not rewrite validator messages.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
