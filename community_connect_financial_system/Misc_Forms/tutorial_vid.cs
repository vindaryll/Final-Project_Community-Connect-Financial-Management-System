using community_connect_financial_system.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Pv = community_connect_finance_system.Classes.PublicVariables;

namespace community_connect_financial_system.Misc_Forms
{
    public partial class tutorial_vid : Form
    {
        public tutorial_vid()
        {
            InitializeComponent();
            // insert the vid
            string loc = $"{Pv.miscFilesPath}Community_Connect_Financial_Video tutorial.mp4";
            axWindowsMediaPlayer1.URL = loc;          
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Form4_Homepage form = new Form4_Homepage();
            form.Show();
            this.Close();
        }
    }
}
