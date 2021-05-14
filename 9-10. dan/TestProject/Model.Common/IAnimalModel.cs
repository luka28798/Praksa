namespace Animal.Model.Common
{
    public interface IAnimalModel
    {
        int AnimalID { get; set; }
        string AnimalName { get; set; }
        string AnimalType { get; set; }
        int HumanID { get; set; }
    }
}