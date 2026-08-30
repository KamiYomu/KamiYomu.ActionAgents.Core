---

description: Get best practices for XUnit unit and integration testing, including data-driven tests and Moq-based dependency mocking
metadata:
github-path: skills/csharp-xunit
github-ref: refs/heads/main
github-repo: https://github.com/github/awesome-copilot
github-tree-sha: ca9d2dfbdb73ccd77e9f75a7492be95e53d9d57a
name: csharp-xunit
------------------

# XUnit Testing Best Practices

Your goal is to help me write effective tests with XUnit, including unit tests, integration tests, data-driven tests, and appropriate use of Moq.

## Project Setup

* Use a separate test project with naming convention `[ProjectName].Tests`
* Reference Microsoft.NET.Test.Sdk, xunit, and xunit.runner.visualstudio packages
* Use Moq when mocking is required
* Create test classes that match the classes being tested (e.g., `CalculatorTests` for `Calculator`)
* Use .NET SDK test commands: `dotnet test` for running tests

## Test Types

Distinguish clearly between unit tests and integration tests.

### Unit Tests

Unit tests should:

* Test a single class or unit of behavior
* Isolate the system under test from external dependencies
* Use Moq to mock dependencies when appropriate
* Avoid accessing databases, filesystems, HTTP services, or other external systems
* Be fast, deterministic, and independent

### Integration Tests

Integration tests should:

* Test how multiple components work together
* Use real implementations for the components being integrated
* Mock only external boundaries that are not part of the integration being tested
* Use Moq when an external dependency needs to be controlled or isolated
* Prefer testing realistic dependency interactions instead of mocking internal implementation details
* Avoid mocking the system under test
* Avoid excessive mocking that turns an integration test into a unit test

Examples of appropriate integration-test mocking:

* External HTTP APIs
* Third-party services
* Message brokers
* Email providers
* Cloud services
* External filesystem/storage services

When possible, use a real database, test database, SQLite, containerized dependency, or other realistic infrastructure when the purpose of the test is to verify that integration.

## Test Structure

* No test class attributes required (unlike MSTest/NUnit)
* Use `[Fact]` for simple tests
* Use `[Theory]` for data-driven tests
* Follow the Arrange-Act-Assert (AAA) pattern
* Name tests using the pattern `MethodName_Scenario_ExpectedBehavior`
* Use the constructor for test setup
* Use `IDisposable.Dispose()` for teardown when necessary
* Use `IClassFixture<T>` for shared context between tests in a class
* Use `ICollectionFixture<T>` for shared context between multiple test classes

## Standard Tests

* Keep tests focused on a single behavior
* Avoid testing multiple unrelated behaviors in one test method
* Use clear assertions that express intent
* Include only the assertions needed to verify the behavior
* Make tests independent and idempotent
* Avoid test interdependencies
* Avoid unnecessary setup and abstraction

## Data-Driven Tests

* Use `[Theory]` for data-driven tests
* Use `[InlineData]` for simple inline test data
* Use `[MemberData]` for method-based test data
* Use `[ClassData]` for class-based test data
* Create custom data attributes by implementing `DataAttribute` when necessary
* Use meaningful parameter names
* Prefer data-driven tests when the same behavior needs to be verified against multiple inputs

## Assertions

Use the appropriate XUnit assertion for the behavior being tested:

* `Assert.Equal` for value equality
* `Assert.NotEqual` for inequality
* `Assert.Same` for reference equality
* `Assert.NotSame` for reference inequality
* `Assert.Null` / `Assert.NotNull` for nullability
* `Assert.True` / `Assert.False` for boolean conditions
* `Assert.Contains` / `Assert.DoesNotContain` for collections and strings
* `Assert.Empty` / `Assert.NotEmpty` for collections
* `Assert.Single` when exactly one item is expected
* `Assert.Matches` / `Assert.DoesNotMatch` for regular expressions
* `Assert.Throws<T>` for synchronous exceptions
* `await Assert.ThrowsAsync<T>` for asynchronous exceptions

Prefer assertions that directly express the expected behavior.

## Moq

Use Moq to isolate dependencies in unit tests and to control external boundaries in integration tests.

### Creating Mocks

Prefer mocking interfaces:

```csharp
var repository = new Mock<IChapterRepository>();
```

