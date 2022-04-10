using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Common;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class ManufacturerRepository:IManufacturerRepository
    {
        static string connectionToString = "Data Source=DESKTOP-IPG6JPI;Initial Catalog=Vehicle;Integrated Security=True";
        List<Manufacturer> manufacturers = new List<Manufacturer>();


        public async Task<List<Manufacturer>> GetAllManufacturersRepositoryAsync(Sorting sorting, Paging paging, ManufacturerFilter filter)
        {
            SqlConnection connection = new SqlConnection(connectionToString);
            StringBuilder query = new StringBuilder("Select * from Manufacturer");
            if (filter != null)
            {
                query.Append("WHERE 1=1");
      
                if (filter.Name != null)
                    query.Append($"AND  Name like '{filter.Name}'");
                if (filter.Id != 0)
                    query.Append($"AND  Id = '{filter.Id}'");
            }
            if (sorting != null)
            {
                if (sorting.SortOrder.ToUpper() == "DESC")
                    query.Append($"ORDER BY '{sorting.ColumnName}' DESC");
                else query.Append($"ORDER BY '{sorting.ColumnName}'");
            }
            if (paging != null)
                query.Append($"OFFSET '{(paging.PageNumber - 1)}'*'{paging.ObjectsPerPage}' ROWS FETCH NEXT '{paging.ObjectsPerPage}' ROWS ONLY");
            
        
        

            using (connection)
            {
                SqlCommand command = new SqlCommand(query.ToString(), connection);
                await connection.OpenAsync();
                SqlDataReader reader =await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Manufacturer model = new Manufacturer();
                        model.Name = reader.GetString(1);
                        model.Id = reader.GetInt32(0);
                        model.Country = reader.GetString(2);
                        
                        manufacturers.Add(model);
                    }
                    connection.Close();
                    return manufacturers;
                }
                else { connection.Close(); return null; }
            }
        }


        public async Task<Manufacturer> GetManufacturerByIdRepositoryAsync(int id)
        {
            SqlConnection connection = new SqlConnection(connectionToString);


            using (connection)
            {

                await connection.OpenAsync();
                SqlCommand command = new SqlCommand($"Select * from Manufacturer where Manufacturer.Id={id}", connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Manufacturer model = new Manufacturer();

                        model.Name = reader.GetString(1);
                        model.Id = reader.GetInt32(0);
                        model.Country = reader.GetString(2);
                        
                        connection.Close();
                        return model;
                    }


                }
                else { connection.Close(); return null; }


            }
            return null;

        }

        public async Task <bool> CreateNewManufacturerRepositoryAsync(ManufacturerRest manufacturer)
        {
            int Id = await GetLastManufacturerIdRepositoryAsync() + 1;
            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {
                string queryString = $"INSERT INTO Manufacturer (Id, Name, Country) VALUES ('{Id}', '{manufacturer.Name}', '{manufacturer.Country}')";
                await connection.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);               
                DataSet manufacturers = new DataSet();
                await Task.Run(() => adapter.Fill(manufacturers, "Manufacturers"));
                connection.Close(); 
                return true; 
                
            }


        }

        public async Task<bool> UpdateManufacturerByIdRepositoryAsync(int id,ManufacturerRest manufacturer)
        {
            if (await GetManufacturerByIdRepositoryAsync(id) == null) return false;
            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {
                
                string queryString = $"UPDATE Manufacturer SET Name='{manufacturer.Name}',Country='{manufacturer.Country}' WHERE Id='{id}'";
                await connection.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);   
                DataSet manufacturers = new DataSet();
                await Task.Run(() => adapter.Fill(manufacturers, "Manufacturers"));
                connection.Close(); 
                return true; 
                
            }

        }

        public async Task<bool> DeleteManufacturerByIdRepositoryAsync(int id)
        {
            if (await GetManufacturerByIdRepositoryAsync(id)==null) return false;
            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {                
                string queryString = $"DELETE FROM Manufacturer WHERE Manufacturer.Id='{id}'";
                await connection.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);             
                DataSet manufacturer = new DataSet();
                await Task.Run(() => adapter.Fill(manufacturer, "Manufacturer"));
                connection.Close();
                return true;
            }


        }
        public async Task<int> GetLastManufacturerIdRepositoryAsync()
        {
            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand($"Select Max(Id) from Manufacturer", connection);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                int engineId = 0;
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
