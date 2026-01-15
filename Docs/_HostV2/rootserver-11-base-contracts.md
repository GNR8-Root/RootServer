# Base Contracts

What is considered a stable contract vs internal implementation detail in this host codebase.

---
## Public contracts

- UI contracts: `Shared/_Sites` hierarchy + layer folders.
- Integration contracts: Airtable integration under `Shared/Plugins/Airtable/`.


## Internal contracts

- Prefix naming conventions for components (e.g., `F_`, `P_`, `A_`).
- Layer folder roles (00..09) in `Shared/_Core` and `Shared/_Editor`.


## DI / service contracts

DI surface is **partially unknown** from this scan.

Investigation steps:
- Parse `Program.cs` service registrations and document stable service APIs.
- Add a “service inventory” section to `01-inventory-index.json` in a follow-up update.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
