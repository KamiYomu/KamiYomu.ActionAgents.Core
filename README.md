# KamiYomu.ActionAgents.Core

A robust, event-driven action system for KamiYomu that enables extensible automation through triggered actions at key application moments.

## Overview

**Actions** are discrete operations triggered by KamiYomu at significant moments during application execution. They enable you to:

- ✅ Automate tasks in response to system events
- ✅ Create extensible workflows without modifying core code
- ✅ Chain multiple actions together for complex automation
- ✅ Respond to manga and chapter lifecycle events
- ✅ Build custom integrations and notifications

### Event Triggers

Actions can be triggered from various sources throughout the KamiYomu lifecycle:

| Trigger | Description |
|---------|-------------|
| **Manual** | User-initiated action execution |
| **Chained** | Triggered by the completion of another action |
| **Manga Download** | When a manga series is successfully downloaded |
| **Chapter Discovery** | When new chapters are discovered for a series |
| **Chapter Download** | When a chapter is successfully downloaded |
| **Chapter Page Read** | When a user reads a chapter page |
| **None** | Unspecified or unknown trigger (fallback) |
## Architecture

The `KamiYomu.ActionAgents.Core` library provides a lightweight, extensible framework for:

- ✅ Defining custom actions that respond to application events
- ✅ Managing action execution and lifecycle
- ✅ Creating complex automation pipelines
- ✅ Decoupling business logic from event handling

### Core Interfaces

- **`IActionAgent`**: The main interface your action must implement
- **`AbstractActionAgent`**: Base class with common functionality (logging, options, versioning)
- **`ActionAgentContext`**: Provides access to manga, chapter, and trigger source information

---

## Creating Your First Action Agent

### Step 1: Create the Project

Create a new class library targeting .NET 8.0:

```bash
dotnet new classlib -n [DeveloperName].ActionAgents.[ProductName] -f net8.0
cd [DeveloperName].ActionAgents.[ProductName]
```

### Step 2: Add the Core Package

Install the KamiYomu.ActionAgents.Core NuGet package:

```bash
dotnet add package KamiYomu.ActionAgents.Core
```

### Step 3: Create Your Action Agent

Create a new file (e.g., `MyFirstActionAgent.cs`) with a class implementing `IActionAgent`:

```csharp
using KamiYomu.ActionAgents.Core;
using KamiYomu.ActionAgents.Core.Contexts;
using Microsoft.Extensions.Logging;

namespace YourName.ActionAgents.MyAction;

public class MyFirstActionAgent : AbstractActionAgent, IActionAgent
{
	public MyFirstActionAgent(IDictionary<string, object> options) : base(options)
	{
	}

	public async Task ExecuteAsync(
		ActionAgentContext context,
		IDictionary<string, object> options,
		CancellationToken cancellationToken)
	{
		// Receive context information
		var mangaTitle = context.Manga?.Title ?? "Unknown Manga";
		var chapterNumber = context.Chapter?.Number ?? "Unknown Chapter";
		var triggerSource = context.TriggerContext?.Source.ToString() ?? "Unknown";

		Logger?.LogInformation($"Action triggered for {mangaTitle}, Chapter {chapterNumber}");
		Logger?.LogInformation($"Triggered by: {triggerSource}");

		// Perform your action here
		await Task.Delay(100, cancellationToken);

		Logger?.LogInformation("Action completed successfully!");
	}
}
```

### Step 4: Configure Package Metadata

Update your `.csproj` file to make the package discoverable by KamiYomu:

```xml
<PropertyGroup>
	<PackageTags>kamiyomu;kamiyomu-action-agents;actions;MyAction;</PackageTags>
</PropertyGroup>

<!-- Optional: Auto-generate NuGet package on Debug builds -->
<PropertyGroup Condition="'$(Configuration)' == 'Debug'">
	<GeneratePackageOnBuild>True</GeneratePackageOnBuild>
</PropertyGroup>
```

### Step 5: Build and Test

```bash
dotnet build
```

---


## Working with Action Context

The `ActionAgentContext` provides access to relevant information when your action is triggered:

### Manga Context
```csharp
var mangaTitle = context.Manga?.Title;
var mangaUrl = context.Manga?.Url;
var mangaDescription = context.Manga?.Description;
```

### Chapter Context
```csharp
var chapterNumber = context.Chapter?.Number;
var chapterUrl = context.Chapter?.URL;
var chapterReleaseDateUtc = context.Chapter?.ReleaseDateUtc;
```

