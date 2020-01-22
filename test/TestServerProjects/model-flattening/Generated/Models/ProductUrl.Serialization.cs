// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace model_flattening.Models
{
    public partial class ProductUrl : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (OdataValue != null)
            {
                writer.WritePropertyName("@odata.value");
                writer.WriteStringValue(OdataValue);
            }
            if (GenericValue != null)
            {
                writer.WritePropertyName("generic_value");
                writer.WriteStringValue(GenericValue);
            }
            writer.WriteEndObject();
        }
        internal static ProductUrl DeserializeProductUrl(JsonElement element)
        {
            ProductUrl result = new ProductUrl();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.OdataValue = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("generic_value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.GenericValue = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
