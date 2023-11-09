using System.Collections.Generic;

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
        var result = new Dictionary<string, string>();

        // check for count first because AllKeys is more expensive 
        if (nameValueCollection.Count == 0)
            return result;

        foreach (string? key in nameValueCollection.AllKeys)
        {
            if (key == null)
                continue;

            if (result.ContainsKey(key))
                continue;

            string? value = nameValueCollection[key];

            if (value == null)
                continue;

            result[key] = value;
        }

        return result;
    }
}