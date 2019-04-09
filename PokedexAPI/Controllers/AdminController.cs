using System.Web.Mvc;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using System.Web.Http.Description;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Threading;

namespace PokedexAPI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string start_pid, string end_pid)
        {
            int start_id = Convert.ToInt32(start_pid);
            int end_id = Convert.ToInt32(end_pid);

            // List<Pokemon> pokemons = new List<Pokemon>();

            PokemonEntities3 db = new PokemonEntities3();

            using (WebClient wc = new WebClient())
            {
                // Slow Process => Progressbar
                for (int current_id = start_id; current_id <= end_id; current_id++)
                {
                    // Check if Pokemon by ID exists in DB then skip
                    // TODO: Update Pokemon rather than skip
                    bool hasData = db.Pokemons.Any(db_row => db_row.id == current_id);
                    if (hasData == true) { continue; } //if true or ID exsits,continue -skip the below code

                    string root_url = string.Format("https://pokeapi.co/api/v2/pokemon/{0}/", current_id);
                    var json = wc.DownloadString(root_url); //dwonloading containts from url as a string 
                    JObject parsed = JObject.Parse(json); //converting json var string to json object parsed.

                    //Pokemon pk = JsonConvert.DeserializeObject<Pokemon>(json);
                    Pokemon pk = new Pokemon();


                    //deserializeobject- converts Json object  to pokemon class
                    // now pk contains properties and it sets in pokemon class
                    //set sprites_front_default = json url
                    //get image from url and convert to byte to store in DB
                    string SpriteUrl = (string)parsed.SelectToken("sprites.front_default"); //getting only part of url as a string
                    pk.id = (int)parsed.SelectToken("id");
                    pk.name = (string)parsed.SelectToken("name");
                    pk.sprite = wc.DownloadData(SpriteUrl); //image downlading from url i.e.parsed object


                    // pokemons.Add(pk);
                    db.Pokemons.Add(pk);
                    db.SaveChanges();


                }

                //db.Pokemons.AddRange(pokemons);
                //db.SaveChanges();

                ViewData["pid"] = start_id;
                ViewData["pname"] = start_id;
                ViewData["sprites"] = start_id; //here json part of the url is displaying the image in UI

                // Part 1 - Admin - Get Remote Data and Store in DB
                // Get Pokemon ID, Name, Sprite as JSON
                // Convert the JSON data to C# Pokemon Class
                // Get Image from Sprite URL and convert to byte
                // Store in DB

                // Part 2 - Admin - Implement Admin Interface
                // Get range of pokemons from remote api
                // Show progressbar
                // Function should UPDATE existing data

            }

            // TODO: Get Input from View somehow start_pid and end_pid
            return View();
        }

    } 
        
}