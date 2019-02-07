using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models
{
    public class Card
    {
        public int ID { get; set; }
        public int ColumnID { get; set; }
        public bool ResumeCheck { get; set; }
        public bool CoverLetterCheck { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string Wage { get; set; }
        public string Description { get; set; }
        public string GHLink1 { get; set; }
        public string GHLink2 { get; set; }
        public string GHLink3 { get; set; }

        public Column Column { get; set; }
        //public JobPosting JobPosting { get; set; } //i don't know if adding this really helps me get access to it's data
        public Focus Focus { get; set; } //i don't know if adding this really helps me get access to it's data
    }
}



