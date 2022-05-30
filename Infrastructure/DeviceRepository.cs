using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain;
using System.Data.SqlClient;
using System.Data;

namespace Infrastructure
{
    public class DeviceRepository : IDeviceRepository
    {
        private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FitnessServer;Integrated Security=True;Pooling=False";

        public void Delete(string nummer, string type)
        {
            using (SqlConnection connection = new(connectionString)) {
                int resultaat = Int32.Parse(nummer);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = "DELETE FROM Machines WHERE (M_Id=@M_Id AND M_Type=@M_Type)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@M_Type", type);
                command.Parameters.AddWithValue("@M_Id", resultaat);

                command.ExecuteNonQuery();


                connection.Close();
            }
        }

        public List<Device> Get()
        {
            List<Device> deviceLijst = new();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new("SELECT M_Id, M_Type, Huidig FROM Machines", connection);

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                string nummer = (string)dataReader["M_Id"];
                                string type = (string)dataReader["M_Type"];
                                string huidig = (string)dataReader["Huidig"];

                                deviceLijst.Add(new Device(nummer, type, huidig));
                            }
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw; // we werpen de uitzondering ongewijzigd verder op 
            }

            return deviceLijst;
        }

        public void Insert(Device device)
        {
            using (SqlConnection connection = new(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = $"INSERT INTO Machines (M_Type) VALUES (`{device.Type}`)";

                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();


                connection.Close();
            }
        }

        public Device Read(string type)
        {
            using (SqlConnection connection = new(connectionString))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                
                SqlCommand command = new($"SELECT M_Type, Huidig FROM Machines Where M_Type = '{type}'", connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        string nummer = (string)dataReader["M_Id"];
                        string huidig = (string)dataReader["model"];

                        return new Device(nummer, type, huidig);
                    }
                    else
                    {
                        return null;
                    }
                }
                connection.Close();
            }
        }

        public void Update(Device device)
        {
            using (SqlConnection connection = new(connectionString))
            {
                int resultaat = Int32.Parse(device.Nummer);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = "UPDATE Machines SET Huidig='Onderhoud' WHERE (M_Id=@M_Id AND M_Type=@M_Type)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@M_Type", device.Type);
                command.Parameters.AddWithValue("@M_Id", resultaat);

                command.ExecuteNonQuery();


                connection.Close();
            }
        }
    }
}
