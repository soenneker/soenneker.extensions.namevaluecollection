[![](https://img.shields.io/nuget/v/Soenneker.Extensions.NameValueCollection.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.NameValueCollection/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.namevaluecollection/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.namevaluecollection/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Extensions.NameValueCollection.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.NameValueCollection/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.namevaluecollection/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.namevaluecollection/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.NameValueCollection
A collection of helpful NameValueCollection extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.NameValueCollection
```

## Quick start

```csharp
using Soenneker.Extensions.NameValueCollection;
```

Import the namespace, then call the extension methods directly on the matching value.

## Common operations

- `ToDictionary()` - NameValueCollection can contain multiple equal keys, but dictionaries cannot. So instead of returning a comma separate list for a value, keys that already exist in the Dictionary will not be added. Will not add keys where the value is null either.
