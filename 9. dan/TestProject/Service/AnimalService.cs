
using System.Collections.Generic;
using System.Threading.Tasks;
using Animal.Repository.Common;
using Animal.Model.Common;
using Animal.Service.Common;
using Project.Common;


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

        public async Task<List<IAnimalModel>> FindAnimals(IAnimalFilterModel animalFilter, IAnimalSortModel animalSort)
        {
            return await Repository.FindAnimals(animalFilter,animalSort);
        }

        public async Task AddAnimal(IAnimalModel value)
        {

            await Repository.AddAnimal(value);
        }

        public async Task<IAnimalModel> GetAnimalByID(int id)
        {
            return await Repository.GetAnimalByID(id);
        }

        public async Task UpdateAnimal(int id, IAnimalModel value)
        {
            await Repository.UpdateAnimal(id, value);
        }

        public async Task DeleteAnimalByID(int id)
        {
            await Repository.DeleteAnimalByID(id);
        }
    }
}