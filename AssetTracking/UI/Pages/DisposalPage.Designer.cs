namespace AssetTracking.Pages
{
    partial class DisposalPage
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
            this.btnDecide = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.flpStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.btnChipProposed = new System.Windows.Forms.Button();
            this.btnChipApproved = new System.Windows.Forms.Button();
            this.btnChipRejected = new System.Windows.Forms.Button();
            this.btnChipAll = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlGrid.SuspendLayout();
            this.flpActions.SuspendLayout();
            this.flpStatus.SuspendLayout();
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
            this.flpActions.Controls.Add(this.btnDecide);
            this.flpActions.Controls.Add(this.btnPrint);
            this.flpActions.Controls.Add(this.btnExcel);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpActions.AutoSize = true;
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.flpActions.Name = "flpActions";
            // 
            // btnDecide
            // 
            this.btnDecide.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnDecide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecide.FlatAppearance.BorderSize = 0;
            this.btnDecide.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnDecide.ForeColor = System.Drawing.Color.White;
            this.btnDecide.Size = new System.Drawing.Size(170, 36);
            this.btnDecide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDecide.Text = "✔ اعتماد / رفض";
            this.btnDecide.UseVisualStyleBackColor = false;
            this.btnDecide.Name = "btnDecide";
            this.btnDecide.Click += new System.EventHandler(this.btnDecide_Click);
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
            this.flpStatus.Controls.Add(this.btnChipProposed);
            this.flpStatus.Controls.Add(this.btnChipApproved);
            this.flpStatus.Controls.Add(this.btnChipRejected);
            this.flpStatus.Controls.Add(this.btnChipAll);
            this.flpStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpStatus.AutoSize = true;
            this.flpStatus.Padding = new System.Windows.Forms.Padding(0, 6, 0, 8);
            this.flpStatus.Name = "flpStatus";
            // 
            // btnChipProposed
            // 
            this.btnChipProposed.BackColor = System.Drawing.Color.White;
            this.btnChipProposed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipProposed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipProposed.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipProposed.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipProposed.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipProposed.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipProposed.Size = new System.Drawing.Size(130, 34);
            this.btnChipProposed.Tag = "Proposed";
            this.btnChipProposed.Text = "بانتظار المدير";
            this.btnChipProposed.UseVisualStyleBackColor = false;
            this.btnChipProposed.Name = "btnChipProposed";
            // 
            // btnChipApproved
            // 
            this.btnChipApproved.BackColor = System.Drawing.Color.White;
            this.btnChipApproved.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipApproved.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipApproved.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipApproved.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipApproved.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipApproved.Size = new System.Drawing.Size(130, 34);
            this.btnChipApproved.Tag = "Approved";
            this.btnChipApproved.Text = "معتمد";
            this.btnChipApproved.UseVisualStyleBackColor = false;
            this.btnChipApproved.Name = "btnChipApproved";
            // 
            // btnChipRejected
            // 
            this.btnChipRejected.BackColor = System.Drawing.Color.White;
            this.btnChipRejected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChipRejected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChipRejected.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipRejected.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnChipRejected.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnChipRejected.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnChipRejected.Size = new System.Drawing.Size(130, 34);
            this.btnChipRejected.Tag = "Rejected";
            this.btnChipRejected.Text = "مرفوض";
            this.btnChipRejected.UseVisualStyleBackColor = false;
            this.btnChipRejected.Name = "btnChipRejected";
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
            this.btnChipAll.Tag = "";
            this.btnChipAll.Text = "الكل";
            this.btnChipAll.UseVisualStyleBackColor = false;
            this.btnChipAll.Name = "btnChipAll";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTitle.Size = new System.Drawing.Size(900, 42);
            this.lblTitle.Text = "التخريد";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // DisposalPage
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
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "DisposalPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
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
        private System.Windows.Forms.Button btnDecide;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.FlowLayoutPanel flpStatus;
        private System.Windows.Forms.Button btnChipProposed;
        private System.Windows.Forms.Button btnChipApproved;
        private System.Windows.Forms.Button btnChipRejected;
        private System.Windows.Forms.Button btnChipAll;
        private System.Windows.Forms.Label lblTitle;
    }
}
