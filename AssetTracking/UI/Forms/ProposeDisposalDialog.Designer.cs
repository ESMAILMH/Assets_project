namespace AssetTracking.Forms
{
    partial class ProposeDisposalDialog
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
            this.lblBookValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRemainingValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
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
            this.label2.Text = "القيمة الدفترية";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Name = "label2";
            // 
            // lblBookValue
            // 
            this.lblBookValue.AutoSize = false;
            this.lblBookValue.Location = new System.Drawing.Point(176, 100);
            this.lblBookValue.Size = new System.Drawing.Size(344, 27);
            this.lblBookValue.Text = "—";
            this.lblBookValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBookValue.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblBookValue.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblBookValue.Name = "lblBookValue";
            // 
            // label3
            // 
            this.label3.AutoSize = false;
            this.label3.Location = new System.Drawing.Point(16, 136);
            this.label3.Size = new System.Drawing.Size(150, 27);
            this.label3.Text = "المتبقي من العمر";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Name = "label3";
            // 
            // lblRemainingValue
            // 
            this.lblRemainingValue.AutoSize = false;
            this.lblRemainingValue.Location = new System.Drawing.Point(176, 136);
            this.lblRemainingValue.Size = new System.Drawing.Size(344, 27);
            this.lblRemainingValue.Text = "—";
            this.lblRemainingValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRemainingValue.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblRemainingValue.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblRemainingValue.Name = "lblRemainingValue";
            // 
            // label4
            // 
            this.label4.AutoSize = false;
            this.label4.Location = new System.Drawing.Point(16, 172);
            this.label4.Size = new System.Drawing.Size(150, 27);
            this.label4.Text = "سبب التخريد *";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Name = "label4";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(176, 172);
            this.txtReason.Size = new System.Drawing.Size(344, 27);
            this.txtReason.Multiline = true;
            this.txtReason.AcceptsReturn = true;
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.MaxLength = 300;
            this.txtReason.Name = "txtReason";
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
            this.btnSave.Size = new System.Drawing.Size(170, 36);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Text = "إرسال للمدير";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(196, 12);
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
            this.lblHeader.Text = "اقتراح إحالة للتخريد";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // ProposeDisposalDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(540, 317);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "اقتراح إحالة للتخريد";
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAssetValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBookValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRemainingValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "ProposeDisposalDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAssetValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBookValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRemainingValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblHeader;
    }
}
