using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaEF.MVC.Models
{
    public class PokemonListResult
    {
        public List<PokemonInfo> Results { get; set; }
    }

    public class PokemonInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}