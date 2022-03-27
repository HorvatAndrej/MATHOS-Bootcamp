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
        public List<Manufacturer> GetAllManufacturersService()
        {
            ManufacturerRepository manufacturer = new ManufacturerRepository();
            return manufacturer.GetAllManufacturersRepository();
        }

        public Manufacturer GetManufacturerByIdService(int id)
        {
            ManufacturerRepository manufacturer = new ManufacturerRepository();
            return manufacturer.GetManufacturerByIdRepository(id);
        }


        public bool CreateNewManufacturerService(Manufacturer manufacturer)
        {
            ManufacturerRepository repository = new ManufacturerRepository();
           
            if (repository.CreateNewManufacturerRepository(manufacturer) == true)
            {
                repository.CreateNewManufacturerRepository(manufacturer);
                return true;
            }
            else return false;
        }

        public bool UpdateManufacturerByIdService(Manufacturer manufacturer)
        {
            ManufacturerRepository repository = new ManufacturerRepository();
            
            if (repository.UpdateManufacturerByIdRepository(manufacturer) == true)
            {
                repository.UpdateManufacturerByIdRepository(manufacturer);
                return true; 
            }
            else return false;
        }

        public bool DeleteManufacturerByIdService(int id)
        {
            ManufacturerRepository repository = new ManufacturerRepository();

            if (repository.DeleteManufacturerByIdRepository(id) == true)
            {
                repository.DeleteManufacturerByIdRepository(id); return true;
            }
            else return false;
        }
    }
}
