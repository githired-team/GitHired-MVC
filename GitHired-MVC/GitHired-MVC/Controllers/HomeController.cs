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

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Api()
        {
            // hit api
            string path = "https://githiredapi.azurewebsites.net/api/GetJobs";

            var json = await GetProductAsync(path);
            
            RootObject result = JsonConvert.DeserializeObject<RootObject>(json.ToString());

            return View(result);
        }
        static async Task<Object> GetProductAsync(string path)
        {
            Object product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Object>();
            }
            return product;
        }
    }
}
