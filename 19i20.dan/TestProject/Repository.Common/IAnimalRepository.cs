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
        Task DeleteAnimalByID(Guid id);
        Task<List<IAnimalModel>> FindAnimals(IAnimalFilterModel animalFilter, IAnimalSortModel animalSort, IPagingModel animalPaging);
        Task<IAnimalModel> GetAnimalByID(Guid id);
        Task UpdateAnimal(Guid id, [FromBody] IAnimalModel value);
    }
}