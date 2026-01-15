#  JavaScript Engine Architecture

---

## **Module Structure**

```
/js
├── core
│   ├── GraphRuntime.js       # Main orchestrator
│   ├── PhysicsWorld.js        # Matter.js wrapper
│   ├── Renderer.js            # p5.js drawing
│   └── InteractionController.js # Input handling
├── models
│   ├── Node.js                # Node model + methods
│   ├── Edge.js                # Edge model + methods
│   └── Port.js                # Port model + hit testing
├── utils
│   ├── Geometry.js            # Bezier, hit testing, layout
│   ├── Colors.js              # Theme + type colors
│   └── EventBus.js            # Internal pub/sub
└── index.js                   # Entry point, exposes global API
```

---

## **GraphRuntime**

*Central coordinator for graph state and lifecycle*

**Properties:**
```javascript
{
  currentGraphId: string,
  version: number,
  nodes: Map<nodeId, Node>,
  edges: Map<edgeId, Edge>,
  bodies: Map<nodeId, Matter.Body>,
  constraints: Map<edgeId, Matter.Constraint>,
  ports: Map<portKey, PortHitbox>,
  dirtyLayout: Set<nodeId>,
  physicsWorld: PhysicsWorld,
  renderer: Renderer,
  interaction: InteractionController
}
```

**API:**
```javascript
// Load complete graph snapshot
loadGraph(snapshot: GraphSnapshot): void

// Apply incremental changes
applyPatch(patch: GraphPatch): void

// Export current layout (positions only)
exportLayout(): { nodeId: { x, y } }

// Navigation
setGraphId(graphId: string): void

// Cleanup
destroy(): void
```

**Lifecycle:**
1. Parse incoming snapshot
2. Create/update Node models
3. Create Matter bodies
4. Create Edge models
5. Create Matter constraints
6. Register port hitboxes
7. Initialize renderer
8. Start physics loop

---

## **PhysicsWorld**

*Matter.js wrapper and configuration*

**Configuration:**
```javascript
{
  gravity: { x: 0, y: 0, scale: 0 },
  timing: {
    timeScale: 1,
    timestamp: 0
  },
  enableSleeping: false,
  velocityIterations: 8,
  positionIterations: 6
}
```

**Node Body Defaults:**
```javascript
{
  frictionAir: 0.25,      // High damping for stable layout
  friction: 0.1,
  restitution: 0,
  density: 0.001,
  inertia: Infinity,      // Prevent rotation
  collisionFilter: {
    group: -1,            // Disable node-node collisions
    category: 0x0001,
    mask: 0x0000
  }
}
```

**Constraint Defaults (Flow Edges):**
```javascript
{
  stiffness: 0.01,        // Soft spring
  damping: 0.9,           // Heavy damping
  length: 120,            // Preferred vertical distance
  render: { visible: false }
}
```

**Constraint Defaults (Data Edges):**
```javascript
{
  stiffness: 0.005,       // Softer than flow
  damping: 0.85,
  length: 200,            // Preferred horizontal distance
  render: { visible: false }
}
```

**Drag Enhancement:**
```javascript
// When user drags a node
onDragStart(nodeId) {
  const body = bodies.get(nodeId);
  body.frictionAir = 0.5; // Increase damping
  
  // Optionally: temporarily stiffen connected edges
  const edges = getConnectedEdges(nodeId);
  edges.forEach(edge => {
    const constraint = constraints.get(edge.id);
    constraint._originalStiffness = constraint.stiffness;
    constraint.stiffness *= 2.0; // Double stiffness
  });
}

onDragEnd(nodeId) {
  const body = bodies.get(nodeId);
  body.frictionAir = 0.25; // Restore
  
  const edges = getConnectedEdges(nodeId);
  edges.forEach(edge => {
    const constraint = constraints.get(edge.id);
    constraint.stiffness = constraint._originalStiffness;
  });
}
```

---

## **Renderer (p5.js)**

*All visual output*

**Draw Order:**
1. Background (clear or transparent)
2. Grid (optional, subtle dots)
3. Edges (back to front by selection state)
4. Nodes (back to front by selection state)
5. Ports
6. Selection outlines
7. Hover highlights
8. Temporary link preview (if linking)
9. Debug overlays (optional)

