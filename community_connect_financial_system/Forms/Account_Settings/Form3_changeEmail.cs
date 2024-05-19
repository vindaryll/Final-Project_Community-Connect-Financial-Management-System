using community_connect_finance_system.Classes;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pv = community_connect_finance_system.Classes.PublicVariables;
namespace community_connect_financial_system.Forms.Account_Settings
{
    public partial class Form3_changeEmail : Form
    {
        // Create a new instance of the "Functions" class 
        Functions func = new Functions();

        public Form3_changeEmail()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            // Show message box with "Yes" or "No" buttons
            DialogResult result = MessageBox.Show("Changes you made may not be saved", "Leave page?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // If the user click "Yes"
                // It will reset the randomCode 
                Pv.randomCode = "";

                // Open Form2_interface
                OpenForm(new Form2_interface());
            }
        }

        private async void btn_sendcode_Click(object sender, EventArgs e)
        {
            if (txt_email.Text == string.Empty)
            {
                // Show error message
                func.ShowErrorMessage("Email can't be empty");
            }
            else if (txt_email.Text == Pv.email)
            {
                // Show error message
                func.ShowErrorMessage("You have entered the current email, please enter a different one");
            }
            else
            {
                // Function to send otp code on the email
                func.changeEmailOTP(txt_email.Text);

                if (Pv.otpsent)
                {
                    // Reset the otpsent variable
                    Pv.otpsent = false;

                    // To avoid spam clicking of the button, we set delay for 60 seconds
                    btn_sendcode.Enabled = false;
                    for (int i = 60; i >= 0; i--)
                    {
                        btn_sendcode.Text = $"Resend in {i}s";
                        await Task.Delay(1000); // Delay for 1 second
                    }

                    // Re-enable the button
                    btn_sendcode.Text = "Send Code";
                    btn_sendcode.Enabled = true;
                }
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (txt_verification.Text == string.Empty)
            {
                // Show error message
                func.ShowErrorMessage("Verification code can't be empty");
            }
            else if (txt_verification.Text != Pv.randomCode)
            {
                // Show error message
                func.ShowErrorMessage("Wrong code, please try again");

                // clear the textbox
                txt_verification.Text = string.Empty;
            }
            else
            {
                if (txt_verification.Text == Pv.randomCode.ToString())
                {
                    // Function to change the email on the database
                    func.changeEmail(txt_email.Text);

                    // Fetch the updated data of admin account on the database
                    func.getAccountInfo();

                    // Reset the randomCode
                    Pv.randomCode = "";

                    // Open Form2_interface
                    OpenForm(new Form2_interface());
                }
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
