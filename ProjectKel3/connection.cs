using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace ProjectKel3
{
    class connection
    {
        private MySqlConnection conn;
        private string server;
        private string user;
        private string pass;
        private string db;

        public connection()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            db = "klinik_pcr";
            user = "root";
            pass = "";
            string connectionString;
            connectionString = "Data Source=" + server + "; Database=" + db + ";User Id=" + user + ";Password=" + pass + ";SSL mode=0";
            conn = new MySqlConnection(connectionString);

        }

        public bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;

                        case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                       
                }
                return false;
            }
        }

        public void close_conn()
        {
            this.conn.Close();
        }

        public MySqlConnection get_connection()
        {
            return this.conn;
        }

    }
}
