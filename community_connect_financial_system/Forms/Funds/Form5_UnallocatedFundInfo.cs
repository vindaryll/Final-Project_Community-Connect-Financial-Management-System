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
namespace community_connect_financial_system.Forms.Funds
{
    public partial class Form5_UnallocatedFundInfo : Form
    {
        
        public Form5_UnallocatedFundInfo()
        {
            InitializeComponent();
            showdata();
        }
        private void showdata()
        {
            // Display the selected fund name in uppercase
            lbl_fundName.Text = Pv.fundName[Pv.fundIndex - 1].ToUpper();

            // Display the balance of the selected fund formatted as currency
            lbl_amount.Text = $"PHP {Pv.fundbalance[Pv.fundIndex - 1].ToString("N2")}";
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            // Open Form1_fundsInterface
            OpenForm(new Form1_fundsInterface());
        }

        private void btn_addbalance_Click(object sender, EventArgs e)
        {
            // Open Form6_cashin
            OpenForm(new Form6_cashin());
        }

        private void btn_distribute_Click(object sender, EventArgs e)
        {
            // Open Form7_distribute
            OpenForm(new Form7_distribute());
        }

        private void OpenForm(Form form)
        {
            // This function Open new form and hide the current form

            form.Show(); // Show new form
            this.Close(); // Close the current form
        }
    }
}
