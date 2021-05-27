using Human.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Project.Common;

namespace Human.Repository.Common
{
    public interface IHumanRepository
    {
        Task AddPeople([FromBody] IHumanModel value);
        Task DeleteHumanByID(int id);
        Task<List<IHumanModel>> FindPeople(IHumanFilterModel humanFilter, IHumanSortModel humanSort, IPagingModel humanPaging);
        Task<IHumanModel> GetPeopleByID(int id);
        Task UpdatePeople(int id, [FromBody] IHumanModel value);
    }
}