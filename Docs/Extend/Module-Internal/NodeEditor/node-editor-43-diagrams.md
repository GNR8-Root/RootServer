
---

# Blazor Behavior Tree Editor - Diagrams

Architecture & UX

---

### Conventions
- Boxes = components/modules
- Arrows show direction of calls/data/events
- "SoT" = Source of Truth (Airtable)
- "JS API" = window.graphEditor exposed from /js/index.js

---


## High-level system architecture (containers)

```text
+------------------------------+        +------------------------------+
| Blazor (.NET)                |        | Airtable (SoT)               |
| - UI (pages/components)      |<------>| - Graphs                     |
| - Services (data + sync)     |  REST  | - Nodes                      |
| - Validation                 | +ETag  | - Edges                      |
| - Streaming                  |        | - Ports (optional)           |
+--------------+---------------+        +------------------------------+
               |
               | JS Interop (loadGraph/applyPatch + callbacks)
               v
+------------------------------+
| JavaScript (/js)             |
| - Matter.js physics          |
| - p5.js rendering            |
| - Runtime orchestration      |
+------------------------------+
```

---


## Project / folder structure (from spec)

```text
Repository
|
+-- /Services
|    |-- IAirtableService.cs
|    |-- AirtableService.cs
|    |-- IGraphService.cs
|    |-- GraphService.cs
|    |-- IJSRuntimeService.cs
|    +-- JSRuntimeService.cs
|
+-- /Pages (or /Components)
|    +-- GraphEditorComponent.razor
|
+-- /Components (suggested)
|    |-- Breadcrumbs.razor
|    +-- NodeInspector.razor
|
+-- /Validation
|    +-- GraphValidator.cs
|
+-- /js
     |-- index.js
     |
     +-- core
     |    |-- GraphRuntime.js
     |    |-- PhysicsWorld.js
     |    |-- Renderer.js
     |    +-- InteractionController.js
     |
     +-- models
     |    |-- Node.js
     |    |-- Edge.js
     |    +-- Port.js
     |
     +-- utils
          |-- Geometry.js
          |-- Colors.js
          +-- EventBus.js
```

---


## Core class/component dependency graph (who depends on whom)

```text
+----------------------------+
| GraphEditorComponent       |
| (Blazor UI page)           |
+-------------+--------------+
              |
              | uses
              v
+----------------------------+       +------------------------+
| GraphService               |------>| GraphValidator          |
| - snapshot build           |       | - rules (root/cycle/...)|
| - ports normalization      |       +------------------------+
| - diff/patch decision      |
| - write ops to Airtable    |------> +------------------------+
+-------------+--------------+        | GraphCache             |
              |                       | - mem cache snapshots  |
              | calls                 +------------------------+
              v
+----------------------------+
| AirtableService            |
| - REST client              |
| - retries/ratelimit        |
| - ETag support             |
+-------------+--------------+
              |
              v
+----------------------------+
| Airtable Tables (SoT)      |
| Graphs / Nodes / Edges     |
| Ports (optional)           |
+----------------------------+

Also:
GraphEditorComponent -> JSRuntimeService -> JS API -> GraphRuntime
GraphNavigationService -> JSRuntimeService (layout export/restore)
Streaming loop lives in UI layer (timer) calling GraphService
```

---


## JavaScript runtime internal architecture (composition)

```text
+------------------------------+
| window.graphEditor (index.js)|
| - exposes global API         |
|   loadGraph / applyPatch     |
|   exportLayout / setCallbacks|
+---------------+--------------+
                |
                v
+------------------------------+
| GraphRuntime (core)          |
| - nodes: Map<id, Node>       |
| - edges: Map<id, Edge>       |
| - bodies: Map<id, Body>      |
| - constraints: Map<id, Con>  |
| - ports: hitboxes registry   |
| - dirtyLayout: Set<nodeId>   |
+------+------+------+---------+
       |      |      |
       |      |      |
       v      v      v
+------+--+ +------+--+ +-------------+
|Physics | |Renderer | |Interaction   |
|World   | |(p5.js)  | |Controller    |
|(Matter)| |draw loop| |state machine |
+--------+ +---------+ +-------------+
    |
    v
Matter.Engine / Bodies / Constraints
```

