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
using System.Threading.Tasks;
using Vehicle.Service.Common;
using Vehicle.DAL.Common;

namespace WebApiCrudDatabase.Controllers
{
    public class EngineController : ApiController
    {

        List<Engine> engines = new List<Engine>();
        protected IEngineService service { get; set; }
        public EngineController(IEngineService service)
        {
            this.service = service; 
        }
        
        [HttpGet]
        [Route("api/engine/get")]
        public async Task<HttpResponseMessage> GetAllEngines(string sortOrder, string columnName, int pageNumber, int objectsPerPage,int? id, string name )
        {
            Sorting sorting = new Sorting();
            sorting.SortOrder = sortOrder;  
            sorting.ColumnName = columnName;
            Paging paging = new Paging();
            paging.PageNumber = pageNumber;
            paging.ObjectsPerPage = objectsPerPage;
            EngineFilter filter=new EngineFilter();
            filter.Id = id;
            filter.Name = name;
            
            List<EngineView> viewList= new List<EngineView>();
            engines = await service.GetAllEnginesServiceAsync(sorting, paging, filter);
            if (engines.Count() != 0)
            {
                foreach (Engine engine in engines)
                {
                    EngineView view = new EngineView();
                    view.Name = engine.Name;
                    view.Type = engine.Type;
                    viewList.Add(view);
                }

                return Request.CreateResponse(HttpStatusCode.OK, viewList);
            }
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "No engine.");

        }





        [HttpGet]
        [Route("api/engine/get/{Id}")]
        public async Task <HttpResponseMessage> GetEngineByIdAsync(int id)
        {
            
            Engine engineholder =await  service.GetEngineByIdServiceAsync(id);
            EngineView view = new EngineView();
           

            if (engineholder != null)
            {
                view.Name = engineholder.Name;
                view.Type = engineholder.Type;
                return Request.CreateResponse(HttpStatusCode.OK, view);
            }
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "No engine.");



        }



        [HttpPost]
        [Route("api/engine/create")]
        public async Task <HttpResponseMessage> CreateNewEngineAsync(EngineRest engineRest)
        {
            
          
            if (await service.CreateNewEngineServiceAsync(engineRest) == true)
            {
                

                return Request.CreateResponse(HttpStatusCode.OK, $"Created");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not created");
            }
        }




        [HttpPut]
        [Route("api/engine/update/{Id}")]
        public async Task <HttpResponseMessage> UpdateEngineByIdAsync(int id,EngineRest engine)
        {
            
            if (service.GetEngineByIdServiceAsync(id) != null)
            {

                if (await service.UpdateEngineByIdServiceAsync(id,engine) == true)
                {iugizgghjvhj


                    return Request.CreateResponse(HttpStatusCode.OK, $"Updated!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, $"Can't update");
                }
            }
            else return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not found");
        }





        [HttpDelete]
        [Route("api/engine/delete/{Id}")]
        public async Task<HttpResponseMessage> DeleteEngineByIDAsync(int id)
        {
           

            if (await service.DeleteEngineByIdServiceAsync(id) == true)
            {
                await service.DeleteEngineByIdServiceAsync(id);

                return Request.CreateResponse(HttpStatusCode.OK, $"Deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Not found");
            }
        }
        
    }

   

   
}
