using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace community_connect_financial_system.Forms
{
    public partial class Form0_Start : Form
    {
        public Form0_Start()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Open Form1_login
            OpenForm(new Form1_login());
        }

        
        private void OpenForm(Form form)
        {
            // This function Open new form and hide the current form

            form.Show(); // Show new form
            this.Hide(); // Hide the current form
        }
    }
}
