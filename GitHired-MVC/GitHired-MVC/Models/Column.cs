using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models
{
    public class Column
    {
        public int ID { get; set; }
        public int BoardID { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        ICollection<Card> Card { get; set; }
        Board Board { get; set; }
    }
}
