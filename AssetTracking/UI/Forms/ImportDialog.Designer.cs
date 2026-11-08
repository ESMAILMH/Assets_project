namespace AssetTracking.Forms
{
    partial class ImportDialog
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
            this.flpPreview = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.grpMapping = new System.Windows.Forms.GroupBox();
            this.lblMapSerialNo = new System.Windows.Forms.Label();
            this.cmbMapSerialNo = new System.Windows.Forms.ComboBox();
            this.lblMapName = new System.Windows.Forms.Label();
            this.cmbMapName = new System.Windows.Forms.ComboBox();
            this.lblMapCategory = new System.Windows.Forms.Label();
            this.cmbMapCategory = new System.Windows.Forms.ComboBox();
            this.lblMapModel = new System.Windows.Forms.Label();
            this.cmbMapModel = new System.Windows.Forms.ComboBox();
            this.lblMapPurchaseDate = new System.Windows.Forms.Label();
            this.cmbMapPurchaseDate = new System.Windows.Forms.ComboBox();
            this.lblMapInServiceDate = new System.Windows.Forms.Label();
            this.cmbMapInServiceDate = new System.Windows.Forms.ComboBox();
            this.lblMapCost = new System.Windows.Forms.Label();
            this.cmbMapCost = new System.Windows.Forms.ComboBox();
            this.lblMapLifeYears = new System.Windows.Forms.Label();
            this.cmbMapLifeYears = new System.Windows.Forms.ComboBox();
            this.lblMapSalvageValue = new System.Windows.Forms.Label();
            this.cmbMapSalvageValue = new System.Windows.Forms.ComboBox();
            this.lblMapLocation = new System.Windows.Forms.Label();
            this.cmbMapLocation = new System.Windows.Forms.ComboBox();
            this.flpFile = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnPick = new System.Windows.Forms.Button();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnErrors = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlGrid.SuspendLayout();
            this.flpPreview.SuspendLayout();
            this.grpMapping.SuspendLayout();
            this.flpFile.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grid);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
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
            // flpPreview
            // 
            this.flpPreview.Controls.Add(this.btnPreview);
            this.flpPreview.Controls.Add(this.lblSummary);
            this.flpPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpPreview.AutoSize = true;
            this.flpPreview.Padding = new System.Windows.Forms.Padding(12, 6, 12, 4);
            this.flpPreview.Name = "flpPreview";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.FlatAppearance.BorderSize = 0;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Size = new System.Drawing.Size(120, 36);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreview.Text = "٣. معاينة";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblSummary.Text = "";
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSummary.Name = "lblSummary";
            // 
            // grpMapping
            // 
            this.grpMapping.Controls.Add(this.lblMapSerialNo);
            this.grpMapping.Controls.Add(this.cmbMapSerialNo);
            this.grpMapping.Controls.Add(this.lblMapName);
            this.grpMapping.Controls.Add(this.cmbMapName);
            this.grpMapping.Controls.Add(this.lblMapCategory);
            this.grpMapping.Controls.Add(this.cmbMapCategory);
            this.grpMapping.Controls.Add(this.lblMapModel);
            this.grpMapping.Controls.Add(this.cmbMapModel);
            this.grpMapping.Controls.Add(this.lblMapPurchaseDate);
            this.grpMapping.Controls.Add(this.cmbMapPurchaseDate);
            this.grpMapping.Controls.Add(this.lblMapInServiceDate);
            this.grpMapping.Controls.Add(this.cmbMapInServiceDate);
            this.grpMapping.Controls.Add(this.lblMapCost);
            this.grpMapping.Controls.Add(this.cmbMapCost);
            this.grpMapping.Controls.Add(this.lblMapLifeYears);
            this.grpMapping.Controls.Add(this.cmbMapLifeYears);
            this.grpMapping.Controls.Add(this.lblMapSalvageValue);
            this.grpMapping.Controls.Add(this.cmbMapSalvageValue);
            this.grpMapping.Controls.Add(this.lblMapLocation);
            this.grpMapping.Controls.Add(this.cmbMapLocation);
            this.grpMapping.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMapping.Size = new System.Drawing.Size(1060, 214);
            this.grpMapping.Text = "٢. مطابقة أعمدة الملف مع حقول الأصل";
            this.grpMapping.Name = "grpMapping";
            // 
            // lblMapSerialNo
            // 
            this.lblMapSerialNo.AutoSize = false;
            this.lblMapSerialNo.Location = new System.Drawing.Point(16, 30);
            this.lblMapSerialNo.Size = new System.Drawing.Size(150, 27);
            this.lblMapSerialNo.Text = "الرقم التسلسلي *";
            this.lblMapSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapSerialNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMapSerialNo.Name = "lblMapSerialNo";
            // 
            // cmbMapSerialNo
            // 
            this.cmbMapSerialNo.Location = new System.Drawing.Point(171, 30);
            this.cmbMapSerialNo.Size = new System.Drawing.Size(320, 28);
            this.cmbMapSerialNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapSerialNo.Name = "cmbMapSerialNo";
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = false;
            this.lblMapName.Location = new System.Drawing.Point(530, 30);
            this.lblMapName.Size = new System.Drawing.Size(150, 27);
            this.lblMapName.Text = "الاسم *";
            this.lblMapName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMapName.Name = "lblMapName";
            // 
            // cmbMapName
            // 
            this.cmbMapName.Location = new System.Drawing.Point(685, 30);
            this.cmbMapName.Size = new System.Drawing.Size(320, 28);
            this.cmbMapName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapName.Name = "cmbMapName";
            // 
            // lblMapCategory
            // 
            this.lblMapCategory.AutoSize = false;
            this.lblMapCategory.Location = new System.Drawing.Point(16, 66);
            this.lblMapCategory.Size = new System.Drawing.Size(150, 27);
            this.lblMapCategory.Text = "التصنيف *";
            this.lblMapCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMapCategory.Name = "lblMapCategory";
            // 
            // cmbMapCategory
            // 
            this.cmbMapCategory.Location = new System.Drawing.Point(171, 66);
            this.cmbMapCategory.Size = new System.Drawing.Size(320, 28);
            this.cmbMapCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapCategory.Name = "cmbMapCategory";
            // 
            // lblMapModel
            // 
            this.lblMapModel.AutoSize = false;
            this.lblMapModel.Location = new System.Drawing.Point(530, 66);
            this.lblMapModel.Size = new System.Drawing.Size(150, 27);
            this.lblMapModel.Text = "الموديل";
            this.lblMapModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapModel.Name = "lblMapModel";
            // 
            // cmbMapModel
            // 
            this.cmbMapModel.Location = new System.Drawing.Point(685, 66);
            this.cmbMapModel.Size = new System.Drawing.Size(320, 28);
            this.cmbMapModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapModel.Name = "cmbMapModel";
            // 
            // lblMapPurchaseDate
            // 
            this.lblMapPurchaseDate.AutoSize = false;
            this.lblMapPurchaseDate.Location = new System.Drawing.Point(16, 102);
            this.lblMapPurchaseDate.Size = new System.Drawing.Size(150, 27);
            this.lblMapPurchaseDate.Text = "تاريخ الشراء";
            this.lblMapPurchaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapPurchaseDate.Name = "lblMapPurchaseDate";
            // 
            // cmbMapPurchaseDate
            // 
            this.cmbMapPurchaseDate.Location = new System.Drawing.Point(171, 102);
            this.cmbMapPurchaseDate.Size = new System.Drawing.Size(320, 28);
            this.cmbMapPurchaseDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapPurchaseDate.Name = "cmbMapPurchaseDate";
            // 
            // lblMapInServiceDate
            // 
            this.lblMapInServiceDate.AutoSize = false;
            this.lblMapInServiceDate.Location = new System.Drawing.Point(530, 102);
            this.lblMapInServiceDate.Size = new System.Drawing.Size(150, 27);
            this.lblMapInServiceDate.Text = "تاريخ بدء الاستخدام *";
            this.lblMapInServiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapInServiceDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMapInServiceDate.Name = "lblMapInServiceDate";
            // 
            // cmbMapInServiceDate
            // 
            this.cmbMapInServiceDate.Location = new System.Drawing.Point(685, 102);
            this.cmbMapInServiceDate.Size = new System.Drawing.Size(320, 28);
            this.cmbMapInServiceDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapInServiceDate.Name = "cmbMapInServiceDate";
            // 
            // lblMapCost
            // 
            this.lblMapCost.AutoSize = false;
            this.lblMapCost.Location = new System.Drawing.Point(16, 138);
            this.lblMapCost.Size = new System.Drawing.Size(150, 27);
            this.lblMapCost.Text = "التكلفة *";
            this.lblMapCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapCost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMapCost.Name = "lblMapCost";
            // 
            // cmbMapCost
            // 
            this.cmbMapCost.Location = new System.Drawing.Point(171, 138);
            this.cmbMapCost.Size = new System.Drawing.Size(320, 28);
            this.cmbMapCost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapCost.Name = "cmbMapCost";
            // 
            // lblMapLifeYears
            // 
            this.lblMapLifeYears.AutoSize = false;
            this.lblMapLifeYears.Location = new System.Drawing.Point(530, 138);
            this.lblMapLifeYears.Size = new System.Drawing.Size(150, 27);
            this.lblMapLifeYears.Text = "العمر الافتراضي";
            this.lblMapLifeYears.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapLifeYears.Name = "lblMapLifeYears";
            // 
            // cmbMapLifeYears
            // 
            this.cmbMapLifeYears.Location = new System.Drawing.Point(685, 138);
            this.cmbMapLifeYears.Size = new System.Drawing.Size(320, 28);
            this.cmbMapLifeYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapLifeYears.Name = "cmbMapLifeYears";
            // 
            // lblMapSalvageValue
            // 
            this.lblMapSalvageValue.AutoSize = false;
            this.lblMapSalvageValue.Location = new System.Drawing.Point(16, 174);
            this.lblMapSalvageValue.Size = new System.Drawing.Size(150, 27);
            this.lblMapSalvageValue.Text = "قيمة الخردة";
            this.lblMapSalvageValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapSalvageValue.Name = "lblMapSalvageValue";
            // 
            // cmbMapSalvageValue
            // 
            this.cmbMapSalvageValue.Location = new System.Drawing.Point(171, 174);
            this.cmbMapSalvageValue.Size = new System.Drawing.Size(320, 28);
            this.cmbMapSalvageValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapSalvageValue.Name = "cmbMapSalvageValue";
            // 
            // lblMapLocation
            // 
            this.lblMapLocation.AutoSize = false;
            this.lblMapLocation.Location = new System.Drawing.Point(530, 174);
            this.lblMapLocation.Size = new System.Drawing.Size(150, 27);
            this.lblMapLocation.Text = "الموقع";
            this.lblMapLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapLocation.Name = "lblMapLocation";
            // 
            // cmbMapLocation
            // 
            this.cmbMapLocation.Location = new System.Drawing.Point(685, 174);
            this.cmbMapLocation.Size = new System.Drawing.Size(320, 28);
            this.cmbMapLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapLocation.Name = "cmbMapLocation";
            // 
            // flpFile
            // 
            this.flpFile.Controls.Add(this.lblFile);
            this.flpFile.Controls.Add(this.txtFile);
            this.flpFile.Controls.Add(this.btnPick);
            this.flpFile.Controls.Add(this.btnTemplate);
            this.flpFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFile.AutoSize = true;
            this.flpFile.Padding = new System.Windows.Forms.Padding(12, 10, 12, 4);
            this.flpFile.Name = "flpFile";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblFile.Text = "١. الملف:";
            this.lblFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFile.Name = "lblFile";
            // 
            // txtFile
            // 
            this.txtFile.Margin = new System.Windows.Forms.Padding(4, 7, 4, 4);
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(430, 27);
            this.txtFile.Name = "txtFile";
            // 
            // btnPick
            // 
            this.btnPick.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnPick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPick.FlatAppearance.BorderSize = 0;
            this.btnPick.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPick.ForeColor = System.Drawing.Color.White;
            this.btnPick.Size = new System.Drawing.Size(120, 36);
            this.btnPick.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPick.Text = "اختيار ملف";
            this.btnPick.UseVisualStyleBackColor = false;
            this.btnPick.Name = "btnPick";
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplate.FlatAppearance.BorderSize = 0;
            this.btnTemplate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTemplate.ForeColor = System.Drawing.Color.White;
            this.btnTemplate.Size = new System.Drawing.Size(120, 36);
            this.btnTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTemplate.Text = "تنزيل القالب";
            this.btnTemplate.UseVisualStyleBackColor = false;
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnErrors);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(100, 58);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(12, 10, 12, 6);
            this.pnlButtons.Name = "pnlButtons";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Size = new System.Drawing.Size(200, 36);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Text = "٤. حفظ الأسطر الصحيحة";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnErrors
            // 
            this.btnErrors.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnErrors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnErrors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrors.FlatAppearance.BorderSize = 0;
            this.btnErrors.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnErrors.ForeColor = System.Drawing.Color.White;
            this.btnErrors.Size = new System.Drawing.Size(170, 36);
            this.btnErrors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnErrors.Text = "🖨 تقرير الأخطاء";
            this.btnErrors.UseVisualStyleBackColor = false;
            this.btnErrors.Name = "btnErrors";
            this.btnErrors.Click += new System.EventHandler(this.btnErrors_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1060, 720);
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "استيراد الأصول من ملف Excel";
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.flpPreview);
            this.Controls.Add(this.grpMapping);
            this.Controls.Add(this.flpFile);
            this.Controls.Add(this.pnlButtons);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ImportDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.flpFile.ResumeLayout(false);
            this.flpFile.PerformLayout();
            this.grpMapping.ResumeLayout(false);
            this.grpMapping.PerformLayout();
            this.flpPreview.ResumeLayout(false);
            this.flpPreview.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.FlowLayoutPanel flpPreview;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.GroupBox grpMapping;
        private System.Windows.Forms.Label lblMapSerialNo;
        private System.Windows.Forms.ComboBox cmbMapSerialNo;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.ComboBox cmbMapName;
        private System.Windows.Forms.Label lblMapCategory;
        private System.Windows.Forms.ComboBox cmbMapCategory;
        private System.Windows.Forms.Label lblMapModel;
        private System.Windows.Forms.ComboBox cmbMapModel;
        private System.Windows.Forms.Label lblMapPurchaseDate;
        private System.Windows.Forms.ComboBox cmbMapPurchaseDate;
        private System.Windows.Forms.Label lblMapInServiceDate;
        private System.Windows.Forms.ComboBox cmbMapInServiceDate;
        private System.Windows.Forms.Label lblMapCost;
        private System.Windows.Forms.ComboBox cmbMapCost;
        private System.Windows.Forms.Label lblMapLifeYears;
        private System.Windows.Forms.ComboBox cmbMapLifeYears;
        private System.Windows.Forms.Label lblMapSalvageValue;
        private System.Windows.Forms.ComboBox cmbMapSalvageValue;
        private System.Windows.Forms.Label lblMapLocation;
        private System.Windows.Forms.ComboBox cmbMapLocation;
        private System.Windows.Forms.FlowLayoutPanel flpFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnErrors;
        private System.Windows.Forms.Button btnClose;
    }
}
