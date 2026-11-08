namespace AssetTracking.Pages
{
    partial class UsersPage
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.flpFilters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRoles = new System.Windows.Forms.Label();
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
            this.flpActions.Controls.Add(this.btnAdd);
            this.flpActions.Controls.Add(this.btnEdit);
            this.flpActions.Controls.Add(this.btnReset);
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
            this.btnAdd.Size = new System.Drawing.Size(130, 36);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Text = "➕ إضافة";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(13, 110, 153);
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Size = new System.Drawing.Size(130, 36);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Text = "✏ تعديل";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(214, 137, 16);
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.Font = new System.Drawing.Font("Cairo", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Size = new System.Drawing.Size(220, 36);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Text = "🔑 إعادة تعيين كلمة المرور";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Name = "btnReset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // flpFilters
            // 
            this.flpFilters.Controls.Add(this.lblRoles);
            this.flpFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpFilters.AutoSize = true;
            this.flpFilters.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.flpFilters.Name = "flpFilters";
            // 
            // lblRoles
            // 
            this.lblRoles.AutoSize = true;
            this.lblRoles.Margin = new System.Windows.Forms.Padding(4, 10, 4, 4);
            this.lblRoles.Text = "مدير: كل الصلاحيات واعتماد التخريد — أمين مخزن: التشغيل اليومي — موظف: يعرض أصوله فقط";
            this.lblRoles.Font = new System.Drawing.Font("Cairo", 9F);
            this.lblRoles.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.lblRoles.Name = "lblRoles";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTitle.Size = new System.Drawing.Size(900, 42);
            this.lblTitle.Text = "المستخدمون والصلاحيات";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // UsersPage
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
            this.Name = "UsersPage";
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
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.FlowLayoutPanel flpFilters;
        private System.Windows.Forms.Label lblRoles;
        private System.Windows.Forms.Label lblTitle;
    }
}
