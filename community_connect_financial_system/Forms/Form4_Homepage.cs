using community_connect_finance_system.Classes;
using community_connect_financial_system.Forms.Account_Settings;
using community_connect_financial_system.Forms.Funds;
using community_connect_financial_system.Forms.Records;
using community_connect_financial_system.Misc_Forms;
using System;
using System.Windows.Forms;
using Pv = community_connect_finance_system.Classes.PublicVariables;

namespace community_connect_financial_system.Forms
{
    public partial class Form4_Homepage : Form
    {
        // Create a new instance of the "Functions" class 
        Functions func = new Functions();
        public Form4_Homepage()
        {
            InitializeComponent();

            // Fetch the total balance of all allocated funds
            func.getTotalAllocatedFunds();

            //Display all the details
            show();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            // Show message box with "Yes" or "No" buttons
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Redirect to login page
                OpenForm(new Form1_login());

                // Reset the log variable
                Pv.log = false;
            }
        }

        private void btn_accountSettings_Click(object sender, EventArgs e)
        {
            // Open Form1_enterpass
            OpenForm(new Form1_enterpass());
        }

        private void show()
        {
            // Display the total balance on the label
            lbl_total.Text = $"PHP {Pv.totalAllocated.ToString("N2")}";

            // Display the userControl for chart
            UserControl1_Piechart userform = new UserControl1_Piechart();
            panel_graph.Controls.Clear();
            userform.Dock = DockStyle.Fill;
            panel_graph.Controls.Add(userform);
            userform.BringToFront();
        }

        private void btn_funds_Click(object sender, EventArgs e)
        {
            // Open Form1_fundsInterface
            OpenForm(new Form1_fundsInterface());
        }

        private void btn_records_Click(object sender, EventArgs e)
        {
            // Open Form1_recordsInterface()
            OpenForm(new Form1_recordsInterface());
        }

        private void btn_tutorial_Click(object sender, EventArgs e)
        {
            // Open form tutorial_vid()
            OpenForm(new tutorial_vid());
        }

        private void OpenForm(Form form)
        {
            // This function Open new form and hide the current form

            form.Show(); // Show new form
            this.Close(); // Close the current form
        }
    }
}