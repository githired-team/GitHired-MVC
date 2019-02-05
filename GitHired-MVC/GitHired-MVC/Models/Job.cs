using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models
{
    public class Job
    {
        public int id { get; set; }
        public string title { get; set; }
        public int companyID { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string wageRange { get; set; }
    }
}
