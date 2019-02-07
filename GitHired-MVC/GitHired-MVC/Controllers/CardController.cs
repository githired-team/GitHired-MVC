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
        public async Task<IActionResult> Create(Card card)
        {
            //Request.Cookies.Append("FocusId", card.FocusID);
            await _card.CreateCard(card);
            return RedirectToAction("Index", "Board");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _card.DeleteCard(id);
            return RedirectToAction("Index", "Board");
        }
    }
}
