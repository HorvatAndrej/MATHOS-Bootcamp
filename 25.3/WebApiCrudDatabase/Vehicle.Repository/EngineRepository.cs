using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class EngineRepository:IEngineRepository
    {
        static string connectionToString = "Data Source=DESKTOP-IPG6JPI;Initial Catalog=Vehicle;Integrated Security=True";
        List<Engine> engines = new List<Engine>();

        
        public List<Engine> GetAllEnginesRepository()
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
                        Engine model = new Engine();
                        model.Name = reader.GetString(1);
                        model.Id = reader.GetInt32(0);
                        model.Type = reader.GetString(2);
                        model.ManufacturerId = reader.GetInt32(3);
                        engines.Add(model);
                    }
                    connection.Close();                  
                    return engines;
                }
                else { connection.Close(); return null; }
            }
        }

        
        public Engine GetEngineByIdRepository(int id)
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
                        Engine model = new Engine();

                        model.Name = reader.GetString(1);
                        model.Id = reader.GetInt32(0);
                        model.Type = reader.GetString(2);
                        model.ManufacturerId = reader.GetInt32(3);                      
                        connection.Close();                        
                        return model;
                    }


                }
                else {connection.Close(); return null; }


            }
            return null;

        }

        public bool CreateNewEngineRepository(Engine engine)
        {
            if (GetEngineByIdRepository(engine.Id) != null) return false;

            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {

                connection.Open(); string queryString = $"INSERT INTO Engine (Id, Name, Type, ManufacturerID) VALUES ('{engine.Id}', '{engine.Name}', '{engine.Type}', '{engine.ManufacturerId}')";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet engines = new DataSet();
                adapter.Fill(engines, "Engines");
                connection.Close();
                return true;
            }

            
        }

        public bool UpdateEngineByIdRepository(Engine engine)
        {
            if (GetEngineByIdRepository(engine.Id) == null) return false;
            SqlConnection connection = new SqlConnection(connectionToString);
            using(connection)
            { 
            string queryString = $"UPDATE Engine SET Id='{engine.Id}',Name='{engine.Name}',Type='{engine.Type}', ManufacturerId='{engine.ManufacturerId}' WHERE Id='{engine.Id}'";
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet engines = new DataSet();
            adapter.Fill(engines, "Engines");
            connection.Close(); 
            return true; 
            }
            

        }

        public bool DeleteEngineByIdRepository(int id)
        {
            if (GetEngineByIdRepository(id) == null) return false;
            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {
                string queryString = $"DELETE FROM Engine WHERE Id='{id}'";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet engines = new DataSet();
                adapter.Fill(engines, "Engines");
                connection.Close();
                return true;
            }

            
        }



    }
}
