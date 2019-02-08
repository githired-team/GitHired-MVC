using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models
{
    public class Focus
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please provide a name for this focus")]
        [Display(Name = "Focus Name")]
        public string Name { get; set; }
        public string DesiredPosition { get; set; }
        public string Location { get; set; }
        public string Skill { get; set; }
        public string ResumeLink { get; set; }
        public string CoverLetter { get; set; }
        public string GHLink1 { get; set; }
        public string GHLink2 { get; set; }
        public string GHLink3 { get; set; }

        public User User { get; set; }
        public Board Board { get; set; }
    }
}
