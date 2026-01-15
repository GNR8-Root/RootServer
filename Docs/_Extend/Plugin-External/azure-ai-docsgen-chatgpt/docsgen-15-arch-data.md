# Data & Storage Architecture

---

## Overview

DocsGen has two distinct persistence concerns:

1. **Artifact storage** – the immutable files produced by a run
2. **Manifest storage** – the structured index that explains what exists and why

Artifacts are the content. Manifests are the audit trail.

---

## Artifact Storage Requirements

An artifact store must support:

- write artifact (text or binary)
- read artifact
- list artifacts by run and phase
- compute and store a content hash
- enforce immutability rules
- create a bundle zip of core documentation files

### Logical Path Convention

```text
run_2025_12_14_0001/phase3/docsgen-13-arch.md
run_2025_12_14_0001/phase3/03-phase3-validation.md
run_2025_12_14_0001/final/docsgen-documentation-bundle.zip
```

The exact path format can vary, but it must be consistent and stable.

---

## Artifact Store Interface (Conceptual)

```csharp
public interface IArtifactStore
{
    Task<ArtifactInfo> WriteTextAsync(
        string logicalPath,
        string content,
        ArtifactType type,
        string createdBy);

    Task<ArtifactInfo> WriteBinaryAsync(
        string logicalPath,
        byte[] content,
        ArtifactType type,
        string createdBy);

    Task<string> ReadTextAsync(string logicalPath);
    Task<byte[]> ReadBinaryAsync(string logicalPath);

    Task<IReadOnlyList<ArtifactInfo>> ListAsync(string runId, int? phase = null);

    Task<ArtifactInfo> BundleZipAsync(
        string runId,
        string bundleLogicalPath,
        IReadOnlyList<string> coreFileLogicalPaths);
}
```

---

## Immutability Enforcement

Immutability must be enforced in two layers:

1. **Manifest policy**
   - the orchestrator decides whether an overwrite is allowed
2. **Artifact store guard**
   - the store rejects writes to an immutable path unless an explicit overwrite token is provided

This prevents accidental overwrites when the orchestrator has a bug.

---

## Manifest Storage

The manifest store records:

- Run
- PhaseExecution history
- Artifact index (path, hash, size, type)
- Validation issues (structured)
- Approval events

### Why Manifests Matter
Manifests enable:
- showing “what changed” between regenerations
- proving that a bundle matches the validated artifacts
- debugging gate failures without rerunning agents

---

## Structured Issues Storage

Validation issues should be stored as structured objects so the UI can:
- filter by file
- filter by rule
- group by severity
- deep-link into file preview

---

## Bundle Creation

A bundle zip is created only after final validation passes.

Bundle content:
- all 43 core documentation files
- optionally a README pointing to `docsgen.md`

Generation artifacts (validation reports, planned files) are not included in the deliverable bundle.

---

---

[← DocsGen](docsgen.md)
1. **[Base](docsgen-00-base-index.md)** – conceptual foundations, terminology, and canonical schemas
2. **[Architecture](docsgen-12-arch-index.md)** – orchestration, agents, validators, storage, and hosting boundaries
3. **[UI](docsgen-26-ui-index.md)** – user workflows, screens, components, and interaction rules
4. **[Appendix](docsgen-39-appendix-index.md)** – folder mapping, task references, and implementation checklist
5. **[Diagrams](docsgen-43-diagrams.md)** – architecture, state machines, and end-to-end sequences

---
