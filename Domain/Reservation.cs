using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Domain
{
    public class Reservation
    {

        
        public static void MakeReservation(object Email, object Login, string text1, string text2, List<int> tijdsloten)
        {
            SqlConnection sqlCon = new(@"Data Source=.\SQLEXPRESS;Initial Catalog=FitnessServer;Integrated Security=True;Pooling=False");

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            string[] hello = text2.Replace("- ", "").Split(" ");
            int getal = int.Parse(hello[1]);
            string gereserveerd = "Gereserveerd";
            string query = "INSERT INTO Afspraken (A_FirstName, A_LastName, A_Datum, A_Toestel, A_ToestelId, A_SLOT, A_Email) VALUES (@A_FirstName, @A_LastName, @A_Datum, @A_Toestel,  @A_ToestelId, @A_SLOT, @A_Email)";

            string query2 = "UPDATE Machines SET Huidig = @Huidig WHERE M_Id = " + getal + " ;";
            //string data = "SELECT * FROM Afspraken";

            string[] gesplitstenaam = Login.ToString().Split(" ");

            for (int i = 0; i < tijdsloten.Count; i++)
            {
                SqlCommand command = new SqlCommand(query, sqlCon);
                SqlCommand command2 = new SqlCommand(query2, sqlCon);

                command.Parameters.AddWithValue("@A_FirstName", gesplitstenaam[0]);
                command.Parameters.AddWithValue("@A_LastName", gesplitstenaam[1]);
                command.Parameters.AddWithValue("@A_Datum", text1);
                command.Parameters.AddWithValue("@A_Toestel", hello[0]);
                command.Parameters.AddWithValue("@A_ToestelId", getal);
                command.Parameters.AddWithValue("@A_SLOT", tijdsloten[i] + "u");
                command.Parameters.AddWithValue("@A_Email", Email.ToString());
                command2.Parameters.AddWithValue("@Huidig", gereserveerd);

                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();

            }

            sqlCon.Close();
        }
    }
}
