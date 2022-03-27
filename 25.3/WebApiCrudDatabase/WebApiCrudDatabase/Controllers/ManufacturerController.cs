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

namespace WebApiCrudDatabase.Controllers
{
    public class ManufacturerController:ApiController
    {
        List<Manufacturer> manufacturers = new List<Manufacturer>();
        [HttpGet]
        public HttpResponseMessage GetAllManufacturers()
        {
            ManufacturerService manufacturer = new ManufacturerService();

            manufacturers = manufacturer.GetAllManufacturersService();
            if (manufacturers.Count() != 0)
                return Request.CreateResponse(HttpStatusCode.OK, manufacturer.GetAllManufacturersService());
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "No engine.");

        }





        [HttpGet]
        [Route("api/manufacturer/get/{Id}")]
        public HttpResponseMessage GetManufacturerById(int id)
        {
            ManufacturerService manufacturer = new ManufacturerService();
            Manufacturer manufacturerholder = manufacturer.GetManufacturerByIdService(id);

            if (manufacturerholder != null)
                return Request.CreateResponse(HttpStatusCode.OK, manufacturerholder);
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "No engine.");



        }



        [HttpPost]
        [Route("api/manufacturer/create")]
        public HttpResponseMessage CreateNewManufacturer(Manufacturer manufacturer)
        {
            ManufacturerService service = new ManufacturerService();
            
            if (service.CreateNewManufacturerService(manufacturer) == true)
            {
                service.CreateNewManufacturerService(manufacturer);

                return Request.CreateResponse(HttpStatusCode.OK, $"Created");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not created");
            }

            
        }




        [HttpPut]
        [Route("api/manufacturer/update")]
        public HttpResponseMessage UpdateManufacturerById(Manufacturer manufacturer)
        {
            ManufacturerService service = new ManufacturerService();
            
            if (service.UpdateManufacturerByIdService(manufacturer) == true)
            {
                service.UpdateManufacturerByIdService(manufacturer);

                return Request.CreateResponse(HttpStatusCode.OK, $"Updated!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not found");
            }
        }





        [HttpDelete]
        [Route("api/manufacturer/delete/{Id}")]
        public HttpResponseMessage DeleteManufacturerByID(int id)
        {
            ManufacturerService service = new ManufacturerService();
            
            if (service.DeleteManufacturerByIdService(id) == true)
            {
                service.DeleteManufacturerByIdService(id);

                return Request.CreateResponse(HttpStatusCode.OK, $"Deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not found");
            }

            
        }




    }
}