### Trigger Context
```csharp
var triggerSource = context.TriggerContext?.Source; // See Action Triggers table above
var triggeredAtUtc = context.TriggerContext?.TriggeredAtUtc;
```

---


## Packaging and Publishing Your Action

### Building a Release Package

```bash
dotnet pack -c Release
```

This generates a `.nupkg` file in the `bin/Release/` directory.

### Publishing Options

Choose one of the following distribution methods:

#### 1. **NuGet.org** (Recommended for public actions)
```bash
dotnet nuget push bin/Release/YourName.ActionAgents.MyAction.*.nupkg \
	--api-key YOUR_NUGET_API_KEY \
	--source https://api.nuget.org/v3/index.json
```

#### 2. **GitHub Packages** (Good for organization-specific actions)
```bash
dotnet nuget push bin/Release/YourName.ActionAgents.MyAction.*.nupkg \
	--api-key YOUR_GITHUB_TOKEN \
	--source https://nuget.pkg.github.com/YourOrg/index.json
```

#### 3. **Azure Artifacts** (Enterprise deployments)
- Configure your credentials in Visual Studio or NuGet.config
- Push using the standard NuGet push command with your feed URL

#### 4. **Local Folder** (Testing without a feed)
- Place the `.nupkg` file directly in KamiYomu's agent folder
- Useful for rapid development and testing

### Configuration for Automatic Package Generation

Add this to your `.csproj` to automatically generate a NuGet package on Debug builds:

```xml
<PropertyGroup Condition="'$(Configuration)' == 'Debug'">
	<GeneratePackageOnBuild>True</GeneratePackageOnBuild>
</PropertyGroup>
```

---

## Debugging Your Action Agent

### Local Debugging

1. **Generate Debug Symbols**
   - Build your project in Debug mode: `dotnet build`
   - This creates `.pdb` files alongside your DLL

2. **Place Symbols in KamiYomu**
   - Copy the `.pdb` file to KamiYomu's agent folder:
	 ```
	 C:\Users\[YourUsername]\AppData\Local\KamiYomu\agents\[DeveloperName].ActionAgents.[ProductName]\lib\net8.0\
	 ```

3. **Enable Debugging in KamiYomu.Web**
   - Attach to the running KamiYomu process using Visual Studio
   - Set breakpoints in your action code
   - KamiYomu will pause execution at your breakpoints with full source visibility

### Logging Best Practices

```csharp
public async Task ExecuteAsync(
	ActionAgentContext context,
	IDictionary<string, object> options,
	CancellationToken cancellationToken)
{
	try
	{
		Logger?.LogInformation("Starting action execution");
		Logger?.LogDebug($"Manga: {context.Manga?.Title}");

		// Your action logic here

		Logger?.LogInformation("Action completed successfully");
	}
	catch (Exception ex)
	{
		Logger?.LogError(ex, "Action execution failed");
		throw;
	}
}
```

---

## Common Implementation Patterns


## Common Implementation Patterns

### Pattern 1: Sending Notifications

```csharp
public class NotificationActionAgent : AbstractActionAgent, IActionAgent
{
	public async Task ExecuteAsync(
		ActionAgentContext context,
		IDictionary<string, object> options,
		CancellationToken cancellationToken)
	{
		var message = $"Chapter {context.Chapter?.Number} of {context.Manga?.Title} " +
					 $"was downloaded at {context.TriggerContext?.TriggeredAtUtc:G}";

		// Send notification (e.g., via webhook, email, Discord, etc.)
		await SendNotificationAsync(message, cancellationToken);
	}

	private async Task SendNotificationAsync(string message, CancellationToken cancellationToken)
	{
		// Implementation here
		await Task.CompletedTask;
	}
}
```

### Pattern 2: External API Integration

```csharp
public class WebhookActionAgent : AbstractActionAgent, IActionAgent
{
	private readonly HttpClient _httpClient;

	public WebhookActionAgent(IDictionary<string, object> options) : base(options)
	{
		_httpClient = new HttpClient();
	}

	public async Task ExecuteAsync(
		ActionAgentContext context,
		IDictionary<string, object> options,
		CancellationToken cancellationToken)
	{
		var payload = new
		{
			manga = context.Manga?.Title,
			chapter = context.Chapter?.Number,
			trigger = context.TriggerContext?.Source,
			timestamp = context.TriggerContext?.TriggeredAtUtc
		};

		var content = new StringContent(
			JsonSerializer.Serialize(payload),
			Encoding.UTF8,
			"application/json");

		try
		{
			var response = await _httpClient.PostAsync(
				"https://your-webhook-url.com/manga-action",
				content,
				cancellationToken);

			if (response.IsSuccessStatusCode)
			{
				Logger?.LogInformation("Webhook sent successfully");
			}
		}
		catch (Exception ex)
		{
			Logger?.LogError(ex, "Failed to send webhook");
			throw;
		}
	}
}
```

