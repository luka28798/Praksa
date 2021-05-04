using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestProject.WebAPI.Controllers
{
    public class Animal
    {
        public int id;
        public string animalType;
        public string animal;
        public Animal(int id, string animalType, string animal)
        {
            this.id = id;
            this.animalType = animalType;
            this.animal = animal;

        }

        public Animal() { }       
         
    }

    


    public class ValuesController : ApiController
    {
        public static List<Animal> TheAnimals = new List<Animal>(){
            new Animal { id = 0, animalType = "Sisavac", animal = "Pas" },
            new Animal { id = 1, animalType = "Riba", animal = "Šaran" },
            new Animal { id = 2, animalType = "Sisavac", animal = "Dupin" },
            new Animal { id = 3, animalType = "Gmaz", animal = "Zmija" },
            new Animal { id = 4, animalType = "Kukac", animal = "Pauk" },
        };

        // GET api/values
        public IEnumerable<Animal> Get()
        {
            return TheAnimals;
        }

        //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "Error message");

        // GET api/values/5
        [HttpGet]
        public HttpResponseMessage getAnimal(int id)
        {
            if (TheAnimals.Count < id)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "Error 404: objekt s tim id ne postoji");
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, TheAnimals[id]);
                return response;
            }
            

        }

        // POST api/values
        
        public HttpResponseMessage Post([FromBody] Animal value)
        {
            TheAnimals.Add(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody] Animal value)
        {
            if (TheAnimals.Count < id)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotFound, "Error 404: objekt s tim id ne postoji");
                return response;
            }
            else
            {
                TheAnimals[id] = value;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, TheAnimals[id]);
                return response;
            }

            
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            if ((id >= 0) && (id <= TheAnimals.Count))
            {
                TheAnimals.RemoveAt(id);
                return Ok();
            }
            else
            {
                return BadRequest("Objekt sa ovim id ne postoji");
            }
        }
    }
}
