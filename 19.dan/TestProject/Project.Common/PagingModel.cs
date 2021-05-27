using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public class PagingModel : IPagingModel
    {
        public int Page { get; set; }
        public int DataPerPage { get; set; }


    }
}
