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
using _Azure.Lro.RpcLegacy.Models;

namespace _Azure.Lro.RpcLegacy
{
    // Data plane generated client.
    /// <summary>
    /// POST to create resource, poll URL via operation-location header.
    /// Hello World
    /// </summary>
    public partial class LegacyClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of LegacyClient. </summary>
        public LegacyClient() : this(new Uri("http://localhost:3000"), new LegacyClientOptions())
        {
        }

        /// <summary> Initializes a new instance of LegacyClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public LegacyClient(Uri endpoint, LegacyClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new LegacyClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Creates a Job. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="jobData"> Data of the job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobData"/> is null. </exception>
        /// <include file="Docs/LegacyClient.xml" path="doc/members/member[@name='CreateJobAsync(WaitUntil,JobData,CancellationToken)']/*" />
        public virtual async Task<Operation<JobResult>> CreateJobAsync(WaitUntil waitUntil, JobData jobData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobData, nameof(jobData));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = jobData.ToRequestContent();
            Operation<BinaryData> response = await CreateJobAsync(waitUntil, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, JobResult.FromResponse, ClientDiagnostics, "LegacyClient.CreateJob");
        }

        /// <summary> Creates a Job. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="jobData"> Data of the job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobData"/> is null. </exception>
        /// <include file="Docs/LegacyClient.xml" path="doc/members/member[@name='CreateJob(WaitUntil,JobData,CancellationToken)']/*" />
        public virtual Operation<JobResult> CreateJob(WaitUntil waitUntil, JobData jobData, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobData, nameof(jobData));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = jobData.ToRequestContent();
            Operation<BinaryData> response = CreateJob(waitUntil, content, context);
            return ProtocolOperationHelpers.Convert(response, JobResult.FromResponse, ClientDiagnostics, "LegacyClient.CreateJob");
        }

        /// <summary>
        /// [Protocol Method] Creates a Job
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateJobAsync(WaitUntil,JobData,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LegacyClient.xml" path="doc/members/member[@name='CreateJobAsync(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> CreateJobAsync(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LegacyClient.CreateJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateJobRequest(content, context);
                return await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "LegacyClient.CreateJob", OperationFinalStateVia.OperationLocation, context, waitUntil).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a Job
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateJob(WaitUntil,JobData,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Docs/LegacyClient.xml" path="doc/members/member[@name='CreateJob(WaitUntil,RequestContent,RequestContext)']/*" />
        public virtual Operation<BinaryData> CreateJob(WaitUntil waitUntil, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("LegacyClient.CreateJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateJobRequest(content, context);
                return ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "LegacyClient.CreateJob", OperationFinalStateVia.OperationLocation, context, waitUntil);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateCreateJobRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200202);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/lro/rpc/legacy/create-resource-poll-via-operation-location/jobs", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
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

        private static ResponseClassifier _responseClassifier200202;
        private static ResponseClassifier ResponseClassifier200202 => _responseClassifier200202 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 202 });
    }
}
