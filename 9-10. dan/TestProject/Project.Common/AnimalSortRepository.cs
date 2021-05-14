using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public class AnimalSortRepository : IAnimalSortRepository
    {
        public bool ValidInput(IAnimalSortModel iAnimalSortModel)
        {
            if (iAnimalSortModel.SortParameter == null && iAnimalSortModel.SortOrder == null)
            {
                return true;
            }

            switch (iAnimalSortModel.SortParameter)
            {
                case "AnimalID":
                    break;
                case "AnimalType":
                    break;
                default:
                    return false;
            }
            switch (iAnimalSortModel.SortOrder)
            {
                case "asc":
                    break;
                case "desc":
                    break;
                default:
                    return false;
            }
            return true;

        }
    }
}
