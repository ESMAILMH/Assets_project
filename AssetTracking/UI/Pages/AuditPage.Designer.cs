namespace AssetTracking.Pages
{
    partial class AuditPage
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
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlGrid.SuspendLayout();
            this.flpActions.SuspendLayout();
            this.flpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grid);
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(222, 226, 232);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pnlGrid.Name = "pnlGrid";
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Name = "grid";
            // 
            // lblCount
            // 
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblCount.Size = new System.Drawing.Size(900, 28);
            this.lblCount.Text = "";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCount.Name = "lblCount";
            // 
            // flpActions
            // 
            this.flpActions.Controls.Add(this.btnPrint);
            this.flpActions.Controls.Add(this.btnExcel);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpActions.AutoSize = true;
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.flpActions.Name = "flpActions";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Size = new System.Drawing.Size(130, 36);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Text = "🖨 طباعة";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Size = new System.Drawing.Size(100, 36);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // flpFilters
            // 
            this.flpFilters.Controls.Add(this.lblUser);
            this.flpFilters.Controls.Add(this.cmbUser);
            this.flpFilters.Controls.Add(this.lblFrom);
            this.flpFilters.Controls.Add(this.dtpFrom);
            this.flpFilters.Controls.Add(this.lblTo);
            this.flpFilters.Controls.Add(this.dtpTo);
            this.flpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFilters.AutoSize = true;
            this.flpFilters.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.flpFilters.Name = "flpFilters";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblUser.Text = "المستخدم:";
            this.lblUser.Name = "lblUser";
            // 
            // cmbUser
            // 
            this.cmbUser.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbUser.Size = new System.Drawing.Size(180, 28);
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Name = "cmbUser";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblFrom.Text = "من:";
            this.lblFrom.Name = "lblFrom";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.dtpFrom.CustomFormat = "yyyy/MM/dd";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Size = new System.Drawing.Size(150, 27);
            this.dtpFrom.Name = "dtpFrom";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblTo.Text = "إلى:";
            this.lblTo.Name = "lblTo";
            // 
            // dtpTo
            // 
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.dtpTo.CustomFormat = "yyyy/MM/dd";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Size = new System.Drawing.Size(150, 27);
            this.dtpTo.Name = "dtpTo";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTitle.Size = new System.Drawing.Size(900, 42);
            this.lblTitle.Text = "سجل العمليات";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // AuditPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.Padding = new System.Windows.Forms.Padding(20, 14, 20, 10);
            this.Size = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.flpActions);
            this.Controls.Add(this.flpFilters);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "AuditPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.flpFilters.ResumeLayout(false);
            this.flpFilters.PerformLayout();
            this.flpActions.ResumeLayout(false);
            this.flpActions.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTitle;
    }
}
