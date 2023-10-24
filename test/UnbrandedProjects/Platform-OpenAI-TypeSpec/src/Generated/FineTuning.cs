// <auto-generated/>

#nullable disable

using System;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Core.Pipeline;
using System.Threading;

namespace OpenAI
{
    // Data plane generated sub-client.
    /// <summary>
    /// The FineTuning sub-client.
    /// Hello World
    /// </summary>
    public partial class FineTuning
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly KeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly MessagePipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal TelemetrySource ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual MessagePipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of FineTuning for mocking. </summary>
        protected FineTuning()
        {
        }

        /// <summary> Initializes a new instance of FineTuning. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> OpenAI Endpoint. </param>
        internal FineTuning(TelemetrySource clientDiagnostics, MessagePipeline pipeline, KeyCredential keyCredential, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        private FineTuningJobs _cachedFineTuningJobs;

        /// <summary> Initializes a new instance of FineTuningJobs. </summary>
        public virtual FineTuningJobs GetFineTuningJobsClient()
        {
            return Volatile.Read(ref _cachedFineTuningJobs) ?? Interlocked.CompareExchange(ref _cachedFineTuningJobs, new FineTuningJobs(ClientDiagnostics, _pipeline, _keyCredential, _endpoint), null) ?? _cachedFineTuningJobs;
        }
    }
}
