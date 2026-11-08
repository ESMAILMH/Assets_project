namespace AssetTracking.Forms
{
    partial class LoginForm
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
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
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lnkSettings = new System.Windows.Forms.LinkLabel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblOrg = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lblIcon = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = false;
            this.lblUser.Location = new System.Drawing.Point(50, 172);
            this.lblUser.Size = new System.Drawing.Size(340, 24);
            this.lblUser.Text = "اسم المستخدم";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUser.Name = "lblUser";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(50, 198);
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUser.Size = new System.Drawing.Size(340, 32);
            this.txtUser.Name = "txtUser";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = false;
            this.lblPass.Location = new System.Drawing.Point(50, 242);
            this.lblPass.Size = new System.Drawing.Size(340, 24);
            this.lblPass.Text = "كلمة المرور";
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPass.Name = "lblPass";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(50, 268);
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPass.Size = new System.Drawing.Size(340, 32);
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.Name = "txtPass";
            // 
            // chkShow
            // 
            this.chkShow.AutoSize = true;
            this.chkShow.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.chkShow.Location = new System.Drawing.Point(50, 308);
            this.chkShow.Text = "إظهار كلمة المرور";
            this.chkShow.Name = "chkShow";
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = false;
            this.lblError.Location = new System.Drawing.Point(50, 334);
            this.lblError.Size = new System.Drawing.Size(340, 24);
            this.lblError.Text = "";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblError.Name = "lblError";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(50, 364);
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Size = new System.Drawing.Size(340, 42);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Text = "دخول";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lnkSettings
            // 
            this.lnkSettings.AutoSize = true;
            this.lnkSettings.Location = new System.Drawing.Point(50, 420);
            this.lnkSettings.Text = "إعدادات الاتصال بقاعدة البيانات";
            this.lnkSettings.Name = "lnkSettings";
            this.lnkSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSettings_LinkClicked);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblOrg);
            this.pnlHeader.Controls.Add(this.lblAppTitle);
            this.pnlHeader.Controls.Add(this.lblIcon);
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(440, 150);
            this.pnlHeader.Name = "pnlHeader";
            // 
            // lblOrg
            // 
            this.lblOrg.AutoSize = false;
            this.lblOrg.Location = new System.Drawing.Point(0, 110);
            this.lblOrg.Size = new System.Drawing.Size(440, 26);
            this.lblOrg.Text = "كلية التقنيات الهندسية – يفرن";
            this.lblOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOrg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrg.ForeColor = System.Drawing.Color.FromArgb(210, 225, 240);
            this.lblOrg.Name = "lblOrg";
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = false;
            this.lblAppTitle.Location = new System.Drawing.Point(0, 72);
            this.lblAppTitle.Size = new System.Drawing.Size(440, 36);
            this.lblAppTitle.Text = "نظام حصر الأصول وتتبع العهد";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Name = "lblAppTitle";
            // 
            // lblIcon
            // 
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 28F);
            this.lblIcon.ForeColor = System.Drawing.Color.White;
            this.lblIcon.Location = new System.Drawing.Point(0, 12);
            this.lblIcon.Size = new System.Drawing.Size(440, 60);
            this.lblIcon.Text = "📦";
            this.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIcon.Name = "lblIcon";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnLogin;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 460);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسجيل الدخول";
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lnkSettings);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "LoginForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lnkSettings;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblOrg;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblIcon;
    }
}