### Pattern 3: Conditional Logic Based on Trigger Source

```csharp
public class ConditionalActionAgent : AbstractActionAgent, IActionAgent
{
	public async Task ExecuteAsync(
		ActionAgentContext context,
		IDictionary<string, object> options,
		CancellationToken cancellationToken)
	{
		var triggerSource = context.TriggerContext?.Source;

		switch (triggerSource)
		{
			case ActionTriggerSource.Manual:
				await HandleManualTriggerAsync(context, cancellationToken);
				break;
			case ActionTriggerSource.ChapterDownloader:
				await HandleChapterDownloadAsync(context, cancellationToken);
				break;
			case ActionTriggerSource.MangaDownloader:
				await HandleMangaDownloadAsync(context, cancellationToken);
				break;
			default:
				Logger?.LogWarning($"Unhandled trigger source: {triggerSource}");
				break;
		}
	}

	private async Task HandleManualTriggerAsync(ActionAgentContext context, CancellationToken ct)
	{
		Logger?.LogInformation("User manually triggered this action");
		await Task.CompletedTask;
	}

	private async Task HandleChapterDownloadAsync(ActionAgentContext context, CancellationToken ct)
	{
		Logger?.LogInformation($"Chapter downloaded: {context.Chapter?.Number}");
		await Task.CompletedTask;
	}

	private async Task HandleMangaDownloadAsync(ActionAgentContext context, CancellationToken ct)
	{
		Logger?.LogInformation($"Manga series downloaded: {context.Manga?.Title}");
		await Task.CompletedTask;
	}
}
```

---

## Quick Reference Commands

### Development Workflow

```bash
# Create new action agent project
dotnet new classlib -n [DeveloperName].ActionAgents.[ProductName] -f net8.0
cd [DeveloperName].ActionAgents.[ProductName]

# Add the core library
dotnet add package KamiYomu.ActionAgents.Core

# Create test project
cd ..
dotnet new xunit -n [DeveloperName].ActionAgents.[ProductName].Tests -f net8.0
cd [DeveloperName].ActionAgents.[ProductName].Tests
dotnet add package KamiYomu.ActionAgents.Core
dotnet add package Moq
dotnet add reference ../[DeveloperName].ActionAgents.[ProductName]/YourName.ActionAgents.MyAction.csproj
```

### Building and Testing

```bash
# Build the project
dotnet build

# Run unit tests
dotnet test

# Build release package
dotnet pack -c Release

# View package contents
dotnet nuget locals all --list
```

### Publishing

```bash
# Publish to NuGet.org
dotnet nuget push bin/Release/YourName.ActionAgents.MyAction.*.nupkg \
	--api-key YOUR_API_KEY \
	--source https://api.nuget.org/v3/index.json

# Publish to GitHub Packages
dotnet nuget push bin/Release/YourName.ActionAgents.MyAction.*.nupkg \
	--api-key YOUR_GITHUB_TOKEN \
	--source https://nuget.pkg.github.com/YourOrganization/index.json
```


## Troubleshooting

### My action isn't being discovered by KamiYomu.Web

**Checklist:**
- ✅ Package name follows the pattern: `*.ActionAgents.*`
- ✅ `PackageTags` in `.csproj` include both `kamiyomu` and `kamiyomu-action-agents`
- ✅ Your class implements `IActionAgent` interface
- ✅ The class has a public constructor accepting `IDictionary<string, object> options`
- ✅ Package is installed in KamiYomu's agent folder
- ✅ All dependencies are included in the package

**Debug Steps:**
```bash
# Verify package contents
unzip -l bin/Release/YourName.ActionAgents.MyAction.*.nupkg

# Check that your class is public and accessible
dotnet build --configuration Release --verbosity diagnostic
```

### Execution fails with "Type not found" error

