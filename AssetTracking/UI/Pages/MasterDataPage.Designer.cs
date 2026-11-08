namespace AssetTracking.Pages
{
    partial class MasterDataPage
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabDepartments = new System.Windows.Forms.TabPage();
            this.tabLocations = new System.Windows.Forms.TabPage();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabs.SuspendLayout();
            this.tabDepartments.SuspendLayout();
            this.tabLocations.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabDepartments);
            this.tabs.Controls.Add(this.tabLocations);
            this.tabs.Controls.Add(this.tabCategories);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Padding = new System.Drawing.Point(16, 6);
            this.tabs.RightToLeftLayout = true;
            this.tabs.Name = "tabs";
            // 
            // tabDepartments
            // 
            this.tabDepartments.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.tabDepartments.Text = "الأقسام";
            this.tabDepartments.Name = "tabDepartments";
            // 
            // tabLocations
            // 
            this.tabLocations.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.tabLocations.Text = "المواقع";
            this.tabLocations.Name = "tabLocations";
            // 
            // tabCategories
            // 
            this.tabCategories.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.tabCategories.Text = "تصنيفات الأصول";
            this.tabCategories.Name = "tabCategories";
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 77, 120);
            this.lblTitle.Size = new System.Drawing.Size(900, 46);
            this.lblTitle.Text = "الأقسام والمواقع والتصنيفات";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // MasterDataPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(243, 245, 248);
            this.Padding = new System.Windows.Forms.Padding(20, 14, 20, 14);
            this.Size = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "MasterDataPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabCategories.ResumeLayout(false);
            this.tabCategories.PerformLayout();
            this.tabLocations.ResumeLayout(false);
            this.tabLocations.PerformLayout();
            this.tabDepartments.ResumeLayout(false);
            this.tabDepartments.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabDepartments;
        private System.Windows.Forms.TabPage tabLocations;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.Label lblTitle;
    }
}
