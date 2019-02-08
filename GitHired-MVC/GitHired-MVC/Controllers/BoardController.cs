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
        /// <summary>
        /// GET Task Action to find the board
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Board view</returns>
        public async Task<IActionResult> Index(int? id)
        {
            if (Request.Cookies["FocusCookie"] != null)
            {
                id = Convert.ToInt32(Request.Cookies["FocusCookie"]);
            }
            else if (id != null)
            {
                Response.Cookies.Append("FocusCookie", id.ToString());
            }
            else
                return NotFound();

            Board board = await _board.GetBoardAsync((int)id);
            return View(board);
        }
    }
}
