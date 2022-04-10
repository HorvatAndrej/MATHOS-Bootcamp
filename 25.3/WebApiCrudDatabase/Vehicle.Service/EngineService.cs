using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Common;
using Vehicle.Model;
using Vehicle.Repository;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class EngineService:IEngineService
    {
        protected IEngineRepository repository { get; set; }
        public EngineService(IEngineRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<Engine>> GetAllEnginesServiceAsync(Sorting sorting, Paging paging, EngineFilter filter)
        {
            
            return await repository.GetAllEnginesRepositoryAsync(sorting, paging, filter);
        }

        public async Task<Engine> GetEngineByIdServiceAsync(int id)
        {
            
            return await repository.GetEngineByIdRepositoryAsync(id);
        }


        public async Task <bool> CreateNewEngineServiceAsync(EngineRest engine)
        {
            
            if (await repository.CreateNewEngineRepositoryAsync(engine) == true)
            {
               
                return true;
            }
            else return false;
        }

        public async Task <bool>UpdateEngineByIdServiceAsync(int id, EngineRest engine)
        {
            
            if (await repository.GetEngineByIdRepositoryAsync(id) != null)
            {
                if (await repository.UpdateEngineByIdRepositoryAsync(id, engine) == true)
                {
                    
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public async Task<bool> DeleteEngineByIdServiceAsync(int id)
        {
            

            if (await repository.DeleteEngineByIdRepositoryAsync(id) == true)
            {
                return true;
            }
            else return false;
        }

    }
   
}
