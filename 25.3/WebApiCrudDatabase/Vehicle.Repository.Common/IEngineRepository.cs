using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Repository.Common
{
    public interface IEngineRepository
    {
        List<Engine> GetAllEnginesRepository();
        Engine GetEngineByIdRepository(int id);
        bool CreateNewEngineRepository(Engine engine);
        bool UpdateEngineByIdRepository(Engine engine);
        bool DeleteEngineByIdRepository(int id);

    }
}
