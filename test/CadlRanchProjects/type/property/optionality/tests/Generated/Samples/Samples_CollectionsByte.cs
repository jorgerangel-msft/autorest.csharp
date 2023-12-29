// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Property.Optionality;
using _Type.Property.Optionality.Models;

namespace _Type.Property.Optionality.Samples
{
    public partial class Samples_CollectionsByte
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_GetAll_ShortVersion()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_GetAll_ShortVersion_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_GetAll_ShortVersion_Convenience()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response<CollectionsByteProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_GetAll_ShortVersion_Convenience_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response<CollectionsByteProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_GetAll_AllParameters()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response response = client.GetAll(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_GetAll_AllParameters_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response response = await client.GetAllAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_GetAll_AllParameters_Convenience()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response<CollectionsByteProperty> response = client.GetAll();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_GetAll_AllParameters_Convenience_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response<CollectionsByteProperty> response = await client.GetAllAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_GetDefault_ShortVersion()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_GetDefault_ShortVersion_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_GetDefault_ShortVersion_Convenience()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response<CollectionsByteProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_GetDefault_ShortVersion_Convenience_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response<CollectionsByteProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_GetDefault_AllParameters()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response response = client.GetDefault(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_GetDefault_AllParameters_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response response = await client.GetDefaultAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("property")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_GetDefault_AllParameters_Convenience()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response<CollectionsByteProperty> response = client.GetDefault();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_GetDefault_AllParameters_Convenience_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            Response<CollectionsByteProperty> response = await client.GetDefaultAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_PutAll_ShortVersion()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_PutAll_ShortVersion_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_PutAll_ShortVersion_Convenience()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            CollectionsByteProperty body = new CollectionsByteProperty();
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_PutAll_ShortVersion_Convenience_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            CollectionsByteProperty body = new CollectionsByteProperty();
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_PutAll_AllParameters()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new object()
            },
            });
            Response response = client.PutAll(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_PutAll_AllParameters_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new object()
            },
            });
            Response response = await client.PutAllAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_PutAll_AllParameters_Convenience()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            CollectionsByteProperty body = new CollectionsByteProperty
            {
                Property = { BinaryData.FromObjectAsJson(new object()) },
            };
            Response response = client.PutAll(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_PutAll_AllParameters_Convenience_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            CollectionsByteProperty body = new CollectionsByteProperty
            {
                Property = { BinaryData.FromObjectAsJson(new object()) },
            };
            Response response = await client.PutAllAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_PutDefault_ShortVersion()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_PutDefault_ShortVersion_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            using RequestContent content = RequestContent.Create(new object());
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_PutDefault_ShortVersion_Convenience()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            CollectionsByteProperty body = new CollectionsByteProperty();
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_PutDefault_ShortVersion_Convenience_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            CollectionsByteProperty body = new CollectionsByteProperty();
            Response response = await client.PutDefaultAsync(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_PutDefault_AllParameters()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new object()
            },
            });
            Response response = client.PutDefault(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_PutDefault_AllParameters_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            using RequestContent content = RequestContent.Create(new
            {
                property = new object[]
            {
new object()
            },
            });
            Response response = await client.PutDefaultAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CollectionsByte_PutDefault_AllParameters_Convenience()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            CollectionsByteProperty body = new CollectionsByteProperty
            {
                Property = { BinaryData.FromObjectAsJson(new object()) },
            };
            Response response = client.PutDefault(body);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CollectionsByte_PutDefault_AllParameters_Convenience_Async()
        {
            CollectionsByte client = new OptionalClient().GetCollectionsByteClient();

            CollectionsByteProperty body = new CollectionsByteProperty
            {
                Property = { BinaryData.FromObjectAsJson(new object()) },
            };
            Response response = await client.PutDefaultAsync(body);
        }
    }
}
