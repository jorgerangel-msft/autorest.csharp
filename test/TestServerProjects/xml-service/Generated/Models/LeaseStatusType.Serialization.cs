// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace xml_service.Models
{
    internal static partial class LeaseStatusTypeExtensions
    {
        public static string ToSerialString(this LeaseStatusType value) => value switch
        {
            LeaseStatusType.Locked => "locked",
            LeaseStatusType.Unlocked => "unlocked",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LeaseStatusType value.")
        };

        public static LeaseStatusType ToLeaseStatusType(this string value)
        {
            if (string.Equals(value, "locked", StringComparison.InvariantCultureIgnoreCase)) return LeaseStatusType.Locked;
            if (string.Equals(value, "unlocked", StringComparison.InvariantCultureIgnoreCase)) return LeaseStatusType.Unlocked;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LeaseStatusType value.");
        }
    }
}
