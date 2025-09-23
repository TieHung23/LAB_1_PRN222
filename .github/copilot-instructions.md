# Copilot Seed Instructions for EVDMS Project

This file contains instructions and prompts for GitHub Copilot to generate seed data in the EVDMS project following a consistent format.

---

## 1. Seed Roles

**Purpose:** Generate seed data for the `Role` entity with deterministic values.

**Prompt for Copilot:**

```csharp
// Copilot: Generate a seed method for Role entity in EF Core
/*
- Seed 4 roles: "Dealer Staff", "Dealer Manager", "EVM Staff", "Admin"
- Each Role has Id (fixed GUID), Name, Description, CreatedById, CreatedAt, CreatedAtTick
- Include UpdatedAt and UpdatedAtTick (same values as CreatedAt/CreatedAtTick)
- Use static/deterministic values, no Guid.NewGuid() or DateTime.Now
- Method should be separate and callable from OnModelCreating
- Compatible with EF Core HasData
*/
```

---

## 2. Seed Accounts

**Purpose:** Generate seed data for 2 initial `Account` entities based on existing Roles.

**Prompt for Copilot:**

```csharp
// Copilot: Generate a seed method for 2 initial Account entities
/*
- Assume Role data is already seeded
- Create 1 Account with Role = Admin and 1 Account with Role = EVM Staff
- Set UserName, HashedPassword, FullName, IsActive, IsDeleted
- Use static/deterministic Id, CreatedById, CreatedAt, CreatedAtTick, UpdatedAt, UpdatedAtTick
- Compatible with EF Core HasData
- Method should be separate and callable from OnModelCreating
- Use Role IDs:
    Admin: 44444444-4444-4444-4444-444444444444
    EVM Staff: 33333333-3333-3333-3333-333333333333
*/
```

---

## 3. Seed Other Entities Based on Roles

**Purpose:** Generate seed data for all other entities except `Role` and initial `Account`, using existing Role IDs.

**Prompt for Copilot:**

```csharp
// Copilot: Generate a seed method for all other entities except Role and initial Account
/*
- Assume Role and initial Account data are already seeded
- Use static/deterministic values for Id, CreatedAt, CreatedAtTick, UpdatedAt, UpdatedAtTick
- Assign RoleId where needed
- Compatible with EF Core HasData
- Include navigation properties only if necessary, otherwise use foreign key IDs
- Method should be separate and callable from OnModelCreating
*/
```

---

**Notes:**

- Always call the generated seed methods from OnModelCreating in ApplicationDbContext.
- Keep all GUIDs and timestamps static to prevent EF Core PendingModelChangesWarning.
