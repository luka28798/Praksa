using Human.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Human.Repository.Common
{
    public interface IHumanRepository
    {
        Task AddPeople([FromBody] IHumanModel value);
        Task DeleteHumanByID(int id);
        Task<List<IHumanModel>> getAllPeople();
        Task<IHumanModel> GetPeopleByID(int id);
        Task UpdatePeople(int id, [FromBody] IHumanModel value);
    }
}