// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace model_flattening.Models
{
    public partial class BaseProduct : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("base_product_id");
            writer.WriteStringValue(ProductId);
            if (Description != null)
            {
                writer.WritePropertyName("base_product_description");
                writer.WriteStringValue(Description);
            }
            writer.WriteEndObject();
        }
        internal static BaseProduct DeserializeBaseProduct(JsonElement element)
        {
            BaseProduct result = new BaseProduct();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("base_product_id"))
                {
                    result.ProductId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("base_product_description"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Description = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
