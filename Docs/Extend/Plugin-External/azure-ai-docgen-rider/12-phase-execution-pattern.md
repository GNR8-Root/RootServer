# Phase Execution Pattern (Chunked Generation)

Goals
- Avoid long-running tool-call sessions and timeouts
- Enable targeted regeneration and clear gate boundaries

Pattern
1) Plan: ask the agent for the phase plan (files + outlines + dependencies)
2) Generate: loop file-by-file, one short agent run per file
3) Stage: persist outputs to staging paths under the current run/phase
4) Validate: execute deterministic validators and produce `XX-phaseX-validation.md`
5) Approve/Advance: depending on review mode, await user approval, then materialize immutable artifacts

Pseudocode
```csharp
foreach (var file in phasePlan.Files)
{
    var content = await agent.GenerateFileAsync(file);
    await artifacts.WriteStagedAsync(runId, phase, file, content);
    await validators.CheckBasicAsync(runId, phase, file); // placeholders, basic markdown
}

var report = await validators.RunGateAsync(runId, phase); // links, terminology, schema, etc.
await artifacts.WriteReportAsync(runId, phase, report);

if (report.Passed)
{
    if (reviewMode == ReviewMode.Interactive)
        await AwaitUserApprovalAsync(runId);

    await artifacts.MaterializePhaseAsync(runId, phase); // flip staged -> immutable
    await orchestration.AdvanceAsync(runId, phase + 1);
}
else
{
    await orchestration.FailAsync(runId, phase, report);
}
```

Partial regeneration
- When a validator flags issues in specific files, the orchestrator requests regeneration only for those files.
- The planned-files authority remains unchanged unless an explicit plan update is approved.

Related
- [06-orchestration-engine.md](06-orchestration-engine.md)
- [07-foundry-agents.md](07-foundry-agents.md)
- [09-validation-and-completeness.md](09-validation-and-completeness.md)
- [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---