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
using Domain.Contracts;
using Infrastructure;

namespace FitnessGui
{
    /// <summary>
    /// Interaction logic for dashboardAdmin.xaml
    /// </summary>
    public partial class dashboardAdmin : Window
    {
        //private DomeinController _dc;

        SqlConnection sqlCon = new(@"Data Source=.\SQLEXPRESS;Initial Catalog=FitnessServer;Integrated Security=True;Pooling=False");
        DomeinController _dc = new DomeinController();

        public dashboardAdmin()
        {
            InitializeComponent();
            FillDataGrid();
        }


        private void btnOnderhoud_Click(object sender, RoutedEventArgs e)
        {

            if (txtType.Text is null)
            {
                MessageBox.Show("Er werd geen type ingegeven", "Opmerking",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                _dc.WijzigDevice(txtNummer.Text, txtType.Text);
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                FillDataGrid();
                sqlCon.Close();

                MessageBox.Show("Toestel is in onderhoud geplaatst");
            }
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (txtType.Text is null)
            {
                MessageBox.Show("Er werd geen type ingegeven", "Opmerking",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                _dc.RegistreerDevice(txtNummer.Text, txtType.Text);
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                FillDataGrid();
                sqlCon.Close();

                MessageBox.Show("Toestel is toegevoegd");
            }
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (txtType.Text is null)
            {
                MessageBox.Show("Er werd geen type ingegeven", "Opmerking",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                _dc.VerwijderDevice(txtNummer.Text, txtType.Text);
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                FillDataGrid();
                sqlCon.Close();

            }
        }

        private void FillDataGrid()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            string query = "SELECT M_Id, M_Type, Huidig FROM Machines";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Machines");
                adapter.Fill(dt);
                dgSimple.ItemsSource = dt.DefaultView;
             
            
            sqlCon.Close();
        }
    }
}