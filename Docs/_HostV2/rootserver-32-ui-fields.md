# Fields

Interactive inputs: responsibilities, where validation should live, and discovered examples.

---
## Field responsibilities

Fields are interactive inputs that both render and capture user input.

Evidence:
- `Shared/_Core/02_Fields/` exists (example: `Shared/_Core/02_Fields/F_Text_Url.razor`).
- `Shared/_Editor/02_Fields/` exists.


## Validation

Validation is expected inside field components and/or shared validators.

Investigation steps:
- Audit `Shared/_Core/02_Fields` for required/format validation.
- Ensure user-visible error surfacing is consistent.


## Examples

- `{examples.get('F_')}`


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to UI index](rootserver-26-ui-index.md)**

---
