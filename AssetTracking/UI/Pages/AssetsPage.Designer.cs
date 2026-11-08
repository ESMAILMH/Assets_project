namespace AssetTracking.Pages
{
    partial class AssetsPage
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
            this.pnlPhoto = new System.Windows.Forms.Panel();
            this.flpPhotoButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPhotoChange = new System.Windows.Forms.Button();
            this.btnPhotoRemove = new System.Windows.Forms.Button();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.lblNoPhoto = new System.Windows.Forms.Label();
            this.lblPhotoTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnHandover = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnDispose = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlGrid.SuspendLayout();
            this.pnlPhoto.SuspendLayout();
            this.flpPhotoButtons.SuspendLayout();
            this.flpActions.SuspendLayout();
            this.flpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).BeginInit();
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
            // pnlPhoto
            // 
            this.pnlPhoto.Controls.Add(this.flpPhotoButtons);
            this.pnlPhoto.Controls.Add(this.picPhoto);
            this.pnlPhoto.Controls.Add(this.lblPhotoTitle);
            this.pnlPhoto.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPhoto.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.pnlPhoto.Size = new System.Drawing.Size(270, 400);
            this.pnlPhoto.Name = "pnlPhoto";
            // 
            // flpPhotoButtons
            // 
            this.flpPhotoButtons.Controls.Add(this.btnPhotoChange);
            this.flpPhotoButtons.Controls.Add(this.btnPhotoRemove);
            this.flpPhotoButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpPhotoButtons.AutoSize = true;
            this.flpPhotoButtons.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flpPhotoButtons.Name = "flpPhotoButtons";
            // 
            // btnPhotoChange
            // 
            this.btnPhotoChange.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnPhotoChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhotoChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhotoChange.FlatAppearance.BorderSize = 0;
            this.btnPhotoChange.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhotoChange.ForeColor = System.Drawing.Color.White;
            this.btnPhotoChange.Size = new System.Drawing.Size(230, 36);
            this.btnPhotoChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPhotoChange.Text = "🖼 إضافة / تغيير الصورة";
            this.btnPhotoChange.UseVisualStyleBackColor = false;
            this.btnPhotoChange.Name = "btnPhotoChange";
            this.btnPhotoChange.Click += new System.EventHandler(this.btnPhotoChange_Click);
            // 
            // btnPhotoRemove
            // 
            this.btnPhotoRemove.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnPhotoRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhotoRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhotoRemove.FlatAppearance.BorderSize = 0;
            this.btnPhotoRemove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhotoRemove.ForeColor = System.Drawing.Color.White;
            this.btnPhotoRemove.Size = new System.Drawing.Size(230, 36);
            this.btnPhotoRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPhotoRemove.Text = "حذف الصورة";
            this.btnPhotoRemove.UseVisualStyleBackColor = false;
            this.btnPhotoRemove.Name = "btnPhotoRemove";
            this.btnPhotoRemove.Click += new System.EventHandler(this.btnPhotoRemove_Click);
            // 
            // picPhoto
            // 
            this.picPhoto.Controls.Add(this.lblNoPhoto);
            this.picPhoto.BackColor = System.Drawing.Color.White;
            this.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPhoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.picPhoto.Size = new System.Drawing.Size(258, 230);
            this.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoto.Name = "picPhoto";
            this.picPhoto.DoubleClick += new System.EventHandler(this.picPhoto_DoubleClick);
            // 
            // lblNoPhoto
            // 
            this.lblNoPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoPhoto.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblNoPhoto.Text = "لا توجد صورة";
            this.lblNoPhoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoPhoto.Name = "lblNoPhoto";
            this.lblNoPhoto.DoubleClick += new System.EventHandler(this.picPhoto_DoubleClick);
            // 
            // lblPhotoTitle
            // 
            this.lblPhotoTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPhotoTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhotoTitle.Size = new System.Drawing.Size(258, 52);
            this.lblPhotoTitle.Text = "اختر أصلاً لعرض صورته";
            this.lblPhotoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPhotoTitle.Name = "lblPhotoTitle";
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
            this.flpActions.Controls.Add(this.btnAdd);
            this.flpActions.Controls.Add(this.btnImport);
            this.flpActions.Controls.Add(this.btnCard);
            this.flpActions.Controls.Add(this.btnHandover);
            this.flpActions.Controls.Add(this.btnReceive);
            this.flpActions.Controls.Add(this.btnMaintenance);
            this.flpActions.Controls.Add(this.btnHistory);
            this.flpActions.Controls.Add(this.btnDispose);
            this.flpActions.Controls.Add(this.btnArchive);
            this.flpActions.Controls.Add(this.btnPrint);
            this.flpActions.Controls.Add(this.btnExcel);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpActions.AutoSize = true;
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.flpActions.Name = "flpActions";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Size = new System.Drawing.Size(130, 36);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Text = "➕ إضافة";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Size = new System.Drawing.Size(170, 36);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImport.Text = "📥 استيراد Excel";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Name = "btnImport";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCard.FlatAppearance.BorderSize = 0;
            this.btnCard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCard.ForeColor = System.Drawing.Color.White;
            this.btnCard.Size = new System.Drawing.Size(170, 36);
            this.btnCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCard.Text = "📄 بطاقة / تعديل";
            this.btnCard.UseVisualStyleBackColor = false;
            this.btnCard.Name = "btnCard";
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnHandover
            // 
            this.btnHandover.BackColor = System.Drawing.Color.FromArgb(214, 137, 16);
            this.btnHandover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHandover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHandover.FlatAppearance.BorderSize = 0;
            this.btnHandover.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHandover.ForeColor = System.Drawing.Color.White;
            this.btnHandover.Size = new System.Drawing.Size(130, 36);
            this.btnHandover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHandover.Text = "📤 تسليم";
            this.btnHandover.UseVisualStyleBackColor = false;
            this.btnHandover.Name = "btnHandover";
            this.btnHandover.Click += new System.EventHandler(this.btnHandover_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.BackColor = System.Drawing.Color.FromArgb(214, 137, 16);
            this.btnReceive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceive.FlatAppearance.BorderSize = 0;
            this.btnReceive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReceive.ForeColor = System.Drawing.Color.White;
            this.btnReceive.Size = new System.Drawing.Size(130, 36);
            this.btnReceive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReceive.Text = "↩ استلام";
            this.btnReceive.UseVisualStyleBackColor = false;
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintenance.FlatAppearance.BorderSize = 0;
            this.btnMaintenance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMaintenance.ForeColor = System.Drawing.Color.White;
            this.btnMaintenance.Size = new System.Drawing.Size(130, 36);
            this.btnMaintenance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMaintenance.Text = "🔧 الصيانة";
            this.btnMaintenance.UseVisualStyleBackColor = false;
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.FlatAppearance.BorderSize = 0;
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Size = new System.Drawing.Size(130, 36);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHistory.Text = "🕘 الحركات";
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnDispose
            // 
            this.btnDispose.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnDispose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDispose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispose.FlatAppearance.BorderSize = 0;
            this.btnDispose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDispose.ForeColor = System.Drawing.Color.White;
            this.btnDispose.Size = new System.Drawing.Size(170, 36);
            this.btnDispose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDispose.Text = "♻ اقتراح تخريد";
            this.btnDispose.UseVisualStyleBackColor = false;
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Click += new System.EventHandler(this.btnDispose_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnArchive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnArchive.ForeColor = System.Drawing.Color.White;
            this.btnArchive.Size = new System.Drawing.Size(170, 36);
            this.btnArchive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnArchive.Text = "🗄 أرشفة / استرجاع";
            this.btnArchive.UseVisualStyleBackColor = false;
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
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
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
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
            this.flpFilters.Controls.Add(this.lblSearch);
            this.flpFilters.Controls.Add(this.txtSearch);
            this.flpFilters.Controls.Add(this.lblCategory);
            this.flpFilters.Controls.Add(this.cmbCategory);
            this.flpFilters.Controls.Add(this.lblDepartment);
            this.flpFilters.Controls.Add(this.cmbDepartment);
            this.flpFilters.Controls.Add(this.lblLocation);
            this.flpFilters.Controls.Add(this.cmbLocation);
            this.flpFilters.Controls.Add(this.lblStatus);
            this.flpFilters.Controls.Add(this.cmbStatus);
            this.flpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFilters.AutoSize = true;
            this.flpFilters.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.flpFilters.Name = "flpFilters";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblSearch.Text = "بحث:";
            this.lblSearch.Name = "lblSearch";
            // 
            // txtSearch
            // 
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.txtSearch.Size = new System.Drawing.Size(240, 27);
            this.txtSearch.Name = "txtSearch";
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
            this.cmbLocation.Size = new System.Drawing.Size(170, 28);
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Name = "cmbLocation";
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
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTitle.Size = new System.Drawing.Size(900, 42);
            this.lblTitle.Text = "الأصول";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // AssetsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.Padding = new System.Windows.Forms.Padding(20, 14, 20, 10);
            this.Size = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlPhoto);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.flpActions);
            this.Controls.Add(this.flpFilters);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "AssetsPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.flpFilters.ResumeLayout(false);
            this.flpFilters.PerformLayout();
            this.flpActions.ResumeLayout(false);
            this.flpActions.PerformLayout();
            this.flpPhotoButtons.ResumeLayout(false);
            this.flpPhotoButtons.PerformLayout();
            this.pnlPhoto.ResumeLayout(false);
            this.pnlPhoto.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel pnlPhoto;
        private System.Windows.Forms.FlowLayoutPanel flpPhotoButtons;
        private System.Windows.Forms.Button btnPhotoChange;
        private System.Windows.Forms.Button btnPhotoRemove;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Label lblNoPhoto;
        private System.Windows.Forms.Label lblPhotoTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Button btnHandover;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnDispose;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblTitle;
    }
}
