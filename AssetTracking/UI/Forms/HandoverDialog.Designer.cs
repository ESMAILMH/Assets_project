namespace AssetTracking.Forms
{
    partial class HandoverDialog
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
            this.cmbAsset = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPerson = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCondition = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
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
            this.label1.Text = "الأصل *";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Name = "label1";
            // 
            // cmbAsset
            // 
            this.cmbAsset.Location = new System.Drawing.Point(176, 64);
            this.cmbAsset.Size = new System.Drawing.Size(404, 28);
            this.cmbAsset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbAsset.Name = "cmbAsset";
            // 
            // label2
            // 
            this.label2.AutoSize = false;
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Size = new System.Drawing.Size(150, 27);
            this.label2.Text = "المستلم *";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Name = "label2";
            // 
            // cmbPerson
            // 
            this.cmbPerson.Location = new System.Drawing.Point(176, 104);
            this.cmbPerson.Size = new System.Drawing.Size(404, 28);
            this.cmbPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbPerson.Name = "cmbPerson";
            // 
            // label3
            // 
            this.label3.AutoSize = false;
            this.label3.Location = new System.Drawing.Point(16, 144);
            this.label3.Size = new System.Drawing.Size(150, 27);
            this.label3.Text = "تاريخ التسليم *";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Name = "label3";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(176, 144);
            this.dtpDate.CustomFormat = "yyyy/MM/dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Size = new System.Drawing.Size(160, 27);
            this.dtpDate.Name = "dtpDate";
            // 
            // label4
            // 
            this.label4.AutoSize = false;
            this.label4.Location = new System.Drawing.Point(16, 184);
            this.label4.Size = new System.Drawing.Size(150, 27);
            this.label4.Text = "حالة الأصل *";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Name = "label4";
            // 
            // cmbCondition
            // 
            this.cmbCondition.Location = new System.Drawing.Point(176, 184);
            this.cmbCondition.Size = new System.Drawing.Size(404, 28);
            this.cmbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondition.Name = "cmbCondition";
            // 
            // label5
            // 
            this.label5.AutoSize = false;
            this.label5.Location = new System.Drawing.Point(16, 224);
            this.label5.Size = new System.Drawing.Size(150, 27);
            this.label5.Text = "ملاحظات";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Name = "label5";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(176, 224);
            this.txtNotes.Size = new System.Drawing.Size(404, 27);
            this.txtNotes.Multiline = true;
            this.txtNotes.AcceptsReturn = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.MaxLength = 300;
            this.txtNotes.Name = "txtNotes";
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Text = "طباعة محضر التسليم بعد الحفظ";
            this.chkPrint.Checked = true;
            this.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrint.Location = new System.Drawing.Point(176, 301);
            this.chkPrint.Name = "chkPrint";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(600, 60);
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
            this.btnSave.Text = "تسليم";
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
            this.lblHeader.Size = new System.Drawing.Size(600, 48);
            this.lblHeader.Text = "تسليم أصل (عهدة شخصية)";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // HandoverDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 405);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تسليم أصل (عهدة شخصية)";
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAsset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPerson);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCondition);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.chkPrint);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "HandoverDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAsset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCondition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHeader;
    }
}
