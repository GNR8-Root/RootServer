# Artifacts and Manifest (Immutability and Indexing)

Purpose
- Provide durable storage and a queryable index of all inputs, generated docs, and reports.
- Enforce immutability and support targeted regeneration.

Artifact store
- Paths: `{runId}/{phase}/{filename}`
- Metadata: `hash`, `size`, `createdBy (agent|tool|user)`, `timestamp`, `type (CoreDoc|GenerationArtifact|Input|Report)`
- Backends: Blob storage (recommended), local disk for dev

Manifest schema (logical)
```json
{
  "run": {
    "id": "R-2025-12-14-001",
    "reviewMode": "interactive",
    "strictness": "strict",
    "currentPhase": 2,
    "status": "AwaitingApproval"
  },
  "artifacts": [
    {
      "path": "R-2025-12-14-001/1/azure-ai-docgen-00-base-index.md",
      "hash": "sha256:...",
      "size": 2048,
      "type": "CoreDoc"
    },
    {
      "path": "R-2025-12-14-001/1/01-phase1-validation.md",
      "hash": "sha256:...",
      "size": 3072,
      "type": "Report"
    }
  ]
}
```

Immutability rules
- CoreDoc entries are immutable after a phase passes; attempts to overwrite are rejected unless in explicit regenerate mode.
- Regeneration writes to a new run or a controlled "phase-regenerate" scope; manifests track lineage.

Queries and API
- `GET /api/runs/{runId}` → run + current gate
- `GET /api/runs/{runId}/artifacts?phase=X` → list artifacts
- `GET /api/runs/{runId}/artifact?path=...` → stream content

Authority relationships
- `01-planned-files.json` is the link authority.
- Manifests index what exists; validators determine if what exists is acceptable.

Related
- [06-orchestration-engine.md](06-orchestration-engine.md)
- [09-validation-and-completeness.md](09-validation-and-completeness.md)
- [12-phase-execution-pattern.md](12-phase-execution-pattern.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---