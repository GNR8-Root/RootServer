 # Intelligence Plane (Azure AI Foundry Agents)

--- 

##  Owns
 - Generate Markdown contents for each phase/file
 - Optionally produce human-readable validation/issue reports
 - Use OpenAPI tools to access deterministic services
 
---

##  Operational constraints
 - Tool-calling runs can expire quickly; design smaller chunks per file
 - Persist agent identity; keep prompts stable to reduce drift
 
---

###  .NET sample: Persistent Agents Client
 ```csharp
 using Azure.AI.Projects;
 
 var project = new AIProjectClient(new Uri(projectEndpoint), new DefaultAzureCredential());
 var agents = project.GetPersistentAgentsClient();
 
 // Create thread per phase
 var thread = await agents.CreateThreadAsync(new CreateThreadOptions());
 
 // Add a user message with explicit instruction
 await agents.CreateMessageAsync(thread.Value.Id, new CreateMessageOptions
 {
     Role = "user",
     Content = $"Generate file {slug}-00-base-index.md. Follow source-of-truth precedence."
 });
 
 // Start a run with tool access
 var run = await agents.CreateRunAsync(thread.Value.Id, new CreateRunOptions
 {
     AgentId = agentId, // e.g., foundation_generator
     Tools = { new OpenApiTool { SpecUrl = toolApiOpenApiUrl } }
 });
 
 // Poll to completion
 var completed = await agents.WaitForRunAsync(thread.Value.Id, run.Value.Id, TimeSpan.FromMinutes(2));
 var messages = await agents.ListMessagesAsync(thread.Value.Id);
 ```

--- 

##  Prompting tips
 - Specify exact filename and acceptance criteria per call
 - Provide planned-files authority for link targets
 - Avoid requesting multiple large files in a single run

--- 

 **Related**
 - [07-foundry-agents.md](07-foundry-agents.md)
 - [12-phase-execution-pattern.md](12-phase-execution-pattern.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---