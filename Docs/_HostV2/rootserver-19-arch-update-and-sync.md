# Update and Sync

How updates propagate and what consistency rules prevent drift between schema and UI.

---
## Update mechanisms

Airtable suggests periodic or on-demand sync. Concrete scheduling mechanisms are **unknown** in this scan.


## Sync actions

Investigation steps:
- Search for background services (`IHostedService`).
- Search for explicit “sync” commands in Actions (`Shared/_Core/04_Actions`, `Shared/_Editor/04_Actions`).


## Consistency rules

- Treat schema as authoritative for UI generation.
- Avoid partial updates that leave UI in mismatched schema states.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
