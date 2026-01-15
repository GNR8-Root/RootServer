# Base Boundaries

The dependency boundary rules used to interpret and document the codebase.

---
## Boundary rules

- Host owns runtime boot, DI wiring, and top-level composition.
- Modules may reference other modules (assumed always-active).
- Plugins may reference modules and host surfaces.
- Avoid Host → Plugin compile-time dependencies.

Evidence:
- `Program.cs`
- `Shared/Plugins/`


## Allowed dependencies

- Module ↔ Module
- Plugin → Module
- Plugin → Host


## Forbidden dependencies

- Host → Plugin (avoid coupling the host to optional extensions)

If a violation is discovered later, it will be logged in the final issues file.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
