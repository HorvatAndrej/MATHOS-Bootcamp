using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebCRUD.Models;
using System.Data.SqlClient;
using Vehicle.Model;
using Vehicle.Service;
using System.Threading.Tasks;

namespace WebApiCrudDatabase.Controllers
{
    public class ManufacturerController:ApiController
    {
        List<Manufacturer> manufacturers = new List<Manufacturer>();
        [HttpGet]
        public async Task <HttpResponseMessage> GetAllManufacturersAsync()
        {
            ManufacturerService service = new ManufacturerService();
            List<ManufacturerView> viewList = new List<ManufacturerView>();
            manufacturers =await  service.GetAllManufacturersServiceAsync();
            if (manufacturers.Count() != 0)
            {
                foreach (Manufacturer manufacturer in manufacturers)
                {
                    ManufacturerView view = new ManufacturerView();
                    view.Name = manufacturer.Name;
                    
                    viewList.Add(view);
                }
                return Request.CreateResponse(HttpStatusCode.OK, viewList);
            }
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "No manfacturer");

        }





        [HttpGet]
        [Route("api/manufacturer/get/{Id}")]
        public async Task <HttpResponseMessage> GetManufacturerByIdAsync(int id)
        {
            ManufacturerService service = new ManufacturerService();
            Manufacturer manufacturerholder = await service.GetManufacturerByIdServiceAsync(id);
            if (manufacturerholder != null)
            {
                ManufacturerView view = new ManufacturerView();
                view.Name = manufacturerholder.Name;

                if (view != null)
                    return Request.CreateResponse(HttpStatusCode.OK, view);
                
            }
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "No manufacturer");
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No manufacturer");



        }



        [HttpPost]
        [Route("api/manufacturer/create")]
        public async Task <HttpResponseMessage> CreateNewManufacturerAsync(ManufacturerRest manufacturer)
        {
            ManufacturerService service = new ManufacturerService();
            
            if (await service.CreateNewManufacturerServiceAsync(manufacturer) == true)
            {
                

                return Request.CreateResponse(HttpStatusCode.OK, $"Created");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not created");
            }

            
        }




        [HttpPut]
        [Route("api/manufacturer/update/{id}")]
        public async Task <HttpResponseMessage> UpdateManufacturerByIdAsync(int id,ManufacturerRest manufacturer)
        {
            ManufacturerService service = new ManufacturerService();
            if (service.GetManufacturerByIdServiceAsync(id) != null)
            {
                if (await service.UpdateManufacturerByIdServiceAsync(id,manufacturer) == true)
                {
                    

                    return Request.CreateResponse(HttpStatusCode.OK, $"Updated!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not found");
                }
            }
            else return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not found");
        }





        [HttpDelete]
        [Route("api/manufacturer/delete/{Id}")]
        public async Task <HttpResponseMessage> DeleteManufacturerByIDAsync(int id)
        {
            ManufacturerService service = new ManufacturerService();
            
            if (await service.DeleteManufacturerByIdServiceAsync(id) == true)
            {
                await service.DeleteManufacturerByIdServiceAsync(id);

                return Request.CreateResponse(HttpStatusCode.OK, $"Deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not found");
            }

            
        }




    }

   
}
