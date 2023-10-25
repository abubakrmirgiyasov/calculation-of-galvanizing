using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Mvc;
using SZGC.Api.Services;
using SZGC.Domain.Constants;
using SZGC.Domain.Models.Response;
using SZGC.Infrastructure.Services;

namespace SZGC.Api.Filters
{
    public class JwtAuthenticationAttribute : AuthorizeAttribute, IAuthenticationFilter
    {
        public JwtAuthenticationAttribute() : base() { }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != AuthenticationConstants.TOKEN_DEFAULT_SCHEME)
            {
                return;
            }

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult(UnauthorizedExceptions.StringMissingToken, request);
                return;
            }

            var token = authorization.Parameter;
            var principal = await AuthenticateJwtToken(token);

            if (principal != null)
            {
                if (ValidateRole(principal))
                {
                    context.Principal = principal;
                }
                else
                {
                    context.ErrorResult = new AuthenticationFailureResult(UnauthorizedExceptions.StringNotEnoughAccess, request);
                }
            }
            else
            {
                context.ErrorResult = new AuthenticationFailureResult(UnauthorizedExceptions.StringInvalidAccess, request);
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private async Task<IEnumerable<Claim>> GetUserRoles(string login)
        {
            var claims = new List<Claim>();

            var roles = await new RoleRequests().GetRoles(login);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            return claims;
        }

        protected async Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            if (ValidateToken(token, out var username))
            {
                var identity = new ClaimsIdentity("Jwt");

                identity.AddClaims(await GetUserRoles(username));
                identity.AddClaim(new Claim(ClaimTypes.Name, username));

                IPrincipal user = new ClaimsPrincipal(identity);

                return user;
            }

            return null;
        }

        private static bool ValidateToken(string token, out string login)
        {
            login = null;

            var simplePrinciple = JwtManager.GetPrincipal(token);

            if (!(simplePrinciple?.Identity is ClaimsIdentity identity))
            {
                return false;
            }

            if (!identity.IsAuthenticated)
            {
                return false;
            }

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            login = usernameClaim?.Value;

            if (string.IsNullOrEmpty(login))
            {
                return false;
            }

            var user = new UserRequests().GetByLoginWithoutIncludes(login);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        private bool ValidateRole(IPrincipal principal)
        {
            bool validate = false;

            if (!string.IsNullOrEmpty(Roles))
            {
                string[] roles = Roles.Split(',');
                foreach (var role in roles)
                {
                    if (principal.IsInRole(role))
                    {
                        validate = true;
                        break;
                    }
                }

                return validate;
            }
            else
            {
                return true;
            }
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;
            context.ChallengeWith("Bearer", parameter);
        }
    }
}