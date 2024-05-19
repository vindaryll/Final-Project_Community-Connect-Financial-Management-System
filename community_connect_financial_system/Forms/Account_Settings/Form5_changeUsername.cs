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

namespace community_connect_financial_system.Forms.Account_Settings
{
    public partial class Form5_changeUsername : Form
    {
        // Create a new instance of the "Functions" class 
        Functions func = new Functions();
        public Form5_changeUsername()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_username.Text))
            {
                // Show error message
                func.ShowErrorMessage("This can't be empty");
                return; // Abort the process
            }

            if(Pv.username == txt_username.Text)
            {
                // Show error message
                func.ShowErrorMessage("The username is still the same. Please provide a different input");
                return; // Abort the process
            }

            // Function to change the username
            func.changeUsername(txt_username.Text);

            // Fetch the updated data of admin account on the database
            func.getAccountInfo();

            // Open Form2_interface
            OpenForm(new Form2_interface());
        }


        private void btn_back_Click(object sender, EventArgs e)
        {
            // Show message box with "Yes" or "No" buttons
            DialogResult result = MessageBox.Show("Changes you made may not be saved", "Leave page?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // If the user click "Yes", Open Form2_interface
                OpenForm(new Form2_interface());
            }
        }

        private void OpenForm(Form form)
        {
            // This function Open new form and hide the current form

            form.Show(); // Show new form
            this.Close(); // Close the current form
        }
    }
}
