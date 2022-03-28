using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class EngineService:IEngineService
    {
        public async Task<List<Engine>> GetAllEnginesServiceAsync()
        {
            EngineRepository engine=new EngineRepository();
            return await engine.GetAllEnginesRepositoryAsync();
        }

        public async Task<Engine> GetEngineByIdServiceAsync(int id)
        {
            EngineRepository engine = new EngineRepository();
            return await engine.GetEngineByIdRepositoryAsync(id);
        }


        public async Task <bool> CreateNewEngineServiceAsync(EngineRest engine)
        {
            EngineRepository repository = new EngineRepository();
            if (await repository.CreateNewEngineRepositoryAsync(engine) == true)
            {
               
                return true;
            }
            else return false;
        }

        public async Task <bool>UpdateEngineByIdServiceAsync(int id, EngineRest engine)
        {
            EngineRepository repository=new EngineRepository();
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
            EngineRepository repository = new EngineRepository();

            if (await repository.DeleteEngineByIdRepositoryAsync(id) == true)
            {
                return true;
            }
            else return false;
        }

    }
   
}
