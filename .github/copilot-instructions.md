# Copilot Instructions for RMS

## General Guidelines

- Target .NET 10 and use the latest stable C# features supported by the repository.
- Prefer simple, maintainable solutions over clever abstractions.
- Preserve existing public behavior unless the task explicitly requests a breaking change.
- Make the smallest cohesive change that solves the task, and avoid unrelated refactoring.
- Keep nullable reference types enabled and treat compiler warnings as issues to resolve.
- Maintain repository-level GitHub Copilot instructions covering .NET 10/C# coding standards, ASP.NET Core layered architecture, dependency injection, async APIs, validation, security, testing, and documentation practices.

## Solution Architecture

Use the existing project boundaries as a layered architecture:

- `RMS.Api`: HTTP transport only—controllers, request/response DTOs, middleware, authentication, and dependency-injection composition.
- `RMS.Services`: application and domain use cases—business rules, orchestration, and service implementations.
- `RMS.Common`: contracts and shared domain models—interfaces, DTOs, value objects, constants, and cross-project primitives.
- `RestaurantManagementSystem`: executable or host-specific code; do not introduce API business logic here.

Dependency direction must point inward: API may depend on Services and Common; Services may depend on Common; Common must not depend on API or Services. Keep controllers thin and do not place business rules, persistence logic, or complex transformations in them.

Use dependency inversion: depend on interfaces at layer boundaries and register implementations in the API composition root. Keep services focused on one use case or cohesive capability. Introduce a repository or gateway abstraction only when persistence or an external system requires it; do not add abstractions speculatively.

## C# and Naming Standards

- Use file-scoped namespaces, four-space indentation, and one public type per file where practical.
- Use PascalCase for types, methods, properties, and constants; camelCase for parameters and local variables; prefix interfaces with `I`.
- Use descriptive names and correct spelling in all new code. Do not copy existing typos into new APIs; rename existing public symbols only when compatibility is addressed.
- Prefer `record` types for immutable request/response DTOs and value-like data. Keep mutable entities and domain models intentional.
- Prefer `var` when the type is clear from the right-hand side; use explicit types when it improves readability.
- Use expression-bodied members only when they remain clear.
- Avoid magic strings and numbers; use named constants, options, enums, or strongly typed values.
- Use `decimal` for monetary values, never `double` or `float`.
- Prefer immutable collections and read-only views when data should not be modified.
- Do not add comments that merely restate code. Document non-obvious business rules and public APIs when useful.

## ASP.NET Core API Practices

- Use attribute routing and RESTful resource-oriented routes.
- Use request and response DTOs at the API boundary; do not expose internal domain or persistence models directly.
- Validate input at the boundary with data annotations or the project’s chosen validation approach. Return appropriate 4xx responses for invalid input and missing resources.
- Return precise status codes and consistent response shapes. Use `ProblemDetails` for errors and avoid leaking stack traces, secrets, or internal implementation details.
- Keep authentication and authorization explicit. Apply least privilege and authorize every protected operation.
- Configure middleware in the correct order and keep environment-specific behavior out of production paths.
- Use configuration binding with strongly typed options and validate required configuration during startup.
- Do not hard-code credentials, tokens, connection strings, or other secrets. Use user secrets, environment variables, or a supported secret store.
- Configure CORS, HTTPS, rate limiting, request size limits, and security headers deliberately when the API requires them.
- Keep OpenAPI documentation accurate for public endpoints, including request validation, response codes, and authorization requirements.

## Services and Asynchronous Code

- Use asynchronous APIs for I/O and propagate `CancellationToken` from controller to service and data-access boundaries.
- Do not use `.Result`, `.Wait()`, or `async void` in application code.
- Avoid fire-and-forget work in request handlers; use a hosted background service or durable queue when needed.
- Keep business rules in services or domain types, not controllers.
- Validate invariants before changing state and make side effects explicit.
- Use structured logging with meaningful event context; never log passwords, tokens, payment data, or sensitive personal information.
- Handle expected failures explicitly and map them consistently to API responses. Do not catch `Exception` unless adding context, translating the error, or handling it at a deliberate boundary.
- Dispose owned resources correctly and use `IHttpClientFactory` for outbound HTTP calls.

## Data, Reliability, and Performance

- Use parameterized queries or the approved data-access library; never concatenate untrusted input into queries or commands.
- Make data-access operations cancellable and avoid N+1 queries and unbounded result sets.
- Add pagination, filtering, and sorting for collection endpoints that may grow.
- Use idempotency and appropriate transaction boundaries for operations that can be retried.
- Measure before optimizing. Prefer clear algorithms and avoid premature caching.
- Treat external calls as unreliable: configure timeouts, validate responses, and use retries only for transient failures with bounded backoff.

## Testing Requirements

- Add or update tests for behavior changes and bug fixes.
- Prefer unit tests for business rules and focused integration tests for HTTP, dependency injection, serialization, authorization, and persistence boundaries.
- Test success paths, validation failures, authorization failures, not-found cases, conflict cases, cancellation, and external dependency failures where applicable.
- Keep tests deterministic, isolated, readable, and independent of execution order. Do not rely on real external services or time without controllable abstractions.
- Use test names that describe behavior, such as `Method_WhenCondition_ShouldOutcome`.

## Change Workflow

1. Inspect existing conventions, interfaces, registrations, and call sites before editing.
2. Define or update contracts before implementations when a cross-layer change is required.
3. Implement the smallest cohesive change while preserving dependency direction.
4. Add or update tests and API documentation for observable behavior changes.
5. Run formatting, targeted tests, and then the full build/test suite when practical.
6. Review the diff for accidental files, secrets, breaking changes, nullable warnings, and unrelated edits.

Do not add packages, projects, frameworks, or architectural layers unless the requirement cannot be met with the existing stack and the tradeoff is clear.