---


## Interop contract (API + callbacks)

```text
Blazor -> JS (commands)
-----------------------
graphEditor.loadGraph(snapshot)          // full replace
graphEditor.applyPatch(patch)            // incremental update
graphEditor.navigateToGraph(graphId)     // macro navigation
graphEditor.clearSelection()             // UI command

JS -> Blazor (events / callbacks)
--------------------------------
onNodeMoved(nodeId, x, y)                // position updates (optional)
onNodeMoveEnd(nodeId, x, y)              // save trigger (debounced)
onEdgeCreated(edgeDraft)                 // persist new edge
onEdgeDeleted(edgeId)                    // delete edge
onNodeSelected(nodeId)                   // selection change
onEnterMacro(nodeId, macroGraphId)       // request navigation
```

---


## Sequence: initial load (Airtable -> Blazor -> JS)

```text
User opens /editor/{GraphId}
  |
  v
GraphEditorComponent.OnAfterRender(firstRender)
  |
  +--> JSRuntimeService.RegisterCallbacks(dotNetRef)
  |
  +--> GraphService.BuildSnapshotAsync(graphId)
  |       |
  |       +--> AirtableService.GetGraphAsync(graphId)
  |       +--> AirtableService.GetNodesAsync(graphId)
  |       +--> AirtableService.GetEdgesAsync(graphId)
  |       +--> normalize + BuildPorts + ComputeHeight
  |
  +--> JSRuntimeService.LoadGraphAsync(snapshot)
          |
          +--> JS: graphEditor.loadGraph(snapshot)
                  |
                  +--> GraphRuntime.loadGraph
                        - build Node/Edge models
                        - create Matter bodies + constraints
                        - register port hitboxes
                        - start physics + rendering
```

---

## Sequence: drag node -> save position (JS -> Blazor -> Airtable)

```text
User drags node header
  |
  v
InteractionController (Dragging state)
  |
  +--> PhysicsWorld.startDrag(nodeId)
  +--> PhysicsWorld.updateDrag(x,y) ... (loop)
  |
  +--> on release:
       PhysicsWorld.endDrag()
       emit onNodeMoveEnd(nodeId, x, y)  (debounced ~300ms)
              |
              v
       GraphEditorComponent.[JSInvokable] OnNodeMoveEnd(...)
              |
              v
       GraphService.UpdateNodePositionAsync(nodeId,x,y)
              |
              v
       AirtableService.UpdateNodeAsync(nodeId, {x,y})
```

---


## Sequence: create edge -> validate -> persist (JS -> Blazor)

```text
User drags from source port to target port
  |
  v
InteractionController (Linking state)
  |
  +--> on release:
       if compatible:
          emit onEdgeCreated(edgeDraft)
              |
              v
          GraphEditorComponent.[JSInvokable] OnEdgeCreated(edgeDraft)
              |
              v
          GraphService.CreateEdgeAsync(edgeDraft)
              |
              +--> GraphValidator.Validate(graphSnapshot)
              |     - root rules
              |     - flow-in rules
              |     - composite children rules
              |     - cycle detection (flow)
              |     - type match (data)
              |
              +--> if valid:
              |       AirtableService.CreateEdgeAsync(edgeCreate)
              |
              +--> if invalid:
                      return errors (for UI highlight + panel)
```

---


## Streaming / sync loop (ETag polling -> patch/apply)

```text
Timer (every ~5s)
  |
  v
GraphEditorComponent.CheckForUpdates()
  |
  +--> GraphService.GetGraphVersionAsync(graphId, ifNoneMatch=ETag)
  |       |
  |       +--> AirtableService (ETag / updated_at / version check)
  |
  +--> if NotModified: return
  |
  +--> if local changes dirty:
  |       show "Remote changes available" banner
  |
  +--> else (clean):
          snapshot = GraphService.BuildSnapshotAsync(graphId)
          layout   = JSRuntimeService.ExportLayoutAsync()
          patch    = ComputePatch(snapshot, layout)
          |
          +--> if patch.IsFullReload:
          |       JSRuntimeService.LoadGraphAsync(snapshot)
          |    else:
          |       JSRuntimeService.ApplyPatchAsync(patch)
```

