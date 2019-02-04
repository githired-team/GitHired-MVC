using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GitHired_MVC.Models
{
    public class Board
    {
        public int ID { get; set; }
        public int FocusID { get; set; }
        public string Name { get; set; }

        public ICollection<Column> Column { get; set; }
        public Focus Focus { get; set; }
    }
}
