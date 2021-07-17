namespace SaleProject
{
    partial class SettingInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpCategories = new System.Windows.Forms.TabPage();
            this.tpProducts = new System.Windows.Forms.TabPage();
            this.categoryInfo1 = new SaleProject.CategoryInfo();
            this.productInfo1 = new SaleProject.UserControls.ProductInfo();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpCategories.SuspendLayout();
            this.tpProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 360);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tpCategories);
            this.tabControl1.Controls.Add(this.tpProducts);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(648, 360);
            this.tabControl1.TabIndex = 0;
            // 
            // tpCategories
            // 
            this.tpCategories.Controls.Add(this.categoryInfo1);
            this.tpCategories.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpCategories.Location = new System.Drawing.Point(25, 4);
            this.tpCategories.Name = "tpCategories";
            this.tpCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tpCategories.Size = new System.Drawing.Size(619, 352);
            this.tpCategories.TabIndex = 0;
            this.tpCategories.Text = "Danh mục sản phẩm";
            this.tpCategories.UseVisualStyleBackColor = true;
            // 
            // tpProducts
            // 
            this.tpProducts.Controls.Add(this.productInfo1);
            this.tpProducts.Location = new System.Drawing.Point(25, 4);
            this.tpProducts.Name = "tpProducts";
            this.tpProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tpProducts.Size = new System.Drawing.Size(619, 352);
            this.tpProducts.TabIndex = 1;
            this.tpProducts.Text = "Sản phẩm";
            this.tpProducts.UseVisualStyleBackColor = true;
            // 
            // categoryInfo1
            // 
            this.categoryInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryInfo1.Location = new System.Drawing.Point(3, 3);
            this.categoryInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.categoryInfo1.Name = "categoryInfo1";
            this.categoryInfo1.Size = new System.Drawing.Size(613, 346);
            this.categoryInfo1.TabIndex = 0;
            // 
            // productInfo1
            // 
            this.productInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productInfo1.Location = new System.Drawing.Point(3, 3);
            this.productInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.productInfo1.Name = "productInfo1";
            this.productInfo1.Size = new System.Drawing.Size(613, 346);
            this.productInfo1.TabIndex = 0;
            // 
            // SettingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SettingInfo";
            this.Size = new System.Drawing.Size(648, 360);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpCategories.ResumeLayout(false);
            this.tpProducts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpCategories;
        private CategoryInfo categoryInfo1;
        private System.Windows.Forms.TabPage tpProducts;
        private UserControls.ProductInfo productInfo1;
    }
}
