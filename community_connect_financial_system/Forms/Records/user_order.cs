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
    public partial class user_order : UserControl
    {
        // Create an instance of the Functions class
        Functions func = new Functions();
        public user_order()
        {
            InitializeComponent();

            // Display data on DataGridView
            showData();

            // Fix column style
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void showData()
        {
            // Query to select order data from the transactions_order table
            string query = $"SELECT orderID, executed_timestamp, transaction_type FROM transactions_order ORDER BY orderID DESC";
            
            // Function that populates DataGridView
            func.Displaydata(dataGridView1, query);

            // Clear Selection to remove highlight
            dataGridView1.ClearSelection();

            // Set column headers
            dataGridView1.Columns["orderID"].HeaderText = "TRANSACTION ID";
            dataGridView1.Columns["executed_timestamp"].HeaderText = "EXECUTED TIMESTAMP";
            dataGridView1.Columns["transaction_type"].HeaderText = "TRANSACTION TYPE";
        }

        private void viewMore(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // Get the orderID and transaction_type from the clicked row
                string stringOrderID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string _transaction_type = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (int.TryParse(stringOrderID, out int orderID) && !string.IsNullOrEmpty(_transaction_type))
                {
                    // Set the orderID and transactionType variables and open Form3_orderViewMore
                    Pv.orderID = orderID;
                    Pv.transactionType = _transaction_type;                 
                    
                    Form3_orderViewMore form = new Form3_orderViewMore();
                    form.ShowDialog();
                }
                else
                {
                    // Reset variables if parsing fails
                    Pv.distributionID = 0;
                    Pv.transactionType = "";
                }
            }
            catch
            {
                // Reset variable if an exception occurs
                Pv.distributionID = 0;
            }
        }

        private void btn_undotransac_Click(object sender, EventArgs e)
        {
            // Get the latest transaction message
            string message = func.getLatestTransaction();

            // Show message box with the latest transaction details
            if (message.StartsWith("An error occured"))
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Ask for confirmation to undo the transaction
                DialogResult result = MessageBox.Show(message, "Undo Transaction", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    // Undo the transaction and refresh the data
                    func.undoTransaction();
                    showData();
                }
            }
        }
    }
}
