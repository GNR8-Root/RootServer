# Base Contracts

---

## Public Contracts

### Service Interfaces

**Pointer_Service**
- Selection state management
- Current workspace, table, row, field tracking
- State change notifications

**EditorView_Service**
- Editor view state
- Panel visibility control

**EditorVisibility_Service**
- Component visibility toggling

**LogCatcher_Service**
- Log capture and display

---

## Component Base Classes

### Field Base Classes

Located in `Shared/_Core/02_Fields/_Core/Base/`:
- `FieldBase` - Base for all fields
- `FieldBase_String` - String field base
- `FieldBase_Numeric` - Numeric field base
- `FieldBase_Date` - Date field base
- `FieldBase_Time` - Time field base
- `BaseF_Text` - Text field base

### Action Base Classes

Located in `Shared/_Core/04_Actions/_Core/`:
- `ABase` - Base for all actions
- `APreBase` - Pre-action hooks
- `APostBase` - Post-action hooks

---

## Plugin API Surface

Plugins can:
- Inject host services (Pointer_Service, etc.)
- Extend base classes (FieldBase, ABase, etc.)
- Register own services in DI
- Implement subset of 00-09 layers

Plugins should not:
- Directly manipulate host internal state
- Assume specific host implementation details
- Couple to other plugins directly

---

[← Back to Base Index](rootserver-00-base-index.md)

---
