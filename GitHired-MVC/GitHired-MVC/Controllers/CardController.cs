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

            card.ColumnID = 1;//by default it will go in the first column
            if (card.Focus.ResumeLink != null)
            {
                card.ResumeCheck = true;
            }
            else
            {
                card.ResumeCheck = false;
            }

            if (card.Focus.CoverLetter != null)
            {
                card.CoverLetterCheck = true;
            }
            else
            {
                card.CoverLetterCheck = false;
            }

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
        public async Task<IActionResult> MoveCardLeft(int id, [Bind("ID,ColumnID,ResumeCheck,CoverLetterCheck,JobTitle,CompanyName,Wage,Description,GHLink1,GHLink2,GHLink3")] Card card)
        {
            card.ColumnID = card.ColumnID - 1;
            await _card.UpdateCard(card);
            return RedirectToAction("Index", "Board");
        }
        [HttpPost]
        public async Task<IActionResult> MoveCardRight(int id, [Bind("ID,ColumnID,ResumeCheck,CoverLetterCheck,JobTitle,CompanyName,Wage,Description,GHLink1,GHLink2,GHLink3")] Card card)
        {
            card.ColumnID = card.ColumnID + 1;
            await _card.UpdateCard(card);
            return RedirectToAction("Index", "Board");
        }
    }
}
