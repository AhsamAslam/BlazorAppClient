using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCommunityBuilder.Identity.Helpers
{
    public class RequireMfa : IAuthorizationRequirement { }

    /// <summary>
    /// Authorize user again MFA
    /// Check if user has MFA enabled
    /// </summary>
    public class RequireMfaHandler : AuthorizationHandler<RequireMfa>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            RequireMfa requirement)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (requirement == null)
                throw new ArgumentNullException(nameof(requirement));

            var amrClaim =
                context.User.Claims.FirstOrDefault(t => t.Type == "amr");

            // Check wheter AMR claim have MFA value
            if (amrClaim != null && amrClaim.Value == "mfa")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
