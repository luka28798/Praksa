using System.Collections.Generic;
using Human.Repository;
using Human.Model;
using System.Threading.Tasks;


namespace Human.Service
{
    public class HumanService
    {
        public HumanRepository Repository { get; set; }
        public HumanService()
        {
            Repository = new HumanRepository();
            
        }

        public async Task<People> GetPeopleByID(int id)
        {
            return await Repository.GetPeopleByID(id);
        }
        public async Task<List<People>> GetAllPeople()
        {
            return await Repository.getAllPeople();
        }

        public async Task AddPeople(People people)
        {
            await Repository.AddPeople(people);
        }

        public async Task DeleteHumanByID(int id)
        {
            await Repository.DeleteHumanByID(id);
        }

        public async Task UpdatePeople(int id, People value)
        {
            await Repository.UpdatePeople(id, value);
        }
    }
}
