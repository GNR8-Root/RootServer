#  Design System

---

> Tailwind-first approach: tokens described using Tailwind-like utility mapping with CSS variables as references.

## Color Palette

### Primary / Accent

| Color | Hex | Usage |
|-------|-----|-------|
| Primary Blue | `#4A90E2` | Primary actions, Flow edges |
| Primary Orange | `#E2A04A` | Data edges, data highlights |
| Primary Green | `#5CB85C` | Success, valid targets |
| Primary Red | `#E74C3C` | Errors, invalid states |
| Primary Purple | `#9B59B6` | Macro nodes, special features |

### Background & Surface (Dark Theme)

| Color | Hex | Usage |
|-------|-----|-------|
| BG Primary | `#0b0b0d` | Canvas background (near zinc-950) |
| BG Secondary | `#1a1a1a` | Panels + node body base (zinc-900-ish) |
| BG Tertiary | `#242424` | Headers, raised chips |
| BG Elevated | `#2f2f2f` | Hover, popovers |

### Text

| Color | Hex | Usage |
|-------|-----|-------|
| Text Primary | `#ffffff` | Primary text |
| Text Secondary | `#cccccc` | Body text |
| Text Tertiary | `#888888` | Hints / disabled |
| Text Inverse | `#0b0b0d` | Text on bright surfaces |

### Semantic

| Color | Hex | Usage |
|-------|-----|-------|
| Success | `#5CB85C` | Positive states |
| Warning | `#F0AD4E` | Cautionary states |
| Error | `#E74C3C` | Error states |
| Info | `#5BC0DE` | Informational states |

### Tailwind Mapping (Guidance)

- **Canvas**: `bg-zinc-950`
- **Surfaces**: `bg-white/5`, `bg-zinc-900/60`
- **Borders**: `border border-white/10`
- **Primary text**: `text-zinc-100`
- **Secondary text**: `text-zinc-400`

---

## Typography

### Font Families

```css
--font-primary: 'Inter', -apple-system, BlinkMacSystemFont, 'Segoe UI', sans-serif;
--font-mono: 'JetBrains Mono', 'Fira Code', 'Consolas', monospace;
```

### Type Scale

| Use Case | Size | Weight | Line Height | Tailwind Example |
|----------|------|--------|-------------|------------------|
| Display | 32px | 700 | 1.2 | `text-3xl font-bold tracking-tight` |
| H1 | 24px | 600 | 1.3 | `text-2xl font-semibold` |
| H2 | 20px | 600 | 1.4 | `text-xl font-semibold` |
| H3 | 16px | 600 | 1.4 | `text-base font-semibold` |
| Body | 14px | 400 | 1.5 | `text-sm leading-6` |
| Caption | 12px | 400 | 1.4 | `text-xs text-zinc-400` |
| Code | 13px | 400 | 1.6 | `font-mono text-xs leading-6` |

## Spacing System

**Base Unit**: 4px

| Variable | Value | Usage |
|----------|-------|-------|
| `--space-1` | 4px | Minimal spacing |
| `--space-2` | 8px | Tight spacing |
| `--space-3` | 12px | Compact spacing |
| `--space-4` | 16px | Base spacing |
| `--space-5` | 24px | Comfortable spacing |
| `--space-6` | 32px | Generous spacing |
| `--space-7` | 48px | Large spacing |
| `--space-8` | 64px | Extra large spacing |

## Elevation & Shadows

```css
--shadow-sm: 0 1px 2px rgba(0, 0, 0, 0.30);
--shadow-md: 0 6px 18px rgba(0, 0, 0, 0.35);
--shadow-lg: 0 10px 30px rgba(0, 0, 0, 0.45);

--shadow-glow-blue: 0 0 20px rgba(74, 144, 226, 0.35);
--shadow-glow-orange: 0 0 20px rgba(226, 160, 74, 0.35);
--shadow-glow-error: 0 0 20px rgba(231, 76, 60, 0.35);
```

**Tailwind Guidance**:
- Cards/panels: `shadow-[0_10px_30px_rgba(0,0,0,.35)]`
- Glow on selection: simulated in p5 (shadowBlur) or CSS overlays for DOM UI

## Border Radius

| Variable | Value | Usage |
|----------|-------|-------|
| `--radius-sm` | 4px | Small elements |
| `--radius-md` | 8px | Default elements |
| `--radius-lg` | 12px | Large elements |
| `--radius-xl` | 16px | Extra large elements |
| `--radius-full` | 9999px | Circular elements |

**Tailwind**:
- Buttons/inputs: `rounded-xl`
- Panels: `rounded-2xl`
- Pills: `rounded-full`

## Animation Timing

```css
--duration-instant: 0ms;
--duration-fast: 100ms;
--duration-base: 200ms;
--duration-slow: 300ms;
--duration-slower: 500ms;

--ease-in: cubic-bezier(0.4, 0.0, 1, 1);
--ease-out: cubic-bezier(0.0, 0.0, 0.2, 1);
--ease-in-out: cubic-bezier(0.4, 0.0, 0.2, 1);
--ease-spring: cubic-bezier(0.34, 1.56, 0.64, 1);
```

---

[← Node-Editor](node-editor.md)
1. **[Base](node-editor-00-base-index.md)** – what the editor is and how it works conceptually
2. **[Architecture](node-editor-12-arch-index.md)** – how the system is structured and implemented
3. **[UI](node-editor-26-ui-index.md)** – how users interact with the editor
4. **[Appendix](node-editor-39-appendix-index.md)** – technical details and references
5. **[Diagrams](node-editor-43-diagrams.md)** – flowcharts and other visual representations

---
