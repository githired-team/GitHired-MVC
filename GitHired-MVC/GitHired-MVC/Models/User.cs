using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string GitHubLink { get; set; }
        public string Avatar { get; set; }
        public ICollection<Focus> Focus { get; set; }
    }
}
