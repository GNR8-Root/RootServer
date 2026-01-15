# Base Models

---

## Overview

DocsGen is easiest to reason about when its core model is explicit.
This file defines the canonical domain objects and how they relate.

The model is designed to support:
- deterministic validation
- artifact immutability
- partial regeneration
- interactive approvals
- auditability across runs

---

## Run

A **Run** is the top-level container for everything produced during generation.

### Responsibilities
- stores run configuration (review mode, strictness)
- tracks current phase and lifecycle status
- anchors the artifact namespace

### Canonical Fields

```json
{
  "runId": "run_2025_12_14_0001",
  "pluginSlug": "docsgen",
  "reviewMode": "interactive",
  "validationStrictness": "strict",
  "currentPhase": 2,
  "status": "running",
  "startedUtc": "2025-12-14T00:00:00Z",
  "completedUtc": null,
  "artifactsManifestId": "manifest_run_2025_12_14_0001_v3"
}
```

---

## PhaseExecution

A **PhaseExecution** is a recorded attempt of a single phase.
A phase may have multiple executions if it was explicitly regenerated.

### Responsibilities
- records the agent used
- records inputs and outputs (artifact references)
- records validation results and approval decisions

### Canonical Fields

```json
{
  "runId": "run_2025_12_14_0001",
  "phaseNumber": 2,
  "executionId": "phase2_exec_001",
  "agentId": "base_layer_generator",
  "inputs": [
    "input/plugin-requirements.json",
    "phase1/docsgen.md",
    "phase1/docsgen-00-base-index.md"
  ],
  "outputs": [
    "phase2/docsgen-02-base-concepts.md",
    "phase2/docsgen-11-base-schema.md"
  ],
  "validationResult": {
    "status": "pass",
    "issues": [],
    "reportArtifact": "phase2/02-phase2-validation.md"
  },
  "approval": {
    "required": true,
    "status": "pending",
    "approvedBy": null,
    "approvedUtc": null
  }
}
```

---

## Artifact

An **Artifact** is a stored file plus metadata.

### Responsibilities
- enable immutability and audit
- support re-validation without regeneration
- allow diffing across runs

### Canonical Fields

```json
{
  "logicalPath": "run_2025_12_14_0001/phase2/docsgen-02-base-concepts.md",
  "contentHash": "sha256:9b3a...e12f",
  "sizeBytes": 3242,
  "artifactType": "CoreDoc",
  "createdBy": "agent",
  "createdUtc": "2025-12-14T00:12:43Z"
}
```

### Artifact Types (Canonical)
- **Input** – uploaded inputs
- **CoreDoc** – one of the 43 deliverable files
- **Report** – validation report or issues report
- **Bundle** – final zip
- **Plan** – planned file list
- **Index** – terminology index and similar registries

---

## ValidationResult and Issue

A **ValidationResult** is the deterministic output of a gate.

```json
{
  "status": "fail",
  "summary": "2 broken links, 1 forbidden placeholder token",
  "issues": [
    {
      "ruleId": "links.internal.resolves",
      "severity": "error",
      "file": "docsgen-26-ui-index.md",
      "message": "Link target does not exist: docsgen-38-ui-examples.md",
      "location": { "line": 17, "column": 5 }
    },
    {
      "ruleId": "placeholders.forbidden",
      "severity": "error",
      "file": "docsgen-03-base-models.md",
      "message": "Forbidden placeholder token detected.",
      "location": { "line": 4, "column": 1 }
    }
  ]
}
```

### Invariants
- A gate “pass” means zero error-severity issues.
- A gate “fail” means at least one error-severity issue.
- Warnings may be allowed depending on strictness policy.

---

## Policy Objects

Policies are deterministic configuration objects owned by the orchestrator.

### ValidationProfile
Defines which validators apply and how strict they are.

### RegenerationPolicy
Defines whether overwrites are allowed and under what explicit run modes.

---

## DocsetProfile

A **DocsetProfile** determines which files are required and which can be optional.

Examples:
- Full strict profile (all 43 files required)
- Lenient profile (diagrams optional; coverage threshold reduced)

Docset profiles prevent “special cases” from creeping into prompts by making requirements explicit.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
