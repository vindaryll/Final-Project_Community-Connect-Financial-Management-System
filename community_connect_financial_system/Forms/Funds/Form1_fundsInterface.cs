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
using Guna.UI2.WinForms;

namespace community_connect_financial_system.Forms.Funds
{
    public partial class Form1_fundsInterface : Form
    {
        // Create a new instance of the "Functions" class 
        Functions func = new Functions();
        public Form1_fundsInterface()
        {
            InitializeComponent();

            // Fetch the information of funds on the database
            func.getFundInfo();

            // Function to change the names of buttons
            getbtnName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set the index to 1
            Pv.fundIndex = 1;

            // Proceed to "Allocated" interface
            OpenForm(new Form2_AllocatedFundInfo());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Set the index to 2
            Pv.fundIndex = 2;

            // Proceed to "Allocated" interface
            OpenForm(new Form2_AllocatedFundInfo());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pv.fundIndex = 3;

            // Proceed to "Allocated" interface
            OpenForm(new Form2_AllocatedFundInfo());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pv.fundIndex = 4;

            // Proceed to "Allocated" interface
            OpenForm(new Form2_AllocatedFundInfo());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pv.fundIndex = 5;

            // Proceed to "Allocated" interface
            OpenForm(new Form2_AllocatedFundInfo());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Pv.fundIndex = 6;

            // Proceed to "Allocated" interface
            OpenForm(new Form2_AllocatedFundInfo());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pv.fundIndex = 7;

            // Proceed to "Allocated" interface
            OpenForm(new Form2_AllocatedFundInfo());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pv.fundIndex = 8;

            // Proceed to "Allocated" interface
            OpenForm(new Form2_AllocatedFundInfo());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Pv.fundIndex = 9;

            // Proceed to "Allocated" interface
            OpenForm(new Form5_UnallocatedFundInfo());
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            // Redirect to Homepage
            OpenForm(new Form4_Homepage());
        }

        private void getbtnName()
        {
            // Loop through numbers 0 to 8 (total number of fund buttons)
            for (int i = 0; i < 9; i++)
            {
                // Find the button control by name
                var btn = this.Controls.Find($"button{i + 1}", true).FirstOrDefault() as Guna2Button;

                // Check if the button exists and if there is a corresponding fund name in the array
                if (btn != null && i < Pv.fundName.Length)
                {
                    // Set the text of the button to the corresponding fund name
                    btn.Text = Pv.fundName[i];
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
