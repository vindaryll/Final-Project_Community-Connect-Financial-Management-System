namespace community_connect_financial_system.Forms.Funds
{
    partial class Form3_spend
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.combo_period = new System.Windows.Forms.ComboBox();
            this.combo_min = new System.Windows.Forms.ComboBox();
            this.combo_hr = new System.Windows.Forms.ComboBox();
            this.combo_yr = new System.Windows.Forms.ComboBox();
            this.combo_dd = new System.Windows.Forms.ComboBox();
            this.combo_mm = new System.Windows.Forms.ComboBox();
            this.checkBox_currtimestamp = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.lbl_fundAmount = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.PictureBox();
            this.lbl_fundName = new System.Windows.Forms.Label();
            this.btn_submit = new Guna.UI2.WinForms.Guna2Button();
            this.txt_amount = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_reason = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_back)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_period
            // 
            this.combo_period.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.combo_period.ForeColor = System.Drawing.Color.Black;
            this.combo_period.FormattingEnabled = true;
            this.combo_period.Items.AddRange(new object[] {
            "am",
            "pm"});
            this.combo_period.Location = new System.Drawing.Point(478, 529);
            this.combo_period.Margin = new System.Windows.Forms.Padding(2);
            this.combo_period.Name = "combo_period";
            this.combo_period.Size = new System.Drawing.Size(67, 26);
            this.combo_period.TabIndex = 9;
            this.combo_period.Leave += new System.EventHandler(this.combo_period_Leave);
            // 
            // combo_min
            // 
            this.combo_min.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.combo_min.ForeColor = System.Drawing.Color.Black;
            this.combo_min.FormattingEnabled = true;
            this.combo_min.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.combo_min.Location = new System.Drawing.Point(394, 529);
            this.combo_min.Margin = new System.Windows.Forms.Padding(2);
            this.combo_min.Name = "combo_min";
            this.combo_min.Size = new System.Drawing.Size(66, 26);
            this.combo_min.TabIndex = 8;
            this.combo_min.Leave += new System.EventHandler(this.combo_min_Leave);
            // 
            // combo_hr
            // 
            this.combo_hr.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.combo_hr.ForeColor = System.Drawing.Color.Black;
            this.combo_hr.FormattingEnabled = true;
            this.combo_hr.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.combo_hr.Location = new System.Drawing.Point(309, 529);
            this.combo_hr.Margin = new System.Windows.Forms.Padding(2);
            this.combo_hr.Name = "combo_hr";
            this.combo_hr.Size = new System.Drawing.Size(67, 26);
            this.combo_hr.TabIndex = 7;
            this.combo_hr.Leave += new System.EventHandler(this.combo_hr_Leave);
            // 
            // combo_yr
            // 
            this.combo_yr.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.combo_yr.ForeColor = System.Drawing.Color.Black;
            this.combo_yr.FormattingEnabled = true;
            this.combo_yr.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.combo_yr.Location = new System.Drawing.Point(481, 455);
            this.combo_yr.Margin = new System.Windows.Forms.Padding(2);
            this.combo_yr.Name = "combo_yr";
            this.combo_yr.Size = new System.Drawing.Size(67, 26);
            this.combo_yr.TabIndex = 6;
            this.combo_yr.Leave += new System.EventHandler(this.combo_yr_Leave);
            // 
            // combo_dd
            // 
            this.combo_dd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.combo_dd.ForeColor = System.Drawing.Color.Black;
            this.combo_dd.FormattingEnabled = true;
            this.combo_dd.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.combo_dd.Location = new System.Drawing.Point(397, 455);
            this.combo_dd.Margin = new System.Windows.Forms.Padding(2);
            this.combo_dd.Name = "combo_dd";
            this.combo_dd.Size = new System.Drawing.Size(66, 26);
            this.combo_dd.TabIndex = 5;
            this.combo_dd.Leave += new System.EventHandler(this.combo_dd_Leave);
            // 
            // combo_mm
            // 
            this.combo_mm.BackColor = System.Drawing.SystemColors.Window;
            this.combo_mm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.combo_mm.ForeColor = System.Drawing.Color.Black;
            this.combo_mm.FormattingEnabled = true;
            this.combo_mm.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.combo_mm.Location = new System.Drawing.Point(312, 455);
            this.combo_mm.Margin = new System.Windows.Forms.Padding(2);
            this.combo_mm.Name = "combo_mm";
            this.combo_mm.Size = new System.Drawing.Size(67, 26);
            this.combo_mm.TabIndex = 4;
            this.combo_mm.Leave += new System.EventHandler(this.combo_mm_Leave);
            // 
            // checkBox_currtimestamp
            // 
            this.checkBox_currtimestamp.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.checkBox_currtimestamp.CheckedState.BorderRadius = 8;
            this.checkBox_currtimestamp.CheckedState.BorderThickness = 0;
            this.checkBox_currtimestamp.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.checkBox_currtimestamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox_currtimestamp.Location = new System.Drawing.Point(306, 570);
            this.checkBox_currtimestamp.Name = "checkBox_currtimestamp";
            this.checkBox_currtimestamp.Size = new System.Drawing.Size(20, 24);
            this.checkBox_currtimestamp.TabIndex = 3;
            this.checkBox_currtimestamp.UncheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.checkBox_currtimestamp.UncheckedState.BorderRadius = 8;
            this.checkBox_currtimestamp.UncheckedState.BorderThickness = 0;
            this.checkBox_currtimestamp.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.checkBox_currtimestamp.CheckedChanged += new System.EventHandler(this.checkBox_currtimestamp_CheckedChanged);
            // 
            // lbl_fundAmount
            // 
            this.lbl_fundAmount.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fundAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.lbl_fundAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.lbl_fundAmount.Location = new System.Drawing.Point(737, 277);
            this.lbl_fundAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_fundAmount.Name = "lbl_fundAmount";
            this.lbl_fundAmount.Size = new System.Drawing.Size(413, 44);
            this.lbl_fundAmount.TabIndex = 0;
            this.lbl_fundAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Transparent;
            this.btn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Location = new System.Drawing.Point(176, 167);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(29, 24);
            this.btn_back.TabIndex = 96;
            this.btn_back.TabStop = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // lbl_fundName
            // 
            this.lbl_fundName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fundName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F);
            this.lbl_fundName.ForeColor = System.Drawing.Color.White;
            this.lbl_fundName.Location = new System.Drawing.Point(210, 150);
            this.lbl_fundName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_fundName.Name = "lbl_fundName";
            this.lbl_fundName.Size = new System.Drawing.Size(859, 59);
            this.lbl_fundName.TabIndex = 97;
            this.lbl_fundName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.Transparent;
            this.btn_submit.BorderRadius = 25;
            this.btn_submit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_submit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_submit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_submit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_submit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_submit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.btn_submit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.Color.White;
            this.btn_submit.Location = new System.Drawing.Point(959, 606);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(209, 52);
            this.btn_submit.TabIndex = 10;
            this.btn_submit.Text = "SUBMIT";
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // txt_amount
            // 
            this.txt_amount.BackColor = System.Drawing.Color.Transparent;
            this.txt_amount.BorderColor = System.Drawing.Color.White;
            this.txt_amount.BorderRadius = 20;
            this.txt_amount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_amount.CustomizableEdges.BottomLeft = false;
            this.txt_amount.CustomizableEdges.TopLeft = false;
            this.txt_amount.DefaultText = "";
            this.txt_amount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_amount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_amount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_amount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_amount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_amount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.txt_amount.ForeColor = System.Drawing.Color.Black;
            this.txt_amount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_amount.Location = new System.Drawing.Point(312, 359);
            this.txt_amount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.PasswordChar = '\0';
            this.txt_amount.PlaceholderText = "Enter an amount";
            this.txt_amount.SelectedText = "";
            this.txt_amount.Size = new System.Drawing.Size(324, 43);
            this.txt_amount.TabIndex = 1;
            // 
            // txt_reason
            // 
            this.txt_reason.BackColor = System.Drawing.Color.Transparent;
            this.txt_reason.BorderColor = System.Drawing.Color.Black;
            this.txt_reason.BorderRadius = 20;
            this.txt_reason.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_reason.DefaultText = "";
            this.txt_reason.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_reason.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_reason.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_reason.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_reason.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_reason.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.txt_reason.ForeColor = System.Drawing.Color.Black;
            this.txt_reason.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_reason.Location = new System.Drawing.Point(723, 383);
            this.txt_reason.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_reason.Multiline = true;
            this.txt_reason.Name = "txt_reason";
            this.txt_reason.PasswordChar = '\0';
            this.txt_reason.PlaceholderText = "Enter the reason";
            this.txt_reason.SelectedText = "";
            this.txt_reason.Size = new System.Drawing.Size(439, 194);
            this.txt_reason.TabIndex = 2;
            // 
            // Form3_spend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::community_connect_financial_system.Properties.Resources.funds_Form3_spend;
            this.ClientSize = new System.Drawing.Size(1226, 690);
            this.Controls.Add(this.txt_reason);
            this.Controls.Add(this.txt_amount);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.lbl_fundName);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.lbl_fundAmount);
            this.Controls.Add(this.checkBox_currtimestamp);
            this.Controls.Add(this.combo_period);
            this.Controls.Add(this.combo_min);
            this.Controls.Add(this.combo_hr);
            this.Controls.Add(this.combo_yr);
            this.Controls.Add(this.combo_dd);
            this.Controls.Add(this.combo_mm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form3_spend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3_spend";
            ((System.ComponentModel.ISupportInitialize)(this.btn_back)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox combo_period;
        private System.Windows.Forms.ComboBox combo_min;
        private System.Windows.Forms.ComboBox combo_hr;
        private System.Windows.Forms.ComboBox combo_yr;
        private System.Windows.Forms.ComboBox combo_dd;
        private System.Windows.Forms.ComboBox combo_mm;
        private Guna.UI2.WinForms.Guna2CustomCheckBox checkBox_currtimestamp;
        private System.Windows.Forms.Label lbl_fundAmount;
        private System.Windows.Forms.PictureBox btn_back;
        private System.Windows.Forms.Label lbl_fundName;
        private Guna.UI2.WinForms.Guna2Button btn_submit;
        private Guna.UI2.WinForms.Guna2TextBox txt_amount;
        private Guna.UI2.WinForms.Guna2TextBox txt_reason;
    }
}