---


## Macro navigation (enter/exit macro graphs)

```text
Enter Macro (from JS event)
---------------------------
InteractionController emits: onEnterMacro(nodeId, macroGraphId)
  |
  v
GraphEditorComponent.OnEnterMacro(...)
  |
  +--> (recommended) GraphNavigationService.EnterMacro(...)
         |
         +--> JSRuntimeService.ExportLayoutAsync()
         +--> push frame {GraphId, Layout, ScrollPos}
         +--> LoadGraphAsync(macroGraphId)
         +--> update breadcrumbs

Exit Macro / Breadcrumb click
-----------------------------
GraphNavigationService.ExitMacro()
  |
  +--> pop frame
  +--> LoadGraphAsync(parentGraphId)
  +--> JSRuntimeService.RestoreLayoutAsync(frame.Layout)
  +--> JSRuntimeService.SetScrollPositionAsync(frame.ScrollPos)
```

---


## Data model (Airtable ER + normalized snapshot)

```text
Airtable Tables
---------------
Graphs(graph_id PK)
  |
  | 1..N
  v
Nodes(node_id PK, graph_id FK, type, x,y,w,h, data JSON, ui JSON,
     macro_graph_id FK -> Graphs.graph_id (only for Macro nodes))
  |
  | (optional 1..N)
  v
Ports(port_id PK, node_id FK, side, name, datatype, index, kind)

Edges(edge_id PK, graph_id FK, kind, from_node FK, from_port, to_node FK, to_port, style JSON)

Normalized Snapshot (Blazor -> JS)
----------------------------------
GraphSnapshot
  - graphId, version, name, metadata(camera)
  - nodes[]: id,type,name,x,y,w,h,data,ui,ports{},macroGraphId
  - edges[]: id,kind,from,fromPort,to,toPort,style{}
```

---


## UX/UI component interactions (Blazor DOM + canvas)

```text
+------------------------------+     +-----------------------------+
| Header Bar (Blazor)          |     | Inspector (Blazor)          |
| - Breadcrumbs                |<--->| - edit node properties      |
| - Sync state / Reload        |     | - validation section        |
| - Validate                   |     +-----------------------------+
+--------------+---------------+
               |
               v
+------------------------------+
| Canvas container (Blazor DOM)|
| - p5 canvas injected here    |
| - receives focus/keyboard    |
+--------------+---------------+
               |
               v
+------------------------------+
| p5 Renderer (JS)             |
| - nodes/ports/edges visuals  |
| - hover/selection highlights |
| - temp linking wire preview  |
+------------------------------+
```

---

## Error / Validation Propagation (GraphValidator -> UI + Renderer)

```text
User action (edge created / node edited / apply remote / manual Validate)
  |
  v
+----------------------------+
| GraphEditorComponent       |
| - triggers validation      |
+-------------+--------------+
              |
              v
+----------------------------+
| GraphService               |
| - builds snapshot context  |
| - calls validator          |
+-------------+--------------+
              |
              v
+----------------------------+
| GraphValidator             |
| - returns errors[]         |
|   code, message, nodeId?   |
|   edgeId? severity         |
+------+------+--------------+
       |      |
       |      +---------------------------------------------+
       |                                                    |
       v                                                    v
+----------------------------+                  +----------------------------+
| Blazor UI state            |                  | JS Renderer (p5)           |
| - banner/chip: "2 errors"  |                  | - draw red rings           |
| - inspector section list   |                  | - draw warning badges      |
| - toast: "validation fail" |                  | - draw error panel overlay |
+-------------+--------------+                  +-------------+--------------+
              |                                               |
              | (optional interop)                            |
              v                                               v
      graphEditor.setValidationErrors(errors)         highlight nodes/edges

Notes:
- Node-linked errors: node outline + badge + inspector entry
- Edge-linked errors: edge color/tooltip + list entry
- Global errors: top banner + validation summary chip
```

---

## Patch Granularity Map (GraphPatch + JS applyPatch lifecycle)

