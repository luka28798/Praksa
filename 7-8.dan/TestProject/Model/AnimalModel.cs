using Animal.Model.Common;

namespace Animal.Model
{
    public class Animals : IAnimalModel
    {
        public int AnimalID { get; set; }
        public string AnimalType { get; set; }
        public string AnimalName { get; set; }
        public int HumanID { get; set; }
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
