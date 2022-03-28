using MUSACA.Services;
using MUSACA.ViewModels.User;
using SIS.HTTP;
using SIS.MvcFramework;

namespace MUSACA.App.Controllers
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
        public HttpResponse Register(RegisterInputModel inputModel)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (this.usersService.UsernameExists(inputModel.Username))
            {
                return this.Error("Username already exists");
            }

            if(inputModel.Username?.Length < 5 || inputModel.Username?.Length > 20)
            {
                return this.Error("Username must be between 5 and 20 characters");
            }

            if(string.IsNullOrEmpty(inputModel.Email) || string.IsNullOrWhiteSpace(inputModel.Email))
            {
                return this.Error("Please enter a valid email address");
            }

            if (this.usersService.EmailExists(inputModel.Email))
            {
                return this.Error("Email already exists");
            }
            
            if(inputModel.Password?.Length < 6 || inputModel.Password?.Length > 20)
            {
                return this.Error("The password must be between 6 and 20 characters");
            }

            if(inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Error("Passwords do not match");
            }

            this.usersService.Register(inputModel.Username, inputModel.Password, inputModel.Email);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Username) || string.IsNullOrWhiteSpace(input.Password))
            {
                return this.View();
            }

            var userId = this.usersService.GetUserById(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId, input.Username);
                return this.Redirect("/");
            }

            return this.Redirect("/");
        }
          
       public HttpResponse Profile()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
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

            return this.Redirect("/Users/Login");
        }
    }
}
