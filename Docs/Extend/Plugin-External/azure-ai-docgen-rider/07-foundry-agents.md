# Foundry Agents (Design and Operation)

---
## Agent patterns
- Six agents (phase-aligned): `preflight_validator`, `foundation_generator`, `base_layer_generator`, `architecture_layer_generator`, `ui_appendix_generator`, `diagram_final_validator`
- Dual-agent (robust): `phase_generator` (content) + `phase_reporter` (issues/validation summaries)

---
## Operational constraints
- Tool-calling runs expire fast (e.g., ~10 minutes). Prefer short, file-scoped runs.
- Persist agent identity; keep prompts stable to limit drift across runs.

---
## .NET usage sketch
```csharp
using Azure.AI.Projects;
using Azure.Identity;

var project = new AIProjectClient(new Uri(projectEndpoint), new DefaultAzureCredential());
var agents = project.GetPersistentAgentsClient();

// 1) Create a thread per phase
var thread = await agents.CreateThreadAsync(new CreateThreadOptions());

// 2) Seed instruction
await agents.CreateMessageAsync(thread.Value.Id, new CreateMessageOptions
{
    Role = "user",
    Content = "Generate {slug}-12-arch-index.md following the planned files list and link rules."
});

// 3) Run with OpenAPI tool access
var run = await agents.CreateRunAsync(thread.Value.Id, new CreateRunOptions
{
    AgentId = generatorAgentId,
    Tools = { new OpenApiTool { SpecUrl = toolApiOpenApiUrl } }
});

// 4) Poll for completion, then fetch messages
await agents.WaitForRunAsync(thread.Value.Id, run.Value.Id, TimeSpan.FromMinutes(2));
var messages = await agents.ListMessagesAsync(thread.Value.Id);
```

---
## Prompting guidance
- Name the exact file to generate and acceptance criteria (no placeholders, links resolve).
- Provide the authoritative planned-files list to avoid broken references.
- Avoid requesting multiple large files in a single run.

---
## Integration with orchestrator
- The orchestrator selects the agent per phase, provides inputs (requirements, planned files), and validates outputs.
- On failure, the orchestrator can request targeted regeneration for specific files.

---
**Related**
- [03-intelligence-plane.md](03-intelligence-plane.md)
- [06-orchestration-engine.md](06-orchestration-engine.md)
- [12-phase-execution-pattern.md](12-phase-execution-pattern.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---