# Plugin Architecture

---

## Current Implementation

One plugin currently exists: **Airtable**

Location: `Shared/Plugins/Airtable/`

---

## Plugin Structure

Follows same numbered hierarchy as Core:

```text
Plugins/Airtable/
├── 00_Core/                 # Plugin system classes
├── 01_Displays/             # Plugin-specific displays
├── 02_Fields/               # Plugin-specific fields
├── 03_Pointers/             # Plugin-specific pointers
├── 04_Actions/              # Plugin-specific actions
├── 05_Nodes/                # Plugin nodes (planned)
├── 06_Components/           # Plugin components
├── 07_Widgets/              # Plugin widgets
├── 08_View/                 # Plugin views
└── 09_Panels/               # Plugin panels
```

---

## Airtable Plugin Components

### Core Classes (`00_Core`)
- Table model definitions
- `AirtableConfig` initialization
- Enums for field types
- Static utilities

### Actions (`04_Actions`)
- `A_AirtableSync` – Sync data from Airtable
- `A_TableBookmark` – Bookmark tables
- `A_RowNew` – Create new rows
- `A_RowDelete` – Delete rows
- `A_RowDuplicate` – Duplicate rows

### Components (`06_Components`)
- `C_TableAir` – Table display component
- `C_Rows` – Row list component
- `C_RowSingle` – Single row display
- `C_Bookmark` – Bookmark display
- `C_InspectorHeader` – Inspector header

### Widgets (`07_Widgets`)
- `W_Tables` – Table list widget

### Views (`08_View`)
- `V_Workspace` – Main workspace view

### Panels (`09_Panels`)
- `PNL_Selection` – Selection panel
- `PNL_Structure` – Structure panel

---

## Plugin Dependencies

### Allowed
- **Plugin → Core** – Plugins use Core base classes
- **Plugin → Host** – Plugins aware of host environment

### Restricted
- **Host → Plugin** – Host should not depend on plugins
- **Plugin → Plugin** – Not yet implemented (Node system planned)

---

## Planned Plugin Features

### Hot-Loading
Load/unload plugins without application restart

### Plugin Discovery
Automatic detection and registration

### Plugin Manifests
```json
{
  "name": "Airtable",
  "version": "1.0.0",
  "dependencies": {
    "Core": ">=1.0.0"
  }
}
```

### Plugin Communication
Via Node graph system (under development)

---

---

**Navigation**

- **[← Module System](rootserver-13-arch-modules.md)**
- **[Dependency Injection →](rootserver-15-arch-di.md)**
- **[Home](rootserver.md)**

---
