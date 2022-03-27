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
                else connection.Close(); return Request.CreateResponse(HttpStatusCode.BadRequest, "No manufactureres.");
            }

        }


        [HttpPost]
        [Route("api/manufacturer/create")]
        public HttpResponseMessage CreateNewManufacturer(ManufacturerModel manufacturer)
        {
            if (GetManufacturerById(manufacturer.Id).IsSuccessStatusCode) return Request.CreateResponse(HttpStatusCode.BadRequest, "Can't create new manufacturer.");
            SqlConnection connection = new SqlConnection(connectionToString);
            string queryString = $"INSERT INTO Manufacturer (Id, Name, Country) VALUES ('{manufacturer.Id}', '{manufacturer.Name}', '{manufacturer.Country}')";
            using (connection)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet manufacturers = new DataSet();
                adapter.Fill(manufacturers, "Manufacturers");
                connection.Close();
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Inserted.");
        }

        [HttpPut]
        [Route("api/manufacturer/update")]
        public HttpResponseMessage UpdateManufacturerByID(ManufacturerModel manufacturer)
        {
            if (!GetManufacturerById(manufacturer.Id).IsSuccessStatusCode) return Request.CreateResponse(HttpStatusCode.BadRequest, "Can't update manufacturer.");
            SqlConnection connection = new SqlConnection(connectionToString);
            string queryString = $"UPDATE Manufacturer SET Id='{manufacturer.Id}',Name='{manufacturer.Name}',Country='{manufacturer.Country}' WHERE Id='{manufacturer.Id}'";
            using (connection)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

                ;
                DataSet manufacturers = new DataSet();
                adapter.Fill(manufacturers, "Manufacturers");
                connection.Close();
            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Updated.");
        }

        [HttpDelete]
        [Route("api/manufacturer/delete/{Id}")]
        public HttpResponseMessage DeleteManufacturerByID(int id)
        {
            if (!GetManufacturerById(id).IsSuccessStatusCode) return Request.CreateResponse(HttpStatusCode.BadRequest, "Can't delete manufacturer.");
            SqlConnection connection = new SqlConnection(connectionToString);

            string queryString = $"DELETE FROM Manufacturer WHERE Id='{id}'";
            using (connection)
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet engines = new DataSet();
                adapter.Fill(engines, "Engines");
                connection.Close();
            }

                return Request.CreateResponse(HttpStatusCode.OK, $"Deleted!");
        }
    }
}