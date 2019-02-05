using GitHired_MVC.Data;
using GitHired_MVC.Models;
using GitHired_MVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoardManager _board;
        private readonly IColumnManager _column;
        private readonly IFocusManager _focus;
        private GitHiredDBContext _context { get; set; }


        public BoardController(IBoardManager board, IColumnManager column, IFocusManager focus)
        {
            _board = board;
            _column = column;
            _focus = focus;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int specificFocusID )
        {
            return View(await _board.GetBoardAsync(specificFocusID));
        }
       
        //[HttpGet]
        //public async Task Create(int specificFocusID)
        //{
        //    Board newBoard = new Board();
        //    newBoard.FocusID

        //}

    }
}
