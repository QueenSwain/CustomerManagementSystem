using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public PokemonEntities3 UserEntitites = new PokemonEntities3();
        
        // GET: User
         public ActionResult Index()
        {
          
            return View(UserEntitites.Pokemons.ToList());
        }

        //[HttpPost]
        //public ActionResult Index(int startid,int endid)
        //{
        //    int pstart_id = Convert.ToInt32(startid);
        //    int pend_id = Convert.ToInt32(endid);
        //    for (int enterdid = pstart_id; enterdid <= pend_id; enterdid++)
        //    {
        //        UserEntitites.Pokemons.ToList();
        //    }
        //    return View();
        //}
    }
}