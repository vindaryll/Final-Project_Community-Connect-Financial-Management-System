using community_connect_finance_system.Classes;
using community_connect_financial_system.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pv = community_connect_finance_system.Classes.PublicVariables; // An alias for "PublicVariables" class

namespace community_connect_financial_system
{
    public partial class Form1_login : Form
    {
        // Create a new instance of the "Functions" class 
        Functions func = new Functions();
        public Form1_login()
        {
            InitializeComponent();

            // Fetch the data of admin account on the database
            func.getAccountInfo();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            // Show message box with "Yes" or "No" buttons
            DialogResult result = MessageBox.Show("Do you want to close the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // If the user click "Yes", the application will be closed
                Application.Exit();
            }           
        }

        private void link_forgotpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open Form2_forgotpass
            OpenForm(new Form2_forgotpass());
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txtEmailOrUsername.Text == string.Empty || txtPass.Text == string.Empty)
            {
                // Show error message
                func.ShowErrorMessage("Please fill out everything");
            }
            else
            {
                // Function to check if the username/email and password matches the database
                func.login(txtEmailOrUsername.Text, txtPass.Text);

                if (Pv.log)
                {
                    // Show successful message
                    func.ShowSuccessfulMessage("Login successful");

                    // Open Form4_Homepage
                    OpenForm(new Form4_Homepage());
                }
                else
                {
                    // Show error message
                    func.ShowErrorMessage("Login Failed - Username or password did not match");

                    // Clear the textboxes
                    txtEmailOrUsername.Text = string.Empty;
                    txtPass.Text = string.Empty;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Check if checkBox1 is checked
            if (checkBox1.Checked)
            {
                // If checked, change the text of checkBox1 to "HIDE"
                checkBox1.Text = "HIDE";

                // Set the PasswordChar property of txtPass to '\0' (showing the password)
                txtPass.PasswordChar = '\0';
            }
            else
            {
                // If unchecked, change the text of checkBox1 to "SHOW"
                checkBox1.Text = "SHOW";

                // Set the PasswordChar property of txtPass to '•' (masking the password)
                txtPass.PasswordChar = '•';
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
