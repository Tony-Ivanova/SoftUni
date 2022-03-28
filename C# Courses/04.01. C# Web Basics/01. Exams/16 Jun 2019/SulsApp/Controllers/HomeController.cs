using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Services;

namespace SulsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewModel = this.problemsService.GetAll();

                return this.View(viewModel, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
