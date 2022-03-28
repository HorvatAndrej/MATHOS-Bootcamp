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
    public class ManufacturerService:IManufacturerService
    {
        public async Task<List<Manufacturer>> GetAllManufacturersServiceAsync()
        {
            ManufacturerRepository manufacturer = new ManufacturerRepository();
            return await manufacturer.GetAllManufacturersRepositoryAsync();
        }

        public async Task <Manufacturer> GetManufacturerByIdServiceAsync(int id)
        {
            ManufacturerRepository manufacturer = new ManufacturerRepository();
            return await manufacturer.GetManufacturerByIdRepositoryAsync(id);
        }


        public async Task <bool> CreateNewManufacturerServiceAsync(ManufacturerRest manufacturer)
        {
            ManufacturerRepository repository = new ManufacturerRepository();
           
            if (await repository.CreateNewManufacturerRepositoryAsync(manufacturer) == true)
            {
                
                return true;
            }
            else return false;
        }

        public async Task <bool> UpdateManufacturerByIdServiceAsync(int id,ManufacturerRest manufacturer)
        {
            ManufacturerRepository repository = new ManufacturerRepository();
            
            if (await repository.UpdateManufacturerByIdRepositoryAsync(id,manufacturer) == true)
            {
                
                return true; 
            }
            else return false;
        }

        public async Task<bool> DeleteManufacturerByIdServiceAsync(int id)
        {
            ManufacturerRepository repository = new ManufacturerRepository();

            if (await repository.DeleteManufacturerByIdRepositoryAsync(id) == true)
            {
                return true;
            }
            else return false;
        }
    }
}
