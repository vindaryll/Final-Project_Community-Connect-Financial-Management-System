using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pv = community_connect_finance_system.Classes.PublicVariables;

namespace community_connect_finance_system.Classes
{
    class Dbconnect
    {
        // Set connection with the connection string
        private MySqlConnection con = new MySqlConnection($"server=127.0.0.1; user=root; database={Pv.dbname}; password=");

        public MySqlConnection Getcon()
        {
            // Retrieve the current MySQL connection instance
            return con;
        }
        public void OpenCon()
        {
            // Check if the connection is closed
            if (con.State == ConnectionState.Closed)
            {
                con.Open(); // Open the connection
            }
        }
        public void CloseCon()
        {
            // Check if the connection is open
            if (con.State == ConnectionState.Open)
            {
                con.Close(); // Close the connection
            }
        }
    }
}
