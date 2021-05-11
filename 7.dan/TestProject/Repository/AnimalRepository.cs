﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Animal.Model;
using Animal.Model.Common;
using System.Data.SqlClient;
using System.Web.Http;
using System.Data;
using System.Configuration;
using Animal.Repository.Common;

namespace Animal.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private static readonly string ConnString = ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString;
        private static readonly SqlConnection myConnection = new SqlConnection(ConnString);

        private static SqlDataReader reader;
        public async Task<IAnimalModel> GetAnimalByID(int id)
        {

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Animals WHERE AnimalID=" + id + "";
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            IAnimalModel animal = null;
            while (reader.Read())
            {

                animal = new Animals();
                animal.AnimalID = Convert.ToInt32(reader.GetValue(0));
                animal.AnimalType = reader.GetValue(1).ToString();
                animal.AnimalName = reader.GetValue(2).ToString();
                animal.HumanID = Convert.ToInt32(reader.GetValue(3));
            }
            myConnection.Close();
            return animal;
        }
        public async Task<List<IAnimalModel>> GetAllAnimals()
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * FROM Animals";
            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            reader = sqlCmd.ExecuteReader();
            IAnimalModel animal = null;
            List<IAnimalModel> animals = new List<IAnimalModel>();
            while (reader.Read())
            {
                animal = new Animals();
                animal.AnimalID = Convert.ToInt32(reader.GetValue(0));
                animal.AnimalType = reader.GetValue(1).ToString();
                animal.AnimalName = reader.GetValue(2).ToString();
                animal.HumanID = Convert.ToInt32(reader.GetValue(3));
                animals.Add(animal);
            }
            myConnection.Close();
            return animals;
        }

        public async Task AddAnimal([FromBody] IAnimalModel value)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Animals (AnimalID, AnimalType, AnimalName, HumanID) VALUES (@AnimalID, @AnimalType, @AnimalName, @HumanID);";

            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();

            sqlCmd.Parameters.AddWithValue("@AnimalID", value.AnimalID);
            sqlCmd.Parameters.AddWithValue("@AnimalType", value.AnimalType);
            sqlCmd.Parameters.AddWithValue("@AnimalName", value.AnimalName);
            sqlCmd.Parameters.AddWithValue("@HumanID", value.HumanID);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();

        }

        public async Task UpdateAnimal(int id, [FromBody] IAnimalModel value)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE ANIMALS SET AnimalID = @AnimalID, AnimalType = @AnimalType, AnimalName = @AnimalName, HumanID = @HumanID WHERE AnimalID =" + id + ";";

            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();

            sqlCmd.Parameters.AddWithValue("@AnimalID", value.AnimalID);
            sqlCmd.Parameters.AddWithValue("@AnimalType", value.AnimalType);
            sqlCmd.Parameters.AddWithValue("@AnimalName", value.AnimalName);
            sqlCmd.Parameters.AddWithValue("@HumanID", value.HumanID);
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }

        public async Task DeleteAnimalByID(int id)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM Animals WHERE AnimalID =" + id + ";";

            sqlCmd.Connection = myConnection;
            await myConnection.OpenAsync();
            sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}
