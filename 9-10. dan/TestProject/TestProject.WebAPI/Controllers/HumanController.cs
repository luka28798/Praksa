using System.Net;
using System.Net.Http;
using System.Web.Http;
using Human.Model.Common;
using Human.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Human.Model;
using Project.Common;
using AutoMapper;

namespace TestProject.WebAPI.Controllers
{


    public class HumanController : ApiController
    {

        protected IHumanService Service { get; set; }
        private readonly IMapper _mapper;

        public HumanController() { }

        public HumanController(IHumanService service, IMapper mapper)
        {
            this.Service = service;
            _mapper = mapper;
        }


        

        [HttpGet]

        public async Task<HttpResponseMessage> Get(int id)
        {
            IHumanModel human = await Service.GetPeopleByID(id);
            if (human == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Human with that ID doesn't exists");

            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<PeopleRest>(human));
            return response;
        }

        [HttpGet]
        [Route("api/Human/")]
        public async Task<HttpResponseMessage> FindPeople([FromUri] HumanFilterModelRest humanFilter, [FromUri] HumanSortModelRest humanSort, [FromUri] PagingModelRest humanPaging)
        {
            List<IHumanModel>  listPeople = await Service.FindPeople(_mapper.Map<IHumanFilterModel>(humanFilter), _mapper.Map<IHumanSortModel>(humanSort), _mapper.Map<IPagingModel>(humanPaging));
            if (listPeople[0] != null)
            {
                HttpResponseMessage response = Request.CreateResponse(_mapper.Map<List<PeopleRest>>(listPeople));
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "List is empty");

        }
        [HttpPost]
        [Route("api/Human/")]
        public async Task<HttpResponseMessage> Post([FromBody] PeopleRest value)
        {
            IHumanModel human = await Service.GetPeopleByID(value.HumanID);
            if (human != null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Human with that ID already exists");
            }
            await Service.AddPeople(_mapper.Map<IHumanModel>(value));
            return Request.CreateResponse(HttpStatusCode.OK, "New human inserted.");
        }

        // DELETE api/values/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            IHumanModel human = await Service.GetPeopleByID(id);
            if (human == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Human with ID = " + id + " doesn't exist.");

            }
            await Service.DeleteHumanByID(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Human with ID=" + id + " is deleted.");      
        }

        public async Task<HttpResponseMessage> Put(int id, [FromBody] PeopleRest value)
        {
            IHumanModel human = await Service.GetPeopleByID(id);
            if (human == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Human with that ID doesn't exist");

            }
            else if (human != null & id != value.HumanID)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "ID can't be changed");
                return response;
            }
            else
            {
                await Service.UpdatePeople(id, _mapper.Map<IHumanModel>(value));
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Animal with ID=" + value.HumanID + " got changed data.");
                return response;


            }
        }

    }

    public class PeopleRest
    {
        public int HumanID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class HumanFilterModelRest
    {
        public string LastName { get; set; }
    }

    public class HumanSortModelRest
    {
        public string SortParameter { get; set; }
        public string SortOrder { get; set; }
    }


}