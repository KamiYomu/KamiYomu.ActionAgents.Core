# KamiYomu.ActionAgents.Core

A event-driven action system for KamiYomu that enables extensible automation through triggered actions at key application moments.

## Overview

**Actions** are events triggered by KamiYomu at specific moments during application execution. They represent discrete operations that can be executed automatically in response to significant events, such as:

- **Manga Downloads**: Actions triggered when a manga series is downloaded
- **Chapter Downloads**: Actions triggered when a chapter is successfully downloaded
- **Chained Actions**: Actions triggered by the completion of other actions, enabling complex workflows

## Purpose

The `KamiYomu.ActionAgents.Core` library provides a robust framework for:

- Defining custom actions that respond to application events
- Managing action execution and lifecycle
- Creating extensible automation pipelines
- Decoupling business logic from event handling

## Key Concepts

### Actions

Actions are the core building blocks of this framework. An action encapsulates a specific operation that should execute when triggered by an event. Actions can be:

- **Simple**: Perform a single operation (e.g., send a notification)
- **Complex**: Orchestrate multiple steps or delegate to other services
- **Chainable**: Trigger subsequent actions upon completion

### Event Triggers

The framework monitors KamiYomu's lifecycle for significant events:

- Manga download completion
- Chapter download completion
- Custom application events
- Action completion events

### Extensibility

Design your actions to be:

- **Configurable**: Accept parameters that customize behavior
- **Composable**: Work together to form larger workflows
- **Testable**: Isolated and mockable for unit testing

## Getting Started

Quick start
-----------
1. Create a class library project (target `net-8.0` for widest compatibility):
    
    Create project:
    
        dotnet new classlib -n [DeveloperName].ActionAgent.[ProductName] -f net-8.0

2. Add NuGet.Config in the solution folder to ensure standard feeds:

    NuGet.Config content (place next to your `.sln`):
    
        <?xml version="1.0" encoding="utf-8"?>
        <configuration>
          <packageSources>
            <clear />
            <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
          </packageSources>
        </configuration>

3. Install the core package:

        dotnet add package KamiYomu.ActionAgents.Core

4. Make your package discoverable by KamiYomu (add `PackageTags` to your `.csproj`):

    Add inside your `.csproj`:

        <PropertyGroup>
		    <PackageTags>kamiyomu;kamiyomu-action-agents;actions;[ProductName];</PackageTags>
        </PropertyGroup>

5. Implement your agent
    - Create a class that implements `IActionAgent` from the `KamiYomu.ActionAgents.Core` namespace.
    - Implement required lifecycle methods (ExecuteAsync). The interface defines how KamiYomu will call your agent.


Packaging and publishing
------------------------
- Build a distributable package:

        dotnet pack -c Release

- To automatically generate a NuGet package for Debug builds, add to your `.csproj`:

        <PropertyGroup Condition="'$(Configuration)' == 'Debug'">
            <GeneratePackageOnBuild>True</GeneratePackageOnBuild>
        </PropertyGroup>

- Publish to a feed accessible by KamiYomu.Web (Nuget.org, GitHub Packages, Azure Artifacts, private feed, or local folder).
- To test without a feed, upload the generated `.nupkg` directly into KamiYomu.Web.

Debugging an installed agent
----------------------------
- Place the `.pdb` alongside the agent DLL inside the agent folder (e.g. `/AppData/agents/{your.package}/lib/net8.0/`) to enable source-level debugging when running inside KamiYomu.Web.

Packaging notes
---------------
- Ensure your package includes necessary runtime assets and dependencies.
- Keep the public API surface minimal and document required configuration and permissions.

Commands summary
----------------
- Create project:
    
        dotnet new classlib -n [DeveloperName].ActionAgent.[ProductName] -f net8.0

- Add package:

        dotnet add package KamiYomu.ActionAgents.Core
- Build Release package:

        dotnet pack -c Release

- Enable package on Debug build:

        Add `<GeneratePackageOnBuild>True</GeneratePackageOnBuild>` under Debug condition in `.csproj`

Dependencies
------------
| Package         | Version |
|-----------------|---------|
| HtmlAgilityPack | 1.12.4  |
| PuppeteerSharp  | 20.2.4  |

Contributing
------------
- Follow repository coding conventions and include unit tests for new behavior.
- Use the validator repo above to confirm compliance before publishing.
- Open issues or pull requests against the core repository with clear descriptions and reproducible examples.

License
-------
This project is licensed under the GNU General Public License v3.0 (GPL-3.0). See the `LICENSE` file for full terms.

Support / Contact
-----------------
- Repo: https://github.com/KamiYomu/KamiYomu.CrawlerAgents.Core
- For integration or runtime questions, open an issue on the repository.

Changelog
---------
- See repository Releases for version-specific notes.

Copyright
---------
Licensed under MIT.