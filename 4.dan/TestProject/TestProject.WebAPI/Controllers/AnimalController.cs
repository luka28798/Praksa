using System.Net;
using System.Net.Http;
using System.Web.Http;
using Animal.Model;
using Animal.Service;
using System.Collections.Generic;

namespace TestProject.WebAPI.Controllers
{
    

    public class AnimalController : ApiController
    {
        public static AnimalService Service = new AnimalService();

        public List<Animals> listAnimal = Service.GetAnimals();
        public HttpResponseMessage Get(int id)
        {

            
            for (int i = 0; i < listAnimal.Count; i++)
            {
                if (listAnimal[i].AnimalID == id)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Service.GetAnimalByID(id));
                    return response;


                }
            }        
            return Request.CreateResponse(HttpStatusCode.NotFound, "Ne postoji životinja s tim ID");
        }
        
        [HttpGet]
        [Route("api/Animal/")]
        public HttpResponseMessage Get()
        {
            if (listAnimal[0] != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Found, Service.GetAnimals());
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "Lista je prazna");
        }
        [HttpPost]
        [Route("api/Animal/")]
        public HttpResponseMessage Post([FromBody] Animals value)
        {
            for (int i = 0; i < listAnimal.Count; i++)
            {
                if (listAnimal[i].AnimalID == value.AnimalID)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Životinja s tim ID već postoji");
                    return response;


                }
            }
            Service.AddAnimal(value);
            return Request.CreateResponse(HttpStatusCode.OK, "Unesena nova životinja.");            
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            for (int i = 0; i < listAnimal.Count; i++)
            {
                if (listAnimal[i].AnimalID == id)
                {
                    Service.DeleteAnimalByID(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Found, "Životinja s ID=" + id + " je obrisana.");
                    return response;


                }
            }


            return Request.CreateResponse(HttpStatusCode.NotFound, "Životinja s ID = " + id + " ne postoji.");
        }

        public HttpResponseMessage Put(int id, [FromBody] Animals value)
        {
            if (id != value.AnimalID)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "ID se ne smije mijenjati");
                return response;
            }
            else
            {
                Service.UpdateAnimal(id, value);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Životinji s ID=" + value.AnimalID + " su promijenjeni podaci.");
                return response;

               
            }
        }

    }

}
