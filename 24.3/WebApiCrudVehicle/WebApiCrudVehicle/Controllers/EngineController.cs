using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApiCrudVehicle.Models;

namespace WebApiCrudVehicle.Controllers
{
    public class EngineController : ApiController
    {
        static string connectionToString = "Data Source=DESKTOP-IPG6JPI;Initial Catalog=Vehicle;Integrated Security=True";
        List<EngineModel> engines = new List<EngineModel>();
        [HttpGet]
        public HttpResponseMessage GetAllEngines()
        {
            SqlConnection connection = new SqlConnection(connectionToString);


            using (connection)
            {
                SqlCommand command = new SqlCommand("Select * from Engine", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EngineModel model = new EngineModel();
                        model.Name = reader.GetString(1);
                        model.Id = reader.GetInt32(0);
                        model.Type = reader.GetString(2);
                        model.ManufacturerId = reader.GetInt32(3);
                        engines.Add(model);

                    }
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, engines);

                }
                else connection.Close(); return Request.CreateResponse(HttpStatusCode.BadRequest, "No engines.");

            }
          ;
        }


        [HttpGet]
        [Route("api/engine/get/{Id}")]
        public HttpResponseMessage GetEngineById(int id)
        {

            SqlConnection connection = new SqlConnection(connectionToString);


            using (connection)
            {

                connection.Open();
                SqlCommand command = new SqlCommand($"Select * from Engine where Engine.Id={id}", connection);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EngineModel model = new EngineModel();

                        model.Name = reader.GetString(1);
                        model.Id = reader.GetInt32(0);
                        model.Type = reader.GetString(2);
                        model.ManufacturerId = reader.GetInt32(3);
                        connection.Close();
                        return Request.CreateResponse(HttpStatusCode.OK, model);
                    }


                }
                else connection.Close(); return Request.CreateResponse(HttpStatusCode.BadRequest, "No engine.");


            }


        }

        [HttpPost]
        [Route("api/engine/create")]
        public HttpResponseMessage CreateNewEngine(EngineModel engine)
        {
            if (GetEngineById(engine.Id).IsSuccessStatusCode) return Request.CreateResponse(HttpStatusCode.BadRequest, "Can't create new engine.");

            SqlConnection connection = new SqlConnection(connectionToString);
            string queryString = $"INSERT INTO Engine (Id, Name, Type, ManufacturerID) VALUES ('{engine.Id}', '{engine.Name}', '{engine.Type}', '{engine.ManufacturerId}')";
            using (connection)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet engines = new DataSet();
                adapter.Fill(engines, "Engines");

                connection.Close();
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"New engine created");
        }

    

            
        




        [HttpPut]
        [Route("api/engine/update")]
        public HttpResponseMessage UpdateEngineByID(EngineModel engine)
        {
            if (!GetEngineById(engine.Id).IsSuccessStatusCode) return Request.CreateResponse(HttpStatusCode.BadRequest, "Can't update engine.");
            SqlConnection connection = new SqlConnection(connectionToString);
            string queryString = $"UPDATE Engine SET Id='{engine.Id}',Name='{engine.Name}',Type='{engine.Type}', ManufacturerId='{engine.ManufacturerId}' WHERE Id='{engine.Id}'";
            using (connection)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

                
                DataSet engines = new DataSet();
                adapter.Fill(engines, "Engines");
                connection.Close();
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Updated.");  
            
        }

            [HttpDelete]
        [Route("api/engine/delete/{Id}")]
        public HttpResponseMessage DeleteEngineByID(int id)
        {
            if (!GetEngineById(id).IsSuccessStatusCode) return Request.CreateResponse(HttpStatusCode.BadRequest, "Can't delete engine.");
            SqlConnection connection = new SqlConnection(connectionToString);
            string queryString = $"DELETE FROM Engine WHERE Id='{id}'";
            using (connection)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet engines = new DataSet();
                adapter.Fill(engines, "Engines");
                connection.Close();
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Deleted."); 
            
            
        }
    }

}
