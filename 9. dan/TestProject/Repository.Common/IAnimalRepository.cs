using Animal.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System;
using System.Data.SqlClient;
using System.Web.Http;
using Project.Common;

namespace Animal.Repository.Common
{
    public interface IAnimalRepository
    {
        Task AddAnimal([FromBody] IAnimalModel value);
        Task DeleteAnimalByID(int id);
        Task<List<IAnimalModel>> GetAllAnimals(AnimalFilterModel animalFilter, AnimalSortModel animalSort);
        Task<IAnimalModel> GetAnimalByID(int id);
        Task UpdateAnimal(int id, [FromBody] IAnimalModel value);
    }
}