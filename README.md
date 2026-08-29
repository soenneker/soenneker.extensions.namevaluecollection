[![](https://img.shields.io/nuget/v/Soenneker.Extensions.NameValueCollection.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.NameValueCollection/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.namevaluecollection/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.namevaluecollection/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Extensions.NameValueCollection.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.NameValueCollection/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.namevaluecollection/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.namevaluecollection/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.NameValueCollection
Converts `NameValueCollection` into a simple ordinal `Dictionary<string, string>` while dropping unusable entries.

## Installation

```bash
dotnet add package Soenneker.Extensions.NameValueCollection
```

## Usage

```csharp
using Soenneker.Extensions.NameValueCollection;

var headers = new NameValueCollection
{
    ["trace-id"] = "abc123",
    ["empty"] = ""
};

Dictionary<string, string> result = headers.ToDictionary();
// { "trace-id": "abc123" }
```

Null/empty keys and null/empty values are omitted. The resulting dictionary uses `StringComparer.Ordinal` and is always a new instance. A null or empty collection returns an empty dictionary.

`NameValueCollection` can hold multiple values for one key. Its indexed getter combines those values into one comma-separated string, and that combined value is what this method stores.
