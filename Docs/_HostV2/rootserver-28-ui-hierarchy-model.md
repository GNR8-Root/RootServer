# UI Hierarchy Model

The concrete hierarchy rooted at `Shared/_Sites` and the rules for composing screens.

---
## Hierarchy source folder

`Shared/_Sites` is the root of the UI hierarchy.

Discovered subfolders:
- `Pages/`
- `Layouts/`
- `Components/`
- `Sections/`
- `Nav/`


## Composition rules

- Pages should be shallow and delegate real work to Components/Sections.
- Layouts define consistent shells.
- Navigation elements live in `Nav/` and should not embed business logic.


## Examples

- Node-style navigation component discovered: `Shared/_Sites/Nav/Section/N_Section.razor`.


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to UI index](rootserver-26-ui-index.md)**

---
