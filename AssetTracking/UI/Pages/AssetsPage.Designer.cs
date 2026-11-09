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
            this.pnlDetailsGap = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblValSerial = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.lblValCategory = new System.Windows.Forms.Label();
            this.lblInfo3 = new System.Windows.Forms.Label();
            this.lblValLocation = new System.Windows.Forms.Label();
            this.lblInfo4 = new System.Windows.Forms.Label();
            this.lblValStatus = new System.Windows.Forms.Label();
            this.lblInfo5 = new System.Windows.Forms.Label();
            this.lblValHolder = new System.Windows.Forms.Label();
            this.lblInfo6 = new System.Windows.Forms.Label();
            this.lblValCost = new System.Windows.Forms.Label();
            this.lblInfo7 = new System.Windows.Forms.Label();
            this.lblValBook = new System.Windows.Forms.Label();
            this.lblInfo8 = new System.Windows.Forms.Label();
            this.lblValRemaining = new System.Windows.Forms.Label();
            this.flpPhotoButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPhotoChange = new System.Windows.Forms.Button();
            this.btnPhotoRemove = new System.Windows.Forms.Button();
            this.picPhoto = new System.Windows.Forms.PictureBox();
            this.lblNoPhoto = new System.Windows.Forms.Label();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnHandover = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnDispose = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.flpStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStatusAll = new System.Windows.Forms.Button();
            this.btnStatusAvailable = new System.Windows.Forms.Button();
            this.btnStatusInCustody = new System.Windows.Forms.Button();
            this.btnStatusDisposed = new System.Windows.Forms.Button();
            this.btnStatusArchived = new System.Windows.Forms.Button();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlGrid.SuspendLayout();
            this.pnlDetailsGap.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.flpPhotoButtons.SuspendLayout();
            this.flpActions.SuspendLayout();
            this.flpStatus.SuspendLayout();
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
            // pnlDetailsGap
            // 
            this.pnlDetailsGap.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetailsGap.Size = new System.Drawing.Size(12, 560);
            this.pnlDetailsGap.Name = "pnlDetailsGap";
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.pnlInfo);
            this.pnlDetails.Controls.Add(this.flpPhotoButtons);
            this.pnlDetails.Controls.Add(this.picPhoto);
            this.pnlDetails.Controls.Add(this.lblDetailsTitle);
            this.pnlDetails.BackColor = System.Drawing.Color.White;
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDetails.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.pnlDetails.Size = new System.Drawing.Size(300, 560);
            this.pnlDetails.Name = "pnlDetails";
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblInfo1);
            this.pnlInfo.Controls.Add(this.lblValSerial);
            this.pnlInfo.Controls.Add(this.lblInfo2);
            this.pnlInfo.Controls.Add(this.lblValCategory);
            this.pnlInfo.Controls.Add(this.lblInfo3);
            this.pnlInfo.Controls.Add(this.lblValLocation);
            this.pnlInfo.Controls.Add(this.lblInfo4);
            this.pnlInfo.Controls.Add(this.lblValStatus);
            this.pnlInfo.Controls.Add(this.lblInfo5);
            this.pnlInfo.Controls.Add(this.lblValHolder);
            this.pnlInfo.Controls.Add(this.lblInfo6);
            this.pnlInfo.Controls.Add(this.lblValCost);
            this.pnlInfo.Controls.Add(this.lblInfo7);
            this.pnlInfo.Controls.Add(this.lblValBook);
            this.pnlInfo.Controls.Add(this.lblInfo8);
            this.pnlInfo.Controls.Add(this.lblValRemaining);
            this.pnlInfo.AutoScroll = true;
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInfo.Name = "pnlInfo";
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = false;
            this.lblInfo1.Location = new System.Drawing.Point(0, 4);
            this.lblInfo1.Size = new System.Drawing.Size(112, 28);
            this.lblInfo1.Text = "الرقم التسلسلي";
            this.lblInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo1.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInfo1.Name = "lblInfo1";
            // 
            // lblValSerial
            // 
            this.lblValSerial.AutoSize = false;
            this.lblValSerial.Location = new System.Drawing.Point(112, 4);
            this.lblValSerial.Size = new System.Drawing.Size(160, 28);
            this.lblValSerial.Text = "—";
            this.lblValSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValSerial.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblValSerial.Name = "lblValSerial";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = false;
            this.lblInfo2.Location = new System.Drawing.Point(0, 36);
            this.lblInfo2.Size = new System.Drawing.Size(112, 28);
            this.lblInfo2.Text = "التصنيف";
            this.lblInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo2.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInfo2.Name = "lblInfo2";
            // 
            // lblValCategory
            // 
            this.lblValCategory.AutoSize = false;
            this.lblValCategory.Location = new System.Drawing.Point(112, 36);
            this.lblValCategory.Size = new System.Drawing.Size(160, 28);
            this.lblValCategory.Text = "—";
            this.lblValCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValCategory.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblValCategory.Name = "lblValCategory";
            // 
            // lblInfo3
            // 
            this.lblInfo3.AutoSize = false;
            this.lblInfo3.Location = new System.Drawing.Point(0, 68);
            this.lblInfo3.Size = new System.Drawing.Size(112, 28);
            this.lblInfo3.Text = "الموقع";
            this.lblInfo3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo3.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInfo3.Name = "lblInfo3";
            // 
            // lblValLocation
            // 
            this.lblValLocation.AutoSize = false;
            this.lblValLocation.Location = new System.Drawing.Point(112, 68);
            this.lblValLocation.Size = new System.Drawing.Size(160, 28);
            this.lblValLocation.Text = "—";
            this.lblValLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValLocation.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblValLocation.Name = "lblValLocation";
            // 
            // lblInfo4
            // 
            this.lblInfo4.AutoSize = false;
            this.lblInfo4.Location = new System.Drawing.Point(0, 100);
            this.lblInfo4.Size = new System.Drawing.Size(112, 28);
            this.lblInfo4.Text = "الحالة";
            this.lblInfo4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo4.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInfo4.Name = "lblInfo4";
            // 
            // lblValStatus
            // 
            this.lblValStatus.AutoSize = false;
            this.lblValStatus.Location = new System.Drawing.Point(112, 100);
            this.lblValStatus.Size = new System.Drawing.Size(160, 28);
            this.lblValStatus.Text = "—";
            this.lblValStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValStatus.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblValStatus.Name = "lblValStatus";
            // 
            // lblInfo5
            // 
            this.lblInfo5.AutoSize = false;
            this.lblInfo5.Location = new System.Drawing.Point(0, 132);
            this.lblInfo5.Size = new System.Drawing.Size(112, 28);
            this.lblInfo5.Text = "صاحب العهدة";
            this.lblInfo5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo5.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInfo5.Name = "lblInfo5";
            // 
            // lblValHolder
            // 
            this.lblValHolder.AutoSize = false;
            this.lblValHolder.Location = new System.Drawing.Point(112, 132);
            this.lblValHolder.Size = new System.Drawing.Size(160, 28);
            this.lblValHolder.Text = "—";
            this.lblValHolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValHolder.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblValHolder.Name = "lblValHolder";
            // 
            // lblInfo6
            // 
            this.lblInfo6.AutoSize = false;
            this.lblInfo6.Location = new System.Drawing.Point(0, 164);
            this.lblInfo6.Size = new System.Drawing.Size(112, 28);
            this.lblInfo6.Text = "التكلفة";
            this.lblInfo6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo6.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInfo6.Name = "lblInfo6";
            // 
            // lblValCost
            // 
            this.lblValCost.AutoSize = false;
            this.lblValCost.Location = new System.Drawing.Point(112, 164);
            this.lblValCost.Size = new System.Drawing.Size(160, 28);
            this.lblValCost.Text = "—";
            this.lblValCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValCost.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblValCost.Name = "lblValCost";
            // 
            // lblInfo7
            // 
            this.lblInfo7.AutoSize = false;
            this.lblInfo7.Location = new System.Drawing.Point(0, 196);
            this.lblInfo7.Size = new System.Drawing.Size(112, 28);
            this.lblInfo7.Text = "القيمة الدفترية";
            this.lblInfo7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo7.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInfo7.Name = "lblInfo7";
            // 
            // lblValBook
            // 
            this.lblValBook.AutoSize = false;
            this.lblValBook.Location = new System.Drawing.Point(112, 196);
            this.lblValBook.Size = new System.Drawing.Size(160, 28);
            this.lblValBook.Text = "—";
            this.lblValBook.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValBook.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblValBook.Name = "lblValBook";
            // 
            // lblInfo8
            // 
            this.lblInfo8.AutoSize = false;
            this.lblInfo8.Location = new System.Drawing.Point(0, 228);
            this.lblInfo8.Size = new System.Drawing.Size(112, 28);
            this.lblInfo8.Text = "المتبقي من العمر";
            this.lblInfo8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo8.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblInfo8.Name = "lblInfo8";
            // 
            // lblValRemaining
            // 
            this.lblValRemaining.AutoSize = false;
            this.lblValRemaining.Location = new System.Drawing.Point(112, 228);
            this.lblValRemaining.Size = new System.Drawing.Size(160, 28);
            this.lblValRemaining.Text = "—";
            this.lblValRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValRemaining.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblValRemaining.Name = "lblValRemaining";
            // 
            // flpPhotoButtons
            // 
            this.flpPhotoButtons.Controls.Add(this.btnPhotoChange);
            this.flpPhotoButtons.Controls.Add(this.btnPhotoRemove);
            this.flpPhotoButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpPhotoButtons.AutoSize = true;
            this.flpPhotoButtons.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.flpPhotoButtons.Name = "flpPhotoButtons";
            // 
            // btnPhotoChange
            // 
            this.btnPhotoChange.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnPhotoChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhotoChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhotoChange.FlatAppearance.BorderSize = 0;
            this.btnPhotoChange.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhotoChange.ForeColor = System.Drawing.Color.White;
            this.btnPhotoChange.Size = new System.Drawing.Size(132, 36);
            this.btnPhotoChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPhotoChange.Text = "🖼 تغيير الصورة";
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
            this.btnPhotoRemove.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhotoRemove.ForeColor = System.Drawing.Color.White;
            this.btnPhotoRemove.Size = new System.Drawing.Size(132, 36);
            this.btnPhotoRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPhotoRemove.Text = "حذف الصورة";
            this.btnPhotoRemove.UseVisualStyleBackColor = false;
            this.btnPhotoRemove.Name = "btnPhotoRemove";
            this.btnPhotoRemove.Click += new System.EventHandler(this.btnPhotoRemove_Click);
            // 
            // picPhoto
            // 
            this.picPhoto.Controls.Add(this.lblNoPhoto);
            this.picPhoto.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.picPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPhoto.Dock = System.Windows.Forms.DockStyle.Top;
            this.picPhoto.Size = new System.Drawing.Size(276, 190);
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
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoEllipsis = true;
            this.lblDetailsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblDetailsTitle.Size = new System.Drawing.Size(276, 40);
            this.lblDetailsTitle.Text = "اختر أصلاً من الجدول";
            this.lblDetailsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetailsTitle.Name = "lblDetailsTitle";
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
            this.btnAdd.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Size = new System.Drawing.Size(140, 36);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Text = "➕ إضافة أصل";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCard.FlatAppearance.BorderSize = 0;
            this.btnCard.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnCard.ForeColor = System.Drawing.Color.White;
            this.btnCard.Size = new System.Drawing.Size(160, 36);
            this.btnCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCard.Text = "📄 البطاقة / تعديل";
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
            this.btnHandover.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnHandover.ForeColor = System.Drawing.Color.White;
            this.btnHandover.Size = new System.Drawing.Size(110, 36);
            this.btnHandover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHandover.Text = "📤 تسليم";
            this.btnHandover.UseVisualStyleBackColor = false;
            this.btnHandover.Name = "btnHandover";
            this.btnHandover.Click += new System.EventHandler(this.btnHandover_Click);
            // 
            // btnReceive
            // 
            this.btnReceive.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnReceive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceive.FlatAppearance.BorderSize = 0;
            this.btnReceive.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnReceive.ForeColor = System.Drawing.Color.White;
            this.btnReceive.Size = new System.Drawing.Size(110, 36);
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
            this.btnMaintenance.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnMaintenance.ForeColor = System.Drawing.Color.White;
            this.btnMaintenance.Size = new System.Drawing.Size(120, 36);
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
            this.btnHistory.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Size = new System.Drawing.Size(120, 36);
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
            this.btnDispose.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnDispose.ForeColor = System.Drawing.Color.White;
            this.btnDispose.Size = new System.Drawing.Size(150, 36);
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
            this.btnArchive.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnArchive.ForeColor = System.Drawing.Color.White;
            this.btnArchive.Size = new System.Drawing.Size(130, 36);
            this.btnArchive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnArchive.Text = "🗄 أرشفة";
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
            this.btnPrint.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Size = new System.Drawing.Size(110, 36);
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
            this.btnExcel.Size = new System.Drawing.Size(90, 36);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // flpStatus
            // 
            this.flpStatus.Controls.Add(this.btnStatusAll);
            this.flpStatus.Controls.Add(this.btnStatusAvailable);
            this.flpStatus.Controls.Add(this.btnStatusInCustody);
            this.flpStatus.Controls.Add(this.btnStatusDisposed);
            this.flpStatus.Controls.Add(this.btnStatusArchived);
            this.flpStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpStatus.AutoSize = true;
            this.flpStatus.Padding = new System.Windows.Forms.Padding(0, 6, 0, 8);
            this.flpStatus.Name = "flpStatus";
            // 
            // btnStatusAll
            // 
            this.btnStatusAll.BackColor = System.Drawing.Color.White;
            this.btnStatusAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatusAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnStatusAll.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnStatusAll.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnStatusAll.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnStatusAll.Size = new System.Drawing.Size(130, 34);
            this.btnStatusAll.Tag = "";
            this.btnStatusAll.Text = "الكل";
            this.btnStatusAll.UseVisualStyleBackColor = false;
            this.btnStatusAll.Name = "btnStatusAll";
            // 
            // btnStatusAvailable
            // 
            this.btnStatusAvailable.BackColor = System.Drawing.Color.White;
            this.btnStatusAvailable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatusAvailable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusAvailable.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnStatusAvailable.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnStatusAvailable.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnStatusAvailable.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnStatusAvailable.Size = new System.Drawing.Size(130, 34);
            this.btnStatusAvailable.Tag = "Available";
            this.btnStatusAvailable.Text = "متاح";
            this.btnStatusAvailable.UseVisualStyleBackColor = false;
            this.btnStatusAvailable.Name = "btnStatusAvailable";
            // 
            // btnStatusInCustody
            // 
            this.btnStatusInCustody.BackColor = System.Drawing.Color.White;
            this.btnStatusInCustody.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatusInCustody.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusInCustody.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnStatusInCustody.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnStatusInCustody.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnStatusInCustody.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnStatusInCustody.Size = new System.Drawing.Size(130, 34);
            this.btnStatusInCustody.Tag = "InCustody";
            this.btnStatusInCustody.Text = "في عهدة";
            this.btnStatusInCustody.UseVisualStyleBackColor = false;
            this.btnStatusInCustody.Name = "btnStatusInCustody";
            // 
            // btnStatusDisposed
            // 
            this.btnStatusDisposed.BackColor = System.Drawing.Color.White;
            this.btnStatusDisposed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatusDisposed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusDisposed.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnStatusDisposed.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnStatusDisposed.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnStatusDisposed.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnStatusDisposed.Size = new System.Drawing.Size(130, 34);
            this.btnStatusDisposed.Tag = "Disposed";
            this.btnStatusDisposed.Text = "مُخرَّد";
            this.btnStatusDisposed.UseVisualStyleBackColor = false;
            this.btnStatusDisposed.Name = "btnStatusDisposed";
            // 
            // btnStatusArchived
            // 
            this.btnStatusArchived.BackColor = System.Drawing.Color.White;
            this.btnStatusArchived.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatusArchived.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatusArchived.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnStatusArchived.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnStatusArchived.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnStatusArchived.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnStatusArchived.Size = new System.Drawing.Size(130, 34);
            this.btnStatusArchived.Tag = "Archived";
            this.btnStatusArchived.Text = "مؤرشف";
            this.btnStatusArchived.UseVisualStyleBackColor = false;
            this.btnStatusArchived.Name = "btnStatusArchived";
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
            this.flpFilters.Controls.Add(this.btnClearFilters);
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
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnClearFilters.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.FlatAppearance.BorderSize = 0;
            this.btnClearFilters.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearFilters.Size = new System.Drawing.Size(140, 32);
            this.btnClearFilters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearFilters.Text = "✕ مسح التصفية";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
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
            this.Size = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlDetailsGap);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.flpActions);
            this.Controls.Add(this.flpStatus);
            this.Controls.Add(this.flpFilters);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "AssetsPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoto)).EndInit();
            this.flpFilters.ResumeLayout(false);
            this.flpFilters.PerformLayout();
            this.flpStatus.ResumeLayout(false);
            this.flpStatus.PerformLayout();
            this.flpActions.ResumeLayout(false);
            this.flpActions.PerformLayout();
            this.flpPhotoButtons.ResumeLayout(false);
            this.flpPhotoButtons.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.pnlDetailsGap.ResumeLayout(false);
            this.pnlDetailsGap.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel pnlDetailsGap;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblValSerial;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Label lblValCategory;
        private System.Windows.Forms.Label lblInfo3;
        private System.Windows.Forms.Label lblValLocation;
        private System.Windows.Forms.Label lblInfo4;
        private System.Windows.Forms.Label lblValStatus;
        private System.Windows.Forms.Label lblInfo5;
        private System.Windows.Forms.Label lblValHolder;
        private System.Windows.Forms.Label lblInfo6;
        private System.Windows.Forms.Label lblValCost;
        private System.Windows.Forms.Label lblInfo7;
        private System.Windows.Forms.Label lblValBook;
        private System.Windows.Forms.Label lblInfo8;
        private System.Windows.Forms.Label lblValRemaining;
        private System.Windows.Forms.FlowLayoutPanel flpPhotoButtons;
        private System.Windows.Forms.Button btnPhotoChange;
        private System.Windows.Forms.Button btnPhotoRemove;
        private System.Windows.Forms.PictureBox picPhoto;
        private System.Windows.Forms.Label lblNoPhoto;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Button btnHandover;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnDispose;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.FlowLayoutPanel flpStatus;
        private System.Windows.Forms.Button btnStatusAll;
        private System.Windows.Forms.Button btnStatusAvailable;
        private System.Windows.Forms.Button btnStatusInCustody;
        private System.Windows.Forms.Button btnStatusDisposed;
        private System.Windows.Forms.Button btnStatusArchived;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Label lblTitle;
    }
}
