using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web.Mvc;


namespace MyPokeTracker.Controllers
{
    public class UserController : Controller
    {
        // Part 3 - User - Retrieve from DB and Displaying data in UI
        // Implement REST Layer
        // Implement GetPokemonById
        // Implement GetPokemonByIdRange
        // Setup Views for User
        public PokedexDBEntities UserEntities = new PokedexDBEntities();
        
        // GET: User
         public ActionResult Index()
        {
           
            using (WebClient wc1 = new WebClient())
            { 
                string root_url = string.Format("http://localhost:62010/api/PokemonAPI");
                var json = wc1.DownloadString(root_url); //dwonloading containts from url as a string 
                List<Pokemon> parsed = JsonConvert.DeserializeObject<List<Pokemon>>(json);
                int rowsize = 50;

                
                    int iterationCount = (int)(System.Math.Ceiling((float)parsed.Count / rowsize));
                
                    for (int i = 0; i < iterationCount; i++)
                    {
                  // var result = parsed.Skip(i * rowsize).Take(rowsize);
                      var result = parsed.GetRange(i * rowsize, rowsize);
                         ViewData["Pokemon"] = result;

                        break;
                    }
                    
                }
                
               // var valueSet = JsonConvert.DeserializeObject<Pokemon>(parsed).id;

                //ViewData["Pokemon"] = result;

                return View();
               
              
            }

//            using System;
//            using System.Collections.Generic;
//            using System.Linq;



//public class Program
//        {
//            public static void Main()
//            {
//                List<String> str = new List<String> { "a", "b", "c", "d", "e", "f", "g", "h" };
//                int RowSize = 2;


//                int iterationCount = (int)(System.Math.Ceiling((float)str.Count / RowSize));
//                for (int i = 0; i < iterationCount; i++)
//                {
//                    //var result=str.Skip(i*RowSize).Take(RowSize);
//                    var result = str.GetRange(i * RowSize, RowSize);
//                    Console.WriteLine(string.Join(",", result));
//                }


//            }
//        }
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
