using PokedexDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PokedexAPI.Controllers
{
    public class PokedexController : ApiController
    {
     public IEnumerable<PokeBasicInfo> Get()
        {
            using (PokedexDBEntities entities = new PokedexDBEntities())
            {
                return entities.PokeBasicInfo.ToList();
            }
        }
        public HttpResponseMessage Get(int id)
        {
            using (PokedexDBEntities entities = new PokedexDBEntities())
            {
                var entity=entities.PokeBasicInfo.FirstOrDefault(e=>e.PokeId==id);
                if(entities!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entities);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Pokes with Id="+id.ToString()+"not found");
                }
            }
        }

        public HttpResponseMessage Post([FromBody]PokeBasicInfo PokeInfoes)
        {
            try { 
            using (PokedexDBEntities entities = new PokedexDBEntities())
            {
                entities.PokeBasicInfo.Add(PokeInfoes);
                entities.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, PokeInfoes);
                    message.Headers.Location = new Uri(Request.RequestUri+PokeInfoes.PokeId.ToString());
                return message;
            }
        }
            catch(Exception ex)
            {
               return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            }


    }
}
