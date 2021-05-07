using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Model
{
    public class Animals
    {
        public int AnimalID;
        public string AnimalType;
        public string AnimalName;
        public int HumanID;
        public Animals(int AnimalID, string AnimalType, string AnimalName, int HumanID)
        {
            this.AnimalID = AnimalID;
            this.AnimalType = AnimalType;
            this.AnimalName = AnimalName;
            this.HumanID = HumanID;
        }

        public Animals() { }
    }
}
