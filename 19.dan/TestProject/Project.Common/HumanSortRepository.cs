using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public class HumanSortRepository : IHumanSortRepository
    {
        public bool ValidInput(IHumanSortModel iHumanSortModel)
        {
            if (iHumanSortModel.SortParameter == null && iHumanSortModel.SortOrder == null)
            {
                return true;
            }

            switch (iHumanSortModel.SortParameter)
            {
                case "HumanID":
                    break;
                case "FirstName":
                    break;
                default:
                    return false;
            }
            switch (iHumanSortModel.SortOrder)
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
