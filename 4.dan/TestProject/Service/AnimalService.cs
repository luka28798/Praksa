
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
        public List<Animals> GetAnimals()
        {
            return Repository.GetAllAnimals();
        }

        public void AddAnimal(Animals value)
        {
            Repository.AddAnimal(value);
        }

        public Animals GetAnimalByID(int id)
        {
            return Repository.GetAnimalByID(id);
        }

        public void UpdateAnimal(int id,Animals value)
        {
            Repository.UpdateAnimal(id, value);
        }

        public void DeleteAnimalByID(int id)
        {
            Repository.DeleteAnimalByID(id);
        }
    }
}