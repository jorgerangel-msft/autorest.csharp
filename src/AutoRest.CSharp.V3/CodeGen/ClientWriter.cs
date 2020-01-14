﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Response = Azure.Response;
using SerializationFormat = AutoRest.CSharp.V3.ClientModels.SerializationFormat;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class ClientWriter
    {
        private readonly TypeFactory _typeFactory;

        public ClientWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public void WriteClient(CodeWriter writer, ServiceClient operationGroup)
        {
            var cs = _typeFactory.CreateType(operationGroup.Name);
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(operationGroup.Description);
                using (writer.Class("internal", "partial", cs.Name))
                {
                    WriteClientFields(writer, operationGroup);

                    WriteClientCtor(writer, operationGroup, cs);

                    foreach (var method in operationGroup.Methods)
                    {
                        WriteRequestCreation(writer, method);
                        WriteOperation(writer, method, true);
                        WriteOperation(writer, method, false);
                    }

                    foreach (var pagingMethod in operationGroup.PagingMethods)
                    {
                        WritePagingOperation(writer, pagingMethod, true);
                        WritePagingOperation(writer, pagingMethod, false);
                    }
                }
            }
        }

        private void WriteClientFields(CodeWriter writer, ServiceClient operationGroup)
        {
            foreach (ServiceClientParameter clientParameter in operationGroup.Parameters)
            {
                writer.Line($"private {_typeFactory.CreateType(clientParameter.Type)} {clientParameter.Name};");
            }

            writer.Line($"private {typeof(ClientDiagnostics)} clientDiagnostics;");
            writer.Line($"private {typeof(HttpPipeline)} pipeline;");
        }

        private void WriteClientCtor(CodeWriter writer, ServiceClient operationGroup, CSharpType cs)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {cs.Name}");
            writer.Append($"public {cs.Name:D}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline,");
            foreach (ServiceClientParameter clientParameter in operationGroup.Parameters)
            {
                WriteParameter(writer, clientParameter);
            }

            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                WriteParameterNullChecks(writer, operationGroup.Parameters);

                foreach (ServiceClientParameter clientParameter in operationGroup.Parameters)
                {
                    writer.Line($"this.{clientParameter.Name} = {clientParameter.Name};");
                }

                writer.Line($"this.clientDiagnostics = clientDiagnostics;");
                writer.Line($"this.pipeline = pipeline;");
            }
        }

        private void WriteParameter(CodeWriter writer, ServiceClientParameter clientParameter)
        {
            writer.Append($"{_typeFactory.CreateInputType(clientParameter.Type)} {clientParameter.Name}");
            if (clientParameter.DefaultValue != null)
            {
                writer.Append($" = {clientParameter.DefaultValue.Value.Value:L}");
            }

            writer.AppendRaw(",");
        }

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private string CreateRequestMethodName(string name) => $"Create{name}Request";

        private void WriteRequestCreation(CodeWriter writer, ClientMethod operation)
        {
            var methodName = CreateRequestMethodName(operation.Name);
            writer.Append($"internal {typeof(HttpMessage)} {methodName}(");
            var parameters = operation.Parameters;
            foreach (ServiceClientParameter clientParameter in parameters)
            {
                writer.Append($"{_typeFactory.CreateInputType(clientParameter.Type)} {clientParameter.Name},");
            }
            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                writer.Line($"var message = pipeline.CreateMessage();");
                writer.Line($"var request = message.Request;");
                var method = operation.Request.Method;
                writer.Line($"request.Method = {typeof(RequestMethod)}.{method.ToRequestMethodName()};");

                var uriType = writer.Type(typeof(Uri));

                //TODO: Add logic to escape the strings when specified, using Uri.EscapeDataString(value);
                //TODO: Need proper logic to convert the values to strings. Right now, everything is just using default ToString().
                //TODO: Need logic to trim duplicate slashes (/) so when combined, you don't end  up with multiple // together
                var urlText = String.Join(String.Empty, operation.Request.HostSegments.Select(s => s.IsConstant ? s.Constant.Value : "{" + s.Parameter.Name + "}"));
                writer.Line($"request.Uri.Reset(new {uriType}($\"{urlText}\"));");

                foreach (var segment in operation.Request.PathSegments)
                {
                    WritePathSegment(writer, segment);
                }

                //TODO: Duplicate code between query and header parameter processing logic
                foreach (var queryParameter in operation.Request.Query)
                {
                    WriteQueryParameter(writer, queryParameter);
                }

                foreach (var header in operation.Request.Headers)
                {
                    WriteHeader(writer, header);
                }

                if (operation.Request.Body is ObjectRequestBody body && body.Serialization is JsonSerialization jsonSerialization)
                {
                    writer.Line($"using var content = new {typeof(Utf8JsonRequestContent)}();");

                    ConstantOrParameter value = body.Value;

                    writer.ToSerializeCall(
                        jsonSerialization,
                        _typeFactory,
                        WriteConstantOrParameter(value),
                        writerName: w => w.Append($"content.{nameof(Utf8JsonRequestContent.JsonWriter)}"));

                    writer.Line($"request.Content = content;");
                }
                else if (operation.Request.Body is ObjectRequestBody xmlBody && xmlBody.Serialization is XmlElementSerialization xmlSerialization)
                {
                    writer.Line($"using var content = new {typeof(XmlWriterContent)}();");

                    ConstantOrParameter value = xmlBody.Value;

                    writer.ToSerializeCall(
                        xmlSerialization,
                        _typeFactory,
                        WriteConstantOrParameter(value),
                        writerName: w => w.Append($"content.{nameof(XmlWriterContent.XmlWriter)}"));

                    writer.Line($"request.Content = content;");
                }

                writer.Line($"return message;");
            }
        }

        private void WriteOperation(CodeWriter writer, ClientMethod operation, bool async)
        {
            //TODO: Handle multiple responses
            var responseBody = operation.Response.ResponseBody;
            CSharpType? bodyType = responseBody != null ? _typeFactory.CreateType(responseBody.Type) : null;
            CSharpType? headerModelType = operation.Response.HeaderModel != null ? _typeFactory.CreateType(operation.Response.HeaderModel.Name) : null;
            CSharpType responseType = bodyType switch
            {
                null when headerModelType != null => new CSharpType(typeof(ResponseWithHeaders<>), headerModelType),
                { } when headerModelType == null => new CSharpType(typeof(Response<>), bodyType),
                { } => new CSharpType(typeof(ResponseWithHeaders<>), bodyType, headerModelType),
                _ => new CSharpType(typeof(Response)),
            };
            var parameters = operation.Parameters;
            writer.WriteXmlDocumentationSummary(operation.Description);

            foreach (ServiceClientParameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            var methodName = CreateMethodName(operation.Name, async);
            CSharpType asyncReturnType = new CSharpType(typeof(ValueTask<>), responseType);
            writer.Append($"public {(async ? "async " : string.Empty)}{(async ? asyncReturnType : responseType)} {methodName}(");

            foreach (ServiceClientParameter parameter in parameters)
            {
                WriteParameter(writer, parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WriteParameterNullChecks(writer, parameters);

                writer.Line($"using var scope = clientDiagnostics.CreateScope({operation.Diagnostics.ScopeName:L});");
                foreach (DiagnosticScopeAttributes diagnosticScopeAttributes in operation.Diagnostics.Attributes)
                {
                    writer.Line($"scope.AddAttribute({diagnosticScopeAttributes.Name:L}, {WriteConstantOrParameter(diagnosticScopeAttributes.Value)};");
                }
                writer.Line($"scope.Start();");

                using (writer.Scope($"try"))
                {
                    var requestMethodName = CreateRequestMethodName(operation.Name);
                    writer.Append($"using var message = {requestMethodName}(");

                    foreach (ServiceClientParameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }

                    writer.RemoveTrailingComma();
                    writer.Line($");");

                    if (async)
                    {
                        writer.Line($"await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);");
                    }
                    else
                    {
                        writer.Line($"pipeline.Send(message, cancellationToken);");
                    }

                    WriteStatusCodeSwitch(writer, responseBody, headerModelType, operation, async);
                }

                using (writer.Scope($"catch ({typeof(Exception)} e)"))
                {
                    writer.Line($"scope.Failed(e);");
                    writer.Line($"throw;");
                }
            }
        }

        private void WritePagingOperation(CodeWriter writer, ClientMethodPaging pagingMethod, bool async)
        {
            var pageType = _typeFactory.CreateType(pagingMethod.ItemType);
            CSharpType responseType = async ? new CSharpType(typeof(AsyncPageable<>), pageType) : new CSharpType(typeof(Pageable<>), pageType);
            var parameters = pagingMethod.Method.Parameters;
            var nextPageParameters = pagingMethod.NextPageMethod.Parameters;

            writer.WriteXmlDocumentationSummary(pagingMethod.Method.Description);

            foreach (ServiceClientParameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            writer.Append($"public {responseType} {CreateMethodName(pagingMethod.Name, async)}(");
            foreach (ServiceClientParameter parameter in parameters)
            {
                WriteParameter(writer, parameter);
            }

            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WriteParameterNullChecks(writer, parameters);

                var pageWrappedType = new CSharpType(typeof(Page<>), pageType);
                var funcType = async ? new CSharpType(typeof(Task<>), pageWrappedType) : pageWrappedType;
                var nullableInt = new CSharpType(typeof(int), true);

                var continuationTokenText = pagingMethod.NextLinkName != null ? $"response.Value.{pagingMethod.NextLinkName}" : "null";
                var asyncText = async ? "async " : string.Empty;
                var awaitText = async ? "await " : string.Empty;
                using (writer.Scope($"{asyncText}{funcType} FirstPageFunc({nullableInt} pageSizeHint)"))
                {
                    writer.Append($"var response = {awaitText}{CreateMethodName(pagingMethod.Method.Name, async)}(");
                    foreach (ServiceClientParameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }
                    writer.Line($"cancellationToken);");
                    writer.Line($"return {typeof(Page)}.FromValues(response.Value.{pagingMethod.ItemName}, {continuationTokenText}, response.GetRawResponse());");
                }

                using (writer.Scope($"{asyncText}{funcType} NextPageFunc({typeof(string)} nextLinkUrl, {nullableInt} pageSizeHint)"))
                {
                    writer.Append($"var response = {awaitText}{CreateMethodName(pagingMethod.NextPageMethod.Name, async)}(");
                    foreach (ServiceClientParameter parameter in nextPageParameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }
                    writer.Line($"cancellationToken);");
                    writer.Line($"return {typeof(Page)}.FromValues(response.Value.{pagingMethod.ItemName}, {continuationTokenText}, response.GetRawResponse());");
                }
                writer.Line($"return PageResponseEnumerator.Create{(async ? "Async" : string.Empty)}Enumerable(FirstPageFunc, NextPageFunc);");
            }
        }

        private CodeWriterDelegate WriteConstantOrParameter(ConstantOrParameter constantOrParameter) => writer =>
        {
            if (constantOrParameter.IsConstant)
            {
                WriteConstant(writer, constantOrParameter.Constant);
            }
            else
            {
                writer.AppendRaw(constantOrParameter.Parameter.Name)
                    .AppendNullableValue(_typeFactory.CreateType(constantOrParameter.Type));
            }
        };

        private void WriteParameterNullChecks(CodeWriter writer, IEnumerable<ServiceClientParameter> parameters)
        {
            foreach (ServiceClientParameter parameter in parameters)
            {
                var cs = _typeFactory.CreateType(parameter.Type);
                if (parameter.IsRequired && (cs.IsNullable || !cs.IsValueType))
                {
                    using (writer.If($"{parameter.Name} == null"))
                    {
                        writer.Line($"throw new {typeof(ArgumentNullException)}(nameof({parameter.Name}));");
                    }
                }
            }
            writer.Line();
        }

        private void WriteConstant(CodeWriter writer, ClientConstant constant)
        {
            if (constant.Value == null)
            {
                // Cast helps the overload resolution
                writer.Append($"({_typeFactory.CreateType(constant.Type)}){null:L}");
                return;
            }

            switch (constant.Type)
            {
                case FrameworkTypeReference frameworkType when frameworkType.Type == typeof(DateTimeOffset):
                    var d = (DateTimeOffset)constant.Value;
                    d = d.ToUniversalTime();
                    writer.Append($"new {typeof(DateTimeOffset)}({d.Year:L}, {d.Month:L}, {d.Day:L} ,{d.Hour:L}, {d.Minute:L}, {d.Second:L}, {d.Millisecond:L}, {typeof(TimeSpan)}.{nameof(TimeSpan.Zero)})");
                    break;
                case FrameworkTypeReference frameworkType when frameworkType.Type == typeof(byte[]):
                    var value = (byte[])constant.Value;
                    writer.Append($"new byte[] {{");
                    foreach (byte b in value)
                    {
                        writer.Append($"{b}, ");
                    }
                    writer.Append($"}}");
                    break;
                case FrameworkTypeReference _:
                    writer.Literal(constant.Value);
                    break;
                default:
                    throw new InvalidOperationException("Unknown constant type");
            }
        }

        private void WritePathSegment(CodeWriter writer, PathSegment segment)
        {
            writer.Append($"request.Uri.AppendPath({WriteConstantOrParameter(segment.Value)}");
            WriteSerializationFormat(writer, segment.Format);
            writer.Line($", {segment.Escape:L});");
        }

        private void WriteHeader(CodeWriter writer, RequestHeader header)
        {
            using (WriteValueNullCheck(writer, header.Value))
            {
                writer.Append($"request.Headers.Add({header.Name:L}, {WriteConstantOrParameter(header.Value)}");
                WriteSerializationFormat(writer, header.Format);
                writer.Line($");");
            }
        }

        private CodeWriter.CodeWriterScope? WriteValueNullCheck(CodeWriter writer, ConstantOrParameter value)
        {
            if (value.IsConstant)
                return default;

            var type = _typeFactory.CreateType(value.Type);
            if (type.IsNullable)
            {
                return writer.If($"{value.Parameter.Name} != null");
            }

            return default;
        }

        private void WriteSerializationFormat(CodeWriter writer, SerializationFormat format)
        {
            if (format == SerializationFormat.Bytes_Base64Url)
            {
                // base64url is the only options for paths ns queries
                return;
            }

            var formatSpecifier = format.ToFormatSpecifier();
            if (formatSpecifier != null)
            {
                writer.Append($", {formatSpecifier:L}");
            }
        }

        private void WriteQueryParameter(CodeWriter writer, QueryParameter queryParameter)
        {
            string method;
            string? delimiter = null;
            switch (queryParameter.SerializationStyle)
            {
                case QuerySerializationStyle.PipeDelimited:
                    method = nameof(UriBuilderExtensions.AppendQueryDelimited);
                    delimiter = "|";
                    break;
                case QuerySerializationStyle.TabDelimited:
                    method = nameof(UriBuilderExtensions.AppendQueryDelimited);
                    delimiter = "\t";
                    break;
                case QuerySerializationStyle.SpaceDelimited:
                    method = nameof(UriBuilderExtensions.AppendQueryDelimited);
                    delimiter = " ";
                    break;
                case QuerySerializationStyle.CommaDelimited:
                    method = nameof(UriBuilderExtensions.AppendQueryDelimited);
                    delimiter = ",";
                    break;

                default:
                    method = nameof(UriBuilderExtensions.AppendQuery);
                    break;
            }

            ConstantOrParameter value = queryParameter.Value;
            using (WriteValueNullCheck(writer, value))
            {
                writer.Append($"request.Uri.{method}({queryParameter.Name:L}, {WriteConstantOrParameter(value)}");
                if (delimiter != null)
                {
                    writer.Append($", {delimiter:L}");
                }
                WriteSerializationFormat(writer, queryParameter.SerializationFormat);
                writer.Line($", {queryParameter.Escape:L});");
            }
        }

        //TODO: Do multiple status codes
        private void WriteStatusCodeSwitch(CodeWriter writer, ResponseBody? responseBody, CSharpType? headersModelType, ClientMethod operation, bool async)
        {
            using (writer.Switch("message.Response.Status"))
            {
                var statusCodes = operation.Response.SuccessfulStatusCodes;
                foreach (var statusCode in statusCodes)
                {
                    writer.Line($"case {statusCode}:");
                }

                using (responseBody != null ? writer.Scope() : default)
                {
                    string valueVariable = "value";

                    if (responseBody is ObjectResponseBody objectResponseBody)
                    {
                        const string document = "document";
                        switch (objectResponseBody.Serialization)
                        {
                            case JsonSerialization jsonSerialization:
                                writer.Append($"using var {document:D} = ");
                                if (async)
                                {
                                    writer.Line($"await {typeof(JsonDocument)}.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);");
                                }
                                else
                                {
                                    writer.Line($"{typeof(JsonDocument)}.Parse(message.Response.ContentStream);");
                                }

                                writer.ToDeserializeCall(
                                    jsonSerialization,
                                    _typeFactory,
                                    w => w.Append($"document.RootElement"),
                                    ref valueVariable
                                );
                                break;
                            case XmlElementSerialization xmlSerialization:
                                writer.Line($"var {document:D} = {typeof(XDocument)}.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);");
                                writer.ToDeserializeCall(
                                    xmlSerialization,
                                    _typeFactory,
                                    w => w.Append($"document"),
                                    ref valueVariable
                                );
                                break;
                        }
                    }
                    else if (responseBody is StreamResponseBody _)
                    {
                        writer.Line($"var {valueVariable:D} = message.ExtractResponseContent();");
                    }

                    if (headersModelType != null)
                    {
                        writer.Line($"var headers = new {headersModelType}(message.Response);");
                    }

                    var responseCallText = responseBody switch
                    {
                        null when headersModelType != null => $"{typeof(ResponseWithHeaders)}.FromValue(headers, message.Response)",
                        { } when headersModelType != null => $"{typeof(ResponseWithHeaders)}.FromValue({valueVariable}, headers, message.Response)",
                        { } => $"{typeof(Response)}.FromValue({valueVariable}, message.Response)",
                        _ => "message.Response"
                    };
                    writer.Line($"return {responseCallText};");
                }

                writer.Line($"default:");
                if (async)
                {
                    writer.Line($"throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"throw message.Response.CreateRequestFailedException();");
                }
            }
        }
    }
}
