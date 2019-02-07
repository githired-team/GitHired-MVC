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

        public Column Column { get; set; }
    }
}



