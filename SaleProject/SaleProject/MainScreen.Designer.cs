namespace SaleProject
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControls = new System.Windows.Forms.TabControl();
            this.tabSaleGoods = new System.Windows.Forms.TabPage();
            this.panSale = new System.Windows.Forms.Panel();
            this.tabImportGoods = new System.Windows.Forms.TabPage();
            this.panImport = new System.Windows.Forms.Panel();
            this.tabStatistic = new System.Windows.Forms.TabPage();
            this.panStastic = new System.Windows.Forms.Panel();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.panSetting = new System.Windows.Forms.Panel();
            this.saleInfo = new SaleProject.SaleInfo();
            this.importInfo = new SaleProject.BillDetailInfo();
            this.statisticalInfo = new SaleProject.UserControls.StatisticalInfo();
            this.settingInfo = new SaleProject.SettingInfo();
            this.panel1.SuspendLayout();
            this.tabControls.SuspendLayout();
            this.tabSaleGoods.SuspendLayout();
            this.panSale.SuspendLayout();
            this.tabImportGoods.SuspendLayout();
            this.panImport.SuspendLayout();
            this.tabStatistic.SuspendLayout();
            this.panStastic.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.panSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControls);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 561);
            this.panel1.TabIndex = 0;
            // 
            // tabControls
            // 
            this.tabControls.Controls.Add(this.tabSaleGoods);
            this.tabControls.Controls.Add(this.tabImportGoods);
            this.tabControls.Controls.Add(this.tabStatistic);
            this.tabControls.Controls.Add(this.tabSetting);
            this.tabControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControls.Location = new System.Drawing.Point(0, 0);
            this.tabControls.Multiline = true;
            this.tabControls.Name = "tabControls";
            this.tabControls.SelectedIndex = 0;
            this.tabControls.Size = new System.Drawing.Size(984, 561);
            this.tabControls.TabIndex = 0;
            // 
            // tabSaleGoods
            // 
            this.tabSaleGoods.Controls.Add(this.panSale);
            this.tabSaleGoods.Location = new System.Drawing.Point(4, 22);
            this.tabSaleGoods.Name = "tabSaleGoods";
            this.tabSaleGoods.Padding = new System.Windows.Forms.Padding(3);
            this.tabSaleGoods.Size = new System.Drawing.Size(976, 535);
            this.tabSaleGoods.TabIndex = 0;
            this.tabSaleGoods.Text = "Bán hàng";
            this.tabSaleGoods.UseVisualStyleBackColor = true;
            // 
            // panSale
            // 
            this.panSale.Controls.Add(this.saleInfo);
            this.panSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSale.Location = new System.Drawing.Point(3, 3);
            this.panSale.Name = "panSale";
            this.panSale.Size = new System.Drawing.Size(970, 529);
            this.panSale.TabIndex = 0;
            // 
            // tabImportGoods
            // 
            this.tabImportGoods.Controls.Add(this.panImport);
            this.tabImportGoods.Location = new System.Drawing.Point(4, 22);
            this.tabImportGoods.Name = "tabImportGoods";
            this.tabImportGoods.Size = new System.Drawing.Size(976, 535);
            this.tabImportGoods.TabIndex = 3;
            this.tabImportGoods.Text = "Nhập hàng";
            this.tabImportGoods.UseVisualStyleBackColor = true;
            // 
            // panImport
            // 
            this.panImport.Controls.Add(this.importInfo);
            this.panImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panImport.Location = new System.Drawing.Point(0, 0);
            this.panImport.Name = "panImport";
            this.panImport.Size = new System.Drawing.Size(976, 535);
            this.panImport.TabIndex = 0;
            // 
            // tabStatistic
            // 
            this.tabStatistic.Controls.Add(this.panStastic);
            this.tabStatistic.Location = new System.Drawing.Point(4, 22);
            this.tabStatistic.Name = "tabStatistic";
            this.tabStatistic.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatistic.Size = new System.Drawing.Size(976, 535);
            this.tabStatistic.TabIndex = 1;
            this.tabStatistic.Text = "Thống kê";
            this.tabStatistic.UseVisualStyleBackColor = true;
            // 
            // panStastic
            // 
            this.panStastic.Controls.Add(this.statisticalInfo);
            this.panStastic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panStastic.Location = new System.Drawing.Point(3, 3);
            this.panStastic.Name = "panStastic";
            this.panStastic.Size = new System.Drawing.Size(970, 529);
            this.panStastic.TabIndex = 0;
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.panSetting);
            this.tabSetting.Location = new System.Drawing.Point(4, 22);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabSetting.Size = new System.Drawing.Size(976, 535);
            this.tabSetting.TabIndex = 2;
            this.tabSetting.Text = "Thiết lập";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // panSetting
            // 
            this.panSetting.Controls.Add(this.settingInfo);
            this.panSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSetting.Location = new System.Drawing.Point(3, 3);
            this.panSetting.Name = "panSetting";
            this.panSetting.Size = new System.Drawing.Size(970, 529);
            this.panSetting.TabIndex = 0;
            // 
            // saleInfo
            // 
            this.saleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saleInfo.Location = new System.Drawing.Point(0, 0);
            this.saleInfo.Name = "saleInfo";
            this.saleInfo.Size = new System.Drawing.Size(970, 529);
            this.saleInfo.TabIndex = 0;
            // 
            // importInfo
            // 
            this.importInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importInfo.Location = new System.Drawing.Point(0, 0);
            this.importInfo.Name = "importInfo";
            this.importInfo.Size = new System.Drawing.Size(976, 535);
            this.importInfo.TabIndex = 0;
            // 
            // statisticalInfo
            // 
            this.statisticalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statisticalInfo.Location = new System.Drawing.Point(0, 0);
            this.statisticalInfo.Name = "statisticalInfo";
            this.statisticalInfo.Size = new System.Drawing.Size(970, 529);
            this.statisticalInfo.TabIndex = 0;
            // 
            // settingInfo
            // 
            this.settingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.settingInfo.Location = new System.Drawing.Point(0, 0);
            this.settingInfo.Name = "settingInfo";
            this.settingInfo.Size = new System.Drawing.Size(970, 529);
            this.settingInfo.TabIndex = 0;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm bán hàng";
            this.panel1.ResumeLayout(false);
            this.tabControls.ResumeLayout(false);
            this.tabSaleGoods.ResumeLayout(false);
            this.panSale.ResumeLayout(false);
            this.tabImportGoods.ResumeLayout(false);
            this.panImport.ResumeLayout(false);
            this.tabStatistic.ResumeLayout(false);
            this.panStastic.ResumeLayout(false);
            this.tabSetting.ResumeLayout(false);
            this.panSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControls;
        private System.Windows.Forms.TabPage tabSaleGoods;
        private System.Windows.Forms.TabPage tabStatistic;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.TabPage tabImportGoods;
        private System.Windows.Forms.Panel panSetting;
        private System.Windows.Forms.Panel panSale;
        private System.Windows.Forms.Panel panImport;
        private System.Windows.Forms.Panel panStastic;
        private BillDetailInfo importInfo;
        private UserControls.StatisticalInfo statisticalInfo;
        private SettingInfo settingInfo;
        private SaleProject.SaleInfo saleInfo;
    }
}