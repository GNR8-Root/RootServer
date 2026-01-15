# JSON and Assets

Where JSON and static assets live, and how to manage duplication and evolution safely.

---
## JSON assets inventory

- Configuration JSON: `appsettings.json`, `appsettings.Development.json`.
- Documentation JSON/exports may exist under `Docs/` (if used as data inputs).

Evidence:
- `Docs/`
- `appsettings*.json`


## Duplication risks

Duplicate or parallel JSON exports increase drift risk.

- See appendix 42 for a canonical naming plan and CI guardrail.


## Asset pipelines

- Static assets live in `wwwroot/`.
- Any external asset pipeline is **unknown** from this scan.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
