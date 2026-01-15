# Quick Start

---

## Run in 5 Minutes

### Step 1: Clone & Restore (1 min)
```bash
git clone <repo-url>
cd RootServer
dotnet restore
```

### Step 2: Configure (2 min)
```bash
dotnet user-secrets init
dotnet user-secrets set "Airtable:ApiKey" "your-key"
dotnet user-secrets set "Airtable:BaseId" "your-base-id"
```

### Step 3: Run (2 min)
```bash
dotnet run
```

Open https://localhost:5001

---

## Quick Commands

```bash
# Build
dotnet build

# Run
dotnet run

# Test (when tests exist)
dotnet test

# Publish
dotnet publish -c Release

# Clean
dotnet clean
```

---

---

**Navigation**

- **[← Onboarding](rootserver-46-devops-onboarding.md)**
- **[Debugging →](rootserver-48-devops-debugging.md)**
- **[Home](rootserver.md)**

---
