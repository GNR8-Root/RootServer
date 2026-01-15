# JavaScript Interop

---

## Current Status

**Minimal JS Interop:** RootServer primarily uses Blazor components without extensive JavaScript interaction.

**Blazorise Dependency:** Blazorise may use JS interop internally for certain components (dropdowns, modals), but this is handled by the library.

---

## Potential JS Interop Scenarios

1. **Lottie Animations:** wwwroot/lottie/ folder suggests animation usage
2. **Spline 3D:** wwwroot/spline/ folder suggests 3D content
3. **Unity WebGL:** wwwroot/unity/ folder suggests potential Unity integration

**Evidence:** Folders exist but actual usage unclear without runtime inspection.

---

## Recommended Patterns

If JS interop is needed:

```csharp
@inject IJSRuntime JS

private async Task CallJavaScript()
{
    await JS.InvokeVoidAsync("myFunction", param1, param2);
}
```

```javascript
// wwwroot/js/site.js
window.myFunction = (param1, param2) => {
    // Implementation
};
```

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
