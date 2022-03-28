using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SulsApp.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.problemsService.FindProblem(id);

            if(problem == null)
            {
                return this.Error("Problem not found!");
            }

            return this.View(problem);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (code == null || code.Length < 30)
            {
                return this.Error("Please provide code with at least 30 characters.");
            }

            this.submissionsService.Create(this.User, problemId, code);

            return Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.Delete(id);

            return this.Redirect("/");
        }
    }
}