**Node Drawing:**
```javascript
drawNode(node, body) {
  push();
  translate(body.position.x, body.position.y);
  
  // Shadow
  drawingContext.shadowBlur = 8;
  drawingContext.shadowColor = 'rgba(0,0,0,0.3)';
  
  // Body
  fill(node.ui.color || getTypeColor(node.type));
  noStroke();
  rect(-node.w/2, -node.h/2, node.w, node.h, 8); // 8px border radius
  
  // Header
  fill(darken(node.ui.color, 20));
  rect(-node.w/2, -node.h/2, node.w, 32, 8, 8, 0, 0);
  
  // Icon + Name
  fill(255);
  textAlign(LEFT, CENTER);
  text(node.name, -node.w/2 + 28, -node.h/2 + 16);
  
  // Properties
  fill(200);
  textSize(12);
  // ... draw properties
  
  pop();
}
```

**Edge Drawing (Flow):**
```javascript
drawFlowEdge(edge, fromPos, toPos) {
  const cp1y = fromPos.y + 60;
  const cp2y = toPos.y - 60;
  
  stroke(edge.style.color || '#4A90E2');
  strokeWeight(edge.isSelected ? 4 : 3);
  noFill();
  
  bezier(
    fromPos.x, fromPos.y,
    fromPos.x, cp1y,
    toPos.x, cp2y,
    toPos.x, toPos.y
  );
  
  // Arrow
  drawArrow(toPos, atan2(toPos.y - cp2y, toPos.x - toPos.x));
}
```

**Hit Testing:**
```javascript
isPointInNode(x, y, node, body) {
  const dx = x - body.position.x;
  const dy = y - body.position.y;
  return Math.abs(dx) < node.w/2 && Math.abs(dy) < node.h/2;
}

isPointInHeader(x, y, node, body) {
  const dx = x - body.position.x;
  const dy = y - body.position.y;
  return Math.abs(dx) < node.w/2 && 
         dy > -node.h/2 && dy < -node.h/2 + 32;
}

getPortAtPoint(x, y) {
  for (const [key, hitbox] of ports) {
    const d = dist(x, y, hitbox.worldX, hitbox.worldY);
    if (d < hitbox.radius) return { key, port: hitbox };
  }
  return null;
}
```

---

## **InteractionController**

*Input handling and state machines*

**States:**
- `Idle` - default state
- `Dragging` - moving node
- `Linking` - creating edge
- `Selecting` - box select (future)

**State Machine (Simplified):**
```javascript
onMousePressed(x, y) {
  // Priority 1: Port click (linking)
  const port = getPortAtPoint(x, y);
  if (port) {
    setState('Linking', { startPort: port });
    return;
  }
  
  // Priority 2: Header click (dragging)
  const node = getNodeAtPoint(x, y);
  if (node && isPointInHeader(x, y, node)) {
    setState('Dragging', { nodeId: node.id });
    physicsWorld.startDrag(node.id, x, y);
    return;
  }
  
  // Priority 3: Node body click (selection)
  if (node) {
    selectNode(node.id);
    return;
  }
  
  // Priority 4: Empty click (deselect)
  clearSelection();
}

onMouseDragged(x, y) {
  switch (state) {
    case 'Dragging':
      physicsWorld.updateDrag(x, y);
      dirtyLayout.add(state.nodeId);
      break;
    case 'Linking':
      // Visual only, no action
      break;
  }
}

onMouseReleased(x, y) {
  switch (state) {
    case 'Dragging':
      physicsWorld.endDrag();
      emitNodeMoveEnd(state.nodeId);
      setState('Idle');
      break;
    case 'Linking':
      const targetPort = getPortAtPoint(x, y);
      if (targetPort && isCompatible(state.startPort, targetPort)) {
        emitEdgeCreated({
          from: state.startPort.nodeId,
          fromPort: state.startPort.name,
          to: targetPort.nodeId,
          toPort: targetPort.name,
          kind: inferEdgeKind(state.startPort, targetPort)
        });
      }
      setState('Idle');
      break;
  }
}
```

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
