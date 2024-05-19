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
    public partial class Form2_interface : Form
    {
        public Form2_interface()
        {
            InitializeComponent();
        }

        private void btn_email_Click(object sender, EventArgs e)
        {
            // Open Form3_changeEmail
            OpenForm(new Form3_changeEmail());
        }

        private void btn_password_Click(object sender, EventArgs e)
        {
            // Open Form4_changePassword
            OpenForm(new Form4_changePassword());
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            // Open Form4_Homepage
            OpenForm(new Form4_Homepage());
        }

        private void btn_username_Click(object sender, EventArgs e)
        {
            // Open Form5_changeUsername
            OpenForm(new Form5_changeUsername());
        }

        private void OpenForm(Form form)
        {
            // This function Open new form and hide the current form

            form.Show(); // Show new form
            this.Close(); // Close the current form
        }
    }
}
