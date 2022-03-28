using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Services;
using SulsApp.ViewModels.Users;

namespace SulsApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel registerInput)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if(registerInput.Password != registerInput.ConfirmPassword)
            {
                return this.Error("Passwords do not match.");
            }

            if(registerInput.Password?.Length < 6 || registerInput.Password?.Length > 20)
            {
                return this.Error("The password must be between 6 and 20 characters.");
            }

            if(registerInput.Username?.Length < 5 || registerInput.Username?.Length > 20)
            {
                return this.Error("The username must be between 5 and 20 characters.");
            }

            if (this.usersService.EmailExists(registerInput.Email))
            {
                return this.Error("This email has already been registered in the system.");
            }

            if (this.usersService.UsernameExists(registerInput.Username))
            {
                return this.Error("This username is already taken.");
            }

            this.usersService.Register(registerInput.Username, registerInput.Email, registerInput.Password);

            return this.Redirect("/Login");
        }
        
        public HttpResponse Login()
        {
            if(this.IsUserLoggedIn())
            {
               return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel loginInput)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(loginInput.Username) || string.IsNullOrWhiteSpace(loginInput.Password))
            {
                return this.View(loginInput);
            }

            var userId = this.usersService.GetUserId(loginInput.Username, loginInput.Password);

            if(userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/");
            }

            return this.View();
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();

            return this.Redirect("/");
        }
    }
}
