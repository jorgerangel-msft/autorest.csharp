// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class VisualFeatureExtensions
    {
        public static string ToSerialString(this VisualFeature value) => value switch
        {
            VisualFeature.Adult => "adult",
            VisualFeature.Brands => "brands",
            VisualFeature.Categories => "categories",
            VisualFeature.Description => "description",
            VisualFeature.Faces => "faces",
            VisualFeature.Objects => "objects",
            VisualFeature.Tags => "tags",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown VisualFeature value.")
        };

        public static VisualFeature ToVisualFeature(this string value)
        {
            if (string.Equals(value, "adult", StringComparison.InvariantCultureIgnoreCase)) return VisualFeature.Adult;
            if (string.Equals(value, "brands", StringComparison.InvariantCultureIgnoreCase)) return VisualFeature.Brands;
            if (string.Equals(value, "categories", StringComparison.InvariantCultureIgnoreCase)) return VisualFeature.Categories;
            if (string.Equals(value, "description", StringComparison.InvariantCultureIgnoreCase)) return VisualFeature.Description;
            if (string.Equals(value, "faces", StringComparison.InvariantCultureIgnoreCase)) return VisualFeature.Faces;
            if (string.Equals(value, "objects", StringComparison.InvariantCultureIgnoreCase)) return VisualFeature.Objects;
            if (string.Equals(value, "tags", StringComparison.InvariantCultureIgnoreCase)) return VisualFeature.Tags;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown VisualFeature value.");
        }
    }
}
