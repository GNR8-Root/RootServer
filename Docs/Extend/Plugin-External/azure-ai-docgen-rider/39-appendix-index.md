# Appendix Index

Purpose
- Central hub for additional materials that support design, implementation, and operations of Azure AI DocGen.
- Appendices are optional deliverables; they must comply with validation rules (no placeholders, link integrity, terminology consistency).

What to expect here
- Profiles, configs, prompts, troubleshooting, security/identity, cost/throughput, and CI/CD automation.
- Each appendix is a focused, self‑contained page. Keep examples runnable and refer back to the core chapters when necessary.

Appendices
- [A1-sample-configs.md](A1-sample-configs.md) — Example generation-config variants, plugin-requirements samples, environment overrides.
- [A2-sample-prompts.md](A2-sample-prompts.md) — Prompt scaffolds for agents (per phase), acceptance criteria phrasing, tool-call examples.
- [A3-troubleshooting.md](A3-troubleshooting.md) — Common validation failures, regeneration strategies, Foundry run/timeouts, OpenAPI tool errors.
- [A4-security-identity.md](A4-security-identity.md) — Identity models (local dev vs cloud), MSI for Tool API, storage permissions, audit.
- [A5-cost-throughput.md](A5-cost-throughput.md) — Tuning chunk sizes, concurrency, caching strategies, validator cost considerations.
- [A6-cicd-automation.md](A6-cicd-automation.md) — Pipeline steps for batch runs, artifact publishing, compliance checks, promotion workflows.
 - [A7-sample-run-manifest.md](A7-sample-run-manifest.md) — Example run manifest with phases, artifacts, and validator outputs.
 - [A8-cli-outline.md](A8-cli-outline.md) — Minimal CLI outline with curl and dotnet examples for interactive and batch scenarios.

Contribution guidance
- File naming: `Ax-title.md` where `x` is 1..n and `title` is lowercase, hyphenated.
- Structure per file:
  - Title and purpose
  - Quickstart or checklist
  - Deep‑dive sections with code/CLI examples
  - Related links to core chapters
- Keep examples deterministic and runnable. Prefer .NET snippets that compile against the proposed solution layout.

Validation notes (from document-plugin-module.md)
- No placeholders (e.g., `{...}`, `TODO`, `TBD`, `FIXME`).
- Only relative links; internal links must resolve to existing files.
- Follow source‑of‑truth precedence when citing facts: requirements JSON → host architecture → reference docset → prose.
- Maintain terminology consistency with the terminology index.

Related
- [00-foundation-index.md](00-foundation-index.md)
- [10-architecture-index.md](10-architecture-index.md)
- [20-operations-index.md](20-operations-index.md)
 - [G1-glossary.md](G1-glossary.md)

---

**Back to index:**
- [root](root.md)
- [foundation](00-foundation-index.md)
- [architecture](10-architecture-index.md)
- [operations](20-operations-index.md)
- [appendix](39-appendix-index.md)

---