using System;
using System.Collections.Generic;
using Human.Model;
using System.Data.SqlClient;
using System.Web.Http;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using Human.Model.Common;
using Human.Repository.Common;

namespace Human.Repository
{
    public class HumanRepository : IHumanRepository
    {
        private static readonly string ConnString = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
        private static readonly SqlConnection myConnection = new SqlConnection(ConnString);

        private static SqlDataReader reader;
        public async Task<IHumanModel> GetPeopleByID(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM People WHERE HumanID=" + id + "";
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            IHumanModel people = null;
            while (reader.Read())
            {
                people = new People();
                people.HumanID = Convert.ToInt32(reader.GetValue(0));
                people.FirstName = reader.GetValue(1).ToString();
                people.LastName = reader.GetValue(2).ToString();

            }
            myConnection.Close();
            return people;
        }

        public async Task<List<IHumanModel>> getAllPeople()
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM People";
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            IHumanModel human = null;
            List<IHumanModel> people = new List<IHumanModel>();
            while (reader.Read())
            {
                human = new People();
                human.HumanID = Convert.ToInt32(reader.GetValue(0));
                human.FirstName = reader.GetValue(1).ToString();
                human.LastName = reader.GetValue(2).ToString();
                people.Add(human);
            }
            myConnection.Close();
            return people;
        }

        public async Task AddPeople([FromBody] IHumanModel value)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO People (HumanID, FirstName, LastName) VALUES (@HumanID, @FirstName, @LastName);";

            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();

            sqlCmd.Parameters.AddWithValue("@HumanID", value.HumanID);
            sqlCmd.Parameters.AddWithValue("@FirstName", value.FirstName);
            sqlCmd.Parameters.AddWithValue("@LastName", value.LastName);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        public async Task DeleteHumanByID(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM People WHERE HumanID =" + id + ";";

            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        public async Task UpdatePeople(int id, [FromBody] IHumanModel value)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE PEOPLE SET HumanID = @HumanID, FirstName = @FirstName, LastName = @LastName WHERE HumanID =" + id + ";";

            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();

            sqlCmd.Parameters.AddWithValue("@HumanID", value.HumanID);
            sqlCmd.Parameters.AddWithValue("@FirstName", value.FirstName);
            sqlCmd.Parameters.AddWithValue("@LastName", value.LastName);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }


    }
}
