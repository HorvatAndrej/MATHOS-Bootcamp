using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Common;
using Vehicle.Model;

namespace Vehicle.Repository.Common
{
    public interface IManufacturerRepository
    {
        Task<List<Manufacturer>> GetAllManufacturersRepositoryAsync(Sorting sorting, Paging paging, ManufacturerFilter filter);
        Task<Manufacturer> GetManufacturerByIdRepositoryAsync(int id);
        Task<bool> CreateNewManufacturerRepositoryAsync(ManufacturerRest manufacturer);
        Task<bool> UpdateManufacturerByIdRepositoryAsync(int id,ManufacturerRest manufacturer);
        Task<bool> DeleteManufacturerByIdRepositoryAsync(int id);

    }
}
