using GitHired_MVC.Data;
using GitHired_MVC.Models;
using GitHired_MVC.Models.Interfaces;
using GitHired_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserManager _user;
        private GitHiredDBContext _context { get; set; }

        public FocusController(IUserManager user,IBoardManager board, IColumnManager column, IFocusManager focus, GitHiredDBContext context)
        {
            _board = board;
            _column = column;
            _focus = focus;
            _user = user;
            _context = context;
        }

        //public async Task<IActionResult> Index(Focus specificUserObj)
        //{
        //    int specificUserID = specificUserObj.UserID;
        //    //var returnInfo = _context.Focus.Include(fu => fu.UserID);
        //    return View(await _focus.GetFocus(specificUserID));
        //    //return View();
        //}
        public async Task<IActionResult> Index(Focus focus)
        {
            int specificUserID = focus.UserID;
            //var returnInfo = _context.Focus.Include(fu => fu.UserID);
            return View(await _focus.GetFocus(specificUserID));
            //return View();
        }

        //this is because the system didn't like two indexes even though they had diff params
        public async Task<IActionResult> ExisitingUserIndex(int id)
        {
            //var returnInfo = _context.Focus.Include(fu => fu.UserID);
            var focuses = await _focus.GetFocus(id);
            var focObj = from o in focuses
                         .Where(i => i.UserID == id)
                         select o;
            return RedirectToAction("Index", focObj.FirstOrDefault());
            //return View();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            // Possible View Model
            // ViewData["UserID"] = new SelectList(_context.User, "ID", "Name");
            FocusViewModel fvm = new FocusViewModel();
            fvm.UserID = id;
            return View(fvm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("UserID, Name, DesiredPosition, Location, Skill, ResumeLink, CoverLetter")] Focus focus)
        {
            if (ModelState.IsValid)
            {
                await _focus.CreateFocus(focus);
                Board newBoard = new Board();
                newBoard.Name = focus.Name;
                newBoard.FocusID = focus.ID;
                await _board.CreateBoard(newBoard);

                Column newDefaultColInterested = new Column();
                newDefaultColInterested.BoardID = newBoard.ID;
                newDefaultColInterested.Name = "Interested";
                newDefaultColInterested.Order = 1;

                Column newDefaultColWIP = new Column();
                newDefaultColWIP.BoardID = newBoard.ID;
                newDefaultColWIP.Name = "Application";
                newDefaultColWIP.Order = 2;

                Column newDefaultColComplete = new Column();
                newDefaultColComplete.BoardID = newBoard.ID;
                newDefaultColComplete.Name = "Submitted";
                newDefaultColComplete.Order = 3;

                Column newDefaultColInterview = new Column();
                newDefaultColInterview.BoardID = newBoard.ID;
                newDefaultColInterview.Name = "Interview";
                newDefaultColInterview.Order = 4;

                await _column.CreateColumn(newDefaultColInterested);
                await _column.CreateColumn(newDefaultColWIP);
                await _column.CreateColumn(newDefaultColComplete);
                await _column.CreateColumn(newDefaultColInterview);

                return RedirectToAction(nameof(Index), focus);
            }
            return RedirectToAction(nameof(Index), focus);

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