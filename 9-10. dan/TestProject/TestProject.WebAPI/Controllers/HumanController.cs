using System.Net;
using System.Net.Http;
using System.Web.Http;
using Human.Model.Common;
using Human.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Human.Model;

namespace TestProject.WebAPI.Controllers
{


    public class HumanController : ApiController
    {

        public IHumanService Service { get; set; }

        public HumanController() { }

        public HumanController(IHumanService service)
        {
            this.Service = service;
        }


        public List<IHumanModel> listPeople;

        [HttpGet]

        public async Task<HttpResponseMessage> Get(int id)
        {
            IHumanModel human = await Service.GetPeopleByID(id);
            if (human == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Ne postoji čovjek s tim ID");

            }

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, await Service.GetPeopleByID(id));
            return response;
        }

        [HttpGet]
        [Route("api/Human/")]
        public async Task<HttpResponseMessage> Get()
        {
            listPeople = await Service.GetAllPeople();
            if (listPeople[0] != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Found, await Service.GetAllPeople());
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "Lista je prazna");

        }
        [HttpPost]
        [Route("api/Human/")]
        public async Task<HttpResponseMessage> Post([FromBody] People value)
        {
            IHumanModel human = await Service.GetPeopleByID(value.HumanID);
            if (human != null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Čovjek s tim ID već postoji");
            }
            await Service.AddPeople(value);
            return Request.CreateResponse(HttpStatusCode.OK, "Unesen novi čovjek.");
        }

        // DELETE api/values/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            IHumanModel human = await Service.GetPeopleByID(id);
            if (human == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Čovjek s ID = " + id + " ne postoji.");

            }
            await Service.DeleteHumanByID(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Čovjek s ID=" + id + " je obrisan.");      
        }

        public async Task<HttpResponseMessage> Put(int id, [FromBody] People value)
        {
            IHumanModel human = await Service.GetPeopleByID(id);
            if (human == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Čovjek s ID = " + id + " ne postoji.");

            }
            else if (human != null & id != value.HumanID)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "ID se ne smije mijenjati");
                return response;
            }
            else
            {
                await Service.UpdatePeople(id, value);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Čovjeku s ID=" + value.HumanID + " su promijenjeni podaci.");
                return response;


            }
        }

    }

}