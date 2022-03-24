using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebCRUD.Models;
using System.Data.SqlClient;

namespace WebApiCrudDatabase.Controllers
{
    public class ManufacturerController:ApiController
    {
        static string connectionToString = "Data Source=DESKTOP-IPG6JPI;Initial Catalog=Vehicle;Integrated Security=True";
        List<ManufacturerModel> manufacturers = new List<ManufacturerModel>();
        [HttpGet]
        public HttpResponseMessage GetAllManufacturer()
        {
            SqlConnection connection = new SqlConnection(connectionToString);


            using (connection)
            {
                SqlCommand command = new SqlCommand("Select * from Manufacturer", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ManufacturerModel model = new ManufacturerModel();
                        model.Name = reader.GetString(1);
                        model.Id = reader.GetInt32(0);
                        model.Country = reader.GetString(2);
                        
                        manufacturers.Add(model);
                    }
                    connection.Close();
                    return Request.CreateResponse(HttpStatusCode.OK, manufacturers);
                }
                else connection.Close(); return Request.CreateResponse(HttpStatusCode.BadRequest, "No manufactureres.");
                
            }

            

        }
        [HttpGet]
        [Route("api/manufacturer/get/{id}")]
        public HttpResponseMessage GetManufacturerById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionToString);


            using (connection)
            {

                SqlCommand command = new SqlCommand($"Select * from Manufacturer where Manufacturer.Id={id}", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ManufacturerModel model = new ManufacturerModel();
                        model.Name = reader.GetString(1);
                        model.Id = reader.GetInt32(0);
                        model.Country = reader.GetString(2);
                        connection.Close();
                        return Request.CreateResponse(HttpStatusCode.OK, model);
                        
                    }
                   
                }
                else connection.Close();  return Request.CreateResponse(HttpStatusCode.BadRequest, "No manufactureres.");
            }
            
        }


        [HttpPost]
        [Route("api/manufacturer/create")]
        public HttpResponseMessage CreateNewManufacturer(ManufacturerModel manufacturer)
        {

            SqlConnection connection = new SqlConnection(connectionToString);

            SqlCommand command = new SqlCommand($"INSERT INTO Manufacturer (Id, Name, Country) VALUES ('{manufacturer.Id}', '{manufacturer.Name}', '{manufacturer.Country}')", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();


            connection.Close();

            return Request.CreateResponse(HttpStatusCode.OK, $"Inserted!");
        }

        [HttpPut]
        [Route("api/manufacturer/update")]
        public HttpResponseMessage UpdateManufacturerByID(ManufacturerModel manufacturer)
        {
            SqlConnection connection = new SqlConnection(connectionToString);

            SqlCommand command2 = new SqlCommand($"SELECT * FROM Manufacturer WHERE Id='{manufacturer.Id}'", connection);
            connection.Open();
            SqlDataReader reader = command2.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                SqlCommand command = new SqlCommand($"UPDATE Manufacturer SET Id='{manufacturer.Id}',Name='{manufacturer.Name}',Country='{manufacturer.Country}' WHERE Id='{manufacturer.Id}'", connection);
                reader = command.ExecuteReader();
                return Request.CreateResponse(HttpStatusCode.OK, $"Updated!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, $"Not found");
            }
        }

        [HttpDelete]
        [Route("api/manufacturer/delete/{Id}")]
        public HttpResponseMessage DeleteManufacturerByID(int id)
        {
            SqlConnection connection = new SqlConnection(connectionToString);

            SqlCommand command = new SqlCommand($"DELETE FROM Manufacturer WHERE Id='{id}'", connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            return Request.CreateResponse(HttpStatusCode.OK, $"Deleted!");
        }




    }
}
