namespace AssetTracking.Forms
{
    partial class MainForm
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnAssets = new System.Windows.Forms.Button();
            this.btnCustody = new System.Windows.Forms.Button();
            this.btnAlerts = new System.Windows.Forms.Button();
            this.btnDisposal = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnPersons = new System.Windows.Forms.Button();
            this.btnMasterData = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnMyAssets = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnAudit = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.flpUser = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.flpMenu.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.flpUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Name = "pnlContent";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.flpMenu);
            this.pnlSidebar.Controls.Add(this.lblFooter);
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Size = new System.Drawing.Size(240, 700);
            this.pnlSidebar.Name = "pnlSidebar";
            // 
            // flpMenu
            // 
            this.flpMenu.Controls.Add(this.btnDashboard);
            this.flpMenu.Controls.Add(this.btnAssets);
            this.flpMenu.Controls.Add(this.btnCustody);
            this.flpMenu.Controls.Add(this.btnAlerts);
            this.flpMenu.Controls.Add(this.btnDisposal);
            this.flpMenu.Controls.Add(this.btnInventory);
            this.flpMenu.Controls.Add(this.btnPersons);
            this.flpMenu.Controls.Add(this.btnMasterData);
            this.flpMenu.Controls.Add(this.btnReports);
            this.flpMenu.Controls.Add(this.btnMyAssets);
            this.flpMenu.Controls.Add(this.btnUsers);
            this.flpMenu.Controls.Add(this.btnAudit);
            this.flpMenu.AutoScroll = true;
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMenu.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flpMenu.WrapContents = false;
            this.flpMenu.Name = "flpMenu";
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(240, 46);
            this.btnDashboard.Tag = "Dashboard";
            this.btnDashboard.Text = "🏠   الشاشة الرئيسية";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnAssets
            // 
            this.btnAssets.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnAssets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssets.FlatAppearance.BorderSize = 0;
            this.btnAssets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnAssets.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnAssets.ForeColor = System.Drawing.Color.White;
            this.btnAssets.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnAssets.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnAssets.Size = new System.Drawing.Size(240, 46);
            this.btnAssets.Tag = "Assets";
            this.btnAssets.Text = "📦   الأصول";
            this.btnAssets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssets.UseVisualStyleBackColor = false;
            this.btnAssets.Name = "btnAssets";
            this.btnAssets.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnCustody
            // 
            this.btnCustody.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnCustody.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustody.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustody.FlatAppearance.BorderSize = 0;
            this.btnCustody.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnCustody.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnCustody.ForeColor = System.Drawing.Color.White;
            this.btnCustody.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnCustody.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnCustody.Size = new System.Drawing.Size(240, 46);
            this.btnCustody.Tag = "Custody";
            this.btnCustody.Text = "🔁   التسليم والاستلام";
            this.btnCustody.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustody.UseVisualStyleBackColor = false;
            this.btnCustody.Name = "btnCustody";
            this.btnCustody.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnAlerts
            // 
            this.btnAlerts.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnAlerts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlerts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlerts.FlatAppearance.BorderSize = 0;
            this.btnAlerts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnAlerts.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnAlerts.ForeColor = System.Drawing.Color.White;
            this.btnAlerts.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnAlerts.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnAlerts.Size = new System.Drawing.Size(240, 46);
            this.btnAlerts.Tag = "Alerts";
            this.btnAlerts.Text = "⏰   التنبيهات";
            this.btnAlerts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlerts.UseVisualStyleBackColor = false;
            this.btnAlerts.Name = "btnAlerts";
            this.btnAlerts.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnDisposal
            // 
            this.btnDisposal.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnDisposal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDisposal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisposal.FlatAppearance.BorderSize = 0;
            this.btnDisposal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnDisposal.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnDisposal.ForeColor = System.Drawing.Color.White;
            this.btnDisposal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnDisposal.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnDisposal.Size = new System.Drawing.Size(240, 46);
            this.btnDisposal.Tag = "Disposal";
            this.btnDisposal.Text = "♻   التخريد";
            this.btnDisposal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisposal.UseVisualStyleBackColor = false;
            this.btnDisposal.Name = "btnDisposal";
            this.btnDisposal.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.FlatAppearance.BorderSize = 0;
            this.btnInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnInventory.ForeColor = System.Drawing.Color.White;
            this.btnInventory.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnInventory.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnInventory.Size = new System.Drawing.Size(240, 46);
            this.btnInventory.Tag = "Inventory";
            this.btnInventory.Text = "📋   الجرد";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnPersons
            // 
            this.btnPersons.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnPersons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPersons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersons.FlatAppearance.BorderSize = 0;
            this.btnPersons.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnPersons.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnPersons.ForeColor = System.Drawing.Color.White;
            this.btnPersons.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnPersons.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnPersons.Size = new System.Drawing.Size(240, 46);
            this.btnPersons.Tag = "Persons";
            this.btnPersons.Text = "👥   الأشخاص";
            this.btnPersons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersons.UseVisualStyleBackColor = false;
            this.btnPersons.Name = "btnPersons";
            this.btnPersons.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnMasterData
            // 
            this.btnMasterData.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnMasterData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasterData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasterData.FlatAppearance.BorderSize = 0;
            this.btnMasterData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnMasterData.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnMasterData.ForeColor = System.Drawing.Color.White;
            this.btnMasterData.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnMasterData.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMasterData.Size = new System.Drawing.Size(240, 46);
            this.btnMasterData.Tag = "MasterData";
            this.btnMasterData.Text = "🗂   الأقسام والمواقع والتصنيفات";
            this.btnMasterData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasterData.UseVisualStyleBackColor = false;
            this.btnMasterData.Name = "btnMasterData";
            this.btnMasterData.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnReports.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(240, 46);
            this.btnReports.Tag = "Reports";
            this.btnReports.Text = "📊   التقارير";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Name = "btnReports";
            this.btnReports.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnMyAssets
            // 
            this.btnMyAssets.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnMyAssets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyAssets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyAssets.FlatAppearance.BorderSize = 0;
            this.btnMyAssets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnMyAssets.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnMyAssets.ForeColor = System.Drawing.Color.White;
            this.btnMyAssets.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnMyAssets.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMyAssets.Size = new System.Drawing.Size(240, 46);
            this.btnMyAssets.Tag = "MyAssets";
            this.btnMyAssets.Text = "🧾   أصولي";
            this.btnMyAssets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyAssets.UseVisualStyleBackColor = false;
            this.btnMyAssets.Name = "btnMyAssets";
            this.btnMyAssets.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnUsers.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnUsers.Size = new System.Drawing.Size(240, 46);
            this.btnUsers.Tag = "Users";
            this.btnUsers.Text = "🔐   المستخدمون";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.BackColor = System.Drawing.Color.FromArgb(23, 37, 56);
            this.btnAudit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAudit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAudit.FlatAppearance.BorderSize = 0;
            this.btnAudit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(38, 58, 84);
            this.btnAudit.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnAudit.ForeColor = System.Drawing.Color.White;
            this.btnAudit.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btnAudit.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnAudit.Size = new System.Drawing.Size(240, 46);
            this.btnAudit.Tag = "Audit";
            this.btnAudit.Text = "📜   سجل العمليات";
            this.btnAudit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAudit.UseVisualStyleBackColor = false;
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Click += new System.EventHandler(this.Menu_Click);
            // 
            // lblFooter
            // 
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(150, 165, 185);
            this.lblFooter.Size = new System.Drawing.Size(240, 44);
            this.lblFooter.Text = "كلية التقنيات الهندسية – يفرن";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFooter.Name = "lblFooter";
            // 
            // lblLogo
            // 
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Size = new System.Drawing.Size(240, 64);
            this.lblLogo.Text = "حصر الأصول";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogo.Name = "lblLogo";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.flpUser);
            this.pnlHeader.Controls.Add(this.lblAppTitle);
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1200, 58);
            this.pnlHeader.Name = "pnlHeader";
            // 
            // flpUser
            // 
            this.flpUser.Controls.Add(this.btnLogout);
            this.flpUser.Controls.Add(this.btnChangePassword);
            this.flpUser.Controls.Add(this.lblCurrentUser);
            this.flpUser.AutoSize = true;
            this.flpUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpUser.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpUser.Padding = new System.Windows.Forms.Padding(8, 10, 8, 0);
            this.flpUser.WrapContents = false;
            this.flpUser.Name = "flpUser";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Size = new System.Drawing.Size(130, 36);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Text = "تسجيل الخروج";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Size = new System.Drawing.Size(150, 36);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChangePassword.Text = "تغيير كلمة المرور";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblCurrentUser.Text = "👤 المستخدم";
            this.lblCurrentUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentUser.Name = "lblCurrentUser";
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblAppTitle.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblAppTitle.Size = new System.Drawing.Size(420, 58);
            this.lblAppTitle.Text = "نظام حصر الأصول وتتبع العهد";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAppTitle.Name = "lblAppTitle";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.ClientSize = new System.Drawing.Size(1280, 760);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1150, 700);
            this.Text = "نظام حصر الأصول وتتبع العهد";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.flpUser.ResumeLayout(false);
            this.flpUser.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flpMenu.ResumeLayout(false);
            this.flpMenu.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnAssets;
        private System.Windows.Forms.Button btnCustody;
        private System.Windows.Forms.Button btnAlerts;
        private System.Windows.Forms.Button btnDisposal;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnPersons;
        private System.Windows.Forms.Button btnMasterData;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnMyAssets;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.FlowLayoutPanel flpUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label lblAppTitle;
    }
}
