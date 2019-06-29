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
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Threading;
using PokedexAPI;

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
        public ActionResult Index(string start_pid, string end_pid) //httppost-sending request to server
        {
            
          int start_id = Convert.ToInt32(start_pid);
            int end_id = Convert.ToInt32(end_pid);
            
            PokedexDBEntities db = new PokedexDBEntities();

            WebClient wc = new WebClient();

            // Slow Process => Progressbar
            for (int current_id = start_id; current_id <= end_id; current_id++)
            {
                // Check if Pokemon by ID exists in DB then skip
                // TODO: Update Pokemon rather than skip
                bool hasData =db.Pokemons.Any(db_row => db_row.id == current_id);
                
                if (hasData == true) { continue; } //if true or ID exsits,continue -skip the  for loop 
                string root_url = string.Format("https://pokeapi.co/api/v2/pokemon/{0}/", current_id);
                var json = string.Empty;
                try
                {
                  json = wc.DownloadString(root_url); //json data in a string format
                }
                catch(WebException excp)
                {
                    ViewData["error"] = excp.Message;
                    continue; //skip and go to next ID when data is not found
                }
                
                //dwonloading containts from url as a string 
                JObject parsed = JObject.Parse(json); //converting json data(string) to json (object).

                Pokemon pk = new Pokemon();
                        
                //deserializeobject- converts Json object  to pokemon class
                // now pk contains properties and it sets in pokemon class
                //set sprites_front_default = json url
                //get image from url and convert to byte to store in DB
                        
                pk.id = (int)parsed.SelectToken("id");  
                pk.name = (string)parsed.SelectToken("name");
                string SpriteUrl = (string)parsed.SelectToken("sprites.front_default"); //getting only part of url as a string

                if (SpriteUrl == null) {
                    pk.sprite = System.IO.File.ReadAllBytes(Server.MapPath("~/Images/pokeballFev.png"));  
                    //ReadAllBytes -opens a binary file and reads the content of the file in to a byte array
                    
                } else {
                    pk.sprite = wc.DownloadData(SpriteUrl); //image downlading from url i.e.parsed object
                }
                
                db.Pokemons.Add(pk);
                db.SaveChanges();

                  //ViewData["sprites"] = pk.sprite;
                 //ViewData["pid"] = pk.id;
                //ViewData["pname"] = pk.name;
               //here json part of the url is displaying the image in UI
            }
            
             // Part 1 - Admin - Get Remote Data and Store in DB
             // Get Pokemon ID, Name, Sprite as JSON
             // Convert the JSON data to C# Pokemon Class
            // Get Image from Sprite URL and convert to byte
            // Store in DB

            // Part 2 - Admin - Implement Admin Interface
            // Get range of pokemons from remote api

            // Show progressbar
            // / should UPDATE existing data

            
                                               
            // TODO: Get Input from View somehow start_pid and end_pid
            return View();
        }

    } 
        
}