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

namespace community_connect_financial_system.Forms.Records
{
    public partial class user_transfer : UserControl
    {
        // Create an instance of the Functions class
        Functions func = new Functions();

        // Declare Variable
        int transferID;
        public user_transfer()
        {
            InitializeComponent();

            // Display main data and clear selection in DataGridViews
            showMainData();
            dataGridView1.ClearSelection();

            // Fix Column Header style
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView2.EnableHeadersVisualStyles = false;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            // Reset ID
            transferID = 0;

            // Refresh the main DataGridView
            showMainData();

            // Clear the second DataGridView
            func.ClearDataGridView(dataGridView2);

            // Clear Selection
            dataGridView1.ClearSelection();

            // Clear the content of textboxes
            txt_amount.Text = string.Empty;
            txt_from.Text = string.Empty;
            txt_to.Text = string.Empty;
        }
        private void showMainData()
        {
            // Clear Selection and select main data from the database
            dataGridView1.ClearSelection();
            string query = $"SELECT transferID, transfer_date, (SELECT fundname FROM funds WHERE fundID = from_fundID) AS from_fund, (SELECT fundname FROM funds WHERE fundID = to_fundID) AS to_fund, CONCAT('PHP ', FORMAT(transfer_amount, 2)) AS transfer_amount FROM transfer_history"; 
            func.Displaydata(dataGridView1, query);

            // Rename collumns
            dataGridView1.Columns["transferID"].HeaderText = "ID";
            dataGridView1.Columns["transfer_date"].HeaderText = "DATE";
            dataGridView1.Columns["from_fund"].HeaderText = "FROM";
            dataGridView1.Columns["to_fund"].HeaderText = "TO"; 
            dataGridView1.Columns["transfer_amount"].HeaderText = "AMOUNT";
        }

        private void viewMore(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // Clear the second DataGridView first
                func.ClearDataGridView(dataGridView2);

                // Get the transferID from the clicked row
                string stringTransferID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (int.TryParse(stringTransferID, out int _transferID))
                {
                    // Set the transferID and display additional details in DataGridView2
                    transferID = _transferID;
                    string query = $"SELECT reason, CONCAT('PHP ', FORMAT(from_prev_balance, 2), ' -> PHP ', FORMAT(from_after_balance, 2)) AS prev_and_after_balance_from_fund, CONCAT('PHP ', FORMAT(to_prev_balance, 2), ' -> PHP ', FORMAT(to_after_balance, 2)) AS prev_and_after_balance_to_fund FROM transfer_history WHERE transferID = {transferID}";
                    func.Displaydata(dataGridView2, query);

                    // Rename the columns
                    dataGridView2.Columns["reason"].HeaderText = "REASON";
                    dataGridView2.Columns["prev_and_after_balance_from_fund"].HeaderText = "FROM (Before/After)";
                    dataGridView2.Columns["prev_and_after_balance_to_fund"].HeaderText = "TO\n(Before/After)";         
                }
                else
                {
                    // Reset transferID and clear DataGridView2 if parsing fails
                    transferID = 0;
                    func.ClearDataGridView(dataGridView2);
                }
            }
            catch
            {
                // Reset transferID and clear DataGridView2 if parsing fails
                transferID = 0;
                func.ClearDataGridView(dataGridView2);
            }
        }

        private void search()
        {
            // Base query to select data from the transfer_history table
            string query = "SELECT b.transferID, b.transfer_date, (SELECT fundname FROM funds WHERE fundID = b.from_fundID) AS from_fund, (SELECT fundname FROM funds WHERE fundID = b.to_fundID) AS to_fund, CONCAT('PHP ', FORMAT(b.transfer_amount, 2)) AS transfer_amount FROM transfer_history b WHERE (1=1)";

            // Add conditions to the query based on txt_from, txt_to, and txt_amount TextBoxes
            if (!string.IsNullOrEmpty(txt_from.Text))
            {
                query += $" AND (LOWER((SELECT fundname FROM funds WHERE fundID = b.from_fundID)) LIKE LOWER('%{txt_from.Text}%') OR LOWER((SELECT abbreviation FROM funds WHERE fundID = b.from_fundID)) LIKE LOWER('%{txt_from.Text}%'))";
            }

            if (!string.IsNullOrEmpty(txt_to.Text))
            {
                query += $" AND (LOWER((SELECT fundname FROM funds WHERE fundID = b.to_fundID)) LIKE LOWER('%{txt_to.Text}%') OR LOWER((SELECT abbreviation FROM funds WHERE fundID = b.to_fundID)) LIKE LOWER('%{txt_to.Text}%'))";
            }

            if (!string.IsNullOrEmpty(txt_amount.Text))
            {
                query += $" AND transfer_amount LIKE '{txt_amount.Text}%'";
            }

            // Display filtered data in DataGridView1
            func.Displaydata(dataGridView1, query);

            // Clear DataGridView2
            func.ClearDataGridView(dataGridView2);

            // Clear selection to remove highlight
            dataGridView1.ClearSelection();
        }

        private void txt_from_TextChanged(object sender, EventArgs e)
        {
            // Call the search function
            search();
        }

        private void txt_to_TextChanged(object sender, EventArgs e)
        {
            // Call the search function
            search();
        }

        private void txt_amount_TextChanged(object sender, EventArgs e)
        {
            // Call the search function
            search();
        }
    }
}
