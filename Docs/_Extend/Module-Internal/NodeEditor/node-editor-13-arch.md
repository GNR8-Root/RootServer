# Blazor Node Editor Architecture
## Physics-Based Behavior Tree Editor with Airtable Backend

---

##  Executive Summary

This document defines the complete architecture for a **visual node editor** built with:
- **Blazor** (data layer, Airtable sync, state management)
- **Matter.js** (physics simulation, constraints, damping)
- **p5.js** (rendering, visual representation)

The editor supports **behavior tree workflows** with top-to-bottom execution flow, left-to-right data flow, **macro nodes** (nested graphs), physics-based drag interactions, and real-time synchronization with Airtable as the source of truth.

---

##  Product Boundaries & Responsibilities

### **Matter.js Domain**
*Physics simulation only*

- Node body positions and velocities
- Constraint-based edge connections
- Drag interactions with damping
- Collision detection (optional)
- Spring forces for connected nodes

### **p5.js Domain**
*Visual rendering only*

- Node shapes, headers, bodies
- Port visualization (circles)
- Wire/edge curves (bezier)
- Selection outlines
- Hover states and highlights
- Temporary link preview during drag

### **Blazor Domain**
*Data orchestration and persistence*

- Airtable synchronization (bidirectional)
- JSON normalization (Airtable → JS contract)
- Graph state management
- Change detection and dirty tracking
- Manual reload triggers
- Streaming update coordination
- Macro navigation stack management

### **Interop Contract**
*Blazor ↔ JavaScript boundary*

**Blazor → JS:**
- `loadGraph(snapshot)` - full graph replacement
- `applyPatch(patch)` - incremental updates
- `navigateToGraph(graphId)` - macro navigation
- `clearSelection()` - UI commands

**JS → Blazor:**
- `onNodeMoved(nodeId, x, y)` - position updates
- `onNodeMoveEnd(nodeId, x, y)` - save trigger
- `onEdgeCreated(edgeDraft)` - new connection
- `onEdgeDeleted(edgeId)` - connection removal
- `onNodeSelected(nodeId)` - selection change
- `onEnterMacro(nodeId, macroGraphId)` - navigation request

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---