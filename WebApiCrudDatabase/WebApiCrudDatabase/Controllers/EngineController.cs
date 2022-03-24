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

namespace WebApiCrudDatabase.Controllers
{
    public class EngineController:ApiController
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
                else connection.Close();  return Request.CreateResponse(HttpStatusCode.BadRequest, "No engine.");
                
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
                else connection.Close(); return Request.CreateResponse(HttpStatusCode.BadRequest, "No manufactureres.");
                

            }
            

        }

        [HttpPost]
        [Route("api/engine/create")]
        public HttpResponseMessage CreateNewEngine(EngineModel engine)
        {

            SqlConnection connection = new SqlConnection(connectionToString);

            SqlCommand command = new SqlCommand($"INSERT INTO Engine (Id, Name, Type, ManufacturerID) VALUES ('{engine.Id}', '{engine.Name}', '{engine.Type}', '{engine.ManufacturerId}')", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();


            connection.Close();

            return Request.CreateResponse(HttpStatusCode.OK, $"Inserted!");
        }




        [HttpPut]
        [Route("api/engine/update")]
        public HttpResponseMessage UpdateEngineByID(EngineModel engine)
        {
            SqlConnection connection = new SqlConnection(connectionToString);

            SqlCommand command2 = new SqlCommand($"SELECT * FROM Engine WHERE Id='{engine.Id}'", connection);
            connection.Open();
            SqlDataReader reader = command2.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                SqlCommand command = new SqlCommand($"UPDATE Engine SET Id='{engine.Id}',Name='{engine.Name}',Type='{engine.Type}',ManufacturerId='{engine.ManufacturerId}' WHERE Id='{engine.Id}'", connection);
                reader = command.ExecuteReader();
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
            SqlConnection connection = new SqlConnection(connectionToString);

            SqlCommand command = new SqlCommand($"DELETE FROM Engine WHERE Id='{id}'", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return Request.CreateResponse(HttpStatusCode.OK, $"Deleted!");
        }
    }
}