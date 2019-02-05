using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models
{
    public class Focus
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string DesiredPosition { get; set; }
        public string Location { get; set; }
        public string Skill { get; set; }
        public string ResumeLink { get; set; }
        public string CoverLetter { get; set; }

        public User User { get; set; }
        public Board Board { get; set; }
    }
}
