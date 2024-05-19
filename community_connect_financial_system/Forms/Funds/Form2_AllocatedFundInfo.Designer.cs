namespace community_connect_financial_system.Forms.Funds
{
    partial class Form2_AllocatedFundInfo
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
            this.lbl_fundName = new System.Windows.Forms.Label();
            this.lbl_amount = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.PictureBox();
            this.btn_use = new Guna.UI2.WinForms.Guna2Button();
            this.btn_transfer = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.btn_back)).BeginInit();
            this.SuspendLayout();
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
            this.lbl_fundName.TabIndex = 0;
            this.lbl_fundName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lbl_amount.TabIndex = 1;
            this.lbl_amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Transparent;
            this.btn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Location = new System.Drawing.Point(184, 163);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(29, 24);
            this.btn_back.TabIndex = 30;
            this.btn_back.TabStop = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_use
            // 
            this.btn_use.BackColor = System.Drawing.Color.Transparent;
            this.btn_use.BorderRadius = 25;
            this.btn_use.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_use.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_use.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_use.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_use.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_use.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.btn_use.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_use.ForeColor = System.Drawing.Color.White;
            this.btn_use.Location = new System.Drawing.Point(423, 514);
            this.btn_use.Name = "btn_use";
            this.btn_use.Size = new System.Drawing.Size(252, 62);
            this.btn_use.TabIndex = 2;
            this.btn_use.Text = "USE";
            this.btn_use.Click += new System.EventHandler(this.btn_use_Click);
            // 
            // btn_transfer
            // 
            this.btn_transfer.BackColor = System.Drawing.Color.Transparent;
            this.btn_transfer.BorderRadius = 25;
            this.btn_transfer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_transfer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_transfer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_transfer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_transfer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_transfer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.btn_transfer.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_transfer.ForeColor = System.Drawing.Color.White;
            this.btn_transfer.Location = new System.Drawing.Point(716, 514);
            this.btn_transfer.Name = "btn_transfer";
            this.btn_transfer.Size = new System.Drawing.Size(252, 62);
            this.btn_transfer.TabIndex = 3;
            this.btn_transfer.Text = "TRANSFER";
            this.btn_transfer.Click += new System.EventHandler(this.btn_transfer_Click);
            // 
            // Form2_AllocatedFundInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::community_connect_financial_system.Properties.Resources.funds_Form2_AllocatedFundInfo;
            this.ClientSize = new System.Drawing.Size(1226, 690);
            this.Controls.Add(this.btn_transfer);
            this.Controls.Add(this.btn_use);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.lbl_amount);
            this.Controls.Add(this.lbl_fundName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2_AllocatedFundInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2_AllocatedFundInfo";
            ((System.ComponentModel.ISupportInitialize)(this.btn_back)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_fundName;
        private System.Windows.Forms.Label lbl_amount;
        private System.Windows.Forms.PictureBox btn_back;
        private Guna.UI2.WinForms.Guna2Button btn_use;
        private Guna.UI2.WinForms.Guna2Button btn_transfer;
    }
}