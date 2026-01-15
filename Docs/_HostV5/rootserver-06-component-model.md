# Component Model

---

## Blazor Component Architecture

RootServer uses `Blazor Server` components as the fundamental UI building blocks. Components are implemented as `.razor` files with optional `.razor.cs` code-behind files.

---

## Base Component Patterns

### Standard Component
Single `.razor` file containing markup and logic:

```razor
@code {
    [Parameter] public string Title { get; set; }
    
    protected override void OnInitialized()
    {
        // Component initialization
    }
}
```

### Code-Behind Pattern
Separate `.razor` (markup) and `.razor.cs` (logic) files:

**Component.razor:**
```razor
@inherits ComponentBase
<div class="component">...</div>
```

**Component.razor.cs:**
```csharp
public partial class Component : ComponentBase
{
    [Parameter] public string Title { get; set; }
}
```

---

## Wrapper + Base Pattern

Many complex components use a two-part structure:

### Wrapper Component
Handles layout, styling, conditional rendering.

**CW_Section.razor:**
```razor
<div class="section-wrapper @CssClass">
    @if (ShowHeader)
    {
        <SectionBase @ref="baseComponent" />
    }
</div>

@code {
    private SectionBase baseComponent;
    [Parameter] public string CssClass { get; set; }
    [Parameter] public bool ShowHeader { get; set; } = true;
}
```

### Base Component
Contains core logic, state management, event handling.

**SectionBase.razor.cs:**
```csharp
public class SectionBase : ComponentBase
{
    [Inject] private Pointer_Service PointerService { get; set; }
    
    protected string CurrentSection { get; set; }
    
    protected override void OnInitialized()
    {
        PointerService.OnSectionChanged += HandleSectionChange;
    }
    
    private void HandleSectionChange(string section)
    {
        CurrentSection = section;
        StateHasChanged();
    }
}
```

---

## Component Lifecycle

Standard `Blazor` lifecycle methods:

- `OnInitialized` / `OnInitializedAsync` – Component initialization
- `OnParametersSet` / `OnParametersSetAsync` – Parameter updates
- `OnAfterRender` / `OnAfterRenderAsync` – Post-render operations
- `Dispose` – Cleanup (implement `IDisposable`)

### Lifecycle Usage in RootServer

```csharp
protected override void OnInitialized()
{
    // Subscribe to events
    PointerService.OnTableChanged += HandleTableChange;
}

protected override async Task OnParametersSetAsync()
{
    // Respond to parameter changes
    await LoadDataAsync();
}

public void Dispose()
{
    // Unsubscribe from events
    PointerService.OnTableChanged -= HandleTableChange;
}
```

---

## Parameter Passing

### Component Parameters

```csharp
[Parameter] public string Title { get; set; }
[Parameter] public int MaxItems { get; set; } = 10;
[Parameter] public EventCallback<string> OnItemClicked { get; set; }
```

### Child Content

```razor
[Parameter] public RenderFragment ChildContent { get; set; }

// Usage:
<ParentComponent>
    <p>This is child content</p>
</ParentComponent>
```

---

## Dependency Injection

Services are injected via `@inject` directive or property injection:

```razor
@inject Pointer_Service PointerService
@inject LogCatcher_Service Logger

// Or in code-behind:
[Inject] private Pointer_Service PointerService { get; set; }
```

---

## Event Handling

### Built-in Events

```razor
<button @onclick="HandleClick">Click Me</button>

@code {
    private void HandleClick(MouseEventArgs e)
    {
        // Handle click
    }
}
```

### Custom Events via EventCallback

```razor
[Parameter] public EventCallback<string> OnValueChanged { get; set; }

private async Task NotifyChange(string value)
{
    await OnValueChanged.InvokeAsync(value);
}
```

---

## State Management

### Component-Level State

```csharp
private bool isLoading = false;
private List<string> items = new();

private void UpdateState()
{
    isLoading = true;
    StateHasChanged(); // Trigger re-render
}
```

### Service-Level State

```csharp
// In service
public event Action<string> OnStateChanged;

private void BroadcastChange(string data)
{
    OnStateChanged?.Invoke(data);
}

// In component
protected override void OnInitialized()
{
    MyService.OnStateChanged += (data) => {
        // Update component
        StateHasChanged();
    };
}
```

---

## Rendering Strategies

### Conditional Rendering

```razor
@if (IsVisible)
{
    <div>Content</div>
}
else
{
    <p>Loading...</p>
}
```

### Loop Rendering

```razor
@foreach (var item in Items)
{
    <div>@item.Name</div>
}
```

### Dynamic Components

```razor
<DynamicComponent Type="componentType" Parameters="parameters" />
```

---

## Component Composition

Components build on lower-level components:

```text
PNL_Selection (Panel)
    └── W_Tables (Widget)
        └── C_TableAir (Component)
            ├── D_TableName (Display)
            ├── P_TableSelector (Pointer)
            └── A_TableSync (Action)
```

This hierarchical composition follows the numbered folder structure.

---

---

**Navigation**

- **[← Project Structure](rootserver-05-project-structure.md)**
- **[Data Flow →](rootserver-07-data-flow.md)**
- **[Home](rootserver.md)**

---
