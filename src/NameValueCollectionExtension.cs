using System.Collections.Generic;
using Soenneker.Extensions.String;

namespace Soenneker.Extensions.NameValueCollection;

/// <summary>
/// A collection of helpful NameValueCollection extension methods
/// </summary>
public static class NameValueCollectionExtension
{
    /// <summary>
    /// NameValueCollection can contain multiple equal keys, but dictionaries cannot. <para/>
    /// So instead of returning a comma separate list for a value, keys that already exist in the Dictionary will not be added.<para/>
    /// Will not add keys where the value is null either.
    /// </summary>
    public static Dictionary<string, string> ToDictionary(this System.Collections.Specialized.NameValueCollection nameValueCollection)
    {
        if (nameValueCollection is null || nameValueCollection.Count == 0)
            return new Dictionary<string, string>(0);

        var result = new Dictionary<string, string>(nameValueCollection.Count);

        for (int i = 0; i < nameValueCollection.Count; i++)
        {
            string? key = nameValueCollection.GetKey(i);
            if (key.IsNullOrEmpty())
                continue;

            // Use indexer to get the value directly.
            string? value = nameValueCollection.Get(i);

            if (value.IsNullOrEmpty())
                continue;

            // Add key-value pair to the dictionary.
            result[key] = value;
        }

        return result;
    }
}