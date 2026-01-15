# Performance and Observability

---

## Performance Targets

**Current State:** No explicitly defined performance targets.

**Typical Blazor Server Metrics:**
- First render: < 2 seconds
- Interaction latency: < 100ms
- SignalR message size: < 1KB per update
- Memory per circuit: < 50MB

---

## Known Hotspots

### Potential Performance Concerns

1. **Large JSON Files:** Deserializing large Airtable schemas
2. **Frequent Re-renders:** Service events triggering many components
3. **SignalR Bandwidth:** Complex component trees = large DOM diffs
4. **Memory Growth:** Scoped services holding large object graphs

**Status:** Requires profiling to confirm.

---

## Logging Infrastructure

### ASP.NET Core Logging

Configured in appsettings.json:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

### LogCatcher_Service

Custom service for capturing and displaying logs in editor.

**Location:** `Shared/_Editor/00_Core/LogCatcher_Service`

**Purpose:** Runtime log inspection within the application

---

## Observability Recommendations

### Application Insights

```csharp
// Add to Program.cs
builder.Services.AddApplicationInsightsTelemetry();
```

Track:
- Page load times
- SignalR connection stability
- Exception rates
- Custom events (sync operations, selections)

### Structured Logging

```csharp
_logger.LogInformation("Table selected: {TableId} by {User}", tableId, userId);
```

### Performance Counters

- Circuit count
- Active connections
- Memory usage
- CPU utilization

---

## Investigation Plan

1. **Profile JSON deserialization** with BenchmarkDotNet
2. **Monitor SignalR traffic** with browser DevTools
3. **Track memory growth** with dotMemory
4. **Measure render times** with Blazor DevTools
5. **Implement Application Insights** for production telemetry

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
