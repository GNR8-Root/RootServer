# Base Concepts

---

## Core Terminology

This page defines the canonical terms used throughout RootServer documentation.

---

### Host

The RootServer Blazor Server application itself. Responsibilities include:
- Application bootstrap (Program.cs)
- Dependency injection configuration
- Middleware pipeline setup
- Plugin lifecycle management
- Shared service registration

**Location:** Root of the project, Program.cs, App.razor

**Key Characteristic:** Does not depend on plugins; provides extension points.

---

### Plugin

A self-contained extension that adds functionality to the host. Plugins follow the layer system and use component prefixes.

**Example:** Airtable plugin (`Shared/Plugins/Airtable/`)

**Characteristics:**
- Implements subset of 00-09 layers (not all layers required)
- Uses standardized prefixes (P_, A_, C_, PNL_)
- Registers services during host startup
- Can reference host services but host should not reference plugin internals

---

### Module

Infrastructure for modular architecture. Currently minimal implementation.

**Location:** `Shared/_Modules/`

**Status:** Infrastructure exists; full module system is planned but not yet implemented.

---

### Layer Folder

Numbered folders (00_Core through 09_Panels) that organize components by abstraction level:

| Number | Name | Abstraction Level | Purpose |
|--------|------|-------------------|---------|
| 00 | Core | Foundation | Enums, events, services, base classes |
| 01 | Displays | Atomic | Read-only output (text, images, media) |
| 02 | Fields | Atomic | Read/write inputs (form fields, editors) |
| 03 | Pointers | Atomic | Interaction helpers (selectors, buttons) |
| 04 | Actions | Atomic | User/system actions (sync, create, update) |
| 05 | Nodes | Composed | Node graph definitions |
| 06 | Components | Composed | Layouts combining displays/fields/pointers/actions |
| 07 | Widgets | Container | Layout containers for multiple views |
| 08 | View | Container | Single or multiple view layouts |
| 09 | Panels | Macro | High-level groupings of multiple views |

---

### Component Prefix

Naming convention indicating component role and layer:

| Prefix | Layer | Role | Example |
|--------|-------|------|---------|
| F_ | 02_Fields | Form fields | F_Text_Email, F_Color, F_Toggle_Switch |
| FW_ | 02_Fields | Field wrappers | FW_Group, FW_Main |
| HP_ | 03_Pointers | Help pointers | HP_CurrentItem, HP_Structure |
| P_ | 03_Pointers | Pointers | P_Table, P_Row, P_Field, P_Workspace |
| A_ | 04_Actions | Actions | A_AirtableSync, A_RowNew |
| ABase | 04_Actions | Action base | ABase, APreBase, APostBase |
| C_ | 06_Components | Components | C_TableAir, C_RowSingle, C_Bookmark |
| CP_ | 06_Components | Component patterns | CP_Dropdown, CP_HeadContentWebflow |
| PNL_ | 09_Panels | Panels | PNL_Structure, PNL_Selection |

---

### Schema-Driven UI

Rendering approach where components are generated from JSON metadata rather than hardcoded layouts.

**Flow:**
1. JSON schema defines data structure (tables, fields, pages)
2. Schema parsed at runtime
3. Appropriate components instantiated based on metadata
4. Component tree rendered via Blazor

**Benefits:**
- Rapid iteration without recompilation
- Consistent UI patterns
- Data-driven customization

---

### Pointer

Selection and state management abstraction. The Pointer_Service tracks:
- Current selected workspace
- Current selected table
- Current selected row
- Current selected field

**Purpose:** Centralized selection state enabling coordinated UI updates across components.

**Location:** `Shared/_Core/00_Core/Events/Pointer_Service.cs`

---

### Editor Environment

Internal UI for runtime inspection and management.

**Location:** `Shared/_Editor/`

**Features:**
- Table browsing
- Row/field inspection
- Airtable sync utility
- Log viewer
- Workspace selector

**Structure:** Follows 00-09 layer system like the core framework.

---

### Site

Public-facing website components assembled from reusable sections.

**Location:** `Shared/_Sites/`

**Structure:**
- Components/ - Reusable UI elements
- Layouts/ - Page layout definitions
- Nav/ - Navigation components
- Pages/ - Page definitions
- Sections/ - Content sections (About, Contact, Gallery, etc.)

---

### JSON Cache

Local file storage for Airtable schemas and data.

**Location:** `Json/` folder

**Purpose:**
- Enable offline development
- Fast local iteration
- Reduce API calls during development

**Pattern:** Cached JSON mirrors Airtable structure (workspaces, tables, rows, fields).

**Issue:** Duplicate files exist with inconsistent naming (see Appendix 42).

---

[← Back to Base Index](rootserver-00-base-index.md)

---
