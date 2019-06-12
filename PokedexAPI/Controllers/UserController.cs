using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace PokedexAPI.Controllers
{
    public class UserController : Controller
    {
        // Part 3 - User - Retrieve from DB and Displaying data in UI
        // Implement REST Layer
        // Implement GetPokemonById
        // Implement GetPokemonByIdRange
        // Setup Views for User
        public PokedexDBEntities4 UserEntities = new PokedexDBEntities4();
        
        // GET: User
         public ActionResult Index()
        {
           
            using (WebClient wc1 = new WebClient())
            { 
                string root_url = string.Format("http://localhost:62010/api/PokemonAPI");
                var json = wc1.DownloadString(root_url); //dwonloading containts from url as a string 
                IEnumerable<Pokemon> parsed = JsonConvert.DeserializeObject<IEnumerable<Pokemon>>(json);
                 //var valueSet =JsonConvert.DeserializeObject<Pokemon>(parsed).id;
                ViewData["Pokemon"] = parsed;              
                return View();
               
              
            }
        }

        //[HttpPost]
        //public ActionResult Index(int startid,int endid)
        //{
        //    int pstart_id = Convert.ToInt32(startid);
        //    int pend_id = Convert.ToInt32(endid);
        //    for (int enterdid = pstart_id; enterdid <= pend_id; enterdeid++)
        //    {
        //        UserEntitites.Pokemons.ToList();
        //    }
        //    return View();
        //}
    }
}