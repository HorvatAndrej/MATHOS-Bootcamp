using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class ManufacturerRepository:IManufacturerRepository
    {
        static string connectionToString = "Data Source=DESKTOP-IPG6JPI;Initial Catalog=Vehicle;Integrated Security=True";
        List<Manufacturer> manufacturers = new List<Manufacturer>();


        public List<Manufacturer> GetAllManufacturersRepository()
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


        public Manufacturer GetManufacturerByIdRepository(int id)
        {
            SqlConnection connection = new SqlConnection(connectionToString);


            using (connection)
            {

                connection.Open();
                SqlCommand command = new SqlCommand($"Select * from Manufacturer where Manufacturer.Id={id}", connection);

                SqlDataReader reader = command.ExecuteReader();
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

        public bool CreateNewManufacturerRepository(Manufacturer manufacturer)
        {
            if (GetManufacturerByIdRepository(manufacturer.Id) != null) return false;
            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {
                string queryString = $"INSERT INTO Manufacturer (Id, Name, Country) VALUES ('{manufacturer.Id}', '{manufacturer.Name}', '{manufacturer.Country}')";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);               
                DataSet manufacturers = new DataSet();
                adapter.Fill(manufacturers, "Manufacturers");
                connection.Close(); 
                return true; 
                
            }


        }

        public bool UpdateManufacturerByIdRepository(Manufacturer manufacturer)
        {
            if (GetManufacturerByIdRepository(manufacturer.Id) == null) return false;
            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {
                
                string queryString = $"UPDATE Manufacturer SET Id='{manufacturer.Id}',Name='{manufacturer.Name}',Country='{manufacturer.Country}' WHERE Id='{manufacturer.Id}'";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);   
                DataSet manufacturers = new DataSet();
                adapter.Fill(manufacturers, "Manufacturers");
                connection.Close(); 
                return true; 
                
            }

        }

        public bool DeleteManufacturerByIdRepository(int id)
        {
            if (GetManufacturerByIdRepository(id)==null) return false;
            SqlConnection connection = new SqlConnection(connectionToString);
            using (connection)
            {                
                string queryString = $"DELETE FROM Manufacturer WHERE Manufacturer.Id='{id}'";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);             
                DataSet manufacturer = new DataSet();
                adapter.Fill(manufacturer, "Manufacturer");
                connection.Close();
                return true;
            }


        }
    }
}
