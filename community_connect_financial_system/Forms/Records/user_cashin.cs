using community_connect_finance_system.Classes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace community_connect_financial_system.Forms.Records
{
    public partial class user_cashin : UserControl
    {
        // Create an instance of the Functions class
        Functions func = new Functions();
        public user_cashin()
        {
            InitializeComponent();

            // Display data in the DataGridView
            showData();

            // Fix column style
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void showData()
        {
            // Select data from the cashin_history table
            string query = $"SELECT cashinID, cashin_date, CONCAT('PHP ', FORMAT(cashin_amount, 2)) AS cashin_amount, source FROM cashin_history";

            // Function to populate the DataGridView
            func.Displaydata(dataGridView1, query);

            // Set column headers
            dataGridView1.Columns["cashinID"].HeaderText = "ID";
            dataGridView1.Columns["cashin_date"].HeaderText = "DATE";
            dataGridView1.Columns["cashin_amount"].HeaderText = "AMOUNT";
            dataGridView1.Columns["source"].HeaderText = "SOURCE";
        }

        private void txt_source_TextChanged(object sender, EventArgs e)
        {
            // Call the search function
            search();
        }
        private void txt_amount_TextChanged(object sender, EventArgs e)
        {
            // Call the search function
            search();
        }


        private void btn_refresh_Click(object sender, EventArgs e)
        {
            // Refresh the data in the DataGridView
            showData();

            // Clear the content of textboxes
            txt_amount.Text = string.Empty;
            txt_source.Text = string.Empty;
        }


        private void search()
        {
            // Base query to select data from the cashin_history table
            string query = "SELECT cashinID, cashin_date, CONCAT('PHP ', FORMAT(cashin_amount, 2)) AS cashin_amount, source FROM cashin_history WHERE 1=1";

            // Add conditions to the query based on txt_source and txt_amount TextBoxes

            if (!string.IsNullOrEmpty(txt_source.Text))
            {
                query += $" AND LOWER(source) LIKE LOWER('%{txt_source.Text}%')";
            }

            if (!string.IsNullOrEmpty(txt_amount.Text))
            {
                query += $" AND cashin_amount LIKE '{txt_amount.Text}%'";
            }

            // Function to populate the DataGridView based on conditions
            func.Displaydata(dataGridView1, query);
        }


    }
}
