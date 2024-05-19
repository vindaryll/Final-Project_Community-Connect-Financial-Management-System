namespace community_connect_financial_system.Misc_Forms
{
    partial class UserControl1_Piechart
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.panel_legend = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pieChart1
            // 
            this.pieChart1.BackColor = System.Drawing.Color.Transparent;
            this.pieChart1.Location = new System.Drawing.Point(43, 2);
            this.pieChart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(281, 378);
            this.pieChart1.TabIndex = 0;
            this.pieChart1.Text = "pieChart1";
            // 
            // panel_legend
            // 
            this.panel_legend.AutoScroll = true;
            this.panel_legend.BackColor = System.Drawing.Color.Transparent;
            this.panel_legend.Location = new System.Drawing.Point(355, 2);
            this.panel_legend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel_legend.Name = "panel_legend";
            this.panel_legend.Size = new System.Drawing.Size(389, 378);
            this.panel_legend.TabIndex = 1;
            // 
            // UserControl1_Piechart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_legend);
            this.Controls.Add(this.pieChart1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserControl1_Piechart";
            this.Size = new System.Drawing.Size(746, 382);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.Panel panel_legend;
    }
}
