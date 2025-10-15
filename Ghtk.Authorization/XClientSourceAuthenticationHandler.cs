using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ghtk.Authorization
{
    public class XClientSourceAuthenticationHandler : AuthenticationHandler<XClientSourceAuthenticationHandlerOptions>
    {
        public XClientSourceAuthenticationHandler(IOptionsMonitor<XClientSourceAuthenticationHandlerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(Options.ClientSourceValidator == null)
            {
                return Task.FromResult(AuthenticateResult.Fail("ClientSourceValidator is not configured"));
            }

            var clientSource = Context.Request.Headers["X-Client-Source"];
            if(clientSource.Count == 0)
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing X-Client-Source"));
            }

            var clientSourceValue = clientSource.FirstOrDefault();

            if (clientSourceValue == null)
            {
                return Task.FromResult(AuthenticateResult.Fail("Multiple X-Client-Source"));
            }
            if (!Options.ClientSourceValidator(clientSourceValue)){
                return Task.FromResult(AuthenticateResult.Fail("Invalid X-Client-Source"));
            }

            var identity = new ClaimsIdentity(Scheme.Name);
            identity.AddClaim(new Claim(ClaimTypes.Name, clientSourceValue));
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
