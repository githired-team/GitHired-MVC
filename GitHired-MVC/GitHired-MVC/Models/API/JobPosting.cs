using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models
{
    public class JobPosting
    {
        public Job job { get; set; }
        public List<string> skills { get; set; }
    }
}
