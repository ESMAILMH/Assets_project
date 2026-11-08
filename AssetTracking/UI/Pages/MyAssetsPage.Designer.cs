namespace AssetTracking.Pages
{
    partial class MyAssetsPage
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
            this.btnCard = new System.Windows.Forms.Button();
            this.btnStatement = new System.Windows.Forms.Button();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
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
            this.flpActions.Controls.Add(this.btnCard);
            this.flpActions.Controls.Add(this.btnStatement);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpActions.AutoSize = true;
            this.flpActions.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.flpActions.Name = "flpActions";
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCard.FlatAppearance.BorderSize = 0;
            this.btnCard.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnCard.ForeColor = System.Drawing.Color.White;
            this.btnCard.Size = new System.Drawing.Size(170, 36);
            this.btnCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCard.Text = "📄 بطاقة الأصل";
            this.btnCard.UseVisualStyleBackColor = false;
            this.btnCard.Name = "btnCard";
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnStatement
            // 
            this.btnStatement.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnStatement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatement.FlatAppearance.BorderSize = 0;
            this.btnStatement.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnStatement.ForeColor = System.Drawing.Color.White;
            this.btnStatement.Size = new System.Drawing.Size(130, 36);
            this.btnStatement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStatement.Text = "🖨 كشف عهدتي";
            this.btnStatement.UseVisualStyleBackColor = false;
            this.btnStatement.Name = "btnStatement";
            this.btnStatement.Click += new System.EventHandler(this.btnStatement_Click);
            // 
            // flpFilters
            // 
            this.flpFilters.Controls.Add(this.lblSearch);
            this.flpFilters.Controls.Add(this.txtSearch);
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
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTitle.Size = new System.Drawing.Size(900, 42);
            this.lblTitle.Text = "أصولي";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // MyAssetsPage
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
            this.Name = "MyAssetsPage";
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
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Button btnStatement;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTitle;
    }
}
