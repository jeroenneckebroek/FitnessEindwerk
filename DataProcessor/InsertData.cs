using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Collections;
using Domain;
using Domain.Contracts;
using Infrastructure;
using CUI;

namespace Main
{

    public class InsertData
    {
        public static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            IDeviceRepository deviceRepo = new DeviceRepository();
            FitnessDBApp app = new(new DomeinController(deviceRepo));

            app.BewerkDB();
        }
    }

}



//List<string> klanten = new();
//List<string> toestellen = new();

//SqlConnection sqlCon = new(@"Data Source=.\SQLEXPRESS;Initial Catalog=FitnessServer;Integrated Security=True;Pooling=False");

//try
//{
//using (var reader = new StreamReader("klanten.txt"))
//{
//    while (!reader.EndOfStream)
//    {
//        klanten.Add(reader.ReadLine());
//    }
//}
//}
//catch (Exception)
//{

//    Console.WriteLine("Fout bij inladen data klanten");
//}

//try
//{
//using (var reader = new StreamReader("FitnessToestellen.txt"))
//{
//    while (!reader.EndOfStream)
//    {
//        toestellen.Add(reader.ReadLine());
//    }
//}
//}
//catch (Exception)
//{

//    Console.WriteLine("Fout bij inladen data fitnesstoestellen");
//}

//using (sqlCon)
//{
//    sqlCon.Open();
//    foreach (string klant in klanten)
//    {
//        string[] klantSplit = klant.Split(",");
//        string query = "INSERT INTO klant (K_FirstName,K_Name,K_Email,K_Gemeente,K_GeboorteDatum,K_Intresse,K_Subscription) VALUES(@K_FirstName,@K_Name,@K_Email,@K_Gemeente,@K_GeboorteDatum,@K_Intresse,@K_Subscription)";

//        SqlCommand cmd = new SqlCommand(query, sqlCon);

//        cmd.Parameters.AddWithValue("@K_FirstName", klantSplit[0]);
//        cmd.Parameters.AddWithValue("@K_Name", klantSplit[1]);
//        cmd.Parameters.AddWithValue("@K_Email", klantSplit[2]);
//        cmd.Parameters.AddWithValue("@K_Gemeente", klantSplit[3]);
//        cmd.Parameters.AddWithValue("@K_GeboorteDatum", klantSplit[4]);
//        cmd.Parameters.AddWithValue("@K_Intresse", HeeftInteresse(klantSplit[5]));
//        cmd.Parameters.AddWithValue("@K_Subscription", HeeftSub(klantSplit[6]));

//        cmd.ExecuteNonQuery();
//    }
//    foreach (string toestel in toestellen)
//    {
//        string[] toestelSplit = toestel.Split(",");
//        string query2 =
//            $"INSERT INTO Machines(M_Type) VALUES ('{toestelSplit[1]}');";
//        SqlCommand cmd = new SqlCommand(query2, sqlCon);

//        cmd.ExecuteNonQuery();
//    }
//    foreach (string klant in klanten)
//    {
//        string[] klantSplit = klant.Split(",");
//        string query3 = "INSERT INTO LoginKlant (L_Username,L_Passwoord) VALUES (@L_Username,@L_Passwoord)";

//        SqlCommand cmd = new SqlCommand(query3, sqlCon);

//        cmd.Parameters.AddWithValue("@L_Username", klantSplit[2].Replace("'", ""));
//        cmd.Parameters.AddWithValue("@L_Passwoord", klantSplit[0].Replace("'", "") + klantSplit[1].Replace("'", ""));

//        cmd.ExecuteNonQuery();
//    }
//    sqlCon.Close();
//}
//string HeeftSub(string v)
//{
//    if (v == "")
//    {
//        return "";
//    }
//    else return v;
//}

//object HeeftInteresse(string v)
//{
//    if (v == "")
//    {
//        return "";
//    }
//    else return v;
//}