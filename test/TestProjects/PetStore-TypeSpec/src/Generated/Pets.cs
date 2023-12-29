// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using PetStore.Models;

namespace PetStore
{
    // Data plane generated sub-client.
    /// <summary> Manage your pets. You can delete or get the Pet from pet store. </summary>
    public partial class Pets
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Pets for mocking. </summary>
        protected Pets()
        {
        }

        /// <summary> Initializes a new instance of Pets. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        internal Pets(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _endpoint = endpoint;
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] delete.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='DeleteAsync(int,RequestContext)']/*" />
        public virtual async Task<Response> DeleteAsync(int petId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Pets.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(petId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] delete.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='Delete(int,RequestContext)']/*" />
        public virtual Response Delete(int petId, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Pets.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(petId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns a pet. Supports eTags. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='ReadAsync(int,CancellationToken)']/*" />
        public virtual async Task<Response<Pet>> ReadAsync(int petId, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ReadAsync(petId, context).ConfigureAwait(false);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary> Returns a pet. Supports eTags. </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='Read(int,CancellationToken)']/*" />
        public virtual Response<Pet> Read(int petId, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Read(petId, context);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Returns a pet. Supports eTags.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ReadAsync(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='ReadAsync(int,RequestContext)']/*" />
        public virtual async Task<Response> ReadAsync(int petId, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Pets.Read");
            scope.Start();
            try
            {
                using HttpMessage message = CreateReadRequest(petId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Returns a pet. Supports eTags.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Read(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="petId"> The id of pet. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='Read(int,RequestContext)']/*" />
        public virtual Response Read(int petId, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Pets.Read");
            scope.Start();
            try
            {
                using HttpMessage message = CreateReadRequest(petId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="pet"> The <see cref="Pet"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pet"/> is null. </exception>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='CreateAsync(Pet,CancellationToken)']/*" />
        public virtual async Task<Response<Pet>> CreateAsync(Pet pet, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(pet, nameof(pet));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = pet.ToRequestContent();
            Response response = await CreateAsync(content, context).ConfigureAwait(false);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <param name="pet"> The <see cref="Pet"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="pet"/> is null. </exception>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='Create(Pet,CancellationToken)']/*" />
        public virtual Response<Pet> Create(Pet pet, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(pet, nameof(pet));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = pet.ToRequestContent();
            Response response = Create(content, context);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateAsync(Pet,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='CreateAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> CreateAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Pets.Create");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Create(Pet,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='Create(RequestContent,RequestContext)']/*" />
        public virtual Response Create(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("Pets.Create");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="kind"> The <see cref="PetKind"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetPetByKindAsync(PetKind,CancellationToken)']/*" />
        public virtual async Task<Response<Pet>> GetPetByKindAsync(PetKind kind, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetPetByKindAsync(kind.ToString(), context).ConfigureAwait(false);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <param name="kind"> The <see cref="PetKind"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetPetByKind(PetKind,CancellationToken)']/*" />
        public virtual Response<Pet> GetPetByKind(PetKind kind, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetPetByKind(kind.ToString(), context);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetPetByKindAsync(PetKind,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="kind"> The <see cref="string"/> to use. Allowed values: "dog" | "cat". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="kind"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetPetByKindAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> GetPetByKindAsync(string kind, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(kind, nameof(kind));

            using var scope = ClientDiagnostics.CreateScope("Pets.GetPetByKind");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetPetByKindRequest(kind, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetPetByKind(PetKind,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="kind"> The <see cref="string"/> to use. Allowed values: "dog" | "cat". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="kind"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetPetByKind(string,RequestContext)']/*" />
        public virtual Response GetPetByKind(string kind, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(kind, nameof(kind));

            using var scope = ClientDiagnostics.CreateScope("Pets.GetPetByKind");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetPetByKindRequest(kind, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="start"> The <see cref="int"/>? to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetFirstPetAsync(int?,CancellationToken)']/*" />
        public virtual async Task<Response<Pet>> GetFirstPetAsync(int? start = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetFirstPetAsync(start, context).ConfigureAwait(false);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <param name="start"> The <see cref="int"/>? to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetFirstPet(int?,CancellationToken)']/*" />
        public virtual Response<Pet> GetFirstPet(int? start = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetFirstPet(start, context);
            return Response.FromValue(Pet.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFirstPetAsync(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="start"> The <see cref="int"/>? to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetFirstPetAsync(int?,RequestContext)']/*" />
        public virtual async Task<Response> GetFirstPetAsync(int? start, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Pets.GetFirstPet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetFirstPetRequest(start, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFirstPet(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="start"> The <see cref="int"/>? to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetFirstPet(int?,RequestContext)']/*" />
        public virtual Response GetFirstPet(int? start, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Pets.GetFirstPet");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetFirstPetRequest(start, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="kind"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetFishAsync(string,CancellationToken)']/*" />
        public virtual async Task<Response<Fish>> GetFishAsync(string kind = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetFishAsync(kind, context).ConfigureAwait(false);
            return Response.FromValue(Fish.FromResponse(response), response);
        }

        /// <param name="kind"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetFish(string,CancellationToken)']/*" />
        public virtual Response<Fish> GetFish(string kind = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetFish(kind, context);
            return Response.FromValue(Fish.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFishAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="kind"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetFishAsync(string,RequestContext)']/*" />
        public virtual async Task<Response> GetFishAsync(string kind, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Pets.GetFish");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetFishRequest(kind, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFish(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="kind"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='GetFish(string,RequestContext)']/*" />
        public virtual Response GetFish(string kind, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("Pets.GetFish");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetFishRequest(kind, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Test that an LRO polling operation defined in a namespace wtihout @service decorator will not be generated. This should be removed after cadl-ranch test case update.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='RefreshAsync(RequestContext)']/*" />
        public virtual async Task<Response> RefreshAsync(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Pets.Refresh");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRefreshRequest(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Test that an LRO polling operation defined in a namespace wtihout @service decorator will not be generated. This should be removed after cadl-ranch test case update.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/Pets.xml" path="doc/members/member[@name='Refresh(RequestContext)']/*" />
        public virtual Response Refresh(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("Pets.Refresh");
            scope.Start();
            try
            {
                using HttpMessage message = CreateRefreshRequest(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateDeleteRequest(int petId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(petId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateReadRequest(int petId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200304);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(petId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateCreateRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetPetByKindRequest(string kind, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets/", false);
            uri.AppendPath(kind, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetFirstPetRequest(int? start, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets", false);
            if (start != null)
            {
                uri.AppendQuery("start", start.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetFishRequest(string kind, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets/getFish", false);
            if (kind != null)
            {
                uri.AppendQuery("kind", kind, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateRefreshRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/pets/refresh", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier200304;
        private static ResponseClassifier ResponseClassifier200304 => _responseClassifier200304 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 304 });
        private static ResponseClassifier _responseClassifier;
        private static ResponseClassifier ResponseClassifier => _responseClassifier ??= new StatusCodeClassifier(stackalloc ushort[] { });
    }
}
