# Validation Rules

What must always be true, and where those rules should be enforced in code.

---
## Validation invariants

- Layer folder roles should match their number/name.
- Prefixes should match component responsibility (e.g., `F_` for Fields).
- UI hierarchy should remain rooted in `Shared/_Sites`.


## Failure modes

- Missing schema fields causing UI generation failures
- Integration failures (network/auth) affecting data-driven UI


## User-visible validation

Where validation is enforced is **partially unknown**.

Investigation steps:
- Search `Shared/_Core/02_Fields` for validation logic.
- Search Actions for guardrails before mutations.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
