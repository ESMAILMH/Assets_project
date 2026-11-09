namespace AssetTracking.Pages
{
    partial class CustodyPage
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
            this.btnHandover = new System.Windows.Forms.Button();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnDocument = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.flpStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChipOpen = new System.Windows.Forms.Button();
            this.btnChipAll = new System.Windows.Forms.Button();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlGrid.SuspendLayout();
            this.flpActions.SuspendLayout();
            this.flpStatus.SuspendLayout();
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
            this.flpActions.Controls.Add(this.btnHandover);
            this.flpActions.Controls.Add(this.btnReceive);
            this.flpActions.Controls.Add(this.btnDocument);
            this.flpActions.Controls.Add(this.btnPrint);
            this.flpActions.Controls.Add(this.btnExcel);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpActions.AutoSize = true;
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.flpActions.Name = "flpActions";
            // 
            // btnHandover
            // 
            this.btnHandover.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnHandover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHandover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHandover.FlatAppearance.BorderSize = 0;
            this.btnHandover.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnHandover.ForeColor = System.Drawing.Color.White;
            this.btnHandover.Size = new System.Drawing.Size(130, 36);
            this.btnHandover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHandover.Text = "📤 تسليم أصل";
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
            this.btnReceive.Size = new System.Drawing.Size(130, 36);
            this.btnReceive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReceive.Text = "↩ استلام";
            this.btnReceive.UseVisualStyleBackColor = false;
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnDocument
            // 
            this.btnDocument.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnDocument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocument.FlatAppearance.BorderSize = 0;
            this.btnDocument.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnDocument.ForeColor = System.Drawing.Color.White;
            this.btnDocument.Size = new System.Drawing.Size(170, 36);
            this.btnDocument.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDocument.Text = "🧾 طباعة المحضر";
            this.btnDocument.UseVisualStyleBackColor = false;
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.Click += new System.EventHandler(this.btnDocument_Click);
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
            // flpStatus
            // 
            this.flpStatus.Controls.Add(this.btnChipOpen);
            this.flpStatus.Controls.Add(this.btnChipAll);
            this.flpStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpStatus.AutoSize = true;
            this.flpStatus.Padding = new System.Windows.Forms.Padding(0, 6, 0, 8);
            this.flpStatus.Name = "flpStatus";
            // 
            // btnChipOpen
            // 
            this.btnChipOpen.BackColor = System.Drawing.Color.White;
            this.btnChipOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipOpen.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipOpen.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipOpen.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipOpen.Size = new System.Drawing.Size(130, 34);
            this.btnChipOpen.Tag = "open";
            this.btnChipOpen.Text = "العهد المفتوحة";
            this.btnChipOpen.UseVisualStyleBackColor = false;
            this.btnChipOpen.Name = "btnChipOpen";
            // 
            // btnChipAll
            // 
            this.btnChipAll.BackColor = System.Drawing.Color.White;
            this.btnChipAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipAll.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipAll.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipAll.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipAll.Size = new System.Drawing.Size(130, 34);
            this.btnChipAll.Tag = "all";
            this.btnChipAll.Text = "كل الحركات";
            this.btnChipAll.UseVisualStyleBackColor = false;
            this.btnChipAll.Name = "btnChipAll";
            // 
            // flpFilters
            // 
            this.flpFilters.Controls.Add(this.lblSearch);
            this.flpFilters.Controls.Add(this.txtSearch);
            this.flpFilters.Controls.Add(this.lblFrom);
            this.flpFilters.Controls.Add(this.dtpFrom);
            this.flpFilters.Controls.Add(this.lblTo);
            this.flpFilters.Controls.Add(this.dtpTo);
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
            this.lblTitle.Text = "التسليم والاستلام";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // CustodyPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.Padding = new System.Windows.Forms.Padding(20, 14, 20, 10);
            this.Size = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.flpActions);
            this.Controls.Add(this.flpStatus);
            this.Controls.Add(this.flpFilters);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "CustodyPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.flpFilters.ResumeLayout(false);
            this.flpFilters.PerformLayout();
            this.flpStatus.ResumeLayout(false);
            this.flpStatus.PerformLayout();
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
        private System.Windows.Forms.Button btnHandover;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.Button btnDocument;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.FlowLayoutPanel flpStatus;
        private System.Windows.Forms.Button btnChipOpen;
        private System.Windows.Forms.Button btnChipAll;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTitle;
    }
}
