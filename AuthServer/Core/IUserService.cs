namespace AuthServer.Core
{
    public interface IUserService
    {
        Task<User> GetUserById(int userId);
        Task<User> GetUserByUsername(string username);
        Task<bool> CreateUser(User newUser, string password);
        Task<bool> ChangePassword(int userId, string newPassword);
        // Add other user management operations as needed
    }
}
