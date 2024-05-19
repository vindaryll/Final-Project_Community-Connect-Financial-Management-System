using community_connect_finance_system.Classes;
using LiveCharts;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace community_connect_financial_system.Misc_Forms
{
    public partial class UserControl1_Piechart : UserControl
    {
        Functions func = new Functions();
        public UserControl1_Piechart()
        {
            InitializeComponent();
            func.populatePieChart(pieChart1, panel_legend);
        }
    }
}
