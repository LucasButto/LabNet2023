using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using PracticaEF.MVC.Models;

namespace PracticaEF.MVC.Controllers
{
    public class PokemonController : Controller
    {
        // GET: Pokemon
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://pokeapi.co/api/v2/pokemon?limit=151";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        PokemonListResult result = JsonConvert.DeserializeObject<PokemonListResult>(content);

                        return View(result.Results);
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
        }
    }
}
