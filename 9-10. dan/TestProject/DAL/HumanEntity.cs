using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans.Entity
{
    public class HumanEntity
    {
        public int HumanID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public HumanEntity(int HumanID, string FirstName, string LastName)
        {
            this.HumanID = HumanID;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public HumanEntity() { }
    }
}
