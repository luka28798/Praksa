using System.Net;
using System.Net.Http;
using System.Web.Http;
using ValuesModel;
using ValuesService;

namespace TestProject.WebAPI.Controllers
{
    

    public class ValuesController : ApiController
    {
 

        public HttpResponseMessage Get(int id)
        {
            
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, AnimalsService.GetAnimalByID(id));
            return response;
        }
        
        [HttpGet]
        [Route("api/Values/")]
        public HttpResponseMessage Get()
        {
            
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, AnimalsService.GetAnimals());
            return response;
        }
        [HttpPost]
        [Route("api/Values/")]
        public HttpResponseMessage Post([FromBody] Animals value)
        {
            AnimalsService.AddAnimal(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
            
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            AnimalsService.DeleteAnimalByID(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
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
                AnimalsService.UpdateAnimal(id, value);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                return response;

               
            }
        }

    }

}
