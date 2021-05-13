﻿using Animal.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Animal.Model.Common;
using Project.Common;

namespace Animal.Service.Common
{
    public interface IAnimalService
    {
        //AnimalRepository Repository { get; set; }

        Task AddAnimal(IAnimalModel value);
        Task DeleteAnimalByID(int id);
        Task<IAnimalModel> GetAnimalByID(int id);
        Task<List<IAnimalModel>> GetAnimals(AnimalFilterModel animalFilter, AnimalSortModel animalSort);
        Task UpdateAnimal(int id, IAnimalModel value);
    }
}