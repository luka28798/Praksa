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
                return Request.CreateResponse(HttpStatusCode.NotFound, "Animal with that ID doesn't exists");

            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<AnimalsRest>(animal));
            return response;

        }

        [HttpGet]
        [Route("api/Animal/")]
        public async Task<HttpResponseMessage> Get([FromUri] AnimalFilterModelRest animalFilter, [FromUri] AnimalSortModelRest animalSort, [FromUri] PagingModelRest animalPaging)
        {
            List<IAnimalModel> listAnimal = await Service.FindAnimals(_mapper.Map<IAnimalFilterModel>(animalFilter), _mapper.Map<IAnimalSortModel>(animalSort), _mapper.Map<IPagingModel>(animalPaging));
            if (listAnimal[0] != null)
            {
                HttpResponseMessage response = Request.CreateResponse(_mapper.Map<List<AnimalsRest>>(listAnimal));
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "List is empty");
        }
        [HttpPost]
        [Route("api/Animal/")]
        public async Task<HttpResponseMessage> Post([FromBody] AnimalsRest value)
        {
            IAnimalModel animal = await Service.GetAnimalByID(value.AnimalID);
            if (animal != null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Animal with that ID already exists");

            }
            await Service.AddAnimal(_mapper.Map<IAnimalModel>(value));
            return Request.CreateResponse(HttpStatusCode.OK, "New animal inserted.");
        }

        // DELETE api/values/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            IAnimalModel animal = await Service.GetAnimalByID(id);
            if (animal == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Animal with that ID doesn't exist");

            }
            await Service.DeleteAnimalByID(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Successful");
        }

        public async Task<HttpResponseMessage> Put(int id, [FromBody] AnimalsRest value)
        {
            IAnimalModel animal = await Service.GetAnimalByID(id);
            if (animal == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Animal with that ID doesn't exist");

            }
            else if (animal != null & id != value.AnimalID)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "ID can't be changed");
                return response;
            }
            else
            {
                await Service.UpdateAnimal(id, _mapper.Map<IAnimalModel>(value));
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Animal with ID=" + value.AnimalID + " got changed data.");
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

    public class AnimalFilterModelRest
    {
        public string AnimalType { get; set; }
    }

    public class AnimalSortModelRest
    {
        public string SortParameter { get; set; }
        public string SortOrder { get; set; }
    }

    public class PagingModelRest
    {
        public int Page { get; set; }
        public int DataPerPage { get; set; }


    }
}
