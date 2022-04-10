using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Common;
using Vehicle.Model;

namespace Vehicle.Service.Common
{
    public interface IEngineService
    {
         Task<List<Engine>> GetAllEnginesServiceAsync(Sorting sorting, Paging paging,EngineFilter filter);
         Task<Engine> GetEngineByIdServiceAsync(int id);
         Task<bool> CreateNewEngineServiceAsync(EngineRest engine);
         Task<bool> UpdateEngineByIdServiceAsync(int id,EngineRest engine);
         Task<bool> DeleteEngineByIdServiceAsync(int id);
    }
}
