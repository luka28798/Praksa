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
    }
}
