# Technology Stack

---

## Core Technologies

### Blazor Server
- **Version**: `.NET 10.0`
- **Purpose**: Server-side rendering with SignalR communication
- **Benefits**: Full .NET runtime on server, minimal client payload

### Airtable API Integration
- **Package**: `Airtable` v1.4.0
- **Purpose**: External schema storage and data source
- **Features**: REST API access, schema introspection, field type mapping

### Blazorise UI Framework
- **Package**: `Blazorise` v1.8.7
- **CSS Framework**: `Tailwind CSS`
- **Icons**: `FontAwesome`
- **Components**: `Splitter`, `Components` extensions

---

## Development Tools

### JetBrains Rider
- Primary IDE for macOS development
- Excellent `.NET` and `Blazor` support
- Integrated debugging and profiling

### Browser Support
- **Primary**: Chrome (all testing done here)
- **Status**: Other browsers not yet tested
- **Requirement**: Modern browser with WebSocket support

---

## Runtime Requirements

### Server
- `.NET 10.0 SDK` or later
- Linux, macOS, or Windows
- WebSocket support for SignalR

### Client
- Modern web browser
- JavaScript enabled
- WebSocket support

---

## Dependencies

### NuGet Packages

```xml
<PackageReference Include="Airtable" Version="1.4.0" />
<PackageReference Include="Blazorise.Tailwind" Version="1.8.7" />
<PackageReference Include="Blazorise.Icons.FontAwesome" Version="1.8.7" />
<PackageReference Include="Blazorise.Splitter" Version="1.8.7" />
<PackageReference Include="Blazorise.Components" Version="1.8.7" />
```

### Target Framework
- `net10.0`
- `Nullable` enabled
- `ImplicitUsings` enabled

---

## Architecture Patterns

### Event-Driven
- Custom event system for state propagation
- Loose coupling between components
- Service-based event broadcasting

### Dependency Injection
- Scoped services per user session
- Constructor injection throughout
- Service registration in `Program.cs`

### Component Model
- Razor components with code-behind
- Wrapper + Base pattern for complex components
- Strongly typed parameters

---

## Data Layer

### JSON Caching
- Local `Json/` folder for offline capability
- Airtable data cached as individual table files
- Manual sync via Editor interface

### Schema Metadata
- `pages.json` – Page definitions
- `sections.json` – Section configurations
- `tables.json` – Airtable table metadata
- Additional JSON files for each table

---

## Future Technology Considerations

### Planned Additions
- `CosmosDB` for schema storage
- `Azure` deployment automation
- `SignalR` real-time collaboration
- Plugin hot-loading mechanism

### Research Areas
- Node graph system implementation
- Module versioning and discovery
- AI-assisted code generation integration

---

---

**Navigation**

- **[← Core Concepts](rootserver-03-core-concepts.md)**
- **[Project Structure →](rootserver-05-project-structure.md)**
- **[Home](rootserver.md)**

---
