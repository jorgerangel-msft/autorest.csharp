// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ManagementClientWriter
    {
        private const string ClientDiagnosticsField = "_clientDiagnostics";
        private const string PipelineField = "_pipeline";
        private const string TokenCredentialVariable = "tokenCredential";
        private const string OptionsVariable = "options";
        private const string ClientSuffixValue = "ManagementClient";
        private const string OperationsSuffixValue = "Operations";

        public static void WriteAggregateClient(CodeWriter writer, BuildContext context)
        {
            var title = GetManagementClientPrefix(context.DefaultLibraryName);
            using (writer.Scope($"namespace {context.Configuration.Namespace ?? context.DefaultNamespace}"))
            {
                Dictionary<string, Parameter> allParameters = new Dictionary<string, Parameter>();
                foreach (var parameter in context.Library.Clients.SelectMany(p => p.RestClient.Parameters))
                {
                    if (ManagementClientWriterHelpers.IsApiVersionParameter(parameter))
                    {
                        continue;
                    }

                    allParameters[parameter.Name] = parameter;
                }

                writer.WriteXmlDocumentationSummary($"{title} service management client.");
                using (writer.Scope($"public partial class {title}ManagementClient"))
                {
                    writer.Line($"private readonly {typeof(ClientDiagnostics)}  {ClientDiagnosticsField};");
                    writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");
                    foreach (var parameter in allParameters.Values)
                    {
                        writer.Line($"private readonly {parameter.Type} _{parameter.Name};");
                    }

                    writer.Line();

                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of {title}ManagementClient for mocking.");
                    using (writer.Scope($"protected {title}ManagementClient()"))
                    {
                    }
                    writer.Line();


                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of {title}ManagementClient");
                    foreach (Parameter parameter in allParameters.Values)
                    {
                        if (ManagementClientWriterHelpers.IsEndpointParameter(parameter))
                        {
                            continue;
                        }
                        writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
                    }
                    writer.WriteXmlDocumentationParameter(TokenCredentialVariable, "The OAuth token for making client requests.");
                    writer.WriteXmlDocumentationParameter(OptionsVariable, "The options for configuring the client.");

                    writer.Append($"public {title}ManagementClient(");
                    foreach (Parameter parameter in allParameters.Values)
                    {
                        if (ManagementClientWriterHelpers.IsEndpointParameter(parameter))
                        {
                            continue;
                        }

                        writer.WriteParameter(parameter);
                    }

                    writer.Append($"{typeof(TokenCredential)} {TokenCredentialVariable}, {title}ManagementClientOptions {OptionsVariable} = null) : this(");
                    foreach (Parameter parameter in allParameters.Values)
                    {
                        // Pass the default host
                        if (ManagementClientWriterHelpers.IsEndpointParameter(parameter))
                        {
                            writer.Append($"null, ");
                            continue;
                        }

                        writer.Append($"{parameter.Name},");
                    }

                    writer.Line($"{TokenCredentialVariable}, {OptionsVariable})");
                    using (writer.Scope())
                    {
                    }

                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of {title}ManagementClient");
                    foreach (Parameter parameter in allParameters.Values)
                    {
                        writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
                    }
                    writer.WriteXmlDocumentationParameter(TokenCredentialVariable, "The OAuth token for making client requests.");
                    writer.WriteXmlDocumentationParameter(OptionsVariable, "The options for configuring the client.");
                    writer.WriteXmlDocumentationRequiredParametersException(allParameters.Values);

                    writer.Append($"public {title}ManagementClient(");
                    foreach (Parameter parameter in allParameters.Values)
                    {
                        writer.WriteParameter(parameter, false);
                    }

                    writer.Append($"{typeof(TokenCredential)} {TokenCredentialVariable}, {title}ManagementClientOptions {OptionsVariable} = null)");

                    using (writer.Scope())
                    {
                        writer.WriteParameterNullChecks(allParameters.Values);

                        writer.Line($"{OptionsVariable} ??= new {title}ManagementClientOptions();");
                        writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}({OptionsVariable});");
                        writer.Line($"{PipelineField} = {typeof(ManagementPipelineBuilder)}.Build({TokenCredentialVariable}, endpoint, {OptionsVariable});");

                        foreach (Parameter parameter in allParameters.Values)
                        {
                            writer.Line($"_{parameter.Name} = {parameter.Name};");
                        }

                    }
                    writer.Line();

                    foreach (var client in context.Library.Clients)
                    {
                        writer.WriteXmlDocumentationSummary($"Returns an instance of {client.Type.Name}");
                        writer.Append($"public virtual {client.Type} {client.ClientShortName} => ");
                        writer.Append($"new {client.Type}({ClientDiagnosticsField}, {PipelineField}, ");
                        foreach (var parameter in client.RestClient.Parameters)
                        {
                            if (ManagementClientWriterHelpers.IsApiVersionParameter(parameter))
                            {
                                continue;
                            }

                            writer.Append($"_{parameter.Name}, ");
                        }

                        writer.RemoveTrailingComma();
                        writer.Line($");");

                        writer.Line();
                    }
                }

            }
        }

        public static void WriteClientOptions(CodeWriter writer, BuildContext context)
        {
            var title = GetManagementClientPrefix(context.DefaultLibraryName);

            using (writer.Scope($"namespace {context.Configuration.Namespace ?? context.DefaultNamespace}"))
            {
                writer.WriteXmlDocumentationSummary($"Client options for {title}.");
                using (writer.Scope($"public partial class {title}ManagementClientOptions: {typeof(ClientOptions)}"))
                {
                }
            }
        }

        public static string GetManagementClientPrefix(string name)
        {
            name = name.ToCleanName();

            if (name.EndsWith(OperationsSuffixValue) && name.Length >= OperationsSuffixValue.Length)
            {
                name = name.Substring(0, name.Length - OperationsSuffixValue.Length);
            }

            if (name.EndsWith(ClientSuffixValue) && name.Length >= ClientSuffixValue.Length)
            {
                name = name.Substring(0, name.Length - ClientSuffixValue.Length);
            }

            return name;
        }

        private static string ToVersionProperty(string s)
        {
            return "V" + s.Replace(".", "_").Replace('-', '_');
        }
    }
}
