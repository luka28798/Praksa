using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public class AnimalSortModel : IAnimalSortModel
    {
        public string SortParameter { get; set; }
        public string SortOrder { get; set; }


        public bool ValidInput()
        {
            if (SortParameter == null && SortOrder == null)
            {
                return true;
            }

            switch (SortParameter)
            {
                case "AnimalID":
                    break;
                case "AnimalType":
                    break;
                default:
                    return false;
            }
            switch (SortOrder)
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
