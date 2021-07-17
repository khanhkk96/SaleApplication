namespace SaleProject
{
    partial class EditBillForm
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
            this.saleInfo1 = new SaleProject.SaleInfo();
            this.SuspendLayout();
            // 
            // saleInfo1
            // 
            this.saleInfo1.Address = "";
            this.saleInfo1.BillNote = "";
            this.saleInfo1.Client = "";
            this.saleInfo1.DetailNote = "";
            this.saleInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saleInfo1.Location = new System.Drawing.Point(0, 0);
            this.saleInfo1.Name = "saleInfo1";
            this.saleInfo1.PhoneNo = "";
            this.saleInfo1.Price = "";
            this.saleInfo1.Quantity = "";
            this.saleInfo1.SaleDate = new System.DateTime(2020, 2, 26, 23, 45, 12, 372);
            this.saleInfo1.Size = new System.Drawing.Size(876, 450);
            this.saleInfo1.TabIndex = 0;
            this.saleInfo1.Total = "0";
            // 
            // EditBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 450);
            this.Controls.Add(this.saleInfo1);
            this.MaximizeBox = false;
            this.Name = "EditBillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin hóa đơn";
            this.ResumeLayout(false);

        }

        #endregion

        private SaleInfo saleInfo1;
    }
}