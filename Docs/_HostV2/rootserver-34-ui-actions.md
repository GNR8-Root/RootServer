# Actions

Control logic units: how they mutate state, run async work, and keep UI predictable.

---
## Actions responsibilities

Actions represent control logic: commands, async operations, and state transitions.

Evidence:
- `Shared/_Core/04_Actions/`
- `Shared/_Editor/04_Actions/`


## State changes

- Actions should be the primary place that shared state is modified.
- Keep Actions small and composable; prefer services for heavy logic.


## Async patterns

- Ensure async Actions surface progress and failures.
- Avoid async void; prefer `Task`.

Example:
- `{examples.get('A_')}`


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to UI index](rootserver-26-ui-index.md)**

---
