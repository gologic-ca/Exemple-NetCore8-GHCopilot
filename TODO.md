# TODO List - Exemple NetCore8 GHCopilot Issues

This document contains a comprehensive list of issues and improvements identified in the codebase.

## 🔴 High Priority Issues

### 1. Incorrect Handler Naming Convention
**Files affected:**
- `src/Conduit/Features/Followers/Add.cs` (line 23)
- `src/Conduit/Features/Followers/Delete.cs` (line 22)
- `src/Conduit/Features/Favorites/Add.cs` (line 23)
- `src/Conduit/Features/Favorites/Delete.cs` (line 22)
- `src/Conduit/Features/Comments/Delete.cs` (line 22)
- `src/Conduit/Features/Articles/Delete.cs` (line ~20)

**Issue:** Handler classes for `Command` requests are incorrectly named `QueryHandler` instead of `CommandHandler`. This violates CQRS pattern conventions where Commands represent write operations and should have CommandHandlers, while Queries represent read operations and should have QueryHandlers.

**Impact:** Confusing naming that makes the codebase harder to understand and maintain.

**Recommended fix:** Rename all `QueryHandler` classes that implement `IRequestHandler<Command, TResponse>` to `CommandHandler`.

---

### 2. Missing ValidationException Handling in ErrorHandlingMiddleware
**File affected:** `src/Conduit/Infrastructure/Errors/ErrorHandlingMiddleware.cs` (line 44-56)

**Issue:** The `ErrorHandlingMiddleware` only handles `RestException` and defaults all other exceptions to `InternalServerError`. However, `ValidationException` (thrown by `ValidationPipelineBehavior`) is not explicitly handled, which means validation errors return a generic 500 error instead of a proper 400 Bad Request with validation details.

**Impact:** Poor API error responses for validation failures, making it difficult for API consumers to understand what went wrong.

**Recommended fix:** Add a case for `ValidationException` to return 422 Unprocessable Entity or 400 Bad Request with validation error details.

---

### 3. Dockerfile Uses Wrong Base Image
**File affected:** `Dockerfile` (line 3)

**Issue:** The Dockerfile uses `mcr.microsoft.com/dotnet/runtime:8.0` as the base image, but Conduit is an ASP.NET Core web application that requires `mcr.microsoft.com/dotnet/aspnet:8.0` which includes the ASP.NET Core runtime.

**Impact:** The application will not run properly in the Docker container because the ASP.NET Core runtime is missing.

**Recommended fix:** Change `FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base` to `FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base`.

---

## 🟡 Medium Priority Issues

### 4. Hardcoded Database Configuration
**File affected:** `src/Conduit/Program.cs` (lines 15-16, 21, 24)

**Issue:** Database connection string and provider are hardcoded instead of being read from environment variables or configuration files. The comments indicate they should come from environment variables, but the implementation doesn't actually read them.

**Impact:** Difficult to configure for different environments (development, staging, production).

**Recommended fix:** Actually read from environment variables or appsettings.json:
```csharp
var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING") ?? defaultDatabaseConnectionString;
var databaseProvider = Environment.GetEnvironmentVariable("DATABASE_PROVIDER") ?? defaultDatabaseProvider;
```

---

### 5. Duplicate CustomSchemaIds Configuration
**File affected:** `src/Conduit/Program.cs` (lines 83, 86)

**Issue:** `x.CustomSchemaIds()` is called twice with different configurations in the Swagger setup, which may cause confusion or unexpected behavior.

**Impact:** The second call may override the first, leading to inconsistent schema naming.

**Recommended fix:** Consolidate into a single `CustomSchemaIds` call or clarify the intention.

---

### 6. Unused Database Context Variable
**File affected:** `src/Conduit/Program.cs` (line 131)

**Issue:** The result of `Database.EnsureCreated()` is assigned to `dbContext` variable but never used. The variable name is misleading as it contains a boolean, not a context.

**Impact:** Confusing code that suggests the context is being stored when it's actually just a boolean result.

**Recommended fix:** Either remove the assignment or use a better variable name:
```csharp
var created = scope.ServiceProvider.GetRequiredService<ConduitContext>().Database.EnsureCreated();
```

---

### 7. Inconsistent Error Messages
**File affected:** Multiple files in `src/Conduit/Features/Favorites/Add.cs` (lines 40, 53)

**Issue:** In `Favorites/Add.cs`, when a person is not found (line 53), the error message says `{ Article = Constants.NOT_FOUND }` instead of `{ User = Constants.NOT_FOUND }`.

**Impact:** Misleading error messages that make debugging harder.

**Recommended fix:** Change line 53 to use `{ User = Constants.NOT_FOUND }`.

---

### 8. Redundant Null Check After Throw Expression
**File affected:** `src/Conduit/Features/Favorites/Add.cs` (lines 75-84)

**Issue:** After successfully adding a favorite and saving changes, the code retrieves the article again and checks if it's null. This is redundant because the article was just used and saved successfully.

**Impact:** Unnecessary database query and confusing logic.

**Recommended fix:** Refactor to reload article data more efficiently or remove the redundant check.

---

## 🟢 Low Priority / Enhancement Issues

### 9. Missing XML Documentation Comments
**Files affected:** All feature files, infrastructure files

