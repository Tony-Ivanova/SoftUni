using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Services;
using SulsApp.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SulsApp.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateProblemInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if(inputModel.Name?.Length < 5 || inputModel.Name?.Length > 20)
            {
                return this.Error("The name of the problem must be between 5 and 20 characters.");
            }
            
            if(inputModel.Points < 50 || inputModel.Points > 300)
            {
                return this.Error("The points of the problem must be between 50 and 300");
            }

            var problemId = this.problemsService.Create(inputModel.Name, inputModel.Points);

            return this.Redirect("/");
        }
        
        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.problemsService.FindProblem(id);           
                       
            return this.View(problem);
        }
    }
}
