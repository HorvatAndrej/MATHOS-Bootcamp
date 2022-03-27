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
        public List<Engine> GetAllEnginesService()
        {
            EngineRepository engine=new EngineRepository();
            return engine.GetAllEnginesRepository();
        }

        public Engine GetEngineByIdService(int id)
        {
            EngineRepository engine = new EngineRepository();
            return engine.GetEngineByIdRepository(id);
        }


        public bool CreateNewEngineService(Engine engine)
        {
            EngineRepository repository = new EngineRepository();
            if (repository.CreateNewEngineRepository(engine) == true)
            {
                repository.CreateNewEngineRepository(engine);
                return true;
            }
            else return false;
        }

        public bool UpdateEngineByIdService(Engine engine)
        {
            EngineRepository repository=new EngineRepository();
            
            if (repository.UpdateEngineByIdRepository(engine) == true)
            {
                repository.UpdateEngineByIdRepository(engine);
                return true;
            }
            else return false;
        }

        public bool DeleteEngineByIdService(int id)
        {
            EngineRepository repository = new EngineRepository();

            if (repository.DeleteEngineByIdRepository(id) == true)
            {
                repository.DeleteEngineByIdRepository(id); return true;
            }
            else return false;
        }

    }
}
