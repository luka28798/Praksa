using System.Net;
using System.Net.Http;
using System.Web.Http;
using Human.Model;
using Human.Service;
using System.Collections.Generic;
namespace TestProject.WebAPI.Controllers
{
    

    public class HumanController : ApiController
    {

        public static HumanService Service = new HumanService();
        public List<People> listPeople = Service.GetAllPeople();

        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            for(int i = 0; i <listPeople.Count; i++)
            {
                if (listPeople[i].HumanID == id)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Service.GetPeopleByID(id));
                    return response;
                    

                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Ne postoji čovjek s tim ID");
        }

        [HttpGet]
        [Route("api/Human/")]
        public HttpResponseMessage Get()
        {
            if (listPeople[0] != null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Found, Service.GetAllPeople());
                return response;
            }
            
            return Request.CreateResponse(HttpStatusCode.NotFound, "Lista je prazna");
        }
        [HttpPost]
        [Route("api/Human/")]
        public HttpResponseMessage Post([FromBody] People value)
        {
            for (int i = 0; i < listPeople.Count; i++)
            {
                if (listPeople[i].HumanID == value.HumanID)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Čovjek s tim ID već postoji");
                    return response;


                }
            }
            Service.AddPeople(value);       
            return Request.CreateResponse(HttpStatusCode.OK, "Unesen novi čovjek.");

        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            for (int i = 0; i < listPeople.Count; i++)
            {
                if (listPeople[i].HumanID == id)
                {
                    Service.DeleteHumanByID(id);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Čovjek s ID="+id+" je obrisan.");
                    return response;


                }
            }                       
            return Request.CreateResponse(HttpStatusCode.NotFound, "Čovjek s ID = "+id+" ne postoji.");
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
                Service.UpdatePeople(id, value);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "Čovjeku s ID="+value.HumanID + " su promijenjeni podaci.");
                return response;
            }
        }

    }

}