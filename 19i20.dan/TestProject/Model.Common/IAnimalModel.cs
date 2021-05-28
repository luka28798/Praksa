using System;
namespace Animal.Model.Common
{
    public interface IAnimalModel
    {
        Guid AnimalID { get; set; }
        string AnimalName { get; set; }
        string AnimalType { get; set; }
        int HumanID { get; set; }
    }
}