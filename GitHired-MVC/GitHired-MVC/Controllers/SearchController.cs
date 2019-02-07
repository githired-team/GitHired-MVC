using GitHired_MVC.Data;
using GitHired_MVC.Models;
using GitHired_MVC.Models.Interfaces;
using GitHired_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHired_MVC.Controllers
{
    public class SearchController : Controller
    {
        private ICardManager _cards;
        private GitHiredDBContext _context;

        public SearchController(ICardManager cards, GitHiredDBContext context)
        {
            _cards = cards;
            _context = context;
        }


        [HttpGet]
        // TODO: ensure that the user id is sent to this controller endpoint by whatever view. 
        public async Task<IActionResult> SearchResults(string query)
        {
            using (HttpClient client = new HttpClient())
            {


                try
                {
                    string path = $"https://githiredapi.azurewebsites.net/api/GetJobs?={query}";
                    HttpResponseMessage response = await client.GetAsync(path);

                    if (response.IsSuccessStatusCode)
                    {
                        string jobsJSON = await response.Content.ReadAsStringAsync();
                        List<JobPosting> jobs = JsonConvert.DeserializeObject<List<JobPosting>>(jobsJSON);

                        string userId = Request.Cookies["GitHiredCookie"];
                        //Response.Cookies.Append("userId", userId);

                        return View(jobs);

                    } else
                    {
                        // TODO: add "something went wrong" page
                        Console.WriteLine("API Broke :(((");
                        return RedirectToAction("Index", "Board");
                    }
                } catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                    return RedirectToAction("Index", "Board");
                }
            }
        }

        
    }
}
