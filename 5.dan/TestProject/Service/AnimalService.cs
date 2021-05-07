
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal.Repository;
using Animal.Model;
namespace Animal.Service
{
    public class AnimalService
    {
        public AnimalRepository Repository { get; set; }
        public AnimalService()
        {
            Repository = new AnimalRepository();

        }
        public async Task<List<Animals>> GetAnimals()
        {
            return await Repository.GetAllAnimals();
        }

        public async Task AddAnimal(Animals value)
        {

            await Repository.AddAnimal(value);
        }

        public async Task<Animals> GetAnimalByID(int id)
        {
            return await Repository.GetAnimalByID(id);
        }

        public async Task UpdateAnimal(int id,Animals value)
        {
            await Repository.UpdateAnimal(id, value);
        }

        public async Task DeleteAnimalByID(int id)
        {
            await Repository.DeleteAnimalByID(id);
        }
    }
}