# TODO Items Found in Exemple-NetCore8-GHCopilot

## Summary
This document contains all TODO items, commented-out code, and potential action items found in the repository.

---

## 1. Commented-Out Code - High Priority

### build/Program.cs (Line 42)
**Status:** Commented-Out Code  
**Priority:** High  
**Description:** CSharpier formatting check is disabled
```csharp
//Run("dotnet", "csharpier --check");
```
**Action Needed:** Decide whether to enable CSharpier formatting checks or remove this line entirely.

---

### src/Conduit/Program.cs (Lines 13-14)
**Status:** Commented-Out Code  
**Priority:** Medium  
**Description:** Environment variable reading for database configuration is commented out
```csharp
//Environment.GetEnvironmentVariable(DEFAULT_DATABASE_PROVIDER)
//Environment.GetEnvironmentVariable(DEFAULT_DATABASE_CONNECTION_STRING)
```
**Action Needed:** Either implement environment variable reading or remove these comments. Currently using hard-coded defaults.

---

## 2. Informational Comments - Low Priority

### src/Conduit/Features/Articles/Create.cs (Line 65)
**Status:** Inline Comment  
**Priority:** Low  
**Description:** Comment about saving immediately for reuse
```csharp
//save immediately for reuse
await context.SaveChangesAsync(cancellationToken);
```
**Action Needed:** This is just an explanatory comment, no action needed.

---

### src/Conduit/ServicesExtensions.cs (Line 108)
**Status:** Inline Comment  
**Priority:** Low  
**Description:** Comment about local debug
```csharp
//just for local debug
```
**Action Needed:** Review if this is still relevant or if code needs cleanup.

---

## 3. Regular Explanatory Comments (No Action Required)

The following files contain regular explanatory comments that document code behavior and are not TODO items:

### src/Conduit/Infrastructure/Slug.cs (Lines 5, 15, 17, 19)
- Reference URL for slug algorithm
- Explanations of slug processing steps

### src/Conduit/Infrastructure/ConduitContext.cs (Lines 50-66)
- Detailed explanations of foreign key constraints for SQL Server compatibility

### src/Conduit/Features/Articles/Edit.cs (Lines 54, 70, 75, 78)
- Comments explaining tag management logic

### src/Conduit/Program.cs (Lines 12, 20, 23, 36, 49, 121, 124, 132)
- Configuration and middleware setup comments

### src/Conduit/ServicesExtensions.cs (Lines 66, 69, 72, 75, 77, 104)
- JWT validation configuration comments

### tests/Conduit.IntegrationTests/Features/Articles/* (Various lines)
- Test case documentation comments

---

## Action Items Summary

| Priority | Count | Description |
|----------|-------|-------------|
| High     | 1     | Commented-out formatting check |
| Medium   | 1     | Commented-out environment variable reading |
| Low      | 1     | Debug-related comment to review |
| **Total**| **3** | **Items requiring attention** |

---

## Recommendations

1. **Immediate Action:**
   - Decide on CSharpier integration (enable or remove from build/Program.cs)

2. **Short-term Action:**
   - Implement or remove environment variable configuration code in Program.cs
   - Review and clean up debug comments in ServicesExtensions.cs

3. **Best Practices:**
   - Consider using actual TODO comments in code when work is pending
   - Document architectural decisions for commented-out code
   - Regularly review and clean up commented code

---

*Generated: 2024*
*Last Updated: Initial scan*
