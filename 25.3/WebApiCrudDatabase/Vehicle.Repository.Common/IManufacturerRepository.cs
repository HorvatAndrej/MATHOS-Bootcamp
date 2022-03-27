using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.Repository.Common
{
    public interface IManufacturerRepository
    {
        List<Manufacturer> GetAllManufacturersRepository();
        Manufacturer GetManufacturerByIdRepository(int id);
        bool CreateNewManufacturerRepository(Manufacturer manufacturer);
        bool UpdateManufacturerByIdRepository(Manufacturer manufacturer);
        bool DeleteManufacturerByIdRepository(int id);

    }
}
