namespace community_connect_financial_system.Forms.Funds
{
    partial class Form5_UnallocatedFundInfo
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
            this.btn_distribute = new Guna.UI2.WinForms.Guna2Button();
            this.btn_addbalance = new Guna.UI2.WinForms.Guna2Button();
            this.btn_back = new System.Windows.Forms.PictureBox();
            this.lbl_amount = new System.Windows.Forms.Label();
            this.lbl_fundName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btn_back)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_distribute
            // 
            this.btn_distribute.BackColor = System.Drawing.Color.Transparent;
            this.btn_distribute.BorderRadius = 25;
            this.btn_distribute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_distribute.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_distribute.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_distribute.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_distribute.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_distribute.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.btn_distribute.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_distribute.ForeColor = System.Drawing.Color.White;
            this.btn_distribute.Location = new System.Drawing.Point(716, 514);
            this.btn_distribute.Name = "btn_distribute";
            this.btn_distribute.Size = new System.Drawing.Size(252, 62);
            this.btn_distribute.TabIndex = 1;
            this.btn_distribute.Text = "DISTRIBUTE";
            this.btn_distribute.Click += new System.EventHandler(this.btn_distribute_Click);
            // 
            // btn_addbalance
            // 
            this.btn_addbalance.BackColor = System.Drawing.Color.Transparent;
            this.btn_addbalance.BorderRadius = 25;
            this.btn_addbalance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addbalance.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_addbalance.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_addbalance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_addbalance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_addbalance.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.btn_addbalance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addbalance.ForeColor = System.Drawing.Color.White;
            this.btn_addbalance.Location = new System.Drawing.Point(423, 514);
            this.btn_addbalance.Name = "btn_addbalance";
            this.btn_addbalance.Size = new System.Drawing.Size(252, 62);
            this.btn_addbalance.TabIndex = 0;
            this.btn_addbalance.Text = "ADD BALANCE";
            this.btn_addbalance.Click += new System.EventHandler(this.btn_addbalance_Click);
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Transparent;
            this.btn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Location = new System.Drawing.Point(184, 163);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(29, 24);
            this.btn_back.TabIndex = 35;
            this.btn_back.TabStop = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // lbl_amount
            // 
            this.lbl_amount.BackColor = System.Drawing.Color.Transparent;
            this.lbl_amount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19F);
            this.lbl_amount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.lbl_amount.Location = new System.Drawing.Point(446, 419);
            this.lbl_amount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.Size = new System.Drawing.Size(496, 53);
            this.lbl_amount.TabIndex = 34;
            this.lbl_amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_fundName
            // 
            this.lbl_fundName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fundName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F);
            this.lbl_fundName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.lbl_fundName.Location = new System.Drawing.Point(240, 230);
            this.lbl_fundName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_fundName.Name = "lbl_fundName";
            this.lbl_fundName.Size = new System.Drawing.Size(912, 104);
            this.lbl_fundName.TabIndex = 33;
            this.lbl_fundName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form5_UnallocatedFundInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::community_connect_financial_system.Properties.Resources.funds_Form5_UnallocatedFundInfo;
            this.ClientSize = new System.Drawing.Size(1226, 690);
            this.Controls.Add(this.btn_distribute);
            this.Controls.Add(this.btn_addbalance);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.lbl_amount);
            this.Controls.Add(this.lbl_fundName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form5_UnallocatedFundInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form5_UnallocatedInterface";
            ((System.ComponentModel.ISupportInitialize)(this.btn_back)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_distribute;
        private Guna.UI2.WinForms.Guna2Button btn_addbalance;
        private System.Windows.Forms.PictureBox btn_back;
        private System.Windows.Forms.Label lbl_amount;
        private System.Windows.Forms.Label lbl_fundName;
    }
}