using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public int CompanyID { get; set; }
        public string Description { get; set; }
        public string location { get; set; }
        public string wageRange { get; set; }
    }
}
