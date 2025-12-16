 # Appendix A5 — Cost and Throughput Tuning
 
 Purpose
 - Operate Azure AI DocGen efficiently: control LLM minutes, API costs, and wall-clock time.
 
 Knobs that matter
 - Chunk size: generate one file per run (default). For tiny files, batch 2–3 max.
 - Concurrency: parallelize across files within a phase cautiously (avoid exceeding Tool API rate limits).
 - Caching: keep stable prompts; persist planned files; avoid regenerating green files.
 - Strictness: lenient lowers validator work, but keep always-on rules.
 
 Recommended defaults
 - interactive + strict for final docs; batch + lenient for exploration.
 - Timeouts: 2–3 minutes per run; abort and retry rather than long polls.
 - Backoff: exponential on Tool API 429/503.
 
 Example orchestrator limits (C#)
 ```csharp
 var options = new ExecutionOptions
 {
   MaxParallelFiles = 3,
   PerRunTimeout = TimeSpan.FromMinutes(2),
   ToolApiRateLimitPerSecond = 5,
 };
 ```
 
 Validator costs
 - Link/placeholder scans: O(N) in file size — cheap, run often.
 - Terminology: cache index; only re-check changed files.
 - Completeness: compute once per phase and cache.
 
 Storage costs
 - Compress bundle only at Phase 5; store intermediate artifacts uncompressed for speed if on local dev.
 - Use lifecycle policies on blob container to tier older runs.
 
 Foundry considerations
 - Prefer smaller, deterministic prompts; reuse agent identity to reduce drift.
 - Avoid tool-call loops; request file content once, then exit.
 
 Observability
 - Emit per-file timings: plan, generate, stage, validate.
 - Track retries and reasons (timeout, 429, validator fail).
 
 Related
 - [12-phase-execution-pattern.md](12-phase-execution-pattern.md)
 - [07-foundry-agents.md](07-foundry-agents.md)
 - [09-validation-and-completeness.md](09-validation-and-completeness.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---