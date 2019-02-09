using GitHired_MVC.Data;
using GitHired_MVC.Models;
using GitHired_MVC.Models.Interfaces;
using GitHired_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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
        /// <summary>
        /// POST Task Action to call the API and create RootObject
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Search results view</returns>
        [HttpPost] 
        public async Task<IActionResult> Index(string query)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string path = QueryHelpers.AddQueryString("https://githiredapi.azurewebsites.net/api/GetJobs", "query", query);
                    HttpResponseMessage response = await client.GetAsync(path);

                    if (response.IsSuccessStatusCode)
                    {
                        string jobsJSON = await response.Content.ReadAsStringAsync();
                        RootObject results = JsonConvert.DeserializeObject<RootObject>(jobsJSON);
                        SearchViewModel model = new SearchViewModel(results.jobs);
                        return View(model);

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
