using Animal.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Animal.Model.Common;
using Project.Common;
using System;
namespace Animal.Service.Common
{
    public interface IAnimalService
    {
        //AnimalRepository Repository { get; set; }

        Task AddAnimal(IAnimalModel value);
        Task DeleteAnimalByID(Guid id);
        Task<IAnimalModel> GetAnimalByID(Guid id);
        Task<List<IAnimalModel>> FindAnimals(IAnimalFilterModel animalFilter, IAnimalSortModel animalSort, IPagingModel animalPaging);
        Task UpdateAnimal(Guid id, IAnimalModel value);
    }
}