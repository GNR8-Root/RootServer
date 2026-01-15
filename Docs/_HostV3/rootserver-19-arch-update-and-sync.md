# Update and Sync

---

## Airtable Synchronization

**Trigger:** Manual via `A_AirtableSync` action in editor

**Process:**
1. User clicks sync button
2. `A_AirtableSync` component invoked
3. Airtable API called for updated schemas/data
4. JSON files in Json/ folder overwritten
5. Components reload from updated JSON
6. UI refreshes

---

## JSON Update Mechanism

**Write Strategy:** Full file replacement

**Atomicity:** No transactional guarantees; file writes not atomic

**Recommendation:** 
- Implement atomic write (write to .tmp, then rename)
- Add file locks to prevent concurrent writes
- Versioning for rollback capability

---

## Cache Invalidation

**Current:** No automatic invalidation; manual sync required

**Recommendation:**
- Implement file watcher for JSON changes
- Automatic re-load on file modification
- Or: periodic background sync with change detection

---

## Consistency Guarantees

**Current:** Eventual consistency via manual sync

**Risks:**
- Stale data if sync not triggered
- Data drift if multiple users sync
- No conflict resolution

---

[← Back to Architecture Index](rootserver-12-arch-index.md)

---
