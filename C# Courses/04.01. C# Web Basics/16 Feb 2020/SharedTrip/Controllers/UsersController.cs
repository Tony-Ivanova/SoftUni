using SharedTrip.Services;
using SharedTrip.ViewModels.UserViews;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            if (string.IsNullOrWhiteSpace(input.Username) || string.IsNullOrWhiteSpace(input.Password))
            {
                return this.View();
            }

            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Trips/All");
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/Trips/All");
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.View(input);
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.View(input);
            }

            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username must be at least 4 characters and at most 10");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Password should match.");
            }

            if (this.usersService.EmailExists(input.Email))
            {
                return this.Error("Email already in use.");
            }

            if (this.usersService.UsernameExists(input.Username))
            {
                return this.Error("Username already in use.");
            }

            this.usersService.Register(input.Username, input.Email, input.Password);


            return this.Redirect("/Users/Login");
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
