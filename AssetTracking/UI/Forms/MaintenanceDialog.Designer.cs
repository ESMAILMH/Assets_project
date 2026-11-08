namespace AssetTracking.Forms
{
    partial class MaintenanceDialog
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
            this.lblAssetValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPerformedBy = new System.Windows.Forms.TextBox();
            this.chkHasCost = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numCost = new System.Windows.Forms.NumericUpDown();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Size = new System.Drawing.Size(150, 27);
            this.label1.Text = "الأصل";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Name = "label1";
            // 
            // lblAssetValue
            // 
            this.lblAssetValue.AutoSize = false;
            this.lblAssetValue.Location = new System.Drawing.Point(176, 64);
            this.lblAssetValue.Size = new System.Drawing.Size(344, 27);
            this.lblAssetValue.Text = "—";
            this.lblAssetValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAssetValue.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblAssetValue.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblAssetValue.Name = "lblAssetValue";
            // 
            // label2
            // 
            this.label2.AutoSize = false;
            this.label2.Location = new System.Drawing.Point(16, 100);
            this.label2.Size = new System.Drawing.Size(150, 27);
            this.label2.Text = "التاريخ *";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Name = "label2";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(176, 100);
            this.dtpDate.CustomFormat = "yyyy/MM/dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Size = new System.Drawing.Size(160, 27);
            this.dtpDate.Name = "dtpDate";
            // 
            // label3
            // 
            this.label3.AutoSize = false;
            this.label3.Location = new System.Drawing.Point(16, 140);
            this.label3.Size = new System.Drawing.Size(150, 27);
            this.label3.Text = "النوع *";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Name = "label3";
            // 
            // cmbType
            // 
            this.cmbType.Location = new System.Drawing.Point(176, 140);
            this.cmbType.Size = new System.Drawing.Size(344, 28);
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbType.Name = "cmbType";
            // 
            // label4
            // 
            this.label4.AutoSize = false;
            this.label4.Location = new System.Drawing.Point(16, 180);
            this.label4.Size = new System.Drawing.Size(150, 27);
            this.label4.Text = "الوصف";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Name = "label4";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(176, 180);
            this.txtDescription.Size = new System.Drawing.Size(344, 27);
            this.txtDescription.Multiline = true;
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Name = "txtDescription";
            // 
            // label5
            // 
            this.label5.AutoSize = false;
            this.label5.Location = new System.Drawing.Point(16, 257);
            this.label5.Size = new System.Drawing.Size(150, 27);
            this.label5.Text = "الجهة المنفذة";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Name = "label5";
            // 
            // txtPerformedBy
            // 
            this.txtPerformedBy.Location = new System.Drawing.Point(176, 257);
            this.txtPerformedBy.Size = new System.Drawing.Size(344, 27);
            this.txtPerformedBy.MaxLength = 100;
            this.txtPerformedBy.Name = "txtPerformedBy";
            // 
            // chkHasCost
            // 
            this.chkHasCost.AutoSize = true;
            this.chkHasCost.Text = "لها تكلفة";
            this.chkHasCost.Location = new System.Drawing.Point(176, 297);
            this.chkHasCost.Name = "chkHasCost";
            // 
            // label6
            // 
            this.label6.AutoSize = false;
            this.label6.Location = new System.Drawing.Point(16, 333);
            this.label6.Size = new System.Drawing.Size(150, 27);
            this.label6.Text = "التكلفة (د.ل)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Name = "label6";
            // 
            // numCost
            // 
            this.numCost.DecimalPlaces = 3;
            this.numCost.Location = new System.Drawing.Point(176, 333);
            this.numCost.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numCost.Size = new System.Drawing.Size(180, 27);
            this.numCost.ThousandsSeparator = true;
            this.numCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCost.Name = "numCost";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(540, 60);
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
            this.lblHeader.Size = new System.Drawing.Size(540, 48);
            this.lblHeader.Text = "تسجيل صيانة";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // MaintenanceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(540, 441);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "تسجيل صيانة";
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAssetValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPerformedBy);
            this.Controls.Add(this.chkHasCost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numCost);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "MaintenanceDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAssetValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPerformedBy;
        private System.Windows.Forms.CheckBox chkHasCost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numCost;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHeader;
    }
}
