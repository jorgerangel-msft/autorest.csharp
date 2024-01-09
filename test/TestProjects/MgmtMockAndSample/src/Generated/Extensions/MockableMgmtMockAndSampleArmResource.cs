// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using MgmtMockAndSample;

namespace MgmtMockAndSample.Mocking
{
    /// <summary> A class to add extension methods to ArmResource. </summary>
    public partial class MockableMgmtMockAndSampleArmResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableMgmtMockAndSampleArmResource"/> class for mocking. </summary>
        protected MockableMgmtMockAndSampleArmResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMgmtMockAndSampleArmResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMgmtMockAndSampleArmResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of RoleAssignmentResources in the ArmResource. </summary>
        /// <returns> An object representing collection of RoleAssignmentResources and their operations over a RoleAssignmentResource. </returns>
        public virtual RoleAssignmentCollection GetRoleAssignments()
        {
            return GetCachedClient(client => new RoleAssignmentCollection(client, Id));
        }

        /// <summary>
        /// Get the specified role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-10-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="RoleAssignmentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<RoleAssignmentResource>> GetRoleAssignmentAsync(string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            return await GetRoleAssignments().GetAsync(roleAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the specified role assignment.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RoleAssignments_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-10-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="RoleAssignmentResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="roleAssignmentName"> The name of the role assignment to get. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="roleAssignmentName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="roleAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<RoleAssignmentResource> GetRoleAssignment(string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            return GetRoleAssignments().Get(roleAssignmentName, cancellationToken);
        }
    }
}
