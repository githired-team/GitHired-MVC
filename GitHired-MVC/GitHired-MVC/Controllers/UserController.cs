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
    public class UserController : Controller
    {
        private readonly IBoardManager _board;
        private readonly IColumnManager _column;
        private readonly IFocusManager _focus;
        private readonly IUserManager _user;
        private GitHiredDBContext _context { get; set; }

        public UserController(IUserManager user, IBoardManager board, IColumnManager column, IFocusManager focus)
        {
            _board = board;
            _column = column;
            _focus = focus;
            _user = user;
        }

        public IActionResult Index(User user)
        {
            return View(user);
        }

        public async Task<IActionResult> ExistingUserIndex(string name)
        {
            return View(await _user.SearchUserName(name));
        }

        [HttpPost]
        public async Task<IActionResult> Index(string specificUser)
        {
            return View(await _user.GetUser(specificUser));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Email,GitHubLink")] User user)
        {
        //User newUser = user;
        if (ModelState.IsValid)
        {
            await _user.CreateUser(user);
            return RedirectToAction(nameof(Index), user);
        }
        return View(user);
        }

    }
}
