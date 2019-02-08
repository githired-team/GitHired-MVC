using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models
{
    public class RootObject
    {
        public List<JobPosting> jobs { get; set; }
        public string query { get; set; }
    }
}
