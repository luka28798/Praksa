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
    public class People
    {
        public int HumanID;
        public string FirstName;
        public string LastName;

        public People(int HumanID, string FirstName, string LastName)
        {
            this.HumanID = HumanID;
            this.FirstName = FirstName;
            this.LastName = LastName;

        }

        public People() { }

    }

    public class HumanController : ApiController
    {


        public HttpResponseMessage Get(int id)
        {
            SqlDataReader reader;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksamono.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=praksa;Password=stipelekic98*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM People WHERE HumanID=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            People people = null;
            while (reader.Read())
            {
                people = new People();
                people.HumanID = Convert.ToInt32(reader.GetValue(0));
                people.FirstName = reader.GetValue(1).ToString();
                people.LastName = reader.GetValue(2).ToString();

            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, people);
            return response;
        }

        [HttpGet]
        [Route("api/Human/")]
        public HttpResponseMessage Get()
        {
            SqlDataReader reader;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksamono.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=praksa;Password=stipelekic98*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM People";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            People human = null;
            List<People> people = new List<People>();
            while (reader.Read())
            {
                human = new People();
                human.HumanID = Convert.ToInt32(reader.GetValue(0));
                human.FirstName = reader.GetValue(1).ToString();
                human.LastName= reader.GetValue(2).ToString();
                people.Add(human);
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, people);
            return response;
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] People value)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = @"Server=tcp:praksamono.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=praksa;Password=stipelekic98*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO People (HumanID, FirstName, LastName) VALUES (@HumanID, @FirstName, @LastName);";

            sqlCmd.Connection = myConnection;
            myConnection.Open();

            sqlCmd.Parameters.AddWithValue("@HumanID", value.HumanID);
            sqlCmd.Parameters.AddWithValue("@FirstName", value.FirstName);
            sqlCmd.Parameters.AddWithValue("@LastName", value.LastName);
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
            sqlCmd.CommandText = "DELETE FROM People WHERE HumanID =" + id + ";";

            sqlCmd.Connection = myConnection;
            myConnection.Open();
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
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
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = @"Server=tcp:praksamono.database.windows.net,1433;Initial Catalog=Praksa;Persist Security Info=False;User ID=praksa;Password=stipelekic98*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "UPDATE PEOPLE SET HumanID = @HumanID, FirstName = @FirstName, LastName = @LastName WHERE HumanID =" + id + ";";

                sqlCmd.Connection = myConnection;
                myConnection.Open();

                sqlCmd.Parameters.AddWithValue("@HumanID", value.HumanID);
                sqlCmd.Parameters.AddWithValue("@FirstName", value.FirstName);
                sqlCmd.Parameters.AddWithValue("@LastName", value.LastName);
                sqlCmd.ExecuteNonQuery();
                myConnection.Close();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                return response;


            }
        }

    }

}