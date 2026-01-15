# Sample Run Manifest and Validator Outputs

---
## Purpose
- Provide a realistic example of a `Run` manifest and validator outputs for Azure AI DocGen. Use this as a reference for storage schema and validation review.

---

## **Manifest (JSON)**
```json
{
  "run": {
    "runId": "2025-01-15T12-33-21Z-9f3a",
    "reviewMode": "interactive",
    "strictness": "strict",
    "profile": "Full43Strict",
    "currentPhase": 2,
    "status": "AwaitingApproval",
    "startedAt": "2025-01-15T12:33:21Z",
    "updatedAt": "2025-01-15T12:38:59Z",
    "manifestId": "manif-6c2b2d"
  },
  "inputs": {
    "requirementsPath": "inputs/plugin-requirements.json",
    "hostBundle": "inputs/host/rootServer.zip",
    "referenceDocset": "inputs/reference/MODULE-node-editor.zip"
  },
  "phases": [
    {
      "phase": 0,
      "name": "Preflight",
      "agentId": "preflight_validator",
      "startedAt": "2025-01-15T12:33:22Z",
      "completedAt": "2025-01-15T12:33:25Z",
      "validation": { "result": "pass", "issues": [] },
      "outputs": [
        { "path": "artifacts/00-preflight-summary.md", "classification": "GenerationArtifact", "hash": "b88f...", "size": 4121 }
      ]
    },
    {
      "phase": 1,
      "name": "Foundation",
      "agentId": "foundation_generator",
      "startedAt": "2025-01-15T12:33:26Z",
      "completedAt": "2025-01-15T12:36:12Z",
      "validation": { "result": "pass", "issues": [] },
      "outputs": [
        { "path": "core/{slug}.md", "classification": "CoreDoc", "hash": "a23d...", "size": 2048 },
        { "path": "core/{slug}-00-base-index.md", "classification": "CoreDoc", "hash": "9cfe...", "size": 3180 },
        { "path": "artifacts/01-planned-files.json", "classification": "GenerationArtifact", "hash": "2e11...", "size": 9820 },
        { "path": "artifacts/01-phase1-validation.md", "classification": "GenerationArtifact", "hash": "7b0c...", "size": 2260 }
      ]
    },
    {
      "phase": 2,
      "name": "Base Layer",
      "agentId": "base_layer_generator",
      "startedAt": "2025-01-15T12:36:13Z",
      "completedAt": "2025-01-15T12:38:58Z",
      "validation": { "result": "pending", "issues": [] },
      "outputs": [
        { "path": "core/{slug}-01.md", "classification": "CoreDoc", "hash": "c1ba...", "size": 6012 },
        { "path": "core/{slug}-02.md", "classification": "CoreDoc", "hash": "14aa...", "size": 5444 },
        { "path": "artifacts/02-terminology-index.json", "classification": "GenerationArtifact", "hash": "bb51...", "size": 3360 },
        { "path": "artifacts/02-phase2-validation.md", "classification": "GenerationArtifact", "hash": "f88d...", "size": 3920 }
      ]
    }
  ],
  "artifactIndex": [
    { "path": "core/{slug}.md", "phase": 1, "classification": "CoreDoc", "createdBy": "foundation_generator" },
    { "path": "core/{slug}-00-base-index.md", "phase": 1, "classification": "CoreDoc", "createdBy": "foundation_generator" },
    { "path": "artifacts/01-planned-files.json", "phase": 1, "classification": "GenerationArtifact", "createdBy": "orchestrator" },
    { "path": "artifacts/01-phase1-validation.md", "phase": 1, "classification": "GenerationArtifact", "createdBy": "orchestrator" },
    { "path": "core/{slug}-01.md", "phase": 2, "classification": "CoreDoc", "createdBy": "base_layer_generator" },
    { "path": "core/{slug}-02.md", "phase": 2, "classification": "CoreDoc", "createdBy": "base_layer_generator" },
    { "path": "artifacts/02-terminology-index.json", "phase": 2, "classification": "GenerationArtifact", "createdBy": "orchestrator" },
    { "path": "artifacts/02-phase2-validation.md", "phase": 2, "classification": "GenerationArtifact", "createdBy": "orchestrator" }
  ],
  "issues": []
}
```
---

## Sample validator outputs

---
## Forbidden string scanner (no placeholders)
```json
{
  "validator": "ForbiddenStringScanner",
  "phase": 2,
  "result": "pass",
  "issues": []
}
```
---
## Markdown link validator
```json
{
  "validator": "MarkdownLinkValidator",
  "phase": 2,
  "result": "fail",
  "issues": [
    {
      "file": "core/{slug}-02.md",
      "line": 88,
      "rule": "relative-link-target-exists",
      "message": "Link target {slug}-19-foo.md not in planned-files list",
      "severity": "error"
    }
  ]
}
```
---
## Terminology validator
```json
{
  "validator": "TerminologyValidator",
  "phase": 2,
  "result": "pass",
  "issues": []
}
```
---
## Schema consistency validator
```json
{
  "validator": "SchemaValidator",
  "phase": 2,
  "result": "pass",
  "issues": []
}
```
---
## Completeness scorer
```json
{
  "validator": "CompletenessScorer",
  "phase": 2,
  "result": "pass",
  "score": 0.92,
  "threshold": 0.90,
  "issues": []
}
```
---

## How to read these
- `result: fail` is blocking in strict mode; in lenient mode certain validators may downgrade to warnings, but link integrity is always enforced.
- Line numbers are 1‑based, measured in the persisted artifact content at validation time.
- The orchestrator aggregates validator outputs into `XX-phaseY-validation.md` and blocks/pauses per gate protocol.

---
**Related**
- [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)
- [09-validation-and-completeness.md](09-validation-and-completeness.md)
- [12-phase-execution-pattern.md](12-phase-execution-pattern.md)
- [30-diagrams.md](30-diagrams.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---