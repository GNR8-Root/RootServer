# Base Examples

Concrete examples of how to extend or navigate the codebase using discovered files.

---
## Common workflows

- Build UI screens by composing `Shared/_Sites` pages with layered components from `Shared/_Core` / `Shared/_Editor`.
- Use Airtable integration to load schema/data that drives UI.


## Common extension patterns

- Add a new Field component under `Shared/_Core/02_Fields/` (example: `Shared/_Core/02_Fields/F_Text_Url.razor`).
- Add an editor variant under `Shared/_Editor/02_Fields/` if it is authoring-facing.


## Common pitfalls

- Introducing Host → Plugin dependencies.
- Duplicating JSON assets without a canonical ownership plan (see appendix 42).


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Base index](rootserver-00-base-index.md)**

---
