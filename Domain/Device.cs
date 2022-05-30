using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Domain
{
    public class Device
    {
        static void Main()
        {
        }
        #region Properties
        public string Nummer { get; set; }

        public string Type { get; set; }

        public string Huidig { get; set; }
        #endregion

        #region Ctor

        public Device(string nummer, string type, string huidig)
        {
            Nummer = nummer;
            Type = type;
            Huidig = huidig;
        }

        public Device(string type)
        {
            Type = type;
        }
        #endregion
        public static void MaintenanceDevice(string nummer, string type)
        {
            SqlConnection sqlCon = new(@"Data Source=.\SQLEXPRESS;Initial Catalog=FitnessServer;Integrated Security=True;Pooling=False");

            int resultaat = Int32.Parse(nummer);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            string query = "UPDATE Machines SET Huidig='Onderhoud' WHERE (M_Id=@M_Id AND M_Type=@M_Type)";

            SqlCommand command = new SqlCommand(query, sqlCon);
            command.Parameters.AddWithValue("@M_Type", type);
            command.Parameters.AddWithValue("@M_Id", resultaat);

            command.ExecuteNonQuery();

            sqlCon.Close();
        }

        public static void RegisterDevice(string nummer, string type)
        {
            SqlConnection sqlCon = new(@"Data Source=.\SQLEXPRESS;Initial Catalog=FitnessServer;Integrated Security=True;Pooling=False");

            int resultaat = Int32.Parse(nummer);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            string query = "INSERT INTO Machines (M_Type) VALUES (@M_Type)";

            SqlCommand command = new SqlCommand(query, sqlCon);
            command.Parameters.AddWithValue("@M_Type", type);

            command.ExecuteNonQuery();

            sqlCon.Close();
        }

        public static void RemoveDevice(string nummer, string type)
        {
            SqlConnection sqlCon = new(@"Data Source=.\SQLEXPRESS;Initial Catalog=FitnessServer;Integrated Security=True;Pooling=False");
            int resultaat = Int32.Parse(nummer);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            string query = "DELETE FROM Machines WHERE (M_Id=@M_Id AND M_Type=@M_Type)";

            SqlCommand command = new SqlCommand(query, sqlCon);
            command.Parameters.AddWithValue("@M_Type", type);
            command.Parameters.AddWithValue("@M_Id", resultaat);

            command.ExecuteNonQuery();


            sqlCon.Close();
        }
    }
}
