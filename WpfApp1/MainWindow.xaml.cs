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
using System.Configuration;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection Cnx = new SqlConnection();
        SqlDataReader Dr;
        SqlCommand cmd = new SqlCommand();
        public MainWindow()
        {
            InitializeComponent();
            Cnx.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
        private bool CheckerUser(string Username, string Password)
        {
            Cnx.Open();
            cmd = Cnx.CreateCommand();
            cmd.CommandText="select USER_Client,PASSW_Client from Client";
            Dr = cmd.ExecuteReader();
            
            if (Dr.Read())
            {
                if(Username == Dr[0].ToString() && Password == Dr[1].ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(Cnx.State == System.Data.ConnectionState.Open)
            {
                Cnx.Close();
            }

            if (CheckerUser(txtUsername.Text, txtPassword.Password))
            {
                MessageBox.Show("Bienvenue");
            }
            else
            {
                MessageBox.Show("Information incorrect");
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
