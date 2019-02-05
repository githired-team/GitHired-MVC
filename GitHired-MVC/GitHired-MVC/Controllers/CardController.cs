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
        private readonly IBoardManager _board;
        private readonly IColumnManager _column;
        private readonly IFocusManager _focus;
        private readonly ICardManager _card;
        private GitHiredDBContext _context { get; set; }


        public CardController(ICardManager card,IBoardManager board, IColumnManager column, IFocusManager focus)
        {
            _board = board;
            _column = column;
            _focus = focus;
            _card = card;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Card newCard = new Card();

            await _card.CreateCard(newCard);
            return RedirectToAction("Index", "Board");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _card.DeleteCard(id);
            return RedirectToAction("Index", "Board");

        }

    }
}
