# Caching Strategy

---

## JSON File Cache

Local caching in `Json/` folder:

```text
Json/
├── pages.json          # Page definitions
├── sections.json       # Section configurations
├── agenda.json         # Agenda data
├── gallery.json        # Gallery data
├── text.json           # Text content
└── [other tables].json
```

---

## Cache Behavior

### Read Operations
- All reads from local JSON files
- No runtime API calls
- Fast, predictable performance

### Write Operations
- Manual sync via Editor interface
- Overwrites entire table file
- No partial updates

---

## Cache Refresh

User-initiated via Editor:
1. Navigate to `/editor`
2. Click Sync button
3. Wait for completion
4. Restart application to load new cache

---

## Future Improvements

- Automatic background sync
- Cache expiration policies
- Partial cache updates
- Cache versioning

---

---

**Navigation**

- **[← Airtable Integration](rootserver-18-arch-airtable.md)**
- **[Performance →](rootserver-20-arch-performance.md)**
- **[Home](rootserver.md)**

---
