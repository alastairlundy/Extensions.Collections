# CollectionExtensions
Extensions to C# IEnumerables, ICollections, and more to improve them.

This readme refers to the ``AlastairLundy.Extensions.Collections`` project and nuget package as CollectionExtensions for the sake of brevity.

[![NuGet](https://img.shields.io/nuget/v/AlastairLundy.Extensions.Collections.svg)](https://www.nuget.org/packages/AlastairLundy.Extensions.Collections/) 
[![NuGet](https://img.shields.io/nuget/dt/AlastairLundy.Extensions.Collections.svg)](https://www.nuget.org/packages/AlastairLundy.Extensions.Collections/)

## Table of Contents
* [Features](#features)
* [Installing CollectionExtensions](#how-to-install-and-use-collection-extensions)
    * [Compatibility](#compatibility)
* [Examples](#examples)
* [Contributing to CollectionExtensions](#how-to-contribute-to-CollectionExtensions)
* [Roadmap](#collectionextensions-roadmap)
* [License](#license)
* [Acknowledgements](#acknowledgements)

## Features
* IDictionary ``AddRange`` extensions
* HashMap types - Provides a Java like HashMap in .NET that uses a C# Dictionary under the hood.

## How to install and use Collection Extensions
Collections Extensions can be installed via the .NET SDK CLI, Nuget via your IDE or code editor's package interface, or via the Nuget website.

| Package Name                         | Nuget Link                                                                                                    | .NET SDK CLI command                                        |
|--------------------------------------|---------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------|
| AlastairLundy.Extensions.Collections | [AlastairLundy.Extensions.Collections Nuget](https://nuget.org/packages/AlastairLundy.Extensions.Collections) | ``dotnet add package AlastairLundy.Extensions.Collections`` |

### Compatibility
Collections Extensions is compatible with the following .NET versions and Target Framework Monikers (TFMs).

| Collections Extensions Version series | .NET Targets supported                                   | 
|---------------------------------------|----------------------------------------------------------|
| >= 6.0.0                              | .NET Standard 2.0, .NET Standard 2.1, .NET 8, and .NET 9 |
| >= 5.4.0 && < 6.0.0                   | .NET Standard 2.0, .NET Standard 2.1, and .NET 8         |
| < 5.4.0                               | .NET 8                                                   |

## Examples

### Extension Methods

#### Dictionary Extensions

##### AddRange
Sometimes it may be desirable to initialize a dictionary with or without values AND then later add a dictionary or an IEnumerable of KeyValuePair objects tot the existing dictionary.

The IDictionary ``AddRange`` extension methods simplify this.
```csharp
using System.Collections.Generic;

using AlastairLundy.Extensions.Collections.Generic;
    
    //Class names and other code ommitted.

// Initialize a dictionary here.
Dictionary<string, string> output = new Dictionary<string, string>();

List<KeyValuePair<string, string>> keyValuePairList = new List<KeyValuePair<string, string>>();
keyValuePairList.Add(new KeyValuePair("drums", "Your ears will hate you later."));
keyValuePairList.Add(new KeyValuePair("bass_guitar", "For when you're all about that bass."));
keyValuePairList.Add(new KeyValuePair("grand_piano", "A luxurious Grand Piano that probably costs a fortune"));

//Later on we can add an IEnumerable of KeyValuePair objects or even another dictionary.
output.AddRange(keyValuePairList);
```

## How to Build CollectionExtensions's code

### Requirements
CollectionExtensions requires the latest .NET release SDK to be installed to target all supported TFM (Target Framework Moniker) build targets.

Currently, the required .NET SDK is .NET 9. 

The current build targets include: 
* .NET 8
* .NET 9
* .NET Standard 2.0
* .NET Standard 2.1

Any version of the .NET 9 SDK can be used, but using the latest version is preferred.

### Versioning new releases
CollectionExtensions aims to follow Semantic versioning with ```[Major].[Minor].[Build]``` for most circumstances and an optional ``.[Revision]`` when only a configuration change is made, or a new build of a preview release is made.

#### Pre-releases
Pre-release versions should have a suffix of -alpha, -beta, -rc, or -preview followed by a ``.`` and what pre-release version number they are. The number should be incremented by 1 after each release unless it only contains a configuration change, or another packaging, or build change. An example pre-release version may look like 1.1.0-alpha.2 , this version string would indicate it is the 2nd alpha pre-release version of 1.1.0 .

#### Stable Releases
Stable versions should follow semantic versioning and should only increment the Revision number if a release only contains configuration or build packaging changes, with no change in functionality, features, or even bug or security fixes.

Releases that only implement bug fixes should see the Build version incremented.

Releases that add new non-breaking changes should increment the Minor version. Minor breaking changes may be permitted in Minor version releases where doing so is necessary to maintain compatibility with an existing supported platform, or an existing piece of code that requires a breaking change to continue to function as intended.

Releases that add major breaking changes or significantly affect the API should increment the Major version. Major version releases should not be released with excessive frequency and should be released when there is a genuine need for the API to change significantly for the improvement of the project.

### Building for Testing
You can build for testing by building the project within your IDE or VS Code, or manually by entering the following command: ``dotnet build -c Debug``.

If you encounter any bugs or issues, try running the tests project and setting breakpoints in the affected code where appropriate. Failing that, please [report the issue](https://github.com/alastairlundy/CollectionExtensions/issues/new/) if one doesn't already exist for the bug(s).

### Building for Release
Before building a release build, ensure you apply the relevant changes to the ``AlastairLundy.Extensions.Collections.csproj`` file:
* Update the Package Version variable 
* Update the project file's Changelog

You should ensure the project builds under debug settings before producing a release build.

#### Producing Release Builds
To manually build for release, enter ``dotnet build -c Release /p:ContinuousIntegrationBuild=true`` for a release with [SourceLink](https://github.com/dotnet/sourcelink) enabled or just ``dotnet build -c Release`` for a build without SourceLink.

Builds should generally always include Source Link and symbol packages if intended for wider distribution.

## How to Contribute to CollectionExtensions
Thank you in advance for considering contributing to CollectionExtensions.

Please see the [CONTRIBUTING.md file](https://github.com/alastairlundy/CollectionExtensions/blob/main/CONTRIBUTING.md) for code and localization contributions.

If you want to file a bug report or suggest a potential feature to add, please check out the [GitHub issues page](https://github.com/alastairlundy/CollectionExtensions/issues/) to see if a similar or identical issue is already open.
If there is not already a relevant issue filed, please [file one here](https://github.com/alastairlundy/CollectionExtensions/issues/new) and follow the respective guidance from the appropriate issue template.

Thanks.

## CollectionExtensions' Roadmap
CollectionExtensions aims to make working with Generic Collections and IEnumerables in C# easier.

All stable releases must be stable and should not contain regressions.

Future updates should aim focus on one or more of the following:
* Adding extension methods that improve ease of use
* Adding new interfaces or classes that add useful Collections/IEnumerables related features that aren't an exact copy of an existing feature in .NET .
* Enhancing existing extension methods, classes, or interfaces.

## License
CollectionExtensions is licensed under the MIT license.

If you use CollectionExtensions in your project please make an exact copy of the contents of CollectionExtensions's [LICENSE.txt](https://github.com/alastairlundy/CollectionExtensions/blob/main/LICENSE.txt) file available either in your third party licenses txt file or as a separate txt file.

## Acknowledgements

### Projects
This project would like to thank the following projects for their work:
* [Polyfill](https://github.com/SimonCropp/Polyfill) for simplifying .NET Standard 2.0 & 2.1 support

For more information, please see the [THIRD_PARTY_NOTICES file](https://github.com/alastairlundy/CollectionExtensions/blob/main/THIRD_PARTY_NOTICES.txt).
