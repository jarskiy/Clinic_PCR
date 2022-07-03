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
using MySql.Data.MySqlClient;

namespace ProjectKel3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username, password, sql;
        private connection conn = new connection();
        private MySqlCommand command;
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            username = user.Text;
            password = pass.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username/password is empty!");
            }
            else
            {
                sql = "SELECT username FROM user WHERE username = '" + username + "' AND password = '" + password + "'";
                if(conn.OpenConnection() == true)
                {
                    try
                    {
                        command = new MySqlCommand(sql, conn.get_connection());
                        object a = command.ExecuteScalar();
                        if(a == null)
                        {
                            MessageBox.Show("Invalid username/password");
                        }
                        else
                        {
                            Dashboard dsb = new Dashboard();
                            dsb.Show();
                            this.Close();
                        }
                    }
                    catch (MySqlException x)
                    {
                        MessageBox.Show("" + x);
                    }
                }
            }
            user.Text = "";
            pass.Password = "";
            conn.close_conn();

        }
    }
}
