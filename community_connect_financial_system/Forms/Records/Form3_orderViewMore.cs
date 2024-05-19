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
namespace community_connect_financial_system.Forms.Records
{
    public partial class Form3_orderViewMore : Form
    {
        // Create an instance of the Functions class
        Functions func = new Functions();
        public Form3_orderViewMore()
        {
            InitializeComponent();

            // Fetch order transaction details based on order ID and transaction type
            func.fetchOrderTransaction(Pv.orderID, Pv.transactionType);

            // Configure labels based on transaction type
            labelsConfig();
        }

        private void labelsConfig()
        {
            // Set labels based on transaction type and assign corresponding values
            lbl_output1.Text = Pv.transactionType;
            lbl_output2.Text = Pv.executed_timestamp;
            switch (Pv.transactionType)
            {
                case "cashin":
                    // Configure labels for cashin transaction
                    label3.Text = "Cash in date ";
                    lbl_output3.Text = Pv.cashin_date;

                    label4.Text = "Cash in amount ";
                    lbl_output4.Text = "PHP " + Pv.cashin_amount;

                    label5.Text = "Source ";
                    lbl_output5.Text = Pv.cashin_source;

                    // Hide unnecessary labels
                    label6.Visible = false;
                    lbl_output6.Visible = false;
                    label7.Visible = false;
                    lbl_output7.Visible = false;

                    break;

                case "distribution":
                    // Configure labels for distribution transaction
                    label3.Text = "Distribution date ";
                    lbl_output3.Text = Pv.distribution_date;

                    label4.Text = "Distributed amount ";
                    lbl_output4.Text = "PHP " + Pv.distributed_amount;

                    // Hide unnecessary labels
                    label5.Visible = false;
                    lbl_output5.Visible = false;
                    label6.Visible = false;
                    lbl_output6.Visible = false;
                    label7.Visible = false;
                    lbl_output7.Visible = false;

                    break;

                case "expenses":
                    // Configure labels for expenses transaction
                    label3.Text = "Expenditure date ";
                    lbl_output3.Text = Pv.expense_date;

                    label4.Text = "Fund name ";
                    lbl_output4.Text = Pv.expense_fundName;

                    label5.Text = "Expenditure amount ";
                    lbl_output5.Text = "PHP " + Pv.expense_amount;

                    label6.Text = "Reason ";
                    lbl_output6.Text = Pv.expense_reason;

                    // Adjust label size and alignment for reason
                    lbl_output6.Size = new Size(540, 203);
                    lbl_output6.TextAlign = HorizontalAlignment.Left;
                    lbl_output6.Multiline = true;

                    // Hide unnecessary labels
                    label7.Visible = false;
                    lbl_output7.Visible = false;

                    break;

                case "transfer":
                    // Configure labels for transfer transaction
                    label3.Text = "Transfer date ";
                    lbl_output3.Text = Pv.transfer_date;

                    label4.Text = "From ";
                    lbl_output4.Text = Pv.from_fundName;

                    label5.Text = "To ";
                    lbl_output5.Text = Pv.to_fundName;

                    label6.Text = "Transferred amount ";
                    lbl_output6.Text = "PHP " + Pv.transfer_amount;
              
                    label7.Text = "Reason ";
                    lbl_output7.Text = Pv.transfer_reason;

                    // Adjust label size and alignment for reason
                    lbl_output7.Size = new Size(540, 203);
                    lbl_output7.TextAlign = HorizontalAlignment.Left;
                    lbl_output7.Multiline = true;

                    break;

            }
        }

        private void resetValues()
        {
            // Reset values in PublicVariables class
            Pv.orderID = 0;
            Pv.transactionType = "";
            Pv.executed_timestamp = "";

            // Reset transaction-specific values
            // cashin
                Pv.cashin_date = "";
                Pv.cashin_amount = "";
                Pv.cashin_source = "";
            // distribution
                Pv.distribution_date = "";
                Pv.distributed_amount = "";
            // expenses
                Pv.expense_fundName = "";
                Pv.expense_date = "";
                Pv.expense_amount = "";
                Pv.expense_reason = "";
            // transfer
                Pv.to_fundName = "";
                Pv.from_fundName = "";
                Pv.transfer_date = "";
                Pv.transfer_amount = "";
                Pv.transfer_reason = "";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            // Reset all values of all variables
            resetValues();

            // Close the current form
            this.Close();
        }
    }
}
