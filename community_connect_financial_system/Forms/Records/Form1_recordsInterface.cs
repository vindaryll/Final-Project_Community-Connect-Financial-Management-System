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
    public partial class Form1_recordsInterface : Form
    {
        public Form1_recordsInterface()
        {
            InitializeComponent();

            // Load the user expenses user control when the form is initialized
            LoadUserControl(new user_expenses());
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            // Open Form4_Homepage
            OpenForm(new Form4_Homepage());
        }

        private void btn_expenses_Click(object sender, EventArgs e)
        {
            // Load the user expenses user control
            LoadUserControl(new user_expenses());
        }

        private void btn_transfer_Click(object sender, EventArgs e)
        {
            // Load the user transfer user control
            LoadUserControl(new user_transfer());
        }

        private void btn_cashin_Click(object sender, EventArgs e)
        {
            // Load the user cash in user control
            LoadUserControl(new user_cashin());
        }

        private void btn_distribution_Click(object sender, EventArgs e)
        {
            // Load the user distribution user control
            LoadUserControl(new user_distribution());
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            // Load the user order user control
            LoadUserControl(new user_order());
        }

        private void LoadUserControl(UserControl userControl)
        {
            // Clear the panel and add the user control, filling the panel and bringing it to the front

            panel1.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(userControl);
            panel1.BringToFront();
        }

        private void OpenForm(Form form)
        {
            // This function Open new form and hide the current form

            form.Show(); // Show new form
            this.Close(); // Close the current form
        }
    }
}
