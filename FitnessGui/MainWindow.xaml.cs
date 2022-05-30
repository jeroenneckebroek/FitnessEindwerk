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
using Domain;
using Domain.Contracts;
using Infrastructure;

namespace FitnessGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
        
        SqlConnection sqlCon = new(@"Data Source=.\SQLEXPRESS;Initial Catalog=FitnessServer;Integrated Security=True;Pooling=False");

        //IDeviceRepository deviceRepo = new DeviceRepository();
        private DomeinController _dc;

        public MainWindow()
        {
            WPFUI.Appearance.Background.Apply(
                 this,                                // Window class
                 WPFUI.Appearance.BackgroundType.Auto // Background type
            );
            InitializeComponent();
            
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                string query = "SELECT COUNT(1) FROM LoginKlant WHERE L_Username=@L_Username AND L_Passwoord=@L_Passwoord";

                SqlCommand sqlCmd = new(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;

                sqlCmd.Parameters.AddWithValue("@L_Username", txtGebruiker.Text);
                string username = txtGebruiker.Text;
                sqlCmd.Parameters.AddWithValue("@L_Passwoord", txtWachtwoord.Password);
                

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                if (count == 1)
                {
                    dashboardGebruiker dashboardGebruiker = new(username);
                    
                    dashboardGebruiker.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Dit zijn geen geldige gegevens");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                string query = "SELECT COUNT(1) FROM Admin WHERE Admin=@Admin AND Wachtwoord=@Wachtwoord";

                SqlCommand sqlCmd = new(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;

                sqlCmd.Parameters.AddWithValue("@Admin", txtGebruiker.Text);
                sqlCmd.Parameters.AddWithValue("@Wachtwoord", txtWachtwoord.Password);

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

                if (count == 1)
                {
                    dashboardAdmin dashboardAdmin = new();
                    dashboardAdmin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Dit zijn geen geldige Admin gegevens");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
