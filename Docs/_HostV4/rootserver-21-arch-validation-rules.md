# Validation Rules

---

## Field Validation

### FieldBase Classes

Base classes in `Shared/_Core/02_Fields/_Core/Base/` provide validation hooks:
- `FieldBase` - Base validation interface
- `FieldBase_String` - String validation
- `FieldBase_Numeric` - Numeric range validation
- `FieldBase_Date` - Date range validation

---

## Validation Patterns

### Client-Side Validation

```csharp
public partial class F_Text_Email : FieldBase_String
{
    protected override bool Validate(string value)
    {
        return IsValidEmail(value);
    }
}
```

### Server-Side Validation

Validation occurs during:
- Form submission
- Airtable sync (schema constraints)
- Data persistence

---

## Data Integrity

**Current State:** Minimal explicit validation beyond base field types.

**Recommendation:**
- Implement FluentValidation or DataAnnotations
- Add validation attributes to models
- Centralize validation rules
- Provide user-friendly error messages

---

## User-Visible Validation

**Current:** Blazorise provides built-in validation UI (ValidationSummary, field-level errors).

**Improvement Opportunities:**
- Custom validation message styling
- Real-time validation feedback
- Validation state in Pointer_Service

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
