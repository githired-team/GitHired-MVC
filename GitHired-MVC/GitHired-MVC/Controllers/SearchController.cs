using GitHired_MVC.Models;
using GitHired_MVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        private DbContext _context;

        public SearchController(ICardManager cards, )
        {
            _cards = cards;
        }

        // TODO: ensure that the user id is sent to this controller endpoint by whatever view. 
        public async Task<IActionResult> SearchResults(int userId, string query)
        {
            using (HttpClient client = new HttpClient())
            {
                if (_context.)

                try
                {
                    string path = $"https://githiredapi.azurewebsites.net/api/GetJobs?={query}";
                    HttpResponseMessage response = await client.GetAsync(path);

                    if (response.IsSuccessStatusCode)
                    {
                        string jobsJSON = await response.Content.ReadAsStringAsync();
                        List<JobPosting> jobs = JsonConvert.DeserializeObject<List<JobPosting>>(jobsJSON);
                        ViewData["userId"] = userId;
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
