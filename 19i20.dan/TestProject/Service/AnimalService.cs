
using System.Collections.Generic;
using System.Threading.Tasks;
using Animal.Repository.Common;
using Animal.Model.Common;
using Animal.Service.Common;
using Project.Common;
using System;

namespace Animal.Service
{
    public class AnimalService : IAnimalService
    {
        protected IAnimalRepository Repository { get; set; }


        public AnimalService() { }
        public AnimalService(IAnimalRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<List<IAnimalModel>> FindAnimals(IAnimalFilterModel animalFilter, IAnimalSortModel animalSort, IPagingModel animalPaging)
        {
            return await Repository.FindAnimals(animalFilter,animalSort, animalPaging);
        }

        public async Task AddAnimal(IAnimalModel value)
        {

            await Repository.AddAnimal(value);
        }

        public async Task<IAnimalModel> GetAnimalByID(Guid id)
        {
            return await Repository.GetAnimalByID(id);
        }

        public async Task UpdateAnimal(Guid id, IAnimalModel value)
        {
            await Repository.UpdateAnimal(id, value);
        }

        public async Task DeleteAnimalByID(Guid id)
        {
            await Repository.DeleteAnimalByID(id);
        }
    }
}