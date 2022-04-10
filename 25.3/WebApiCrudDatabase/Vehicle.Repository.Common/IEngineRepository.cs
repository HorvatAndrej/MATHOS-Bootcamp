using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Common;
using Vehicle.Model;

namespace Vehicle.Repository.Common
{
    public interface IEngineRepository
    {
         Task<List<Engine>> GetAllEnginesRepositoryAsync(Sorting sorting, Paging paging, EngineFilter filter);
         Task<Engine> GetEngineByIdRepositoryAsync(int id);
         Task<bool> CreateNewEngineRepositoryAsync(EngineRest engine);
         Task<bool> UpdateEngineByIdRepositoryAsync(int id,EngineRest engine);
         Task<bool> DeleteEngineByIdRepositoryAsync(int id);
        Task<int> GetLastEngineIdRepositoryAsync();

    }
}
