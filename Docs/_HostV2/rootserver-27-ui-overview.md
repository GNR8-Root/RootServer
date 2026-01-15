# UI Overview

How the UI is structured and how a user interaction maps onto folders and components.

---
## UI overview

UI is organized around `Shared/_Sites` (hierarchy) and layered UI building blocks under `Shared/_Core` and `Shared/_Editor`.

Evidence:
- `Shared/_Sites/`
- `Shared/_Core/`
- `Shared/_Editor/`


## Navigation model

Navigation is expressed through `Shared/_Sites/Nav/` and `Shared/_Sites/Pages/`.

Evidence:
- `Shared/_Sites/Nav/`
- `Shared/_Sites/Pages/`


## User journeys

Typical journey:
- User navigates to a Page in `Shared/_Sites/Pages`
- Page composes Layouts/Components/Sections
- Components pull data/state via DI and integrations (e.g., Airtable)


---
- **[Back to rootserver.md](rootserver.md)**
- **[Back to UI index](rootserver-26-ui-index.md)**

---
