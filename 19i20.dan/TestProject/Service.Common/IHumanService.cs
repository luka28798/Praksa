using Human.Model.Common;

using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Common;
using System;
namespace Human.Service.Common
{
    public interface IHumanService
    {
        //HumanRepository Repository { get; set; }

        Task AddPeople(IHumanModel people);
        Task DeleteHumanByID(int id);
        Task<List<IHumanModel>> FindPeople(IHumanFilterModel humanFilter, IHumanSortModel humanSort, IPagingModel humanPaging);
        Task<IHumanModel> GetPeopleByID(int id);
        Task UpdatePeople(int id, IHumanModel value);
    }
}