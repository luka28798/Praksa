using System.Collections.Generic;
using ValuesModel;
using System.Web.Http;
using ValuesRepository;

namespace ValuesService
{
    public class AnimalsService
    {
        public static List<Animals> GetAnimals() 
        {
            return AnimalRep.GetAllAnimals();
        }

        public static void AddAnimal([FromBody] Animals value)
        {
            AnimalRep.AddAnimal(value);
        }
        
        public static Animals GetAnimalByID(int id)
        {
            return AnimalRep.GetAnimalByID(id);
        }

        public static void UpdateAnimal(int id, [FromBody] Animals value) 
        {
            AnimalRep.UpdateAnimal(id, value);
        }

        public static void DeleteAnimalByID(int id)
        {
            AnimalRep.DeleteAnimalByID(id);
        }
    }
}