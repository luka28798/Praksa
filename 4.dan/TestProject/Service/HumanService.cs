using System.Collections.Generic;
using Human.Repository;
using Human.Model;

namespace Human.Service
{
    public class HumanService
    {
        public HumanRepository Repository { get; set; }
        public HumanService()
        {
            Repository = new HumanRepository();
            
        }

        public People GetPeopleByID(int id)
        {
            return Repository.GetPeopleByID(id);
        }
        public List<People> GetAllPeople()
        {
            return Repository.getAllPeople();
        }

        public void AddPeople(People people)
        {
            Repository.AddPeople(people);
        }

        public void DeleteHumanByID(int id)
        {
            Repository.DeleteHumanByID(id);
        }

        public void UpdatePeople(int id, People value)
        {
            Repository.UpdatePeople(id, value);
        }
    }
}
