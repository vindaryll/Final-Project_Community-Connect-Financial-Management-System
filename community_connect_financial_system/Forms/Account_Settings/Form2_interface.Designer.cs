namespace community_connect_financial_system.Forms.Account_Settings
{
    partial class Form2_interface
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
            this.btn_dashboard = new System.Windows.Forms.PictureBox();
            this.btn_username = new Guna.UI2.WinForms.Guna2Button();
            this.btn_email = new Guna.UI2.WinForms.Guna2Button();
            this.btn_password = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.btn_dashboard)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_dashboard
            // 
            this.btn_dashboard.BackColor = System.Drawing.Color.Transparent;
            this.btn_dashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dashboard.Location = new System.Drawing.Point(177, 169);
            this.btn_dashboard.Name = "btn_dashboard";
            this.btn_dashboard.Size = new System.Drawing.Size(29, 24);
            this.btn_dashboard.TabIndex = 17;
            this.btn_dashboard.TabStop = false;
            this.btn_dashboard.Click += new System.EventHandler(this.btn_dashboard_Click);
            // 
            // btn_username
            // 
            this.btn_username.BackColor = System.Drawing.Color.Transparent;
            this.btn_username.BorderRadius = 25;
            this.btn_username.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_username.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_username.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_username.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.btn_username.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_username.ForeColor = System.Drawing.Color.White;
            this.btn_username.Location = new System.Drawing.Point(302, 490);
            this.btn_username.Name = "btn_username";
            this.btn_username.Size = new System.Drawing.Size(219, 55);
            this.btn_username.TabIndex = 0;
            this.btn_username.Text = "CHANGE USERNAME";
            this.btn_username.Click += new System.EventHandler(this.btn_username_Click);
            // 
            // btn_email
            // 
            this.btn_email.BackColor = System.Drawing.Color.Transparent;
            this.btn_email.BorderRadius = 25;
            this.btn_email.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_email.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_email.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_email.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.btn_email.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_email.ForeColor = System.Drawing.Color.White;
            this.btn_email.Location = new System.Drawing.Point(605, 490);
            this.btn_email.Name = "btn_email";
            this.btn_email.Size = new System.Drawing.Size(219, 55);
            this.btn_email.TabIndex = 1;
            this.btn_email.Text = "CHANGE EMAIL";
            this.btn_email.Click += new System.EventHandler(this.btn_email_Click);
            // 
            // btn_password
            // 
            this.btn_password.BackColor = System.Drawing.Color.Transparent;
            this.btn_password.BorderRadius = 25;
            this.btn_password.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_password.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_password.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_password.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.btn_password.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_password.ForeColor = System.Drawing.Color.White;
            this.btn_password.Location = new System.Drawing.Point(907, 490);
            this.btn_password.Name = "btn_password";
            this.btn_password.Size = new System.Drawing.Size(219, 55);
            this.btn_password.TabIndex = 2;
            this.btn_password.Text = "CHANGE PASSWORD";
            this.btn_password.Click += new System.EventHandler(this.btn_password_Click);
            // 
            // Form2_interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::community_connect_financial_system.Properties.Resources.account_Form2_interface;
            this.ClientSize = new System.Drawing.Size(1226, 690);
            this.Controls.Add(this.btn_password);
            this.Controls.Add(this.btn_email);
            this.Controls.Add(this.btn_username);
            this.Controls.Add(this.btn_dashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2_interface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2_interface";
            ((System.ComponentModel.ISupportInitialize)(this.btn_dashboard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox btn_dashboard;
        private Guna.UI2.WinForms.Guna2Button btn_username;
        private Guna.UI2.WinForms.Guna2Button btn_email;
        private Guna.UI2.WinForms.Guna2Button btn_password;
    }
}