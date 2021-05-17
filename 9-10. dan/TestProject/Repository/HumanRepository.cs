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
using Humans.Entity;
using AutoMapper;
using Project.Common;

namespace Human.Repository
{
    public class HumanRepository : IHumanRepository
    {
        private static readonly string ConnString = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
        private static readonly SqlConnection myConnection = new SqlConnection(ConnString);

        private static SqlDataReader reader;

        private readonly IMapper mapper;
        protected IHumanSortRepository SortRepository { get; set; }
        public HumanRepository(IMapper mapper, IHumanSortRepository sortRepository)
        {
            this.mapper = mapper;
            this.SortRepository = sortRepository;
        }
        public async Task<IHumanModel> GetPeopleByID(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM People WHERE HumanID=" + id + "";
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            HumanEntity people = null;
            while (reader.Read())
            {
                people = new HumanEntity();
                people.HumanID = Convert.ToInt32(reader.GetValue(0));
                people.FirstName = reader.GetValue(1).ToString();
                people.LastName = reader.GetValue(2).ToString();

            }
            myConnection.Close();
            return mapper.Map<IHumanModel>(people);
        }

        public async Task<List<IHumanModel>> FindPeople(IHumanFilterModel humanFilter, IHumanSortModel humanSort, IPagingModel humanPaging)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM People";

            if (humanFilter == null)
            {
                sqlCmd.CommandText += "";
            }
            else
            {
                if (humanFilter.LastName != "")

                {
                    sqlCmd.CommandText += " WHERE LastName Like '" + humanFilter.LastName + "%'";
                }
            }


            if (humanSort == null)
            {
                sqlCmd.CommandText += "";

            }
            else
            {
                if (!(SortRepository.ValidInput(humanSort)))
                {
                    sqlCmd.CommandText += " ORDER BY " + humanSort.SortParameter + " " + humanSort.SortOrder;
                }
            }

            if (humanPaging == null)
            {
                sqlCmd.CommandText += "";
            }
            else
            {
                if (humanSort.SortParameter != "")
                    if (humanPaging.DataPerPage != 0 && humanPaging.Page != 0)
                    {
                        sqlCmd.CommandText += " OFFSET " + humanPaging.DataPerPage * (humanPaging.Page - 1) + " ROWS FETCH NEXT " + humanPaging.DataPerPage + " ROWS ONLY ";
                    }
            }
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            HumanEntity human = null;
            List<HumanEntity> peopleList = new List<HumanEntity>();
            while (reader.Read())
            {
                human = new HumanEntity();
                human.HumanID = Convert.ToInt32(reader.GetValue(0));
                human.FirstName = reader.GetValue(1).ToString();
                human.LastName = reader.GetValue(2).ToString();
                peopleList.Add(human);
            }
            myConnection.Close();
            return mapper.Map<List<IHumanModel>>(peopleList);
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
