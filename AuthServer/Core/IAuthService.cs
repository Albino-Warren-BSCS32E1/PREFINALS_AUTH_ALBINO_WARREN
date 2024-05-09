namespace AuthServer.Core
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken(User user);
        Task<bool> ValidateCredentials(string username, string password);
        // Add other authentication operations as needed
    }
}
