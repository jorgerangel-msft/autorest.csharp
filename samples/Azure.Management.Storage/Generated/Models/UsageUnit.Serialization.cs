// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.Management.Storage.Models
{
    internal static partial class UsageUnitExtensions
    {
        public static string ToSerialString(this UsageUnit value) => value switch
        {
            UsageUnit.Count => "Count",
            UsageUnit.Bytes => "Bytes",
            UsageUnit.Seconds => "Seconds",
            UsageUnit.Percent => "Percent",
            UsageUnit.CountsPerSecond => "CountsPerSecond",
            UsageUnit.BytesPerSecond => "BytesPerSecond",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UsageUnit value.")
        };

        public static UsageUnit ToUsageUnit(this string value)
        {
            if (string.Equals(value, "Count", StringComparison.InvariantCultureIgnoreCase)) return UsageUnit.Count;
            if (string.Equals(value, "Bytes", StringComparison.InvariantCultureIgnoreCase)) return UsageUnit.Bytes;
            if (string.Equals(value, "Seconds", StringComparison.InvariantCultureIgnoreCase)) return UsageUnit.Seconds;
            if (string.Equals(value, "Percent", StringComparison.InvariantCultureIgnoreCase)) return UsageUnit.Percent;
            if (string.Equals(value, "CountsPerSecond", StringComparison.InvariantCultureIgnoreCase)) return UsageUnit.CountsPerSecond;
            if (string.Equals(value, "BytesPerSecond", StringComparison.InvariantCultureIgnoreCase)) return UsageUnit.BytesPerSecond;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UsageUnit value.");
        }
    }
}
