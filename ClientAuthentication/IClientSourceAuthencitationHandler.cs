namespace ClientAuthentication
{
    public interface IClientSourceAuthencitationHandler
    {
        bool Validate(string ClientSource);
    }
}
