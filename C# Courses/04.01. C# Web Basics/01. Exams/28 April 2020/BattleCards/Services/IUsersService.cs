namespace BattleCards.Services
{
    public interface IUsersService
    {
        void Register(string username, string email, string password);

        bool UsernameExists(string username);

        bool EmailExists(string email);

        string GetUserById(string username, string password);
    }
}
