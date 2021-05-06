using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Configuration;
using System.Web;
//using System.Web.Mvc;

using System.Data.SqlClient;  
namespace TestProject.WebAPI.Controllers
{
    public class Animals
    {
        public int AnimalID;
        public string AnimalType;
        public string Animal;
        public int HumanID;
        public Animals(int AnimalID, string AnimalType, string Animal, int HumanID)
        {
            this.AnimalID = AnimalID;
            this.AnimalType = AnimalType;
            this.Animal = Animal;
            this.HumanID = HumanID;
        }

        public Animals() { }       
         
    }

    public class ValuesController : ApiController
    {
 

        public HttpResponseMessage Get(int id)
        {
            SqlDataReader reader;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksamono.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=praksa;Password=stipelekic98*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Animals WHERE AnimalID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Animals animal = null;
            while (reader.Read())
            {
                animal = new Animals(); 
                animal.AnimalID = Convert.ToInt32(reader.GetValue(0));
                animal.AnimalType = reader.GetValue(1).ToString();
                animal.Animal = reader.GetValue(2).ToString();
                animal.HumanID = Convert.ToInt32(reader.GetValue(3));
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, animal);
            return response;
        }
        
        [HttpGet]
        [Route("api/Values/")]
        public HttpResponseMessage Get()
        {
            SqlDataReader reader;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksamono.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=praksa;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Animals";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Animals animal = null;
            List<Animals> animals = new List<Animals>();
            while (reader.Read())
            {
                animal = new Animals();
                animal.AnimalID = Convert.ToInt32(reader.GetValue(0));
                animal.AnimalType = reader.GetValue(1).ToString();
                animal.Animal = reader.GetValue(2).ToString();
                animal.HumanID = Convert.ToInt32(reader.GetValue(3));
                animals.Add(animal);
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, animals);
            return response;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Animals value)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksamono.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=praksa;Password=stipelekic98*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Animals (AnimalID, AnimalType, Animal, HumanID) VALUES (@AnimalID, @AnimalType, @Animal, @HumanID);";

            sqlCmd.Connection = myConnection;
            myConnection.Open();
            
            sqlCmd.Parameters.AddWithValue("@AnimalID",  value.AnimalID);
            sqlCmd.Parameters.AddWithValue("@AnimalType", value.AnimalType);
            sqlCmd.Parameters.AddWithValue("@Animal", value.Animal);
            sqlCmd.Parameters.AddWithValue("@HumanID", value.HumanID);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
            
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {  
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksamono.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=praksa;Password=stipelekic98*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM Animals WHERE AnimalID ="+ id + ";";

            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
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
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = @"Server=tcp:praksamono.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=praksa;Password=stipelekic98*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "UPDATE ANIMALS SET AnimalID = @AnimalID, AnimalType = @AnimalType, Animal = @Animal, HumanID = @HumanID WHERE AnimalID ="+id+";";

                sqlCmd.Connection = myConnection;
                myConnection.Open();
              
                sqlCmd.Parameters.AddWithValue("@AnimalID", value.AnimalID);
                sqlCmd.Parameters.AddWithValue("@animalType", value.AnimalType);
                sqlCmd.Parameters.AddWithValue("@animal", value.Animal);
                sqlCmd.Parameters.AddWithValue("@HumanID", value.HumanID);
                sqlCmd.ExecuteNonQuery();
                myConnection.Close();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                return response;

               
            }
        }

    }

}
