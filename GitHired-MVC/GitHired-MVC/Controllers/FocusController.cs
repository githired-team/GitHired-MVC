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
    public class FocusController : Controller
    {
        private readonly IBoardManager _board;
        private readonly IColumnManager _column;
        private readonly IFocusManager _focus;
        private GitHiredDBContext _context { get; set; }

        public FocusController(IBoardManager board, IColumnManager column, IFocusManager focus)
        {
            _board = board;
            _column = column;
            _focus = focus;
        }

        public IActionResult Index(int specificUserID)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Possible View Model
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, [Bind("UserID, Name, DesiredPosition, Location, Skill, ResumeLink, CoverLetter")] Focus focus)
        {
            
            //Board newBoard = new Board();
            //newBoard.FocusID = newFocus.ID;
            //newBoard.Name = newFocus.Name;

            //Column newDefaultColInterested = new Column();
            //newDefaultColInterested.BoardID = newBoard.ID;
            //newDefaultColInterested.Name = "Interested";
            //newDefaultColInterested.Order = 1;

            //Column newDefaultColWIP = new Column();
            //newDefaultColWIP.BoardID = newBoard.ID;
            //newDefaultColWIP.Name = "In Prcess";
            //newDefaultColWIP.Order = 2;

            //Column newDefaultColComplete = new Column();
            //newDefaultColComplete.BoardID = newBoard.ID;
            //newDefaultColComplete.Name = "Done";
            //newDefaultColComplete.Order = 3;

            //newBoard.Column.Add(newDefaultColInterested);
            //newBoard.Column.Add(newDefaultColInterested);
            //newBoard.Column.Add(newDefaultColInterested);

            
                await _focus.CreateFocus(focus);
                //await _board.CreateBoard(newBoard);
                //await _column.CreateColumn(newDefaultColInterested);
                //await _column.CreateColumn(newDefaultColWIP);
                //await _column.CreateColumn(newDefaultColComplete);
                return RedirectToAction(nameof(Index), focus.UserID);
            
        }

        //edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var focus = await _focus.GetFocus(id);
            if (focus == null)
            {
                return NotFound();
            }
            return View(focus);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID, UserID, Name, DesiredPosition, Location, Skill,ResumeLink, CoverLetter")] Focus focus)
        {
            await _focus.UpdateFocus(focus);
            return RedirectToAction(nameof(Index));
        }

        //delete 
        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var delHotel = await _focus.GetFocus(id);
        //    return View(delHotel);
        //}

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var focus = await _focus.DeleteFocus(id);
            return RedirectToAction(nameof(Index));
        }

        //detail may come later
    }
}
