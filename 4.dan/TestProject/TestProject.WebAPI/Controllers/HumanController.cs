using System.Net;
using System.Net.Http;
using System.Web.Http;
using PeopleModel;
using PeopleService;
namespace TestProject.WebAPI.Controllers
{
    

    public class HumanController : ApiController
    {

        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, HumanService.GetPeopleByID(id));
            return response;
        }

        [HttpGet]
        [Route("api/Human/")]
        public HttpResponseMessage Get()
        {
            
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, HumanService.GetAllPeople());
            return response;
        }
        [HttpPost]
        [Route("api/Human/")]
        public HttpResponseMessage Post([FromBody] People value)
        {
            HumanService.AddPeople(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;

        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            HumanService.DeleteHumanByID(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        public HttpResponseMessage Put(int id, [FromBody] People value)
        {
            if (id != value.HumanID)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "ID se ne smije mijenjati");
                return response;
            }
            else
            {
                HumanService.UpdatePeople(id, value);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }
        }

    }

}