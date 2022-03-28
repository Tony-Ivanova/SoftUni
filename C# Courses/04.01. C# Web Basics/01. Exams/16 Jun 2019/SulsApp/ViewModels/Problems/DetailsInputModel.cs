using System.Collections.Generic;

namespace SulsApp.ViewModels.Problems
{
    public class DetailsInputModel
    {
        public string ProblemId { get; set; }

        public string Name { get; set; }

        public IEnumerable<SubmissionsInputModel> Submissions { get; set; }
    }
}
