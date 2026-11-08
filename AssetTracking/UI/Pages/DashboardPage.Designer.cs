namespace AssetTracking.Pages
{
    partial class DashboardPage
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
            this.lblRecent = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.flpCards = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlGrid.SuspendLayout();
            this.flpActions.SuspendLayout();
            this.flpCards.SuspendLayout();
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
            this.flpActions.Controls.Add(this.lblRecent);
            this.flpActions.Controls.Add(this.btnRefresh);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpActions.AutoSize = true;
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.flpActions.Name = "flpActions";
            // 
            // lblRecent
            // 
            this.lblRecent.AutoSize = true;
            this.lblRecent.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblRecent.Text = "آخر العمليات";
            this.lblRecent.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecent.Name = "lblRecent";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Size = new System.Drawing.Size(100, 36);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // flpCards
            // 
            this.flpCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCards.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.flpCards.Size = new System.Drawing.Size(900, 250);
            this.flpCards.Name = "flpCards";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTitle.Size = new System.Drawing.Size(900, 42);
            this.lblTitle.Text = "الشاشة الرئيسية";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // DashboardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.Padding = new System.Windows.Forms.Padding(20, 14, 20, 10);
            this.Size = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.flpActions);
            this.Controls.Add(this.flpCards);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "DashboardPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.flpCards.ResumeLayout(false);
            this.flpCards.PerformLayout();
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
        private System.Windows.Forms.Label lblRecent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.FlowLayoutPanel flpCards;
        private System.Windows.Forms.Label lblTitle;
    }
}
