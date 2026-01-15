# Base Integrations

---

## Airtable Integration

**Purpose:** Fetch table schemas and data from Airtable API, cache locally as JSON.

**Initialization:** `AirtableConfig.Initialize(builder.Configuration)` in Program.cs

**Key Components:**
- Configuration class for API credentials
- Sync action (`A_AirtableSync`) for manual synchronization
- JSON caching for offline development
- Strongly-typed table models

**Failure Policy:** Unknown - requires investigation (see Appendix 40)

**Sync Mechanism:** Manual via `A_AirtableSync` action component in editor

---

## Blazorise UI Framework

**Purpose:** Provides Bootstrap 5 and Tailwind CSS component library for Blazor.

**Integration:**
```csharp
builder.Services
    .AddBlazorise(options => { options.Immediate = true; })
    .AddTailwindProviders()
    .AddFontAwesomeIcons();
```

**Components Used:**
- Form inputs (fields)
- Dropdowns (pointers)
- Icons (FontAwesome)
- Layout utilities (Tailwind)

---

## External Dependencies

From RootServer.csproj:
- Blazorise.Bootstrap5
- Blazorise.Icons.FontAwesome
- Standard .NET 8 Blazor Server packages

**No database:** All data sourced from Airtable or JSON cache.

---

[← Back to Base Index](rootserver-00-base-index.md)

---