**Issue:** The codebase lacks XML documentation comments (`///`) for public classes, methods, and properties.

**Impact:** Reduced code maintainability and no IntelliSense documentation for developers.

**Recommended fix:** Add XML documentation comments to all public APIs.

---

### 10. Typo in Variable Name
**File affected:** `src/Conduit/Program.cs` (line 15)

**Issue:** Variable name `defaultDatabaseConnectionSrting` has a typo (missing 't' in "String").

**Impact:** Minor - code works but looks unprofessional.

**Recommended fix:** Rename to `defaultDatabaseConnectionString`.

---

### 11. Missing NuGet Package Updates for Dependabot
**File affected:** `.github/dependabot.yml`

**Issue:** Dependabot is only configured to check for GitHub Actions updates, but not for NuGet package updates.

**Impact:** Dependencies may become outdated without automatic notification.

**Recommended fix:** Add NuGet ecosystem to dependabot.yml:
```yaml
- package-ecosystem: "nuget"
  directory: "/"
  schedule:
    interval: "weekly"
```

---

### 12. No Health Check Endpoint
**File affected:** `src/Conduit/Program.cs`

**Issue:** The application doesn't expose a health check endpoint, which is a best practice for production applications and container orchestration.

**Impact:** Difficult to monitor application health in production environments.

**Recommended fix:** Add health checks using ASP.NET Core Health Checks:
```csharp
builder.Services.AddHealthChecks();
app.MapHealthChecks("/health");
```

---

### 13. CORS Configuration Too Permissive
**File affected:** `src/Conduit/Program.cs` (line 116)

**Issue:** CORS is configured to allow any origin, any header, and any method (`AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()`).

**Impact:** Security risk - any website can make requests to this API.

**Recommended fix:** Configure CORS to only allow specific origins in production:
```csharp
app.UseCors(x => x
    .WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>())
    .AllowAnyHeader()
    .AllowAnyMethod());
```

---

### 14. Missing Async Validation
**File affected:** `src/Conduit/Infrastructure/ValidationPipelineBehavior.cs` (line 25)

**Issue:** Validators are executed synchronously using `v.Validate(context)`, but FluentValidation supports async validation with `ValidateAsync`.

**Impact:** Cannot use async validation rules (e.g., checking database for unique values).

**Recommended fix:** Change to use `ValidateAsync` and await the results.

---

### 15. Redundant Task.FromResult in Comments/Delete Handler
**File affected:** `src/Conduit/Features/Comments/Delete.cs` (line 44)

**Issue:** The handler returns `await Task.FromResult(Unit.Value)` which is redundant since the method is already async and MediatR handles void returns.

**Impact:** Unnecessary code that adds no value.

**Recommended fix:** Simply return after `SaveChangesAsync`, or just use `return;`.

---

### 16. Missing Integration Tests for Error Scenarios
**File affected:** `tests/Conduit.IntegrationTests/Features/Users/CreateTests.cs`

**Issue:** Only one test exists for user creation. There are no tests for error scenarios like validation failures, duplicate users, etc.

**Impact:** Incomplete test coverage may allow bugs to slip through.

**Recommended fix:** Add more integration tests covering error scenarios and edge cases.

---

### 17. No Logging Configuration
**File affected:** `src/Conduit/Program.cs`

**Issue:** While Serilog is referenced (`AddSerilogLogging()`), there's no configuration for log levels, sinks, or formatting visible in the Program.cs.

**Impact:** Unclear logging behavior and potentially missing important logs.

**Recommended fix:** Add explicit Serilog configuration or reference the configuration file.

---

### 18. Build Project Name Confusion
**File affected:** `build/build.csproj`, `Dockerfile`

**Issue:** The project has a `build` directory with a `build.csproj` that seems to be a build automation project, but this is not clearly documented and may confuse developers.

**Impact:** Developers may not understand the purpose of the build project.

**Recommended fix:** Add documentation explaining the purpose of the build project, or consider using standard .NET build targets.

---

### 19. Missing .dockerignore Optimization
**File affected:** `.dockerignore`

**Issue:** Should verify that .dockerignore properly excludes unnecessary files to optimize Docker build context.

**Impact:** Slower Docker builds and larger build contexts.

**Recommended fix:** Review and ensure .dockerignore includes bin/, obj/, .git/, etc.

---

### 20. No API Versioning Strategy
**File affected:** `src/Conduit/Program.cs`

**Issue:** The API is currently at v1 (Swagger: "v1"), but there's no versioning strategy in place for future API changes.

**Impact:** Difficult to evolve the API without breaking existing clients.

**Recommended fix:** Implement API versioning using `Microsoft.AspNetCore.Mvc.Versioning` package.

---

## Summary

- **High Priority:** 3 critical issues that should be fixed immediately
- **Medium Priority:** 6 issues that affect code quality and maintainability  
- **Low Priority:** 11 enhancements and best practices improvements

**Total Issues:** 20

---

## Contributing

When fixing these issues:
1. Create a separate branch for each issue
2. Write tests that verify the fix
3. Update documentation as needed
4. Submit a pull request with a clear description

## References

- [CQRS Pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [ASP.NET Core Error Handling](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling)
- [Docker Best Practices](https://docs.docker.com/develop/dev-best-practices/)
- [FluentValidation Documentation](https://docs.fluentvalidation.net/)
