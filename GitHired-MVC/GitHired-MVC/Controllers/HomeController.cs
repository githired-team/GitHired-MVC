using GitHired_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHired_MVC.Controllers
{
    public class HomeController: Controller
    {
        static HttpClient client = new HttpClient();
        /// <summary>
        /// GET Action for homepage
        /// </summary>
        /// <returns>Homepage view</returns>
        public IActionResult Index()
        {
            Response.Cookies.Delete("GitHiredCookie");
            return View();
        }
    }
}
