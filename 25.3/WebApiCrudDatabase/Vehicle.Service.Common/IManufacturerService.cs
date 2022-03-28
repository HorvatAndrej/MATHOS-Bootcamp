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
        Task<List<Manufacturer>> GetAllManufacturersServiceAsync();
        Task<Manufacturer> GetManufacturerByIdServiceAsync(int id);
        Task<bool> CreateNewManufacturerServiceAsync(ManufacturerRest manufacturer);
        Task<bool> UpdateManufacturerByIdServiceAsync(int id,ManufacturerRest manufacturer);
        Task<bool> DeleteManufacturerByIdServiceAsync(int id);



    }
}
