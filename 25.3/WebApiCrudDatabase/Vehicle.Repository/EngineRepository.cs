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
    public class EngineRepository : IEngineRepository
    {
        static string connectionToString = "Data Source=DESKTOP-IPG6JPI;Initial Catalog=Vehicle;Integrated Security=True";
        List<Engine> engines = new List<Engine>();


        public async Task<List<Engine>> GetAllEnginesRepositoryAsync()
        {
            SqlConnection connection = new SqlConnection(connectionToString);


            using (connection)
            {
                SqlCommand command = new SqlCommand("Select * from Engine", connection);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();

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


        public async Task<Engine> GetEngineByIdRepositoryAsync(int id)
        {
            SqlConnection connection = new SqlConnection(connectionToString);


            using (connection)
            {

                await connection.OpenAsync();
                SqlCommand command = new SqlCommand($"Select * from Engine where Engine.Id={id}", connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();

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
                else { connection.Close(); return null; }


            }
            return null;

        }

        public async Task<bool> CreateNewEngineRepositoryAsync(EngineRest engine)
        {
            int Id = await GetLastEngineIdRepositoryAsync()+1;
            
            
            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {

                await connection.OpenAsync();
                string queryString = $"INSERT INTO Engine (Id, Name, Type, ManufacturerID) VALUES ('{Id}', '{engine.Name}', '{engine.Type}', '{engine.ManufacturerId}')";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet engines = new DataSet();
                await Task.Run(() => adapter.Fill(engines, "Engines"));
                connection.Close();
                return true;
            }


        }

        public async Task<bool> UpdateEngineByIdRepositoryAsync(int id, EngineRest engine)
        {
            if (GetEngineByIdRepositoryAsync(id) == null) return false;
            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {
                string queryString = $"UPDATE Engine SET Name='{engine.Name}',Type='{engine.Type}', ManufacturerId='{engine.ManufacturerId}' WHERE Id='{id}'";
                await connection.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet engines = new DataSet();
                await Task.Run(() => adapter.Fill(engines, "Engines"));
                connection.Close();
                return true;
            }


        }

        public async Task<bool> DeleteEngineByIdRepositoryAsync(int id)
        {
            if ((await GetEngineByIdRepositoryAsync(id)) == null) return false;
            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {
                string queryString = $"DELETE FROM Engine WHERE Id='{id}'";
                await connection.OpenAsync();

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                DataSet engines = new DataSet();
                await Task.Run(() => adapter.Fill(engines, "Engines"));
                connection.Close();
                return true;
            }


        }

        public async Task<int> GetLastEngineIdRepositoryAsync()
        {
            SqlConnection connection = new SqlConnection(connectionToString);
            using(connection)
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand($"Select Max(Id) from Engine", connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                int engineId=0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                         engineId = reader.GetInt32(0);

                       
                    }
                    connection.Close();
                    return engineId;


                }
                else { connection.Close(); return 0; }

            }

        }



    }
}
    
