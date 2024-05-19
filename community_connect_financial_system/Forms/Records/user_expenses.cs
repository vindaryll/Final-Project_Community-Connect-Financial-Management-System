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

namespace community_connect_financial_system.Forms.Records
{
    public partial class user_expenses : UserControl
    {
        // Create an instance of the Functions class
        Functions func = new Functions();

        // Declare variable
        int expenseID;
        

        public user_expenses()
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
            expenseID = 0;

            // Refresh the main DataGridView
            showMainData();

            // Clear the second DataGridView
            func.ClearDataGridView(dataGridView2);

            // Clear Selection
            dataGridView1.ClearSelection();

            // Clear the content of textboxes
            txt_amount.Text = string.Empty;
            txt_name.Text = string.Empty;
        }

        private void showMainData() 
        {
            // Select main data from the database
            string query = $"SELECT a.expenseID, a.expense_date, b.fundname, CONCAT('PHP ', FORMAT(a.expense_amount, 2)) AS expenses_amount FROM expenses_history a JOIN funds b ON b.fundID = a.fundID";
            
            // Populate the DataGridView
            func.Displaydata(dataGridView1, query);

            // Set column headers
            dataGridView1.Columns["expenseID"].HeaderText = "ID";
            dataGridView1.Columns["expense_date"].HeaderText = "DATE";
            dataGridView1.Columns["fundname"].HeaderText = "FUND NAME";
            dataGridView1.Columns["expenses_amount"].HeaderText = "AMOUNT";

        }

        private void viewMore(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // Clear the second DataGridView first
                func.ClearDataGridView(dataGridView2);

                // Get the expenseID from the clicked row
                string stringExpenseID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (int.TryParse(stringExpenseID, out int _expenseID))
                {
                    // Set the expenseID and display additional details in DataGridView2
                    expenseID = _expenseID;
                    string query = $"SELECT reason, CONCAT('PHP ', FORMAT(prev_balance, 2), ' -> PHP ', FORMAT(after_balance, 2)) AS prev_and_after_balance FROM expenses_history WHERE expenseID = {expenseID}";
                    func.Displaydata(dataGridView2,query);

                    // Rename the columns
                    dataGridView2.Columns["reason"].HeaderText = "REASON";
                    dataGridView2.Columns["prev_and_after_balance"].HeaderText = "BALANCE (Before/After)";

                }
                else
                {
                    // Reset expenseID and clear DataGridView2 if parsing fails
                    expenseID = 0;
                    func.ClearDataGridView(dataGridView2);
                }
            }
            catch
            {
                // Reset expenseID and clear DataGridView2 if an exception occurs
                expenseID = 0;
                func.ClearDataGridView(dataGridView2);
            }
        }

        private void search()
        {
            // Base query to select data from the expenses_history table
            string query = "SELECT a.expenseID, a.expense_date, b.fundname, CONCAT('PHP ', FORMAT(a.expense_amount, 2)) AS expenses_amount FROM expenses_history a JOIN funds b ON b.fundID = a.fundID WHERE (1=1)";

            // Add conditions to the query based on txt_name and txt_amount TextBoxes
            if (!string.IsNullOrEmpty(txt_name.Text))
            {
                query += $" AND (LOWER(b.fundname) LIKE LOWER('%{txt_name.Text}%') OR LOWER(b.abbreviation) LIKE LOWER('%{txt_name.Text}%'))";             
            }

            if (!string.IsNullOrEmpty(txt_amount.Text)) {
                query += $" AND expense_amount LIKE '{txt_amount.Text}%'";
            }

            // Display filtered data in DataGridView1
            func.Displaydata(dataGridView1, query);

            // Clear DataGridView2
            func.ClearDataGridView(dataGridView2);

            // Clear selection to remove highlight
            dataGridView1.ClearSelection();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
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
