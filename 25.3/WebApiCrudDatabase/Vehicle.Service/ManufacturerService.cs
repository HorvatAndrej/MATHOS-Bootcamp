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
    public class ManufacturerService:IManufacturerService
    {
        protected IManufacturerRepository repository { get; set; }
        public ManufacturerService(IManufacturerRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<Manufacturer>> GetAllManufacturersServiceAsync(Sorting sorting, Paging paging, ManufacturerFilter filter)
        {
            
            return await repository.GetAllManufacturersRepositoryAsync(sorting, paging, filter);
        }

        public async Task <Manufacturer> GetManufacturerByIdServiceAsync(int id)
        {
            
            return await repository.GetManufacturerByIdRepositoryAsync(id);
        }


        public async Task <bool> CreateNewManufacturerServiceAsync(ManufacturerRest manufacturer)
        {
            
           
            if (await repository.CreateNewManufacturerRepositoryAsync(manufacturer) == true)
            {
                
                return true;
            }
            else return false;
        }

        public async Task <bool> UpdateManufacturerByIdServiceAsync(int id,ManufacturerRest manufacturer)
        {
            
            
            if (await repository.UpdateManufacturerByIdRepositoryAsync(id,manufacturer) == true)
            {
                
                return true; 
            }
            else return false;
        }

        public async Task<bool> DeleteManufacturerByIdServiceAsync(int id)
        {
            

            if (await repository.DeleteManufacturerByIdRepositoryAsync(id) == true)
            {
                return true;
            }
            else return false;
        }
    }
}
