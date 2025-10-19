using ClientAuthentication;

namespace GHTK.Api.AuthenticationHandler
{
    public class RemoteClientSourceAuthencitationHandler : IClientSourceAuthencitationHandler
    {
        private readonly string authenticationServiceUrl;
        private static readonly HttpClient httpClient = new();

        public RemoteClientSourceAuthencitationHandler(string authenticationServiceUrl)
        {
            this.authenticationServiceUrl = authenticationServiceUrl;
        }
        public bool Validate(string ClientSource)
        {
            if(string.IsNullOrEmpty(ClientSource))
            {
                return false;
            }
            var response = httpClient.GetAsync($"{authenticationServiceUrl}/api/ClientSource/{ClientSource}").Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
