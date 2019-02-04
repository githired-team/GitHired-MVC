using GitHired_MVC.Data;
using GitHired_MVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Controllers
{
    public class ColumnController : Controller
    {
        private readonly IBoardManager _board;
        private readonly IColumnManager _column;
        private readonly IFocusManager _focus;
        private GitHiredDBContext _context { get; set; }


        public ColumnController(IBoardManager board, IColumnManager column, IFocusManager focus)
        {
            _board = board;
            _column = column;
            _focus = focus;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
