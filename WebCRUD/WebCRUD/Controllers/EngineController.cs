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
    public class EngineController : ApiController
    {
        public static List<EngineModel> listEngines = new List<EngineModel>(3) {
        new EngineModel { Id = 1, Name = "2.0 TDI", Type = "150 hp", ManufacturerId = 1 },
        new EngineModel { Id = 2, Name = "1.5 dci", Type = "90 hp", ManufacturerId = 2 },
        new EngineModel { Id = 3, Name = "220 d", Type = "170 hp", ManufacturerId = 3 }
        };


        

        //GET api/values
        [HttpGet]
        public HttpResponseMessage GetAllEngines()
        {
            if (listEngines.Count == 0)
            { return Request.CreateResponse(HttpStatusCode.BadRequest, "No engine."); }

            return Request.CreateResponse(HttpStatusCode.OK, listEngines);

        }

        [HttpGet]
        [Route("api/engine/{Id}")]
        public HttpResponseMessage GetEnginesById(int id)
        {
            var engine = listEngines.Find(e => e.Id == id);

            if (engine == null)
            { return Request.CreateResponse(HttpStatusCode.BadRequest, $"Engine {id} not found"); }

            return Request.CreateResponse(HttpStatusCode.OK, engine);

        }



        // POST api/values
        [HttpPost]
        public void CreateNewEngine(EngineModel engine)
        {
            if (engine == null)
            { return; }

            if (listEngines.Count == 0)
            { engine.Id = 1; }
            else
            { engine.Id = listEngines.Last().Id + 1; }

            listEngines.Add(engine);
        }

        // POST api/values
        [HttpPost]
        [Route("api/engine/create")]
        public void CreateNewEngine(List<EngineModel> engines)
        {
            if (engines == null)
            { return; }

            foreach (var item in engines)
            {
                if (listEngines.Count == 0)
                { item.Id = 1; }
                else
                { item.Id = listEngines.Last().Id + 1; }

                listEngines.Add(item);
            }
        }

        // PUT api/values
        [HttpPut]
        public HttpResponseMessage EditEngine(EngineModel engine)
        {
            var engineFromList = listEngines.Find(e => e.Id == engine.Id);

            if (engineFromList == null)
            { return Request.CreateResponse(HttpStatusCode.BadRequest, $"Engine {engine.Id} not found"); }

            engineFromList.Name = engine.Name;
            engineFromList.Type = engine.Type;
            engineFromList.ManufacturerId = engine.ManufacturerId;

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/values/delete/3
        [HttpDelete]
        [Route("api/engine/delete/{Id}")]
        public HttpResponseMessage DeleteEngineById(int id)
        {
            var engineFromList = listEngines.Find(e => e.Id == id);

            if (engineFromList == null)
            { Request.CreateResponse(HttpStatusCode.BadRequest, $"Engine {id} not found"); }

            listEngines.Remove(engineFromList);

            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}