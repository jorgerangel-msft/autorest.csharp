// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using NUnit.Framework;

namespace Server.Versions.NotVersioned.Samples
{
    public partial class Samples_NotVersionedClient
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NotVersioned_WithoutApiVersion_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = client.WithoutApiVersion();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NotVersioned_WithoutApiVersion_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = await client.WithoutApiVersionAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NotVersioned_WithoutApiVersion_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = client.WithoutApiVersion();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NotVersioned_WithoutApiVersion_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = await client.WithoutApiVersionAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NotVersioned_WithQueryApiVersion_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = client.WithQueryApiVersion("<apiVersion>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NotVersioned_WithQueryApiVersion_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = await client.WithQueryApiVersionAsync("<apiVersion>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NotVersioned_WithQueryApiVersion_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = client.WithQueryApiVersion("<apiVersion>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NotVersioned_WithQueryApiVersion_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = await client.WithQueryApiVersionAsync("<apiVersion>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NotVersioned_WithPathApiVersion_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = client.WithPathApiVersion("<apiVersion>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NotVersioned_WithPathApiVersion_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = await client.WithPathApiVersionAsync("<apiVersion>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_NotVersioned_WithPathApiVersion_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = client.WithPathApiVersion("<apiVersion>");

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_NotVersioned_WithPathApiVersion_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            NotVersionedClient client = new NotVersionedClient(endpoint);

            Response response = await client.WithPathApiVersionAsync("<apiVersion>");

            Console.WriteLine(response.Status);
        }
    }
}
