# Displays

What displays are, where they live, and how they should behave.

---
## Display responsibilities

Displays are expected to be output-only UI elements.

Evidence:
- `Shared/_Core/01_Displays/` exists.
- `Shared/_Editor/01_Displays/` exists.


## Rendering patterns

- Displays should take immutable input models.
- Avoid side effects and service calls inside display components.


## Examples

A dedicated `D_` prefix was **not observed** in `.razor` filenames during this scan.

Practical next step:
- Decide whether Displays are expressed as `C_` components instead of `D_`.
- If `D_` is intended, enforce it via code review or CI checks.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to UI index](rootserver-26-ui-index.md)**

---
