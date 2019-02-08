using GitHired_MVC.Data;
using GitHired_MVC.Models;
using GitHired_MVC.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
        /// <summary>
        /// GET Task Action to find the user
        /// </summary>
        /// <returns>User page or Home page on error</returns>
        public async Task<IActionResult> Index()
        {
            if(Request.Cookies["GitHiredCookie"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            int id = Convert.ToInt32(Request.Cookies["GitHiredCookie"]);
            User user = await _user.GetUserById(id);
            return View(user);
        }
        /// <summary>
        /// GET Task Action to find the user and create cookie
        /// </summary>
        /// <param name="name"></param>
        /// <returns>User page</returns>
        public async Task<IActionResult> Login(string name)
        {
            User user = await _user.GetUserByName(name);


            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Append("GitHiredCookie", user.ID.ToString());


            return RedirectToAction("Index");
        }
        /// <summary>
        /// GET Action to navigate to create form
        /// </summary>
        /// <returns>Create view</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// POST Task Action to create a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User page</returns>
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Email,GitHubLink")] User user)
        {
        //User newUser = user;
        if (ModelState.IsValid)
        {
            await _user.CreateUser(user);

            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Append("GitHiredCookie", user.ID.ToString());

            return RedirectToAction(nameof(Index));
        }
        return View(user);
        }
    }
}
