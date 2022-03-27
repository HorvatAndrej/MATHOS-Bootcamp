using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebCRUD.Models;
using System.Data.SqlClient;
using System.Data;
using Vehicle.Service;
using Vehicle.Model;

namespace WebApiCrudDatabase.Controllers
{
    public class EngineController : ApiController
    {

        List<Engine> engines = new List<Engine>();
        [HttpGet]
        public HttpResponseMessage GetAllEngines()
        {
            EngineService engine = new EngineService();

            engines = engine.GetAllEnginesService();
            if (engines.Count() != 0)
                return Request.CreateResponse(HttpStatusCode.OK, engine.GetAllEnginesService());
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "No engine.");

        }





        [HttpGet]
        [Route("api/engine/get/{Id}")]
        public HttpResponseMessage GetEngineById(int id)
        {
            EngineService engine = new EngineService();
            Engine engineholder = engine.GetEngineByIdService(id);

            if (engineholder != null)
                return Request.CreateResponse(HttpStatusCode.OK, engineholder);
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "No engine.");



        }



        [HttpPost]
        [Route("api/engine/create")]
        public HttpResponseMessage CreateNewEngine(Engine engine)
        {
            EngineService service = new EngineService();
            if (service.CreateNewEngineService(engine) == true)
            {
                service.CreateNewEngineService(engine);

                return Request.CreateResponse(HttpStatusCode.OK, $"Created");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not created");
            }
        }




        [HttpPut]
        [Route("api/engine/update")]
        public HttpResponseMessage UpdateEngineById(Engine engine)
        {
            EngineService service = new EngineService();
            
            if (service.UpdateEngineByIdService(engine) == true)
            {
                service.UpdateEngineByIdService(engine);

                return Request.CreateResponse(HttpStatusCode.OK, $"Updated!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Not found");
            }
        }





        [HttpDelete]
        [Route("api/engine/delete/{Id}")]
        public HttpResponseMessage DeleteEngineByID(int id)
        {
           EngineService service=new EngineService();

            if (service.DeleteEngineByIdService(id) == true)
            {
                service.DeleteEngineByIdService(id);

                return Request.CreateResponse(HttpStatusCode.OK, $"Deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not found");
            }
        }
    }
}
