using System.Net;
using System.Net.Http;
using System.Web.Http;
using Animal.Model.Common;
using Animal.Service.Common;
using Animal.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Controllers
{


    public class AnimalController : ApiController
    {
        protected IAnimalService Service { get; set; }

        public AnimalController() { }
        public AnimalController(IAnimalService service)
        {
            this.Service = service;
        }

        public List<IAnimalModel> listAnimal;
        public async Task<HttpResponseMessage> Get(int id)
        {

            listAnimal = await Service.GetAnimals();
            for (int i = 0; i < listAnimal.Count; i++)
            {
                if (listAnimal[i].AnimalID == id)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, await Service.GetAnimalByID(id));
                    return response;


                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Ne postoji životinja s tim ID");
        }

        [HttpGet]
        [Route("api/Animal/")]
        public async Task<HttpResponseMessage> Get()
        {
            listAnimal = await Service.GetAnimals();
            if (listAnimal[0] != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Found, await Service.GetAnimals());
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "Lista je prazna");
        }
        [HttpPost]
        [Route("api/Animal/")]
        public async Task<HttpResponseMessage> Post([FromBody] Animals value)
        {
            listAnimal = await Service.GetAnimals();
            for (int i = 0; i < listAnimal.Count; i++)
            {
                if (listAnimal[i].AnimalID == value.AnimalID)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Životinja s tim ID već postoji");
                    return response;


                }
            }
            await Service.AddAnimal(value);
            return Request.CreateResponse(HttpStatusCode.OK, "Unesena nova životinja.");
        }

        // DELETE api/values/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            listAnimal = await Service.GetAnimals();
            for (int i = 0; i < listAnimal.Count; i++)
            {
                if (listAnimal[i].AnimalID == id)
                {
                    await Service.DeleteAnimalByID(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Found, "Životinja s ID=" + id + " je obrisana.");
                    return response;


                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Životinja s ID = " + id + " ne postoji.");
        }

        public async Task<HttpResponseMessage> Put(int id, [FromBody] Animals value)
        {
            if (id != value.AnimalID)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "ID se ne smije mijenjati");
                return response;
            }
            else
            {
                await Service.UpdateAnimal(id, value);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Životinji s ID=" + value.AnimalID + " su promijenjeni podaci.");
                return response;


            }
        }

    }

}
