# Getting Started

---

## Prerequisites

- `.NET 10.0 SDK` or later
- `JetBrains Rider` (recommended) or `Visual Studio 2022+`
- `Airtable API key` (request from arnold@znzr.io)
- Chrome browser (primary testing platform)
- macOS, Windows, or Linux development environment

---

## Initial Setup

### 1. Clone and Open Project

```bash
# Navigate to project root
cd RootServer

# Open in Rider (macOS)
open -a "Rider" RootServer.sln

# Or open in Visual Studio (Windows)
start RootServer.sln
```

### 2. Configure Airtable API Key

Create or edit `appsettings.Development.json`:

```json
{
  "Airtable": {
    "ApiKey": "your-api-key-here",
    "BaseId": "your-base-id-here"
  }
}
```

**Security Note:** Never commit API keys. Use user secrets or environment variables in production.

### 3. Restore Dependencies

```bash
dotnet restore
```

### 4. Run Application

```bash
dotnet run
```

The application will start at `https://localhost:5001` (or port specified in `launchSettings.json`).

---

## Project Structure Overview

```text
RootServer/
├── Pages/                 # Blazor pages (Index, Editor, TestPage)
├── Shared/                # Component hierarchy
│   ├── _Core/            # Foundation components
│   ├── _Editor/          # Development tooling
│   ├── _Sites/           # Public UI sections
│   └── Plugins/          # Plugin modules (Airtable)
├── Json/                  # Cached Airtable data
├── wwwroot/              # Static assets
├── Program.cs            # Application startup
├── App.razor             # Blazor root component
└── appsettings.json      # Configuration

```

---

## First Steps

### 1. Explore the Public Site

Navigate to `https://localhost:5001` to see the schema-driven public site. The UI is assembled from sections defined in `Json/pages.json` and `Json/sections.json`.

### 2. Open the Editor

Navigate to `/editor` to access the internal development tools:
- Browse Airtable tables
- Inspect rows and fields
- Sync data from Airtable to local JSON cache

### 3. Examine the JSON Cache

Review files in the `Json/` folder to see how Airtable data is cached locally. These files drive the UI at runtime.

---

## Common Tasks

### Sync Airtable Data

1. Navigate to `/editor`
2. Click the **Sync** button in the Airtable toolbar
3. Data is fetched from Airtable API and saved to `Json/` folder
4. Restart application to load updated data

### Add a New Section

1. Add section definition to `Json/sections.json`
2. Create corresponding Razor component in `Shared/_Sites/Sections/`
3. Follow naming convention: `C_SectionName.razor` + `C_SectionName.razor.cs`
4. Implement `SectionBase` or use wrapper pattern

### Modify a Table Model

1. Locate table class in `Shared/Plugins/Airtable/00_Core/Tables/`
2. Update properties to match Airtable schema
3. Re-sync data via editor
4. Test changes in UI

---

## Development Workflow

```text
1. Modify Airtable schema (add/update tables, fields)
   ↓
2. Sync data in Editor (`/editor`)
   ↓
3. Update C# table models if schema changed
   ↓
4. Test UI changes
   ↓
5. Commit code (excluding `Json/` if sensitive)
```

---

## Troubleshooting

### Application Won't Start
- Verify `.NET 10.0 SDK` is installed: `dotnet --version`
- Check for port conflicts in `launchSettings.json`
- Review console output for dependency errors

### Airtable Sync Fails
- Confirm API key is valid in `appsettings.Development.json`
- Check network connectivity
- Verify Airtable base ID is correct

### UI Not Updating
- Ensure JSON cache is current (re-sync in Editor)
- Restart application after JSON changes
- Clear browser cache

---

## Next Steps

- Review **[Core Concepts](rootserver-03-core-concepts.md)** for architectural understanding
- Explore **[UI Hierarchy](rootserver-27-ui-hierarchy.md)** to understand component organization
- Read **[Airtable Integration](rootserver-18-arch-airtable.md)** for data flow details

---

---

**Navigation**

- **[← Architecture Overview](rootserver-01-arch-overview.md)**
- **[Core Concepts →](rootserver-03-core-concepts.md)**
- **[Home](rootserver.md)**

---
