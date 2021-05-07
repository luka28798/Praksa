using System;

namespace ValuesModel
{
    public class Animals
    {
        public int AnimalID;
        public string AnimalType;
        public string Animal;
        public int HumanID;
        public Animals(int AnimalID, string AnimalType, string Animal, int HumanID)
        {
            this.AnimalID = AnimalID;
            this.AnimalType = AnimalType;
            this.Animal = Animal;
            this.HumanID = HumanID;
        }

        public Animals() { }
    }
}