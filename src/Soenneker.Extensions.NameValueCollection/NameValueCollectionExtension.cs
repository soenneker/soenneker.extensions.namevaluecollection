using Soenneker.Extensions.String;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.NameValueCollection;

/// <summary>
/// A collection of helpful NameValueCollection extension methods
/// </summary>
public static class NameValueCollectionExtension
{
    /// <summary>
    /// Copies nonempty keys and values into a new ordinal dictionary.
    /// </summary>
    /// <remarks>When a key has multiple values, the <see cref="System.Collections.Specialized.NameValueCollection"/>
    /// indexed getter combines them into the string stored in the dictionary.</remarks>
    /// <param name="nvc">The collection to copy. A null collection produces an empty dictionary.</param>
    /// <returns>A new dictionary containing the collection's nonempty keys and combined nonempty values.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Dictionary<string, string> ToDictionary(
        this System.Collections.Specialized.NameValueCollection nvc)
    {
        if (nvc is null)
            return [];

        int count = nvc.Count;

        if (count == 0)
            return [];

        var result = new Dictionary<string, string>(count, StringComparer.Ordinal);

        for (int i = 0; i < count; i++)
        {
            string? key = nvc.GetKey(i);

            if (key.IsNullOrEmpty())
                continue;

            string? value = nvc.Get(i);

            if (value.IsNullOrEmpty())
                continue;

            // Direct assignment avoids Add + exception path
            result[key] = value;
        }

        return result;
    }
}