```text
Airtable change detected (ETag/version changed)
  |
  v
+-----------------------------+
| GraphService.BuildSnapshot  |
| - fetch graph/nodes/edges   |
+--------------+--------------+
               |
               v
+-----------------------------+
| ComputePatch(snapshot,      |
|             currentLayout)  |
|                             |
| outputs GraphPatch:         |
|  - addedNodes[]             |
|  - updatedNodes[] (partial) |
|  - removedNodes[]           |
|  - addedEdges[]             |
|  - updatedEdges[] (partial) |
|  - removedEdges[]           |
|  - preserveLayout[]         |
|  - version, graphId         |
|  - IsFullReload (fallback)  |
+--------------+--------------+
               |
               v
+-----------------------------+
| JS: graphEditor.applyPatch  |
+--------------+--------------+
               |
               v
+-----------------------------+
| GraphRuntime.applyPatch     |
| 1) removeEdges              |
| 2) removeNodes              |
| 3) addNodes (create bodies) |
| 4) addEdges (constraints)   |
| 5) merge updatedNodes       |
|    - if x/y changed:        |
|      Body.setPosition       |
| 6) rebuild constraints      |
|    for added/updated edges  |
+-----------------------------+

Patch decision rule of thumb:
- If many deletes or graphId changed -> full reload
- If small field edits -> patch
- preserveLayout[] prevents clobbering local positions when desired

```

---

## Port Generation Rules (implicit + from data JSON)

```text
Node record from Airtable
  - type: Root / Sequence / Selector / Action / Condition / Macro / Decorator
  - data: JSON
  - (optional) Ports table rows

             +--------------------------------------+
             | BuildPorts(node) (GraphService)      |
             +-------------------+------------------+
                                 |
              +------------------+------------------+
              |                                     |
              v                                     v
     Implicit ports by NodeType               Data-driven ports
     -------------------------               -------------------
 Root:      flowOut                          for each key in node.data:
 Sequence:  flowIn + flowOut                  dataIn_<key>
 Selector:  flowIn + flowOut                  - side: left
 Action:    flowIn                            - index: incrementing
 Condition: flowIn                            - datatype inferred
 Decorator: flowIn + flowOut (and 1 child)    (optional future)
 Macro:     flowIn + flowOut + "open" UX

Output shape (normalized for JS):
ports = {
  flowIn:  { side:"top",    datatype:"flow", kind:"FlowIn"  },
  flowOut: { side:"bottom", datatype:"flow", kind:"FlowOut" },
  dataIn_target: { side:"left", datatype:"object", kind:"DataIn", index:0 }
}

Optional Ports table override:
- if Ports table exists for node:
    - use it as authoritative or merge with implicit ports
    - enables custom ordering/side/kind/datatype validation

```

---

## Permissions / Rate Limiting / Retry Flow (AirtableService)

```text
Any write operation (UpdateNode / CreateEdge / DeleteEdge / BatchUpdate)
  |
  v
+-----------------------------+
| AirtableService             |
| - HttpClient wrapper        |
| - auth header (ApiKey)      |
| - base + table routing      |
+--------------+--------------+
               |
               v
+-----------------------------+
| Client-side Rate Limiter    |
| - max ~5 req/sec            |
| - queue / token bucket      |
+--------------+--------------+
               |
               v
+-----------------------------+
| Send HTTP Request           |
| - ifNoneMatch / ETag (read) |
| - payload (write)           |
+--------------+--------------+
               |
               v
+-----------------------------+
| Response Handling           |
|                             |
| 2xx: success                |
| 304: NotModified (read)     |
| 401/403: auth/perm error    |
| 404: bad table/record id    |
| 409/422: conflict/invalid   |
| 429: rate limited           |
| 5xx: transient              |
+--------------+--------------+
               |
               v
+-----------------------------+
| Retry Policy (selective)    |
| - 429: backoff + retry      |
| - 5xx: exponential backoff  |
| - 401/403: NO retry         |
| - 4xx invalid: NO retry     |
+--------------+--------------+
               |
               v
+-----------------------------+
| Bubble result to caller     |
| - GraphService decides UI   |
|   (toast/banner/reload)     |
+-----------------------------+

Recommended UX mapping:
- 429/5xx: show "Saving..." then "Retrying..." (non-blocking)
- 401/403: blocking banner: "Invalid Airtable credentials"
- 409/version mismatch: conflict banner with Reload / Export Layout
```

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---