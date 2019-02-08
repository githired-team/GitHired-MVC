using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace GitHired_MVC.Models
{
    public class Board
    {
        public int ID { get; set; }
        public int FocusID { get; set; }

        [Required(ErrorMessage = "Please provide a name for this board")]
        [Display(Name = "Board Name")]
        public string Name { get; set; }

        public ICollection<Column> Column { get; set; }
        public Focus Focus { get; set; }
    }
}
