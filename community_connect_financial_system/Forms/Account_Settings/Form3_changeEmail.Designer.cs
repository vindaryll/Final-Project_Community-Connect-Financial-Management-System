namespace community_connect_financial_system.Forms.Account_Settings
{
    partial class Form3_changeEmail
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
            this.btn_back = new System.Windows.Forms.PictureBox();
            this.btn_submit = new Guna.UI2.WinForms.Guna2Button();
            this.btn_sendcode = new Guna.UI2.WinForms.Guna2Button();
            this.txt_verification = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_email = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_back)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Transparent;
            this.btn_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_back.Location = new System.Drawing.Point(176, 169);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(30, 24);
            this.btn_back.TabIndex = 19;
            this.btn_back.TabStop = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
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
            this.btn_submit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.Color.White;
            this.btn_submit.Location = new System.Drawing.Point(561, 582);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(210, 51);
            this.btn_submit.TabIndex = 18;
            this.btn_submit.Text = "SAVE CHANGES";
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_sendcode
            // 
            this.btn_sendcode.BackColor = System.Drawing.Color.Transparent;
            this.btn_sendcode.BorderRadius = 19;
            this.btn_sendcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sendcode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_sendcode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_sendcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_sendcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_sendcode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(96)))));
            this.btn_sendcode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sendcode.ForeColor = System.Drawing.Color.White;
            this.btn_sendcode.Location = new System.Drawing.Point(761, 417);
            this.btn_sendcode.Name = "btn_sendcode";
            this.btn_sendcode.Size = new System.Drawing.Size(131, 37);
            this.btn_sendcode.TabIndex = 17;
            this.btn_sendcode.Text = "SEND CODE";
            this.btn_sendcode.Click += new System.EventHandler(this.btn_sendcode_Click);
            // 
            // txt_verification
            // 
            this.txt_verification.BackColor = System.Drawing.Color.Transparent;
            this.txt_verification.BorderRadius = 20;
            this.txt_verification.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_verification.DefaultText = "";
            this.txt_verification.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_verification.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_verification.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_verification.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_verification.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_verification.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.txt_verification.ForeColor = System.Drawing.Color.Black;
            this.txt_verification.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_verification.Location = new System.Drawing.Point(445, 465);
            this.txt_verification.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_verification.Name = "txt_verification";
            this.txt_verification.PasswordChar = '\0';
            this.txt_verification.PlaceholderText = "Enter the code";
            this.txt_verification.SelectedText = "";
            this.txt_verification.Size = new System.Drawing.Size(441, 45);
            this.txt_verification.TabIndex = 16;
            // 
            // txt_email
            // 
            this.txt_email.BackColor = System.Drawing.Color.Transparent;
            this.txt_email.BorderRadius = 20;
            this.txt_email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_email.DefaultText = "";
            this.txt_email.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_email.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_email.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_email.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_email.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_email.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.txt_email.ForeColor = System.Drawing.Color.Black;
            this.txt_email.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_email.Location = new System.Drawing.Point(445, 347);
            this.txt_email.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_email.Name = "txt_email";
            this.txt_email.PasswordChar = '\0';
            this.txt_email.PlaceholderText = "Enter your email";
            this.txt_email.SelectedText = "";
            this.txt_email.Size = new System.Drawing.Size(441, 46);
            this.txt_email.TabIndex = 15;
            // 
            // Form3_changeEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::community_connect_financial_system.Properties.Resources.account_Form3_changeEmail;
            this.ClientSize = new System.Drawing.Size(1226, 690);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.btn_sendcode);
            this.Controls.Add(this.txt_verification);
            this.Controls.Add(this.txt_email);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form3_changeEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3_changeEmail";
            ((System.ComponentModel.ISupportInitialize)(this.btn_back)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btn_back;
        private Guna.UI2.WinForms.Guna2Button btn_submit;
        private Guna.UI2.WinForms.Guna2Button btn_sendcode;
        private Guna.UI2.WinForms.Guna2TextBox txt_verification;
        private Guna.UI2.WinForms.Guna2TextBox txt_email;
    }
}