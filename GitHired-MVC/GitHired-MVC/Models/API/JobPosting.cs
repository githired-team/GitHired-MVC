using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models
{
    public class JobPosting
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string WageRange { get; set; }
        public string ApplicationUrl { get; set; }
        public List<string> Skillset { get; set; }
    }
}
