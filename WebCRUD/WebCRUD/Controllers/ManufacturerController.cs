using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebCRUD.Models;

namespace WebCRUD.Controllers
{
    public class ManufacturerController:ApiController
    {
        public static List<ManufacturerModel> listManufacturers = new List<ManufacturerModel>() { 
        new ManufacturerModel { Id = 1, Name = "VW", Country = "Germany" },
        new ManufacturerModel { Id = 2, Name = "Renault", Country ="France" },
        new ManufacturerModel { Id = 3, Name = "Mercedes", Country = "Germany" }
        };

       

        // GET api/values
        [HttpGet]
        public HttpResponseMessage GetAllManufacturers()
        {
            if (listManufacturers.Count >0)
            {return  Request.CreateResponse(HttpStatusCode.OK, listManufacturers); }

           else return Request.CreateResponse(HttpStatusCode.BadRequest, "No manufacturer.");

        }

        [HttpGet]
        [Route("api/manufacturer/{Id}")]
        public HttpResponseMessage GetManufacturerById(int id)
        {
            var manufacturer = listManufacturers.Find(m => m.Id == id);

            if (manufacturer == null)
            { return Request.CreateResponse(HttpStatusCode.BadRequest, $"Engine {id} not found"); }

            return Request.CreateResponse(HttpStatusCode.OK, manufacturer);

        }


        [HttpPost]
        public void CreateNewManufacturer(ManufacturerModel manufacturer)
        {
            if (manufacturer == null)
            { return; }

            if (listManufacturers.Count == 0)
            { manufacturer.Id = 1; }
            else
            { manufacturer.Id = listManufacturers.Last().Id + 1; }

            listManufacturers.Add(manufacturer);
        }

        // POST api/values
        [HttpPost]
        [Route("api/manufacturer/create")]
        public void CreateNewManufacturer(List<ManufacturerModel> manufacturers)
        {
            if (manufacturers == null)
            { return; }

            foreach (var item in manufacturers)
            {
                if (listManufacturers.Count == 0)
                { item.Id = 1; }
                else
                { item.Id = listManufacturers.Last().Id + 1; }

                listManufacturers.Add(item);
            }
        }

        // PUT api/values
        [HttpPut]
        public HttpResponseMessage EditManufacturer(ManufacturerModel manufacturer)
        {
            var manufacturerFromList = listManufacturers.Find(s => s.Id == manufacturer.Id);

            if (manufacturerFromList == null)
            { return Request.CreateResponse(HttpStatusCode.BadRequest, $"Manufacturer {manufacturer.Id} not found"); }

            manufacturerFromList.Name = manufacturer.Name;
            manufacturerFromList.Country = manufacturer.Country;

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/values/delete/3
        
        [HttpDelete]
        [Route("api/manufacturer/delete/{id}")]
        public HttpResponseMessage DeleteManufacturerById(int id)
        {
            var manufacturerFromList = listManufacturers.Find(m => m.Id == id);

            if (manufacturerFromList == null)
            { Request.CreateResponse(HttpStatusCode.BadRequest, $"Manufacturer {id} not found"); }

            listManufacturers.Remove(manufacturerFromList);

            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}