namespace AssetTracking.Pages
{
    partial class ReportsPage
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblPreviewTitle = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblPerson = new System.Windows.Forms.Label();
            this.cmbPerson = new System.Windows.Forms.ComboBox();
            this.lblAsset = new System.Windows.Forms.Label();
            this.cmbAsset = new System.Windows.Forms.ComboBox();
            this.lblSession = new System.Windows.Forms.Label();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.lblCustody = new System.Windows.Forms.Label();
            this.cmbCustody = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblMonths = new System.Windows.Forms.Label();
            this.numMonths = new System.Windows.Forms.NumericUpDown();
            this.lstReports = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.flpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonths)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grid);
            this.pnlMain.Controls.Add(this.lblPreviewTitle);
            this.pnlMain.Controls.Add(this.flpButtons);
            this.pnlMain.Controls.Add(this.flpFilters);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlMain.Name = "pnlMain";
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.White;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Name = "grid";
            // 
            // lblPreviewTitle
            // 
            this.lblPreviewTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPreviewTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPreviewTitle.Size = new System.Drawing.Size(600, 32);
            this.lblPreviewTitle.Text = "";
            this.lblPreviewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPreviewTitle.Name = "lblPreviewTitle";
            // 
            // flpButtons
            // 
            this.flpButtons.Controls.Add(this.btnShow);
            this.flpButtons.Controls.Add(this.btnPrint);
            this.flpButtons.Controls.Add(this.btnPdf);
            this.flpButtons.Controls.Add(this.btnExcel);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpButtons.AutoSize = true;
            this.flpButtons.BackColor = System.Drawing.Color.White;
            this.flpButtons.Padding = new System.Windows.Forms.Padding(10, 4, 10, 8);
            this.flpButtons.Name = "flpButtons";
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnShow.ForeColor = System.Drawing.Color.White;
            this.btnShow.Size = new System.Drawing.Size(110, 36);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShow.Text = "👁 عرض";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Name = "btnShow";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Size = new System.Drawing.Size(110, 36);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Text = "🖨 طباعة";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPdf.FlatAppearance.BorderSize = 0;
            this.btnPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPdf.ForeColor = System.Drawing.Color.White;
            this.btnPdf.Size = new System.Drawing.Size(90, 36);
            this.btnPdf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPdf.Text = "PDF";
            this.btnPdf.UseVisualStyleBackColor = false;
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Size = new System.Drawing.Size(90, 36);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // flpFilters
            // 
            this.flpFilters.Controls.Add(this.lblDepartment);
            this.flpFilters.Controls.Add(this.cmbDepartment);
            this.flpFilters.Controls.Add(this.lblLocation);
            this.flpFilters.Controls.Add(this.cmbLocation);
            this.flpFilters.Controls.Add(this.lblCategory);
            this.flpFilters.Controls.Add(this.cmbCategory);
            this.flpFilters.Controls.Add(this.lblStatus);
            this.flpFilters.Controls.Add(this.cmbStatus);
            this.flpFilters.Controls.Add(this.lblPerson);
            this.flpFilters.Controls.Add(this.cmbPerson);
            this.flpFilters.Controls.Add(this.lblAsset);
            this.flpFilters.Controls.Add(this.cmbAsset);
            this.flpFilters.Controls.Add(this.lblSession);
            this.flpFilters.Controls.Add(this.cmbSession);
            this.flpFilters.Controls.Add(this.lblUser);
            this.flpFilters.Controls.Add(this.cmbUser);
            this.flpFilters.Controls.Add(this.lblCustody);
            this.flpFilters.Controls.Add(this.cmbCustody);
            this.flpFilters.Controls.Add(this.lblFrom);
            this.flpFilters.Controls.Add(this.dtpFrom);
            this.flpFilters.Controls.Add(this.lblTo);
            this.flpFilters.Controls.Add(this.dtpTo);
            this.flpFilters.Controls.Add(this.lblMonths);
            this.flpFilters.Controls.Add(this.numMonths);
            this.flpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFilters.AutoSize = true;
            this.flpFilters.BackColor = System.Drawing.Color.White;
            this.flpFilters.Padding = new System.Windows.Forms.Padding(10, 8, 10, 6);
            this.flpFilters.Name = "flpFilters";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblDepartment.Text = "القسم:";
            this.lblDepartment.Name = "lblDepartment";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbDepartment.Size = new System.Drawing.Size(150, 28);
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.Name = "cmbDepartment";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblLocation.Text = "الموقع:";
            this.lblLocation.Name = "lblLocation";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbLocation.Size = new System.Drawing.Size(180, 28);
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Name = "cmbLocation";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblCategory.Text = "التصنيف:";
            this.lblCategory.Name = "lblCategory";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbCategory.Size = new System.Drawing.Size(150, 28);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Name = "cmbCategory";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblStatus.Text = "الحالة:";
            this.lblStatus.Name = "lblStatus";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbStatus.Size = new System.Drawing.Size(110, 28);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Name = "cmbStatus";
            // 
            // lblPerson
            // 
            this.lblPerson.AutoSize = true;
            this.lblPerson.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblPerson.Text = "الشخص:";
            this.lblPerson.Name = "lblPerson";
            // 
            // cmbPerson
            // 
            this.cmbPerson.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbPerson.Size = new System.Drawing.Size(200, 28);
            this.cmbPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerson.Name = "cmbPerson";
            // 
            // lblAsset
            // 
            this.lblAsset.AutoSize = true;
            this.lblAsset.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblAsset.Text = "الأصل:";
            this.lblAsset.Name = "lblAsset";
            // 
            // cmbAsset
            // 
            this.cmbAsset.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbAsset.Size = new System.Drawing.Size(240, 28);
            this.cmbAsset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsset.Name = "cmbAsset";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblSession.Text = "جلسة الجرد:";
            this.lblSession.Name = "lblSession";
            // 
            // cmbSession
            // 
            this.cmbSession.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbSession.Size = new System.Drawing.Size(200, 28);
            this.cmbSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSession.Name = "cmbSession";
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
            this.cmbUser.Size = new System.Drawing.Size(150, 28);
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.Name = "cmbUser";
            // 
            // lblCustody
            // 
            this.lblCustody.AutoSize = true;
            this.lblCustody.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblCustody.Text = "العملية:";
            this.lblCustody.Name = "lblCustody";
            // 
            // cmbCustody
            // 
            this.cmbCustody.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.cmbCustody.Size = new System.Drawing.Size(380, 28);
            this.cmbCustody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustody.Name = "cmbCustody";
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
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblMonths.Text = "خلال (شهر):";
            this.lblMonths.Name = "lblMonths";
            // 
            // numMonths
            // 
            this.numMonths.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.numMonths.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            this.numMonths.Size = new System.Drawing.Size(70, 27);
            this.numMonths.Value = new decimal(new int[] { 12, 0, 0, 0 });
            this.numMonths.Name = "numMonths";
            // 
            // lstReports
            // 
            this.lstReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstReports.Dock = System.Windows.Forms.DockStyle.Right;
            this.lstReports.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstReports.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lstReports.IntegralHeight = false;
            this.lstReports.ItemHeight = 34;
            this.lstReports.Size = new System.Drawing.Size(280, 560);
            this.lstReports.Name = "lstReports";
            this.lstReports.SelectedIndexChanged += new System.EventHandler(this.lstReports_SelectedIndexChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTitle.Size = new System.Drawing.Size(900, 44);
            this.lblTitle.Text = "التقارير";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // ReportsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.Padding = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.Size = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lstReports);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ReportsPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonths)).EndInit();
            this.flpFilters.ResumeLayout(false);
            this.flpFilters.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.flpButtons.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblPreviewTitle;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.ComboBox cmbPerson;
        private System.Windows.Forms.Label lblAsset;
        private System.Windows.Forms.ComboBox cmbAsset;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label lblCustody;
        private System.Windows.Forms.ComboBox cmbCustody;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.NumericUpDown numMonths;
        private System.Windows.Forms.ListBox lstReports;
        private System.Windows.Forms.Label lblTitle;
    }
}
