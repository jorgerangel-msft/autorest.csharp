﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using Azure.Core;

#pragma warning disable SA1649
namespace AutoRest.CSharp.Common.Input
{
    internal record InputNamespace(string Name, string Description, IReadOnlyList<string> ApiVersions, IReadOnlyList<InputEnumType> Enums, IReadOnlyList<InputModelType> Models, IReadOnlyList<InputClient> Clients, InputAuth Auth)
    {
        public InputNamespace() : this(Name: string.Empty, Description: string.Empty, ApiVersions: new List<string>(), Enums: new List<InputEnumType>(), Models: new List<InputModelType>(), Clients: new List<InputClient>(), Auth: new InputAuth()) {}
    }

    internal record InputAuth();

    internal record InputClient(string Name, string Description, IReadOnlyList<InputOperation> Operations)
    {
        private readonly string? _key;

        public string Key
        {
            get => _key ?? Name;
            init => _key = value;
        }

        public InputClient() : this(string.Empty, string.Empty, new List<InputOperation>()) { }
    }

    internal record InputOperation(
        string Name,
        string? Summary,
        string Description,
        string? Accessibility,
        IReadOnlyList<InputParameter> Parameters,
        IReadOnlyList<OperationResponse> Responses,
        RequestMethod HttpMethod,
        BodyMediaType RequestBodyMediaType,
        string Uri,
        string Path,
        string? ExternalDocsUrl,
        IReadOnlyList<string>? RequestMediaTypes,
        bool BufferResponse,
        OperationLongRunning? LongRunning,
        OperationPaging? Paging)
    {
        public InputOperation() : this(
            Name: string.Empty,
            Summary: null,
            Description: string.Empty,
            Accessibility: null,
            Parameters: new List<InputParameter>(),
            Responses: new List<OperationResponse>(),
            HttpMethod: RequestMethod.Get,
            RequestBodyMediaType: BodyMediaType.None,
            Uri: string.Empty,
            Path: string.Empty,
            ExternalDocsUrl: null,
            RequestMediaTypes: new List<string>(),
            BufferResponse: false,
            LongRunning: null,
            Paging: null)
        { }
    }

    internal record InputParameter(
        string Name,
        string NameInRequest,
        string? Description,
        InputType Type,
        RequestLocation Location,
        InputConstant? DefaultValue,
        VirtualParameter? VirtualParameter,
        InputParameter? GroupedBy,
        InputOperationParameterKind Kind,
        bool IsRequired,
        bool IsApiVersion,
        bool IsResourceParameter,
        bool IsContentType,
        bool IsEndpoint,
        bool SkipUrlEncoding,
        bool Explode,
        string? ArraySerializationDelimiter,
        string? HeaderCollectionPrefix)
    {
        public InputParameter() : this(
            Name: string.Empty,
            NameInRequest: string.Empty,
            Description: null,
            Type: new InputPrimitiveType(InputTypeKind.Object),
            Location: RequestLocation.None,
            DefaultValue: null,
            VirtualParameter: null,
            GroupedBy: null,
            Kind: InputOperationParameterKind.Method,
            IsRequired: false,
            IsApiVersion: false,
            IsResourceParameter: false,
            IsContentType: false,
            IsEndpoint: false,
            SkipUrlEncoding: false,
            Explode: false,
            ArraySerializationDelimiter: null,
            HeaderCollectionPrefix: null)
        { }
    }

    internal record OperationResponse(IReadOnlyList<int> StatusCodes, InputType? BodyType, BodyMediaType BodyMediaType, IReadOnlyList<HttpResponseHeader> Headers)
    {
        public OperationResponse() : this(StatusCodes: new List<int>(), BodyType: null, BodyMediaType: BodyMediaType.None, Headers: new List<HttpResponseHeader>()) { }
    }

    internal record OperationLongRunning(OperationFinalStateVia FinalStateVia, OperationResponse FinalResponse);

    internal record OperationPaging(string? NextLinkName, string? ItemName)
    {
        public InputOperation? NextLinkOperation => NextLinkOperationRef?.Invoke() ?? null;
        public Func<InputOperation>? NextLinkOperationRef { get; init; }
    }

    internal abstract record InputType(string Name, bool IsNullable = false) { }

