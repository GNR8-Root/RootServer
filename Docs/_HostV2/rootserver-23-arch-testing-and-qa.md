# Testing and QA

What testing exists today, what is missing, and a concrete plan to improve it.

---
## Test strategy

No dedicated test project was discovered in this inventory pass.

Not present in this codebase (as discovered in inventory).


## Coverage notes

Current state implies coverage is either manual or ad-hoc.

Remediation plan:
- Add a `RootServer.Tests` project.
- Start with integration tests around Airtable data retrieval and schema parsing.
- Add snapshot tests for key UI generation outputs.


## CI/CD hooks (if any)

CI configuration is **unknown** in this scan.

Investigation steps:
- Search for `.github/workflows/` or pipeline configs.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
