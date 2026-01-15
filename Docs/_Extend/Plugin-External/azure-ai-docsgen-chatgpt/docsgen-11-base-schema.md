# Canonical Schema

---

## Purpose

This file defines the canonical JSON structures used by DocsGen to store run state and validation outputs.

These schemas are designed to be:
- deterministic
- easy to validate
- stable across versions

---

## Run Schema

```json
{
  "runId": "string",
  "pluginSlug": "string",
  "reviewMode": "interactive | batch",
  "validationStrictness": "strict | lenient",
  "currentPhase": "number",
  "status": "running | awaiting_approval | failed | complete | canceled",
  "startedUtc": "string",
  "completedUtc": "string | null",
  "artifactsManifestId": "string"
}
```

---

## PhaseExecution Schema

```json
{
  "executionId": "string",
  "runId": "string",
  "phaseNumber": "number",
  "agentId": "string",
  "inputs": ["string"],
  "outputs": ["string"],
  "validationResult": "ValidationResult",
  "approval": "Approval"
}
```

---

## Artifact Schema

```json
{
  "logicalPath": "string",
  "contentHash": "string",
  "sizeBytes": "number",
  "artifactType": "Input | CoreDoc | Report | Plan | Index | Bundle",
  "createdBy": "agent | tool | user",
  "createdUtc": "string"
}
```

---

## ValidationResult Schema

```json
{
  "status": "pass | fail",
  "summary": "string",
  "issues": ["ValidationIssue"]
}
```

---

## ValidationIssue Schema

```json
{
  "ruleId": "string",
  "severity": "error | warning",
  "file": "string",
  "message": "string",
  "location": { "line": "number", "column": "number" }
}
```

---

## Approval Schema

```json
{
  "required": "boolean",
  "status": "pending | approved | rejected",
  "approvedBy": "string | null",
  "approvedUtc": "string | null"
}
```

---

## Planned Files Schema (Generation Artifact)

```json
{
  "version": "1.0",
  "slug": "docsgen",
  "core_files": ["string"],
  "optional_files": ["string"],
  "excluded_files": ["string"]
}
```

---

## Terminology Index Schema (Generation Artifact)

```json
{
  "version": "1.0",
  "slug": "docsgen",
  "terms": [
    {
      "term": "Run",
      "definition": "One end-to-end generation lifecycle.",
      "definedIn": "docsgen-02-base-concepts.md"
    }
  ],
  "forbiddenTerms": [
    {
      "term": "pipeline step",
      "useInstead": "phase",
      "reason": "Phase is the canonical term across the docset."
    }
  ]
}
```

---

## Invariants

- Internal links must point to core documentation files.
- Terminology terms are defined once and used consistently.
- Core documentation artifacts cannot be overwritten after an approved gate.
- Final bundling is permitted only after final validation passes.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
