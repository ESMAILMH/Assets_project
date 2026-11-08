namespace AssetTracking.Forms
{
    partial class AssetDialog
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
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpPurchase = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpInService = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.numCost = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numLife = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numSalvage = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDepreciationValue = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblBookValue = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblRemainingValue = new System.Windows.Forms.Label();
            this.grpImage = new System.Windows.Forms.GroupBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnPickImage = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrintCard = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpImage.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalvage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Size = new System.Drawing.Size(150, 27);
            this.label1.Text = "الرقم التسلسلي *";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Name = "label1";
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(176, 64);
            this.txtSerial.Size = new System.Drawing.Size(400, 27);
            this.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSerial.MaxLength = 50;
            this.txtSerial.Name = "txtSerial";
            // 
            // label2
            // 
            this.label2.AutoSize = false;
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Size = new System.Drawing.Size(150, 27);
            this.label2.Text = "الاسم *";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Name = "label2";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(176, 104);
            this.txtName.Size = new System.Drawing.Size(400, 27);
            this.txtName.MaxLength = 150;
            this.txtName.Name = "txtName";
            // 
            // label3
            // 
            this.label3.AutoSize = false;
            this.label3.Location = new System.Drawing.Point(16, 144);
            this.label3.Size = new System.Drawing.Size(150, 27);
            this.label3.Text = "التصنيف *";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Name = "label3";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Location = new System.Drawing.Point(176, 144);
            this.cmbCategory.Size = new System.Drawing.Size(400, 28);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Name = "cmbCategory";
            // 
            // label4
            // 
            this.label4.AutoSize = false;
            this.label4.Location = new System.Drawing.Point(16, 184);
            this.label4.Size = new System.Drawing.Size(150, 27);
            this.label4.Text = "الموديل";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Name = "label4";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(176, 184);
            this.txtModel.Size = new System.Drawing.Size(400, 27);
            this.txtModel.MaxLength = 100;
            this.txtModel.Name = "txtModel";
            // 
            // label5
            // 
            this.label5.AutoSize = false;
            this.label5.Location = new System.Drawing.Point(16, 224);
            this.label5.Size = new System.Drawing.Size(150, 27);
            this.label5.Text = "القسم";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Name = "label5";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.Location = new System.Drawing.Point(176, 224);
            this.cmbDepartment.Size = new System.Drawing.Size(400, 28);
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.Name = "cmbDepartment";
            // 
            // label6
            // 
            this.label6.AutoSize = false;
            this.label6.Location = new System.Drawing.Point(16, 264);
            this.label6.Size = new System.Drawing.Size(150, 27);
            this.label6.Text = "الموقع";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Name = "label6";
            // 
            // cmbLocation
            // 
            this.cmbLocation.Location = new System.Drawing.Point(176, 264);
            this.cmbLocation.Size = new System.Drawing.Size(400, 28);
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Name = "cmbLocation";
            // 
            // label7
            // 
            this.label7.AutoSize = false;
            this.label7.Location = new System.Drawing.Point(16, 304);
            this.label7.Size = new System.Drawing.Size(150, 27);
            this.label7.Text = "تاريخ الشراء";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Name = "label7";
            // 
            // dtpPurchase
            // 
            this.dtpPurchase.Location = new System.Drawing.Point(176, 304);
            this.dtpPurchase.CustomFormat = "yyyy/MM/dd";
            this.dtpPurchase.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPurchase.Size = new System.Drawing.Size(160, 27);
            this.dtpPurchase.ShowCheckBox = true;
            this.dtpPurchase.Name = "dtpPurchase";
            // 
            // label8
            // 
            this.label8.AutoSize = false;
            this.label8.Location = new System.Drawing.Point(16, 344);
            this.label8.Size = new System.Drawing.Size(150, 27);
            this.label8.Text = "تاريخ بدء الاستخدام *";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Name = "label8";
            // 
            // dtpInService
            // 
            this.dtpInService.Location = new System.Drawing.Point(176, 344);
            this.dtpInService.CustomFormat = "yyyy/MM/dd";
            this.dtpInService.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInService.Size = new System.Drawing.Size(160, 27);
            this.dtpInService.Name = "dtpInService";
            // 
            // label9
            // 
            this.label9.AutoSize = false;
            this.label9.Location = new System.Drawing.Point(16, 384);
            this.label9.Size = new System.Drawing.Size(150, 27);
            this.label9.Text = "التكلفة (د.ل) *";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Name = "label9";
            // 
            // numCost
            // 
            this.numCost.DecimalPlaces = 3;
            this.numCost.Location = new System.Drawing.Point(176, 384);
            this.numCost.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numCost.Size = new System.Drawing.Size(180, 27);
            this.numCost.ThousandsSeparator = true;
            this.numCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCost.Name = "numCost";
            // 
            // label10
            // 
            this.label10.AutoSize = false;
            this.label10.Location = new System.Drawing.Point(16, 424);
            this.label10.Size = new System.Drawing.Size(150, 27);
            this.label10.Text = "العمر الافتراضي (سنة) *";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.label10.Name = "label10";
            // 
            // numLife
            // 
            this.numLife.Location = new System.Drawing.Point(176, 424);
            this.numLife.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numLife.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numLife.Size = new System.Drawing.Size(120, 27);
            this.numLife.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.numLife.Name = "numLife";
            // 
            // label11
            // 
            this.label11.AutoSize = false;
            this.label11.Location = new System.Drawing.Point(16, 464);
            this.label11.Size = new System.Drawing.Size(150, 27);
            this.label11.Text = "قيمة الخردة (د.ل)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Name = "label11";
            // 
            // numSalvage
            // 
            this.numSalvage.DecimalPlaces = 3;
            this.numSalvage.Location = new System.Drawing.Point(176, 464);
            this.numSalvage.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numSalvage.Size = new System.Drawing.Size(180, 27);
            this.numSalvage.ThousandsSeparator = true;
            this.numSalvage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSalvage.Name = "numSalvage";
            // 
            // label12
            // 
            this.label12.AutoSize = false;
            this.label12.Location = new System.Drawing.Point(16, 504);
            this.label12.Size = new System.Drawing.Size(150, 27);
            this.label12.Text = "الحالة";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Name = "label12";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = false;
            this.lblStatusValue.Location = new System.Drawing.Point(176, 504);
            this.lblStatusValue.Size = new System.Drawing.Size(400, 27);
            this.lblStatusValue.Text = "—";
            this.lblStatusValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusValue.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblStatusValue.Name = "lblStatusValue";
            // 
            // label13
            // 
            this.label13.AutoSize = false;
            this.label13.Location = new System.Drawing.Point(16, 540);
            this.label13.Size = new System.Drawing.Size(150, 27);
            this.label13.Text = "الإهلاك المتراكم";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Name = "label13";
            // 
            // lblDepreciationValue
            // 
            this.lblDepreciationValue.AutoSize = false;
            this.lblDepreciationValue.Location = new System.Drawing.Point(176, 540);
            this.lblDepreciationValue.Size = new System.Drawing.Size(400, 27);
            this.lblDepreciationValue.Text = "—";
            this.lblDepreciationValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDepreciationValue.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblDepreciationValue.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblDepreciationValue.Name = "lblDepreciationValue";
            // 
            // label14
            // 
            this.label14.AutoSize = false;
            this.label14.Location = new System.Drawing.Point(16, 576);
            this.label14.Size = new System.Drawing.Size(150, 27);
            this.label14.Text = "القيمة الدفترية";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Name = "label14";
            // 
            // lblBookValue
            // 
            this.lblBookValue.AutoSize = false;
            this.lblBookValue.Location = new System.Drawing.Point(176, 576);
            this.lblBookValue.Size = new System.Drawing.Size(400, 27);
            this.lblBookValue.Text = "—";
            this.lblBookValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBookValue.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblBookValue.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblBookValue.Name = "lblBookValue";
            // 
            // label15
            // 
            this.label15.AutoSize = false;
            this.label15.Location = new System.Drawing.Point(16, 612);
            this.label15.Size = new System.Drawing.Size(150, 27);
            this.label15.Text = "المتبقي من العمر";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Name = "label15";
            // 
            // lblRemainingValue
            // 
            this.lblRemainingValue.AutoSize = false;
            this.lblRemainingValue.Location = new System.Drawing.Point(176, 612);
            this.lblRemainingValue.Size = new System.Drawing.Size(400, 27);
            this.lblRemainingValue.Text = "—";
            this.lblRemainingValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRemainingValue.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.lblRemainingValue.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblRemainingValue.Name = "lblRemainingValue";
            // 
            // grpImage
            // 
            this.grpImage.Controls.Add(this.picImage);
            this.grpImage.Controls.Add(this.btnPickImage);
            this.grpImage.Controls.Add(this.btnRemoveImage);
            this.grpImage.Location = new System.Drawing.Point(600, 64);
            this.grpImage.Size = new System.Drawing.Size(260, 330);
            this.grpImage.Text = "صورة الأصل (اختيارية، حتى 2MB)";
            this.grpImage.Name = "grpImage";
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(14, 30);
            this.picImage.Size = new System.Drawing.Size(232, 230);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.Name = "picImage";
            // 
            // btnPickImage
            // 
            this.btnPickImage.Location = new System.Drawing.Point(14, 274);
            this.btnPickImage.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnPickImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPickImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPickImage.FlatAppearance.BorderSize = 0;
            this.btnPickImage.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnPickImage.ForeColor = System.Drawing.Color.White;
            this.btnPickImage.Size = new System.Drawing.Size(112, 40);
            this.btnPickImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPickImage.Text = "اختيار صورة";
            this.btnPickImage.UseVisualStyleBackColor = false;
            this.btnPickImage.Name = "btnPickImage";
            this.btnPickImage.Click += new System.EventHandler(this.btnPickImage_Click);
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.Location = new System.Drawing.Point(134, 274);
            this.btnRemoveImage.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnRemoveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveImage.FlatAppearance.BorderSize = 0;
            this.btnRemoveImage.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnRemoveImage.ForeColor = System.Drawing.Color.White;
            this.btnRemoveImage.Size = new System.Drawing.Size(112, 40);
            this.btnRemoveImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoveImage.Text = "حذف الصورة";
            this.btnRemoveImage.UseVisualStyleBackColor = false;
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnPrintCard);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Size = new System.Drawing.Size(880, 60);
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
            // btnPrintCard
            // 
            this.btnPrintCard.Location = new System.Drawing.Point(276, 12);
            this.btnPrintCard.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnPrintCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintCard.FlatAppearance.BorderSize = 0;
            this.btnPrintCard.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintCard.ForeColor = System.Drawing.Color.White;
            this.btnPrintCard.Size = new System.Drawing.Size(170, 36);
            this.btnPrintCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintCard.Text = "طباعة البطاقة";
            this.btnPrintCard.UseVisualStyleBackColor = false;
            this.btnPrintCard.Name = "btnPrintCard";
            this.btnPrintCard.Click += new System.EventHandler(this.btnPrintCard_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.lblHeader.Size = new System.Drawing.Size(880, 48);
            this.lblHeader.Text = "بطاقة الأصل";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeader.Name = "lblHeader";
            // 
            // AssetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AcceptButton = this.btnSave;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(880, 716);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "بطاقة الأصل";
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpPurchase);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpInService);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numCost);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numLife);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numSalvage);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblStatusValue);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblDepreciationValue);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblBookValue);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblRemainingValue);
            this.Controls.Add(this.grpImage);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "AssetDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalvage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.grpImage.ResumeLayout(false);
            this.grpImage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpPurchase;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpInService;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numCost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numLife;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numSalvage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDepreciationValue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblBookValue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblRemainingValue;
        private System.Windows.Forms.GroupBox grpImage;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnPickImage;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrintCard;
        private System.Windows.Forms.Label lblHeader;
    }
}