Configure only the behavior required by the test:

```csharp
repository
    .Setup(x => x.GetByIdAsync(chapterId))
    .ReturnsAsync(chapter);
```

Avoid configuring unnecessary members.

### Verification

Use `Verify` when the interaction itself is part of the behavior being tested:

```csharp
repository.Verify(
    x => x.GetByIdAsync(chapterId),
    Times.Once);
```

Do not verify every method call by default.

Prefer state/output assertions when they adequately verify the behavior.

### Strict vs Loose Mocks

Use `MockBehavior.Strict` when unexpected interactions should fail the test and the dependency contract is important.

Use loose mocks when strict verification would add unnecessary coupling to implementation details.

Do not use strict mocks automatically for every test.

### Async Dependencies

Use Moq's async APIs:

```csharp
mock
    .Setup(x => x.ExecuteAsync(It.IsAny<CancellationToken>()))
    .ReturnsAsync(result);
```

Avoid blocking asynchronous code with `.Result` or `.Wait()`.

### Argument Matching

Use `It.Is<T>()` when the exact argument is not important but specific conditions must be satisfied:

```csharp
mock.Verify(
    x => x.SaveAsync(It.Is<Chapter>(c => c.Id == chapterId)),
    Times.Once);
```

Avoid overly broad `It.IsAny<T>()` when verifying important behavior.

## Moq in Integration Tests

When writing integration tests, first determine what the test is intended to integrate.

### Mock External Boundaries

Moq can be used to replace dependencies outside the integration boundary.

For example:

```csharp
var externalService = new Mock<IExternalService>();

externalService
    .Setup(x => x.GetDataAsync(It.IsAny<CancellationToken>()))
    .ReturnsAsync(expectedData);
```

Then use the real application components being tested with the mocked external service injected through dependency injection.

### Do Not Over-Mock

Do not mock:

* The system under test
* Components whose real behavior is the purpose of the integration test
* Internal classes merely to make the test easier to write
* Database repositories when the purpose is to test database integration

If the purpose is to test:

```text
Service ? Repository ? Database
```

use the real repository and a test database.

If the purpose is to test:

```text
Service ? External API
```

it may be appropriate to use Moq for the external API boundary.

### Integration Test Dependency Injection

Prefer replacing dependencies through the application's existing dependency-injection configuration rather than manually constructing large object graphs.

For example:

```csharp
services.AddSingleton<IExternalService>(
    externalService.Object);
```

Keep the production components under test configured as close as possible to the real application.

## Test Organization

* Group tests by feature or component
* Use `[Trait("Category", "CategoryName")]` for categorization
* Consider separate categories for `Unit`, `Integration`, and `E2E`
* Use fixtures for expensive shared infrastructure
* Use `IClassFixture<T>` for shared test resources
* Use `ICollectionFixture<T>` when resources must be shared across multiple test classes
* Use `ITestOutputHelper` for test diagnostics
* Skip tests conditionally with `Skip = "reason"` when appropriate

## Integration Test Isolation

Integration tests must remain deterministic.

* Do not depend on production databases
* Do not depend on real third-party services unless explicitly testing that integration
* Use dedicated test databases or test containers when appropriate
* Clean up test data after execution
* Avoid relying on test execution order
* Avoid shared mutable state between tests
* Use fixtures for expensive infrastructure rather than sharing mutable test data

## Test Quality

Before writing tests:

1. Identify the behavior being tested.
2. Determine whether the test is a unit or integration test.
3. Inspect existing tests for project conventions.
4. Identify the minimum required dependencies.
5. Use Moq only where isolation or external-boundary control is useful.

When reviewing tests:

* Remove unnecessary mocks
* Remove unnecessary verifications
* Remove duplicate assertions
* Avoid testing implementation details
* Prefer behavior-focused tests
* Keep tests readable
* Keep unit tests fast
* Keep integration tests realistic

## Scope

When working on tests:

* Inspect the system under test and its direct dependencies first.
* Inspect existing tests for the same component.
* Only inspect unrelated code when necessary.
* Do not scan the entire repository unless the task requires it.
* Do not modify production code unless explicitly requested.
* Do not introduce new testing libraries unless explicitly requested.
* Make the smallest test changes necessary to provide meaningful coverage.
