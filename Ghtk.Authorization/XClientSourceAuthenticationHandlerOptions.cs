using Microsoft.AspNetCore.Authentication;

namespace Ghtk.Authorization
{
    public class XClientSourceAuthenticationHandlerOptions: AuthenticationSchemeOptions
    {
        public Func<string, string, bool> ClientValidator { get; set; } = (clientSource, token) => false;
        public string IssuerSigningKey { get; set; } = string.Empty;
    }
}
