using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Animal.Model;
using Animal.Model.Common;
using System.Data.SqlClient;
using System.Web.Http;
using System.Data;
using System.Configuration;
using Animal.Repository.Common;
using AnimalsEntity;
using AutoMapper;
using Project.Common;

namespace Animal.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private static readonly string ConnString = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
        private static readonly SqlConnection myConnection = new SqlConnection(ConnString);

        private static SqlDataReader reader;

        private readonly IMapper mapper;
        protected IAnimalSortRepository SortRepository { get; set; }
        public AnimalRepository(IMapper mapper, IAnimalSortRepository sortRepository)
        {
            this.mapper = mapper;
            this.SortRepository = sortRepository;
        }
        public async Task<IAnimalModel> GetAnimalByID(Guid id)
        {
            

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Animals WHERE AnimalID='" + id + "'";
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            AnimalEntity animal = null;
            while (reader.Read())
            {

                animal = new AnimalEntity();
                animal.AnimalID = reader.GetGuid(0);
                animal.AnimalType = reader.GetValue(1).ToString();
                animal.AnimalName = reader.GetValue(2).ToString();
                animal.HumanID = Convert.ToInt32(reader.GetValue(3));
            }
            myConnection.Close();
            return mapper.Map<IAnimalModel>(animal);
        }

        
        public async Task<List<IAnimalModel>> FindAnimals(IAnimalFilterModel animalFilter, IAnimalSortModel animalSort, IPagingModel animalPaging)
        {
            List<AnimalEntity> animals = new List<AnimalEntity>();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Animals ";
            
            if (animalFilter == null)
            {
                sqlCmd.CommandText += "";
            }else
            {
                if (animalFilter.AnimalType != "")

                {      
                        sqlCmd.CommandText += " WHERE AnimalType Like '" + animalFilter.AnimalType + "%'";
                }
            }

            
            if (animalSort == null)
            {
                sqlCmd.CommandText += "";

            }
            else 
            {
                if (!(SortRepository.ValidInput(animalSort)))
                {
                    sqlCmd.CommandText += " ORDER BY " + animalSort.SortParameter + " " + animalSort.SortOrder;
                }
            }
            
            if (animalPaging == null)
            {
                sqlCmd.CommandText += "";
            }
            else
            {
                if (animalSort.SortParameter != "")
                    if (animalPaging.DataPerPage != 0 && animalPaging.Page != 0)
                    {
                        sqlCmd.CommandText += " OFFSET " + animalPaging.DataPerPage * (animalPaging.Page - 1) + " ROWS FETCH NEXT " + animalPaging.DataPerPage + " ROWS ONLY ";
                    }
            }
            
            
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            AnimalEntity animal = null;
            while (reader.Read())
            {
                animal = new AnimalEntity();
                animal.AnimalID = reader.GetGuid(0);
                animal.AnimalType = reader.GetValue(1).ToString();
                animal.AnimalName = reader.GetValue(2).ToString();
                animal.HumanID = Convert.ToInt32(reader.GetValue(3));
                animals.Add(animal);
            }
            
            myConnection.Close();
            
            
            return mapper.Map<List<IAnimalModel>>(animals);
            

        }

        public async Task AddAnimal([FromBody] IAnimalModel value)
        {
            
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Animals(AnimalID, AnimalType, AnimalName, HumanID) VALUES (default, @AnimalType, @AnimalName, @HumanID);";
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            
 
            sqlCmd.Parameters.AddWithValue("@AnimalType", value.AnimalType);
            sqlCmd.Parameters.AddWithValue("@AnimalName", value.AnimalName);
            sqlCmd.Parameters.AddWithValue("@HumanID", value.HumanID);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();

        }

        public async Task UpdateAnimal(Guid id, [FromBody] IAnimalModel value)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE ANIMALS SET AnimalType = @AnimalType, AnimalName = @AnimalName, HumanID = @HumanID WHERE AnimalID ='" + id + "';";

            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();

    
            sqlCmd.Parameters.AddWithValue("@AnimalType", value.AnimalType);
            sqlCmd.Parameters.AddWithValue("@AnimalName", value.AnimalName);
            sqlCmd.Parameters.AddWithValue("@HumanID", value.HumanID);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        public async Task DeleteAnimalByID(Guid id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM Animals WHERE AnimalID ='" + id + "';";

            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        
    }
}
