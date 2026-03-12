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
    /// NameValueCollection can contain multiple equal keys, but dictionaries cannot. <para/>
    /// So instead of returning a comma separate list for a value, keys that already exist in the Dictionary will not be added.<para/>
    /// Will not add keys where the value is null either.
    /// </summary>
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