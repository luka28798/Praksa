using System.Collections.Generic;
using HumanRepository;
using PeopleModel;
using System.Web.Http;
namespace PeopleService 
{ 
    public class HumanService
    {
        public static People GetPeopleByID(int id)
        {
            return HumanRep.GetPeopleByID(id);
        }
        public static List<People> GetAllPeople()
        {
            return HumanRep.getAllPeople();
        }

        public static void AddPeople([FromBody] People people)
        {
            HumanRep.AddPeople(people);
        }

        public static void DeleteHumanByID(int id)
        {
            HumanRep.DeleteHumanByID(id);
        }

        public static void UpdatePeople(int id, [FromBody] People value)
        {
            HumanRep.UpdatePeople(id, value);
        }
    }
}