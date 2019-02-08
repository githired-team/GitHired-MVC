using GitHired_MVC.Data;
using GitHired_MVC.Models;
using GitHired_MVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardManager _card;
        private GitHiredDBContext _context;

        public CardController(ICardManager card, GitHiredDBContext context)
        {
            _context = context;
            _card = card;
        }

        public async Task<IActionResult> Index(int cardId)
        {
            return View( await _card.GetCard(cardId) );
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID,ColumnID,ResumeCheck,CoverLetterCheck,JobTitle,CompanyName,Wage,Description,GHLink1,GHLink2,GHLink3")] Card card)
        {
            int focusID = Convert.ToInt32(Request.Cookies["FocusCookie"]);
            int boardID = await _context.Board.Where(b => b.FocusID == focusID)
                                              .Select(b => b.ID)
                                              .FirstOrDefaultAsync();

            card.ColumnID = await _context.Column.Where(c => c.BoardID == boardID)
                                                  .Where(c => c.Order == 1)
                                                  .Select(c => c.ID)
                                                  .FirstOrDefaultAsync();
            //by default it will go in the first column
            //if (card.Focus.ResumeLink != null)
            //{
            //    card.ResumeCheck = true;
            //}
            //else
            //{
            //    card.ResumeCheck = false;
            //}

            //if (card.Focus.CoverLetter != null)
            //{
            //    card.CoverLetterCheck = true;
            //}
            //else
            //{
            //    card.CoverLetterCheck = false;
            //}

            await _card.CreateCard(card);
            return RedirectToAction("Index", "Board");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _card.DeleteCard(id);
            return RedirectToAction("Index", "Board");

        }
        [HttpPost]
        public async Task<IActionResult> MoveCardLeft(int id)
        {
            int focusID = Convert.ToInt32(Request.Cookies["FocusCookie"]);
            Board board = await _context.Board.Where(b => b.FocusID == focusID)
                                        .Include(b => b.Column)
                                        .FirstOrDefaultAsync();



            Card card = await _context.Card.Where(c => c.ID == id)
                                            .Include(c => c.Column)
                                            .FirstOrDefaultAsync();

            int desiredColumnOrder = card.Column.Order - 1;

            int? desiredColumnID = board.Column.Where(c => c.Order == desiredColumnOrder)
                                              .Select(c => c.ID)
                                              .First();
            if (desiredColumnID != null)
            {
                card.ColumnID = (int)desiredColumnID;
                await _card.UpdateCard(card);
            }
            return RedirectToAction("Index", "Board");
        }
        [HttpPost]
        public async Task<IActionResult> MoveCardRight(int id)
        {
            int focusID = Convert.ToInt32(Request.Cookies["FocusCookie"]);
            Board board = await _context.Board.Where(b => b.FocusID == focusID)
                                               .Include(b => b.Column)
                                               .FirstOrDefaultAsync();

            Card card = await _context.Card.Where(c => c.ID == id)
                                            .Include(c => c.Column)
                                            .FirstOrDefaultAsync();

            int desiredColumnOrder = card.Column.Order + 1;

            int? desiredColumnID = board.Column.Where(c => c.Order == desiredColumnOrder)
                                              .Select(c => c.ID)
                                              .First();
            if (desiredColumnID != null)
            {
                card.ColumnID = (int)desiredColumnID;
                await _card.UpdateCard(card);
            }
            return RedirectToAction("Index", "Board");
        }
    }
}
