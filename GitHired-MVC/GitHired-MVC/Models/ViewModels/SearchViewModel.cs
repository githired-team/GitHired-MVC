using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models.ViewModels
{
    public class SearchViewModel
    {
        public List<JobPosting> JobPostings { get; set; }
        public Card Card { get; set; }

        public SearchViewModel(List<JobPosting> jobPostings)
        {
            JobPostings = jobPostings;
        }
    }
}
