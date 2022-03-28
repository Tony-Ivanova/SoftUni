namespace MUSACA.Services
{
    public interface IUsersService
    {
        void Register(string username, string password, string email);

        bool UsernameExists(string username);

        bool EmailExists(string email);

        string GetUserById(string username, string password);
    }
}
