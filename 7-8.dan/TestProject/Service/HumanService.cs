using System.Collections.Generic;
using Human.Repository.Common;
using Human.Model.Common;
using Human.Service.Common;
using System.Threading.Tasks;


namespace Human.Service
{
    public class HumanService : IHumanService
    {
        public IHumanRepository Repository { get; set; }

        public HumanService() { }

        public HumanService(IHumanRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<IHumanModel> GetPeopleByID(int id)
        {
            return await Repository.GetPeopleByID(id);
        }
        public async Task<List<IHumanModel>> GetAllPeople()
        {
            return await Repository.getAllPeople();
        }

        public async Task AddPeople(IHumanModel people)
        {
            await Repository.AddPeople(people);
        }

        public async Task DeleteHumanByID(int id)
        {
            await Repository.DeleteHumanByID(id);
        }

        public async Task UpdatePeople(int id, IHumanModel value)
        {
            await Repository.UpdatePeople(id, value);
        }
    }
}
