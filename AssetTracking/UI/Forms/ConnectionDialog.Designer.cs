namespace AssetTracking.Forms
{
    partial class ConnectionDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAuth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSqlUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSqlPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Size = new System.Drawing.Size(150, 27);
            this.label1.Text = "اسم الخادم *";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Name = "label1";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(176, 64);
            this.txtServer.Size = new System.Drawing.Size(364, 27);
            this.txtServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServer.Name = "txtServer";
            // 
            // label2
            // 
            this.label2.AutoSize = false;
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Size = new System.Drawing.Size(150, 27);
            this.label2.Text = "قاعدة البيانات *";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Name = "label2";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(176, 104);
            this.txtDatabase.Size = new System.Drawing.Size(364, 27);
            this.txtDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDatabase.Name = "txtDatabase";
            // 
            // label3
            // 
            this.label3.AutoSize = false;
            this.label3.Location = new System.Drawing.Point(16, 144);
            this.label3.Size = new System.Drawing.Size(150, 27);
            this.label3.Text = "طريقة الدخول";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Name = "label3";
            // 
            // cmbAuth
            // 
            this.cmbAuth.Location = new System.Drawing.Point(176, 144);
            this.cmbAuth.Size = new System.Drawing.Size(364, 28);
            this.cmbAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuth.Name = "cmbAuth";
            // 
            // label4
            // 
            this.label4.AutoSize = false;
            this.label4.Location = new System.Drawing.Point(16, 184);
            this.label4.Size = new System.Drawing.Size(150, 27);
            this.label4.Text = "مستخدم SQL";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Name = "label4";
            // 
            // txtSqlUser
            // 
            this.txtSqlUser.Location = new System.Drawing.Point(176, 184);
            this.txtSqlUser.Size = new System.Drawing.Size(364, 27);
            this.txtSqlUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSqlUser.Name = "txtSqlUser";
            // 
            // label5
            // 
            this.label5.AutoSize = false;
            this.label5.Location = new System.Drawing.Point(16, 224);
            this.label5.Size = new System.Drawing.Size(150, 27);
            this.label5.Text = "كلمة مرور SQL";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Name = "label5";
            // 
            // txtSqlPass
            // 
            this.txtSqlPass.Location = new System.Drawing.Point(176, 224);
            this.txtSqlPass.Size = new System.Drawing.Size(364, 27);
            this.txtSqlPass.UseSystemPasswordChar = true;
            this.txtSqlPass.Name = "txtSqlPass";
            // 
            // label6
            // 
            this.label6.AutoSize = false;
            this.label6.Location = new System.Drawing.Point(16, 264);
            this.label6.Size = new System.Drawing.Size(150, 27);
            this.label6.Text = "اسم المؤسسة";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Name = "label6";
            // 
            // txtOrg
            // 
            this.txtOrg.Location = new System.Drawing.Point(176, 264);
            this.txtOrg.Size = new System.Drawing.Size(364, 27);
            this.txtOrg.Name = "txtOrg";
            // 
            // label7
            // 
            this.label7.AutoSize = false;
            this.label7.Location = new System.Drawing.Point(16, 304);
            this.label7.Size = new System.Drawing.Size(150, 27);
            this.label7.Text = "القسم";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Name = "label7";
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(176, 304);
            this.txtDept.Size = new System.Drawing.Size(364, 27);
            this.txtDept.Name = "txtDept";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnTest);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(560, 60);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 12);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(146, 12);
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Text = "إلغاء";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(276, 12);
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.FlatAppearance.BorderSize = 0;
            this.btnTest.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnTest.ForeColor = System.Drawing.Color.White;
            this.btnTest.Size = new System.Drawing.Size(170, 36);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTest.Text = "اختبار الاتصال";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Name = "btnTest";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.lblHeader.Size = new System.Drawing.Size(560, 48);
            this.lblHeader.Text = "إعدادات الاتصال بقاعدة البيانات";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // ConnectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(560, 412);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "إعدادات الاتصال بقاعدة البيانات";
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAuth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSqlUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSqlPass);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOrg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDept);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "ConnectionDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAuth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSqlUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSqlPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblHeader;
    }
}
