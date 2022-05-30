using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using CUI;
using Domain;

namespace FitnessGui
{
    /// <summary>
    /// Interaction logic for dashboardGebruiker.xaml
    /// </summary>
    public partial class dashboardGebruiker : Window
    {
        SqlConnection sqlCon = new(@"Data Source=.\SQLEXPRESS;Initial Catalog=FitnessServer;Integrated Security=True;Pooling=False");


        public dashboardGebruiker(string username)
        {
            InitializeComponent();
            LoadComboBoxes();
            EmailKlant.Content = username;

            username = CutLogin(username);
            LoginName.Content = username;
            dpDag.DisplayDateStart = DateTime.Now;
            dpDag.DisplayDateEnd = DateTime.Now.AddDays(7);

        }

        private void LoadComboBoxes()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            string query = "SELECT M_Id,M_Type FROM Machines WHERE Huidig <> 'Onderhoud' AND Huidig <> 'Gereserveerd'";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbType.Items.Add(dr["M_Type"] + " - " + dr["M_Id"].ToString());
            }

            dr.Close();

            string queryy = "SELECT T_Uur FROM Tijdsloten";
            SqlCommand cmdd = new SqlCommand(queryy, sqlCon);
            SqlDataAdapter adapterr = new SqlDataAdapter(cmdd);

            SqlDataReader drr = cmdd.ExecuteReader();
            while (drr.Read())
            {
                Lsb_TimeSlot.Items.Add(drr["T_Uur"].ToString());
            }

            sqlCon.Close();
        }
       
        private void btnAfspraak_Click(object sender, RoutedEventArgs e)
        {
            string listbox = Lsb_TimeSlot.SelectedItem.ToString();
            List<int> tijdsloten = new List<int>();

            if (Lsb_TimeSlot.SelectedItems.Count > 0 && Lsb_TimeSlot.SelectedItems.Count < 5)
            {
                foreach (var item in Lsb_TimeSlot.SelectedItems)
                {
                    string x = item.ToString().Replace("u", "");
                    int z = int.Parse(x);
                    tijdsloten.Add(z);
                }

                if (Lsb_TimeSlot.SelectedItems.Count >= 1 && Lsb_TimeSlot.SelectedItems.Count < 3)
                {
                    Reservation.MakeReservation(EmailKlant.Content, LoginName.Content, dpDag.Text, cmbType.Text, tijdsloten);
                    NogEenAfspraakMaken();
                }
                else
                {
                    if (tijdsloten[0] + 2 == tijdsloten[2])
                    {
                        MessageBox.Show("Te veel selecties na elkaar");
                    }
                    else
                    {
                        Reservation.MakeReservation(EmailKlant.Content, LoginName.Content, dpDag.Text, cmbType.Text, tijdsloten);
                        NogEenAfspraakMaken();
                    }
                }
            }
            else
            {
                MessageBox.Show("meer als 4 totale selecties");
            }

        }

        private string CutLogin(string username)
        {
            return username = username.Replace(".", " ").Substring(0, username.IndexOf("@"));
        }

        private void NogEenAfspraakMaken()
        {
            MessageBoxResult result;
            result = MessageBox.Show("Nog een afspraak maken?", "Question",
               MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                this.Close();
            }
            else
            {
                Lsb_TimeSlot.UnselectAll();
                cmbType.Items.Clear();
                LoadComboBoxes();
            }
        }
    }
}
