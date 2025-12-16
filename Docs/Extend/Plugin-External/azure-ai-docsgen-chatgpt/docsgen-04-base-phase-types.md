# Base Phase Types

---

## Overview

DocsGen uses a six-step progression:

- **Phase 0**: Preflight (blocking)
- **Phase 1**: Foundation (root + indices + planned files)
- **Phase 2**: Base Layer (conceptual truth + terminology index)
- **Phase 3**: Architecture Layer (implementation truth)
- **Phase 4**: UI & Appendix (user-facing + project mapping)
- **Phase 5**: Diagrams & Cross-Validation (global consistency)

Each phase is defined by:
- required inputs
- required outputs
- a deterministic validation gate

---

## Phase 0 – Preflight (Blocking)

### Goal
Confirm that required inputs exist and are internally consistent before any documentation files are generated.

### Inputs
- plugin requirements JSON
- host project structure reference (zip or tree)
- documentation formula
- example docset zip (structure conventions)

### Outputs
- Preflight summary (if passing), or preflight questions (if failing)

### Gate Behavior
Preflight failure halts the run in all modes and all strictness levels.

---

## Phase 1 – Foundation

### Goal
Generate the structural skeleton that all later phases depend on.

### Required Outputs
- Root doc file (entry point)
- Base index
- Architecture index
- UI index
- Appendix index
- Planned file list (generation artifact)

### Gate Focus
- all required files exist
- no placeholders
- navigation links resolve

---

## Phase 2 – Base Layer

### Goal
Define the conceptual and schema-level truth of the plugin without implementation details.

### Required Outputs
- 11 base layer files (01–11)
- terminology index (generation artifact)

### Gate Focus
- terminology consistency
- schema completeness
- internal link integrity

---

## Phase 3 – Architecture Layer

### Goal
Document how the plugin is implemented and integrated.

### Required Outputs
- 13 architecture files (13–25)

### Gate Focus
- references to base layer schema are consistent
- no new entities introduced
- integration and dependency rules are explicit

---

## Phase 4 – UI & Appendix

### Goal
Document user-facing workflows and map documentation to project structure.

### Required Outputs
- 12 UI files (27–38)
- appendix files (40–42)

### Gate Focus
- UI validation messages match canonical rules
- appendix correctly maps components/services/models to docs

---

## Phase 5 – Diagrams & Cross-Validation

### Goal
Produce diagrams and run global cross-validation across the entire docset.

### Required Outputs
- diagrams file (43) in strict mode
- final validation report
- bundle zip containing all core files

### Gate Focus
- full docset link integrity
- cross-layer schema/terminology consistency
- completeness threshold (coverage scoring)

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
