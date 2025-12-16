# Execution

---

## Execution Model

---

The Node Editor executes graphs as **ordered, directed flows**.

- Execution starts from the **root node**
- Nodes execute when all required inputs are resolved
- Output of a node becomes input for connected nodes
- AI nodes may introduce probabilistic or branching results

Execution is **declarative**, meaning graphs describe *what should happen*, not *how it is implemented*.  
Runtime systems interpret graphs into concrete application behavior.

---

## Runtime Model

---

At runtime, graphs are:
- Loaded as structured definitions
- Transformed into execution plans
- Executed step-by-step or event-driven

Runtime does not mutate graph definitions.
Graphs remain immutable blueprints and can be:
- Versioned
- Reused
- Executed multiple times with different data

---

## Validation Rules

---

Graphs are validated before execution.

Validation includes:
- Required inputs are connected
- Node type compatibility
- Circular dependency detection
- Required data presence
- AI node configuration completeness

Validation failures prevent execution and provide **graph-level feedback**, not runtime crashes.

---

## Runtime Model - Behavior Tree Execution

---


### Status model
Every node evaluation returns exactly one of:
- `Success`
- `Failure`
- `Running`

`Running` indicates the node has started but has not completed.

---

### Tick loop
A **tick** is the fundamental evaluation step.

A tick occurs when:
- user triggers Run/Step in editor
- external runtime triggers evaluation on an interval or event

Tick algorithm:
1. Start at `Root`.
2. Evaluate node by type rules (Sequence/Selector/Decorator/etc.).
3. Stop when:
    - `Root` returns `Success` or `Failure`, or
    - a subtree returns `Running` (engine remembers the running path/state).

---

### Node memory/state
Nodes can be **stateless** or **stateful**.

Stateful examples:
- Sequence/Selector with memory (resume child index)
- Decorators like Cooldown/Repeat-Until
- Async Actions that take time

State must live in runtime memory, not Airtable:
- **Blackboard/Context** (shared variables)
- **Per-node runtime state** (e.g., running child index, timers)
- Optional **Debug trace** store

---

### Cancellation / Reset
Define explicit rules:
- **Stop**: cancels running actions and clears running-path state
- **Reset**: clears node runtime state and blackboard entries (if configured)
- **Restart**: Reset then start ticking from Root

---

### Blackboard / Context
Define how nodes share data.

Recommended:
- Key/value dictionary with typed helpers
- Scoped keys (global vs per-subtree)
- Optional “readonly” graph inputs

Minimal interface:
- `Get<T>(key, default?)`
- `Set<T>(key, value)`
- `Has(key)`
- `Unset(key)`

---

### Debugging
Recommended runtime debug outputs:
- tick count
- active/running node path
- last status per node
- action start/end timestamps
- per-node last error (if any)

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---