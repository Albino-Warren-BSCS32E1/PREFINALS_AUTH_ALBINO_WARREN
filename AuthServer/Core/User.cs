namespace AuthServer.Core
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        // Add other properties as needed (e.g., email, role, etc.)
    }
}
