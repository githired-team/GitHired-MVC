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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID, UserID, Name, DesiredPosition, Location, Skill,ResumeLink, CoverLetter")] Focus focus)
        {
            Focus newFocus = focus;
            if (ModelState.IsValid)
            {
                await _focus.CreateFocus(newFocus);
                return RedirectToAction(nameof(Index));
            }
            return View(focus);
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