- ✅ Ensure all NuGet dependencies are listed in your `.csproj`
- ✅ Verify .NET 8.0 target framework matches KamiYomu's runtime
- ✅ Check that custom types are public and properly namespaced

### Logging not appearing in KamiYomu

- ✅ Verify you're calling `Logger?.LogInformation()` (with null-coalescing)
- ✅ Ensure logger is passed in options with key `"KamiYomuILogger"`
- ✅ Check KamiYomu's logging configuration level (may filter out Debug messages)

### Tests are failing

- ✅ Ensure test project also targets `net8.0`
- ✅ Mock dependencies properly (e.g., `ILogger`, HTTP clients)
- ✅ Use the provided `ActionAgentContextBuilder` for building test contexts
- ✅ Handle `CancellationToken` properly in async tests

### Action takes too long to execute

- ✅ Implement proper async/await patterns
- ✅ Avoid blocking operations (use `async Task` instead of `Task.Run()`)
- ✅ Implement cancellation support via `CancellationToken`
- ✅ Set reasonable timeout values for external calls

```csharp
// Good: Proper async pattern
public async Task ExecuteAsync(
	ActionAgentContext context,
	IDictionary<string, object> options,
	CancellationToken cancellationToken)
{
	using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
	cts.CancelAfter(TimeSpan.FromSeconds(30));

	try
	{
		await SomeLongOperationAsync(cts.Token);
	}
	catch (OperationCanceledException)
	{
		Logger?.LogWarning("Action execution was cancelled");
	}
}

// Avoid: Blocking patterns
// ❌ Task.Run(() => { /* blocking code */ }).Wait();
// ❌ Task.Delay(1000).Wait();
```

---

## API Reference

### ActionAgentContext Properties

| Property | Type | Description |
|----------|------|-------------|
| `Manga` | `MangaContext` | Information about the manga being processed |
| `Chapter` | `ChapterContext` | Information about the chapter being processed |
| `TriggerContext` | `ActionTriggerContext` | Information about what triggered this action |

### MangaContext Properties

| Property | Type | Description |
|----------|------|-------------|
| `Title` | `string` | The manga series title |
| `URL` | `string` | The source URL of the manga |
| `Description` | `string` | Manga description or synopsis |

### ChapterContext Properties

| Property | Type | Description |
|----------|------|-------------|
| `Number` | `string` | Chapter number or identifier |
| `URL` | `string` | The URL to the chapter |
| `ReleaseDateUtc` | `DateTime?` | When the chapter was released (UTC) |

### ActionTriggerContext Properties

| Property | Type | Description |
|----------|------|-------------|
| `Source` | `ActionTriggerSource` | What triggered this action (see table above) |
| `TriggeredAtUtc` | `DateTime` | When the action was triggered (UTC) |

---

## Resources

### Official Documentation
- **Core Library Repository**: https://github.com/KamiYomu/KamiYomu.ActionAgents.Core
- **Main KamiYomu Project**: https://github.com/KamiYomu/KamiYomu

## Community

Join the conversation and be part of the KamiYomu community:

| Action | Link |
| :--- | :--- |
| **Following** | [![GitHub followers](https://img.shields.io/github/followers/kamiyomu)](https://github.com/orgs/KamiYomu/followers) |
| **Discord** | [![Join the discord](https://img.shields.io/discord/1468597233032101942)](https://discord.gg/b9zwEEejsJ) |
| **Sponsor** | [![GitHub Sponsors](https://img.shields.io/github/sponsors/kamiyomu?logo=github&label=Sponsor)](https://github.com/sponsors/kamiyomu) |
| **Report** | [![GitHub issues](https://img.shields.io/github/issues/kamiyomu/KamiYomu.ActionAgents.Core?logo=github&label=Issues)](https://github.com/kamiyomu/KamiYomu.ActionAgents.Core/issues) |
| **Contribute** | [![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?logo=github)](https://github.com/KamiYomu/KamiYomu.ActionAgents.Core/pulls) |

### Best Practices
- Follow SOLID principles in your action design
- Keep actions focused and single-responsibility
- Document all configuration options
- Add comprehensive error logging
- Write unit tests for your actions
- Use semantic versioning for your package

---

## License

This project is licensed under the **MIT License** for the library code.

See the `LICENSE` file in the repository for full terms.

### Copyright

© KamiYomu. Licensed under AGPL-3.0 for the KamiYomu project itself.

The `KamiYomu.ActionAgents.Core` library is provided under the MIT License to enable community contributions and third-party action development.

