# Onboarding

---

## New Developer Onboarding

**Time Estimate**: 2-4 hours

---

## Prerequisites

1. Install `.NET 10.0 SDK`
2. Install `JetBrains Rider` or `Visual Studio 2022+`
3. Request `Airtable API` key from arnold@znzr.io
4. Clone repository

---

## Setup Steps

### 1. Environment Setup (30 min)
```bash
# Verify .NET installation
dotnet --version  # Should show 10.0.x

# Clone repository (if not done)
git clone <repository-url>
cd RootServer

# Restore dependencies
dotnet restore
```

### 2. Configure Secrets (15 min)
```bash
# Use user secrets for development
dotnet user-secrets init
dotnet user-secrets set "Airtable:ApiKey" "your-key"
dotnet user-secrets set "Airtable:BaseId" "your-base-id"
```

### 3. First Run (15 min)
```bash
# Run application
dotnet run

# Open browser to https://localhost:5001
# Verify public site loads
# Navigate to /editor
# Test Airtable sync
```

### 4. IDE Configuration (30 min)
- Open `RootServer.sln` in Rider
- Configure code style settings
- Install recommended plugins
- Set up debugging profiles

### 5. Read Documentation (1-2 hours)
- Review **[Architecture Overview](rootserver-01-arch-overview.md)**
- Understand **[Component Model](rootserver-06-component-model.md)**
- Study **[UI Hierarchy](rootserver-27-ui-hierarchy.md)**

---

## Key Concepts to Learn

1. Numbered hierarchy (`00_Core` → `09_Panels`)
2. Component prefixes (`D_`, `F_`, `P_`, `A_`, etc.)
3. Wrapper + Base pattern
4. Event-driven architecture
5. Service-based DI

---

## First Tasks

### Beginner Tasks
- Fix a typo in documentation
- Add a simple display component
- Update a color in CSS

### Intermediate Tasks
- Add a new section to the public site
- Implement a new pointer component
- Add a field to an existing table model

### Advanced Tasks
- Design a new plugin
- Implement a complex action
- Optimize a performance bottleneck

---

## Getting Help

- Review documentation
- Ask in team chat
- Pair programming session
- Code review feedback

---

---

**Navigation**

- **[← DevOps Index](rootserver-45-devops-index.md)**
- **[Quick Start →](rootserver-47-devops-quick-start.md)**
- **[Home](rootserver.md)**

---
