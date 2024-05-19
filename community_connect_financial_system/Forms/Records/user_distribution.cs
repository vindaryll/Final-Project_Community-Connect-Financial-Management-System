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
using System.Windows.Media.TextFormatting;
using Pv = community_connect_finance_system.Classes.PublicVariables;

namespace community_connect_financial_system.Forms.Records
{
    public partial class user_distribution : UserControl
    {
        // Create an instance of the Functions class
        Functions func = new Functions();
        public user_distribution()
        {
            InitializeComponent();

            // Display data in the DataGridView
            showData();

            // Fix column style
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void showData() 
        {
            // Select data from the distribution_history table
            string query = $"SELECT distributionID, distribution_date, CONCAT('PHP ', FORMAT(distributed_amount, 2)) AS amount, CONCAT('PHP ', FORMAT(prev_balance, 2)) AS prev_balance, CONCAT('PHP ', FORMAT(after_balance, 2)) AS after_balance FROM distribution_history";

            // Function to populate the DataGridView
            func.Displaydata(dataGridView1, query);

            // Set column headers
            dataGridView1.Columns["distributionID"].HeaderText = "ID";
            dataGridView1.Columns["distribution_date"].HeaderText = "DATE";
            dataGridView1.Columns["amount"].HeaderText = "AMOUNT";
            dataGridView1.Columns["prev_balance"].HeaderText = "UNALLOCATED BALANCE (before)";
            dataGridView1.Columns["after_balance"].HeaderText = "UNALLOCATED BALANCE (after)";

            // Clear selection in the DataGridView
            dataGridView1.ClearSelection();
        }

        private void search()
        {
            string query;
            if (!string.IsNullOrEmpty(txt_amount.Text))
            {
                // Select data based on the distributed_amount column
                query = $"SELECT distributionID, distribution_date, CONCAT('PHP ', FORMAT(distributed_amount, 2)) AS amount, CONCAT('PHP ', FORMAT(prev_balance, 2)) AS prev_balance, CONCAT('PHP ', FORMAT(after_balance, 2)) AS after_balance FROM distribution_history WHERE distributed_amount LIKE '{txt_amount.Text}%';";

                // Function to populate the DataGridView based on the conditions
                func.Displaydata(dataGridView1, query);
            }
            else
            {
                // If txt_amount is empty, show all data
                showData();
            }

            // Clear selection in the DataGridView
            dataGridView1.ClearSelection();
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

            // Clear text in txt_amount and reset distributionID
            txt_amount.Text = string.Empty;
            Pv.distributionID = 0;
        }

        private void viewMore(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // Get the value of distributionID from the clicked row
                string stringDistributionID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (int.TryParse(stringDistributionID, out int distributionID))
                {
                    // Set distributionID in PublicVariables and open the view more form
                    Pv.distributionID = distributionID;
                    Form2_distributionViewMore form = new Form2_distributionViewMore();
                    form.ShowDialog();
                }
                else
                {
                    // Reset distributionID if parsing fails
                    Pv.distributionID = 0;
                }
            }
            catch
            {
                // Reset distributionID if an exception occurs
                Pv.distributionID = 0;
            }
        }
    }
}
