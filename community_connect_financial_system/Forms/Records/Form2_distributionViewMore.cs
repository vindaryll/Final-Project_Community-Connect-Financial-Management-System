using community_connect_finance_system.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pv = community_connect_finance_system.Classes.PublicVariables;
namespace community_connect_financial_system.Forms.Records
{
    public partial class Form2_distributionViewMore : Form
    {
        // Create an instance of the Functions class
        Functions func = new Functions();
        public Form2_distributionViewMore()
        {
            InitializeComponent();

            // Display distribution data on DataGridView
            showData();

            // Fix column style
            dataGridView1.EnableHeadersVisualStyles = false;
        }
        
        private void showData()
        {
            // Select distribution details per fund
            string query = $"SELECT c.fundname, CONCAT('PHP ', FORMAT(a.distributed_amount, 2)) AS distributed_amount, CONCAT('PHP ', FORMAT(a.prev_balance, 2)) AS prev_balance, CONCAT('PHP ', FORMAT(a.after_balance, 2)) AS after_balance FROM amount_distribution_history a JOIN distribution_history b ON b.distributionID = a.distributionID JOIN funds c ON c.fundID = a.fundID WHERE b.distributionID = {Pv.distributionID};";
            
            // function to populate DataGridView
            func.Displaydata(dataGridView1, query);

            // Rename column headers
            dataGridView1.Columns["fundname"].HeaderText = "ALLOCATED FUNDS";
            dataGridView1.Columns["distributed_amount"].HeaderText = "AMOUNT";
            dataGridView1.Columns["prev_balance"].HeaderText = "BALANCE (before)";
            dataGridView1.Columns["after_balance"].HeaderText = "BALANCE (after)";
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            // Close this form
            this.Close();
        }
    }
}
