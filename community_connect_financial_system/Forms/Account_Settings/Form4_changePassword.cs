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

namespace community_connect_financial_system.Forms.Account_Settings
{
    public partial class Form4_changePassword : Form
    {
        // Create a new instance of the "Functions" class 
        Functions func = new Functions();
        public Form4_changePassword()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // Show message box with "Yes" or "No" buttons
            DialogResult result = MessageBox.Show("Changes you made may not be saved", "Leave page?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // If the user click "Yes", Redirect to login page
                OpenForm(new Form2_interface());
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (txtPass1.Text == string.Empty || txtPass2.Text == string.Empty)
            {
                // Show error message
                func.ShowErrorMessage("Please Fill out everything");
            }
            else
            {
                if (txtPass1.Text != txtPass2.Text)
                {                                                  
                    // If textboxes don't match, display an error message
                    func.ShowErrorMessage("Password isn't match");

                    // Clear the textboxes
                    txtPass1.Text = string.Empty;
                    txtPass2.Text = string.Empty;

                }
                else
                {
                    // Function to reset the password on the database
                    func.resetPass(txtPass1.Text);

                    // Fetch the updated data of admin account on the database
                    func.getAccountInfo();

                    // Open Form2_interface
                    OpenForm(new Form2_interface());
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // If checked, change the text of checkBox1 to "HIDE"
                checkBox1.Text = "HIDE";

                // Set the PasswordChar property of txtPass1 and txtPass2 to '\0' (showing the password)
                txtPass1.PasswordChar = '\0';
                txtPass2.PasswordChar = '\0';
            }
            else
            {
                // If unchecked, change the text of checkBox1 to "SHOW"
                checkBox1.Text = "SHOW";

                // Set the PasswordChar property of txtPass1 and txtPass2 to '•' (masking the password)
                txtPass1.PasswordChar = '•';
                txtPass2.PasswordChar = '•';
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
