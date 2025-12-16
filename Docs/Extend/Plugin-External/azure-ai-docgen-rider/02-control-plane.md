 # Control Plane (Orchestrator API)
 
##  **Owns**
 - Phase state machine (0..5), stop-on-fail, user gates
 - Calls Foundry agents, manages runs/threads
 - Artifact registry and immutability/versioning
 - Deterministic validators at each gate
 - Run events for UI (SignalR/SSE)
 
---

##  **DTOs**
 ```csharp
 public record RunId(string Value);
 public enum ReviewMode { Interactive, Batch }
 public enum Strictness { Strict, Lenient }
 public enum Phase { Preflight=0, Foundation=1, Base=2, Architecture=3, UiAppendix=4, Diagrams=5 }
 public enum RunStatus { Running, AwaitingApproval, Failed, Complete }
 
 public record Run(
     RunId Id,
     ReviewMode ReviewMode,
     Strictness Strictness,
     Phase Current,
     RunStatus Status,
     string ArtifactsManifestId);
 
 public record PhaseExecution(
     RunId RunId,
     Phase Phase,
     string AgentId,
     IReadOnlyList<string> Inputs,
     IReadOnlyList<string> Outputs,
     ValidationResult Validation,
     string? UserApproval);
 
 public record ValidationResult(bool Passed, IReadOnlyList<ValidationIssue> Issues);
 public record ValidationIssue(string File, string Rule, string Message, int? Line);
 ```

--- 

##  **REST endpoints (UI-facing)**
 - POST `/api/runs`
 - GET `/api/runs/{runId}`
 - POST `/api/runs/{runId}/approve`
 - POST `/api/runs/{runId}/cancel`
 - GET `/api/runs/{runId}/download`
 
---

##  **Gate algorithm**
 ```csharp
 // Pseudocode
 var result = await AgentRunner.RunPhaseAsync(run, phase);
 var issues = await Validators.RunGateAsync(phase, result.Outputs);
 await Artifacts.RegisterAsync(run.Id, phase, result.Outputs, issues);
 if (issues.Any(i => i.IsBlocking(strictness)))
 {
     await Runs.FailAsync(run.Id, phase, issues);
     return; // stop
 }
 if (reviewMode == ReviewMode.Interactive)
 {
     await Runs.AwaitApprovalAsync(run.Id, phase);
 }
 await Runs.AdvanceAsync(run.Id, phase + 1);
 ```

---

 **Related**
 - [06-orchestration-engine.md](06-orchestration-engine.md)
 - [11-artifacts-and-manifest.md](11-artifacts-and-manifest.md)

 ---


**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---
