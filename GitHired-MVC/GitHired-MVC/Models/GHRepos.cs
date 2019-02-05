using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models
{
    public class GHRepos
    {
        public int ID { get; set; }
        public int FocusID { get; set; }
        public string GHRepo { get; set; }

        //nav
        public Focus Focus { get; set; }
        public Card Card { get; set; }
    }
}
