using System.Web.Mvc;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

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

            using (WebClient wc = new WebClient())
            {
                //string pid = "1";
                //if (start_pid == null)
                //{
                //    Random random = new Random();
                //    pid = random.Next(1, 800).ToString();
                //} else
                //{
                  string pid = start_pid;
                //}


                string root_url = string.Format("https://pokeapi.co/api/v2/pokemon/{0}/", pid);
                var json = wc.DownloadString(root_url);

             
                Pokemon pk = JsonConvert.DeserializeObject<Pokemon>(json);

                // TODO: Avoid double parsing. Use Pokemon class directly to unpack all data if possible
                JObject jo = JObject.Parse(json);
                string sprite_url = (string)jo.SelectToken("sprites.front_default");
         
                pk.Sprite= wc.DownloadData(sprite_url);

                //ViewData["pid"] = pk.id;
                //ViewData["pname"] = pk.name;
                //ViewData["sprite"] = pk.sprite;

                // poke url
                // Download image from url to memory
                // Convert memory to byte
                // Store in DB


                UploadPokemon(pk);


                ViewData["pid"] = pk.Id;
                ViewData["pname"] = pk.PokemonName;
                ViewData["sprite"] = sprite_url;
            }

            // TODO: Get Input from View somehow start_pid and end_pid
            return View();
        }

        [HttpPost]
        public ActionResult UploadPokemon(Pokemon modeldata)
        {


            PokedexDBEntities1 PEntites = new PokedexDBEntities1();
            {
                if (ModelState.IsValid)
                {
                    using (var db = new PokedexDBEntities1())
                    {
                        // var encryptedPassword = CustomEncrypt.Encrypt(model.Password); /*encrypting our password  CustomLibrary*/


                        //replaced with below line var Patient = db.Patient.Create();

                        db.Pokemons.Add(modeldata);

                        db.SaveChanges();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Error with one or more fields,Please check fields");
                }
                return View();
            }
        }
        private class PokemonUI
        {
            public int id { get; set; }
            public string name { get; set; } 
            public string sprite { get; set; }
        }
        
    }
}