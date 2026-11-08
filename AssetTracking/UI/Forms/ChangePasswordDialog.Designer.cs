namespace AssetTracking.Forms
{
    partial class ChangePasswordDialog
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
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Size = new System.Drawing.Size(150, 27);
            this.label1.Text = "كلمة المرور الحالية *";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Name = "label1";
            // 
            // txtCurrent
            // 
            this.txtCurrent.Location = new System.Drawing.Point(176, 64);
            this.txtCurrent.Size = new System.Drawing.Size(264, 27);
            this.txtCurrent.UseSystemPasswordChar = true;
            this.txtCurrent.Name = "txtCurrent";
            // 
            // label2
            // 
            this.label2.AutoSize = false;
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Size = new System.Drawing.Size(150, 27);
            this.label2.Text = "الجديدة *";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Name = "label2";
            // 
            // txtNew
            // 
            this.txtNew.Location = new System.Drawing.Point(176, 104);
            this.txtNew.Size = new System.Drawing.Size(264, 27);
            this.txtNew.UseSystemPasswordChar = true;
            this.txtNew.Name = "txtNew";
            // 
            // label3
            // 
            this.label3.AutoSize = false;
            this.label3.Location = new System.Drawing.Point(16, 144);
            this.label3.Size = new System.Drawing.Size(150, 27);
            this.label3.Text = "تأكيد الجديدة *";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Name = "label3";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(176, 144);
            this.txtConfirm.Size = new System.Drawing.Size(264, 27);
            this.txtConfirm.UseSystemPasswordChar = true;
            this.txtConfirm.Name = "txtConfirm";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(460, 60);
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
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.lblHeader.Size = new System.Drawing.Size(460, 48);
            this.lblHeader.Text = "تغيير كلمة المرور";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // ChangePasswordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(460, 252);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تغيير كلمة المرور";
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "ChangePasswordDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHeader;
    }
}
