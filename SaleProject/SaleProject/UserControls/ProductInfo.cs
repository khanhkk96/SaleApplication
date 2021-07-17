using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataObjectAccess.Models;
using System.Linq;

namespace SaleProject.UserControls
{
    public partial class ProductInfo : UserControl
    {
        #region Properties
        public string NameProduct
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public string Price
        {
            get { return txtPrice.Text; }
            set { txtPrice.Text = value; }
        }

        public DateTime ExpiredTime
        {
            get { return dtpExpiredTime.Value; }
            set { dtpExpiredTime.Value = value; }
        }

        public Guid CategoryId
        {
            get { return (Guid)cboCategory.SelectedValue; }
            set { cboCategory.SelectedValue = value; }
        }

        public List<CategoryOfProduct> CategoryList
        {
            get { return cboCategory.DataSource as List<CategoryOfProduct>; }
            set { cboCategory.DataSource = value.ToList(); }
        }

        public List<Product> ProductList
        {
            get { return dgvProducts.DataSource as List<Product>; }
            set { dgvProducts.DataSource = value.ToList(); }
        }

        public int SelectedProduct
        {
            get { return dgvProducts.SelectedRows[0].Index; }
        }

        public event ToolStripItemClickedEventHandler MenuItemClicked
        {
            add { MenuForProduct.ItemClicked += value; }
            remove { MenuForProduct.ItemClicked -= value; }
        }

        public event EventHandler BtnSaveClick
        {
            add { btnSaveProductInfo.Click += value; }
            remove { btnSaveProductInfo.Click -= value; }
        }

        public event EventHandler BtnCancelClick
        {
            add { btnCancel.Click += value; }
            remove { btnCancel.Click -= value; }
        }
        #endregion

        public ProductInfo()
        {
            InitializeComponent();

            ProductList = new List<Product>();

            dgvProducts.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
    }
}
