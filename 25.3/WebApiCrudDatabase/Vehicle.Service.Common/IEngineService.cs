using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Service.Common
{
    public interface IEngineService
    {
        List<Engine> GetAllEnginesService();
        Engine GetEngineByIdService(int id);
        bool CreateNewEngineService(Engine engine);
        bool UpdateEngineByIdService(Engine engine);
        bool DeleteEngineByIdService(int id);
    }
}
