using SulsApp.Models;
using SulsApp.ViewModels.Home;
using SulsApp.ViewModels.Problems;
using System.Collections.Generic;
using System.Linq;

namespace SulsApp.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }


        public IEnumerable<IndexInputModel> GetAll()
        {
            return this.db.Problems.Select(x => new IndexInputModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count()
            }).ToArray();
        }
        
        public string Create(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();

            return problem.Id;
        }

        public DetailsInputModel FindProblem(string id)
        {
            var problem = this.db.Problems.Where(x => x.Id == id)
                .Select(x => new DetailsInputModel
                {
                    ProblemId = x.Id,
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionsInputModel
                    {
                        CreatedOn = s.CreatedOn,
                        AchievedResult = s.AchievedResult,
                        SubmissionId = s.Id,
                        MaxPoints = x.Points,
                        Username = s.User.Username
                    })
                }).FirstOrDefault();

            return problem;
        }
    }
}
