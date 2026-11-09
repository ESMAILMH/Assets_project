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
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlRecent = new System.Windows.Forms.Panel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.flpRecentHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRecent = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.pnlUrgent = new System.Windows.Forms.Panel();
            this.gridUrgent = new System.Windows.Forms.DataGridView();
            this.lblUrgent = new System.Windows.Forms.Label();
            this.pnlGap = new System.Windows.Forms.Panel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.tblChart = new System.Windows.Forms.TableLayoutPanel();
            this.lblChart = new System.Windows.Forms.Label();
            this.flpCards = new System.Windows.Forms.FlowLayoutPanel();
            this.flpQuick = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuickAdd = new System.Windows.Forms.Button();
            this.btnQuickHandover = new System.Windows.Forms.Button();
            this.btnQuickReceive = new System.Windows.Forms.Button();
            this.btnQuickReports = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody.SuspendLayout();
            this.pnlRecent.SuspendLayout();
            this.flpRecentHeader.SuspendLayout();
            this.pnlSide.SuspendLayout();
            this.pnlUrgent.SuspendLayout();
            this.pnlGap.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.flpCards.SuspendLayout();
            this.flpQuick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUrgent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlRecent);
            this.pnlBody.Controls.Add(this.pnlSide);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlBody.Name = "pnlBody";
            // 
            // pnlRecent
            // 
            this.pnlRecent.Controls.Add(this.grid);
            this.pnlRecent.Controls.Add(this.lblCount);
            this.pnlRecent.Controls.Add(this.flpRecentHeader);
            this.pnlRecent.BackColor = System.Drawing.Color.White;
            this.pnlRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRecent.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.pnlRecent.Size = new System.Drawing.Size(400, 260);
            this.pnlRecent.Name = "pnlRecent";
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
            this.lblCount.Size = new System.Drawing.Size(500, 26);
            this.lblCount.Text = "";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCount.Name = "lblCount";
            // 
            // flpRecentHeader
            // 
            this.flpRecentHeader.Controls.Add(this.lblRecent);
            this.flpRecentHeader.Controls.Add(this.btnRefresh);
            this.flpRecentHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpRecentHeader.AutoSize = true;
            this.flpRecentHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.flpRecentHeader.Name = "flpRecentHeader";
            // 
            // lblRecent
            // 
            this.lblRecent.AutoSize = true;
            this.lblRecent.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblRecent.Text = "🕘  آخر العمليات";
            this.lblRecent.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
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
            this.btnRefresh.Size = new System.Drawing.Size(90, 36);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlSide
            // 
            this.pnlSide.Controls.Add(this.pnlUrgent);
            this.pnlSide.Controls.Add(this.pnlGap);
            this.pnlSide.Controls.Add(this.pnlChart);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSide.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.pnlSide.Size = new System.Drawing.Size(420, 400);
            this.pnlSide.Name = "pnlSide";
            // 
            // pnlUrgent
            // 
            this.pnlUrgent.Controls.Add(this.gridUrgent);
            this.pnlUrgent.Controls.Add(this.lblUrgent);
            this.pnlUrgent.BackColor = System.Drawing.Color.White;
            this.pnlUrgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUrgent.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.pnlUrgent.Size = new System.Drawing.Size(400, 260);
            this.pnlUrgent.Name = "pnlUrgent";
            // 
            // gridUrgent
            // 
            this.gridUrgent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUrgent.BackgroundColor = System.Drawing.Color.White;
            this.gridUrgent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridUrgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridUrgent.Name = "gridUrgent";
            // 
            // lblUrgent
            // 
            this.lblUrgent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUrgent.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            this.lblUrgent.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblUrgent.Size = new System.Drawing.Size(380, 34);
            this.lblUrgent.Text = "⚠  أصول انتهى عمرها";
            this.lblUrgent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUrgent.Name = "lblUrgent";
            // 
            // pnlGap
            // 
            this.pnlGap.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGap.Size = new System.Drawing.Size(400, 14);
            this.pnlGap.Name = "pnlGap";
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.tblChart);
            this.pnlChart.Controls.Add(this.lblChart);
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart.Padding = new System.Windows.Forms.Padding(12, 8, 12, 12);
            this.pnlChart.Size = new System.Drawing.Size(400, 270);
            this.pnlChart.Name = "pnlChart";
            // 
            // tblChart
            // 
            this.tblChart.AutoScroll = true;
            this.tblChart.ColumnCount = 3;
            this.tblChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblChart.Size = new System.Drawing.Size(360, 200);
            this.tblChart.Name = "tblChart";
            // 
            // lblChart
            // 
            this.lblChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChart.Font = new System.Drawing.Font("Cairo", 11F, System.Drawing.FontStyle.Bold);
            this.lblChart.ForeColor = System.Drawing.Color.FromArgb(33, 37, 41);
            this.lblChart.Size = new System.Drawing.Size(380, 34);
            this.lblChart.Text = "📊  الأصول حسب التصنيف";
            this.lblChart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChart.Name = "lblChart";
            // 
            // flpCards
            // 
            this.flpCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCards.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.flpCards.Size = new System.Drawing.Size(900, 250);
            this.flpCards.Name = "flpCards";
            // 
            // flpQuick
            // 
            this.flpQuick.Controls.Add(this.btnQuickAdd);
            this.flpQuick.Controls.Add(this.btnQuickHandover);
            this.flpQuick.Controls.Add(this.btnQuickReceive);
            this.flpQuick.Controls.Add(this.btnQuickReports);
            this.flpQuick.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpQuick.AutoSize = true;
            this.flpQuick.Padding = new System.Windows.Forms.Padding(0, 4, 0, 6);
            this.flpQuick.Name = "flpQuick";
            // 
            // btnQuickAdd
            // 
            this.btnQuickAdd.BackColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.btnQuickAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickAdd.FlatAppearance.BorderSize = 0;
            this.btnQuickAdd.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickAdd.ForeColor = System.Drawing.Color.White;
            this.btnQuickAdd.Size = new System.Drawing.Size(150, 36);
            this.btnQuickAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuickAdd.Text = "➕ إضافة أصل";
            this.btnQuickAdd.UseVisualStyleBackColor = false;
            this.btnQuickAdd.Name = "btnQuickAdd";
            this.btnQuickAdd.Click += new System.EventHandler(this.btnQuickAdd_Click);
            // 
            // btnQuickHandover
            // 
            this.btnQuickHandover.BackColor = System.Drawing.Color.FromArgb(214, 137, 16);
            this.btnQuickHandover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickHandover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickHandover.FlatAppearance.BorderSize = 0;
            this.btnQuickHandover.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickHandover.ForeColor = System.Drawing.Color.White;
            this.btnQuickHandover.Size = new System.Drawing.Size(150, 36);
            this.btnQuickHandover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuickHandover.Text = "📤 تسليم أصل";
            this.btnQuickHandover.UseVisualStyleBackColor = false;
            this.btnQuickHandover.Name = "btnQuickHandover";
            this.btnQuickHandover.Click += new System.EventHandler(this.btnQuickHandover_Click);
            // 
            // btnQuickReceive
            // 
            this.btnQuickReceive.BackColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.btnQuickReceive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReceive.FlatAppearance.BorderSize = 0;
            this.btnQuickReceive.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickReceive.ForeColor = System.Drawing.Color.White;
            this.btnQuickReceive.Size = new System.Drawing.Size(150, 36);
            this.btnQuickReceive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuickReceive.Text = "↩ استلام أصل";
            this.btnQuickReceive.UseVisualStyleBackColor = false;
            this.btnQuickReceive.Name = "btnQuickReceive";
            this.btnQuickReceive.Click += new System.EventHandler(this.btnQuickReceive_Click);
            // 
            // btnQuickReports
            // 
            this.btnQuickReports.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnQuickReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickReports.FlatAppearance.BorderSize = 0;
            this.btnQuickReports.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickReports.ForeColor = System.Drawing.Color.White;
            this.btnQuickReports.Size = new System.Drawing.Size(150, 36);
            this.btnQuickReports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuickReports.Text = "📊 التقارير";
            this.btnQuickReports.UseVisualStyleBackColor = false;
            this.btnQuickReports.Name = "btnQuickReports";
            this.btnQuickReports.Click += new System.EventHandler(this.btnQuickReports_Click);
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblDate.Size = new System.Drawing.Size(900, 26);
            this.lblDate.Text = "التاريخ";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDate.Name = "lblDate";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTitle.Size = new System.Drawing.Size(900, 44);
            this.lblTitle.Text = "مرحباً";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // DashboardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.Padding = new System.Windows.Forms.Padding(20, 10, 20, 14);
            this.Size = new System.Drawing.Size(1100, 760);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.flpCards);
            this.Controls.Add(this.flpQuick);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Cairo", 10F);
            this.Name = "DashboardPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUrgent)).EndInit();
            this.flpQuick.ResumeLayout(false);
            this.flpQuick.PerformLayout();
            this.flpCards.ResumeLayout(false);
            this.flpCards.PerformLayout();
            this.pnlChart.ResumeLayout(false);
            this.pnlChart.PerformLayout();
            this.pnlGap.ResumeLayout(false);
            this.pnlGap.PerformLayout();
            this.pnlUrgent.ResumeLayout(false);
            this.pnlUrgent.PerformLayout();
            this.pnlSide.ResumeLayout(false);
            this.pnlSide.PerformLayout();
            this.flpRecentHeader.ResumeLayout(false);
            this.flpRecentHeader.PerformLayout();
            this.pnlRecent.ResumeLayout(false);
            this.pnlRecent.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlRecent;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.FlowLayoutPanel flpRecentHeader;
        private System.Windows.Forms.Label lblRecent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Panel pnlUrgent;
        private System.Windows.Forms.DataGridView gridUrgent;
        private System.Windows.Forms.Label lblUrgent;
        private System.Windows.Forms.Panel pnlGap;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.TableLayoutPanel tblChart;
        private System.Windows.Forms.Label lblChart;
        private System.Windows.Forms.FlowLayoutPanel flpCards;
        private System.Windows.Forms.FlowLayoutPanel flpQuick;
        private System.Windows.Forms.Button btnQuickAdd;
        private System.Windows.Forms.Button btnQuickHandover;
        private System.Windows.Forms.Button btnQuickReceive;
        private System.Windows.Forms.Button btnQuickReports;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTitle;
    }
}
