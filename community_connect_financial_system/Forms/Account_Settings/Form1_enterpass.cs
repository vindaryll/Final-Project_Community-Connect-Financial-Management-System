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
    public partial class Form1_enterpass : Form
    {
        // Create a new instance of the "Functions" class 
        Functions func = new Functions();

        public Form1_enterpass()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            // Open Form4_Homepage
            OpenForm(new Form4_Homepage());
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            // Fetch the data of admin account on the database
            func.getAccountInfo();

            if (txt_pass.Text == string.Empty)
            {
                // Show error message
                func.ShowErrorMessage("This can't be blank, please enter the password");
            }
            else if (txt_pass.Text != Pv.password)
            {
                // Show error message
                func.ShowErrorMessage("The password is incorrect");

                // Clear the textbox
                txt_pass.Text = string.Empty;
            }
            else
            {
                // Show successful message
                func.ShowSuccessfulMessage("Account verified");

                // Open Form2_interface
                OpenForm(new Form2_interface());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // If checked, change the text of checkBox1 to "HIDE"
                checkBox1.Text = "HIDE";

                // Set the PasswordChar property of txtPass1 and txtPass2 to '\0' (showing the password)
                txt_pass.PasswordChar = '\0';
            }
            else
            {
                // If unchecked, change the text of checkBox1 to "SHOW"
                checkBox1.Text = "SHOW";

                // Set the PasswordChar property of txtPass1 and txtPass2 to '•' (masking the password)
                txt_pass.PasswordChar = '•';
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