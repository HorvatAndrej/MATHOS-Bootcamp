using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Service.Common
{
    public interface IManufacturerService
    {
        List<Manufacturer> GetAllManufacturersService();
        Manufacturer GetManufacturerByIdService(int id);
        bool CreateNewManufacturerService(Manufacturer manufacturer);
        bool UpdateManufacturerByIdService(Manufacturer manufacturer);
        bool DeleteManufacturerByIdService(int id);



    }
}
