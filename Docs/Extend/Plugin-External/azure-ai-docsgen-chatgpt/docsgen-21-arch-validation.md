# Deterministic Validation Architecture

---

## Overview

DocsGen’s validators are deterministic services that enforce global invariants.

Validators must:
- produce structured issues
- be composable into phase gates
- avoid LLM judgment
- be fast enough to run at every gate

---

## Validator Modules (Canonical)

### ForbiddenStringScanner
Detects forbidden placeholder strings and “unfinished” tokens.

Typical forbidden patterns:
- unresolved template tokens
- task markers (unfinished notes)
- ambiguous “fill later” language

---

### MarkdownLinkValidator
Checks internal documentation links.

Rules:
- relative paths only
- targets must exist in the planned file list
- optional: anchor resolution (if anchor linking is used)
- no external links unless explicitly allowed by policy

---

### TerminologyValidator
Enforces canonical terminology as defined by Base Concepts and the terminology index.

Rules:
- defined terms must be used consistently
- forbidden terms must not appear
- acronyms should be defined on first use per file (if policy requires)

---

### SchemaValidator
Validates that:
- the plugin requirements JSON is consistent with schema rules
- entities and fields described in documentation match the JSON truth
- documentation does not introduce new entities

---

### ErrorMessageExactMatchValidator
For UI validation documentation:
- user-facing error messages must match JSON exactly
- no paraphrasing
- error codes must not be orphaned

---

### CompletenessScorer
Computes a coverage score:

- total requirements from JSON
- documented requirements found across the docset
- coverage percentage

Threshold depends on strictness mode.

---

## Gate Composition (By Phase)

### Phase 1 Gate
- placeholder scan
- link integrity for indices and root doc
- required sections present in root doc

### Phase 2 Gate
- terminology consistency
- schema completeness (entities and invariants)
- link integrity across base files

### Phase 3 Gate
- cross-reference to base schema
- no new conceptual terms introduced without definition
- integration coverage documented

### Phase 4 Gate
- UI validation strings match canonical rules
- appendix mapping completeness (components/services/models mapped)

### Phase 5 Gate
- full docset link integrity
- terminology and schema consistency across all files
- completeness score threshold
- bundle creation allowed only after pass

---

## Structured Issue Output

Validators emit issues with:

- rule ID
- severity
- file
- message
- optional line/column

This enables the UI to provide actionable navigation and filtering.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
