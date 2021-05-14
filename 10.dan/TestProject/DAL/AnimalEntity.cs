using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsEntity
{
    public class AnimalEntity
    {
        public int AnimalID { get; set; }
        public string AnimalType { get; set; }
        public string AnimalName { get; set; }
        public int HumanID { get; set; }

        public AnimalEntity(int AnimalID, string AnimalType, string AnimalName, int HumanID)
        {
            this.AnimalID = AnimalID;
            this.AnimalType = AnimalType;
            this.AnimalName = AnimalName;
            this.HumanID = HumanID;
        }

        public AnimalEntity() { }
    }
}
