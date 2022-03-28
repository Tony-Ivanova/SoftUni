using SulsApp.ViewModels.Home;
using System.Collections.Generic;

namespace SulsApp.Services
{
    public interface IUsersService
    {
        void Register(string username, string email, string password);

        bool EmailExists(string email);

        bool UsernameExists(string username);

        string GetUserId(string username, string password);
    }
}