    internal record InputPrimitiveType(InputTypeKind Kind, bool IsNullable = false) : InputType(Kind.ToString(), IsNullable)
    {
        public static InputPrimitiveType AzureLocation { get; }      = new(InputTypeKind.AzureLocation);
        public static InputPrimitiveType Boolean { get; }            = new(InputTypeKind.Boolean);
        public static InputPrimitiveType Bytes { get; }              = new(InputTypeKind.Bytes);
        public static InputPrimitiveType BytesBase64Url { get; }     = new(InputTypeKind.BytesBase64Url);
        public static InputPrimitiveType Date { get; }               = new(InputTypeKind.Date);
        public static InputPrimitiveType DateTime { get; }           = new(InputTypeKind.DateTime);
        public static InputPrimitiveType DateTimeISO8601 { get; }    = new(InputTypeKind.DateTimeISO8601);
        public static InputPrimitiveType DateTimeRFC1123 { get; }    = new(InputTypeKind.DateTimeRFC1123);
        public static InputPrimitiveType DateTimeUnix { get; }       = new(InputTypeKind.DateTimeUnix);
        public static InputPrimitiveType DurationISO8601 { get; }    = new(InputTypeKind.DurationISO8601);
        public static InputPrimitiveType DurationConstant { get; }   = new(InputTypeKind.DurationConstant);
        public static InputPrimitiveType ETag { get; }               = new(InputTypeKind.ETag);
        public static InputPrimitiveType Float32 { get; }            = new(InputTypeKind.Float32);
        public static InputPrimitiveType Float64 { get; }            = new(InputTypeKind.Float64);
        public static InputPrimitiveType Float128 { get; }           = new(InputTypeKind.Float128);
        public static InputPrimitiveType Guid { get; }               = new(InputTypeKind.Guid);
        public static InputPrimitiveType Int32 { get; }              = new(InputTypeKind.Int32);
        public static InputPrimitiveType Int64 { get; }              = new(InputTypeKind.Int64);
        public static InputPrimitiveType Object { get; }             = new(InputTypeKind.Object);
        public static InputPrimitiveType ResourceIdentifier { get; } = new(InputTypeKind.ResourceIdentifier);
        public static InputPrimitiveType ResourceType { get; }       = new(InputTypeKind.ResourceType);
        public static InputPrimitiveType Stream { get; }             = new(InputTypeKind.Stream);
        public static InputPrimitiveType String { get; }             = new(InputTypeKind.String);
        public static InputPrimitiveType Time { get; }               = new(InputTypeKind.Time);
        public static InputPrimitiveType Uri { get; }                = new(InputTypeKind.Uri);

        public bool IsNumber => Kind is InputTypeKind.Int32 or InputTypeKind.Int64 or InputTypeKind.Float32 or InputTypeKind.Float64 or InputTypeKind.Float128;
    }

    internal record InputModelType(string Name, string? Namespace, string? Accessibility, IReadOnlyList<InputModelProperty> Properties, InputModelType? BaseModel, IReadOnlyList<InputModelType> DerivedModels, string? DiscriminatorValue) : InputType(Name)
    {
        public IEnumerable<InputModelType> GetSelfAndBaseModels() => EnumerateBase(this);

        public IEnumerable<InputModelType> GetAllBaseModels() => EnumerateBase(BaseModel);

        public IReadOnlyList<InputModelType> GetAllDerivedModels()
        {
            var list = new List<InputModelType>(DerivedModels);
            for (var i = 0; i < list.Count; i++)
            {
                list.AddRange(list[i].DerivedModels);
            }

            return list;
        }

        private static IEnumerable<InputModelType> EnumerateBase(InputModelType? model)
        {
            while (model != null)
            {
                yield return model;
                model = model.BaseModel;
            }
        }
    }

    internal record InputEnumType(string Name, string? Namespace, string? Accessibility, string Description, InputPrimitiveType EnumValueType, IReadOnlyList<InputEnumTypeValue> AllowedValues, bool IsExtendable, bool IsNullable = false)
        : InputType(Name, IsNullable)
    {
        public static IEqualityComparer<InputEnumType> IgnoreNullabilityComparer { get; } = new IgnoreNullabilityComparerImplementation();

        private class IgnoreNullabilityComparerImplementation : IEqualityComparer<InputEnumType>
        {
            public bool Equals(InputEnumType? x, InputEnumType? y)
            {
                if (x is null || y is null)
                {
                    return ReferenceEquals(x, y);
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return x.Name == y.Name
                    && x.Namespace == y.Namespace
                    && x.Accessibility == y.Accessibility
                    && x.Description == y.Description
                    && x.EnumValueType.Equals(y.EnumValueType)
                    && x.AllowedValues.SequenceEqual(y.AllowedValues)
                    && x.IsExtendable == y.IsExtendable;
            }

            public int GetHashCode(InputEnumType obj)
            {

                var hashCode = new HashCode();
                hashCode.Add(obj.Name);
                hashCode.Add(obj.Namespace);
                hashCode.Add(obj.Accessibility);
                hashCode.Add(obj.Description);
                hashCode.Add(obj.EnumValueType);
                hashCode.Add(obj.IsExtendable);
                foreach (var item in obj.AllowedValues)
                {
                    hashCode.Add(item);
                }

                return hashCode.ToHashCode();
            }
        }
    }

    internal record InputListType(string Name, InputType ElementType, bool IsNullable = false) : InputType(Name, IsNullable) { }

    internal record InputDictionaryType(string Name, InputType KeyType, InputType ValueType, bool IsNullable = false) : InputType(Name, IsNullable) { }

    internal record InputModelProperty(string Name, string? SerializedName, string Description, InputType Type, bool IsRequired, bool IsReadOnly, bool IsDiscriminator) { }

    internal record InputConstant(object? Value, InputType Type);

    internal record InputEnumTypeValue(string Name, string Value, string? Description);

    internal enum InputOperationParameterKind
    {
        Method = 0,
        Client = 1,
        Constant = 2,
        Flattened = 3,
        Grouped = 4,
    }

    internal enum BodyMediaType
    {
        None,
        Binary,
        Form,
        Json,
        Multipart,
        Text,
        Xml
    }

    internal enum InputTypeKind
    {
        AzureLocation,
        Boolean,
        Bytes,
        BytesBase64Url,
        Date,
        DateTime,
        DateTimeISO8601,
        DateTimeRFC1123,
        DateTimeUnix,
        DurationISO8601,
        DurationConstant,
        ETag,
        Float32,
        Float64,
        Float128,
        Guid,
        Int32,
        Int64,
        Object,
        ResourceIdentifier,
        ResourceType,
        Stream,
        String,
        Time,
        Uri,
    }
}
