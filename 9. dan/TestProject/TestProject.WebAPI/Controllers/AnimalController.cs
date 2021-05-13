using System.Net;
using System.Net.Http;
using System.Web.Http;
using Animal.Model.Common;
using Animal.Service.Common;
using Animal.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AutoMapper;
using Project.Common;


namespace TestProject.WebAPI.Controllers
{


    public class AnimalController : ApiController
    {
        protected IAnimalService Service { get; set; }
        private readonly IMapper _mapper;
        public AnimalController() { }
        public AnimalController(IAnimalService service, IMapper mapper)
        {
            this.Service = service;
            _mapper = mapper;
        }

        //public List<IAnimalModel> listAnimal;
        public async Task<HttpResponseMessage> Get(int id)
        {

            IAnimalModel animal = await Service.GetAnimalByID(id);
            if (animal == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Ne postoji životinja s tim ID");
                
            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<AnimalsRest>(animal));
            return response;
            
        }

        [HttpGet]
        [Route("api/Animal/")]
        public async Task<HttpResponseMessage> Get([FromUri] AnimalFilterModel animalFilter, [FromUri] AnimalSortModel animalSort)
        {
            List<IAnimalModel> listAnimal = await Service.GetAnimals(animalFilter, animalSort);
            if (listAnimal[0] != null)
            {
                HttpResponseMessage response = Request.CreateResponse(_mapper.Map<List<AnimalsRest>>(listAnimal));
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "Lista je prazna");
        }
        [HttpPost]
        [Route("api/Animal/")]
        public async Task<HttpResponseMessage> Post([FromBody] AnimalsRest value)
        {
            IAnimalModel animal = await Service.GetAnimalByID(value.AnimalID);
            if (animal != null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Životinja s tim ID već postoji");

            }
            await Service.AddAnimal(_mapper.Map<IAnimalModel>(value));
            return Request.CreateResponse(HttpStatusCode.OK, "Unesena nova životinja.");
        }

        // DELETE api/values/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            IAnimalModel animal = await Service.GetAnimalByID(id);
            if (animal == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Ne postoji životinja s tim ID");

            }
            await Service.DeleteAnimalByID(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Successful");        
        }

        public async Task<HttpResponseMessage> Put(int id, [FromBody] AnimalsRest value)
        {
            IAnimalModel animal = await Service.GetAnimalByID(id);
            if (animal == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Ne postoji životinja s tim ID");

            }
            else if (animal != null & id != value.AnimalID)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "ID se ne smije mijenjati");
                return response;
            }
            else
            {
                await Service.UpdateAnimal(id, _mapper.Map<IAnimalModel>(value));
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Životinji s ID=" + value.AnimalID + " su promijenjeni podaci.");
                return response;


            }
        }

        

    }
    public class AnimalsRest
    {
        public int AnimalID { get; set; }
        public string AnimalType { get; set; }
        public string AnimalName { get; set; }
        public int HumanID { get; set; }
    }

}
