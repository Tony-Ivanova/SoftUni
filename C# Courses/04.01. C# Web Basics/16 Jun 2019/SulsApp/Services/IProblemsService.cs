using SulsApp.Models;
using SulsApp.ViewModels.Home;
using SulsApp.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Text;

namespace SulsApp.Services
{
    public interface IProblemsService
    {
        string Create(string name, int points);

        DetailsInputModel FindProblem(string id);

        public IEnumerable<IndexInputModel> GetAll();
    }
}
