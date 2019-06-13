using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PokedexAPI.Controllers
{
    public class PokemonAPIController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Pokemon> Get()
        {
            using (PokedexDBEntities entities = new PokedexDBEntities())
            {
                return entities.Pokemons.ToList();
            }

        }
        
        // GET api/<controller>/5
        public Pokemon Get(int id)
        {
            using (PokedexDBEntities entities = new PokedexDBEntities())
            {
                return entities.Pokemons.FirstOrDefault(e=>e.id==id);
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
                        
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}