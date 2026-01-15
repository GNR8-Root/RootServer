# JS Interop

How JavaScript interop is (or is not) used and what safety rules apply.

---
## Interop boundary

JavaScript assets exist; interop usage must be confirmed by scanning for `IJSRuntime` calls.


## Call patterns

Investigation steps:
- Search `.cs`/`.razor` for `IJSRuntime` and `.InvokeAsync`.


## Safety notes

- Keep interop calls behind narrow abstractions.
- Validate inputs when crossing the boundary.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to Architecture index](rootserver-12-arch-index.md)**

---
