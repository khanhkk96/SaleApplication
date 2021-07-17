using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataObjectAccess.Models;

namespace SaleProject
{
    public partial class BillDetailInfo : UserControl
    {
        #region Properties
        public Guid ProductId
        {
            get { return (Guid)cboProduct.SelectedValue; }
            set
            {
                cboProduct.SelectedValue = value;
            }
        }

        public string Quantity
        {
            get { return txtQuantity.Text; }
            set { txtQuantity.Text = value.ToString(); }
        }

        public string Price
        {
            get { return txtPrice.Text; }
            set { txtPrice.Text = value.ToString(); }
        }

        public DateTime ImportDate
        {
            get { return dtpImportDate.Value; }
            set { dtpImportDate.Value = value; }
        }

        public string Note
        {
            get { return txtNote.Text; }
            set { txtNote.Text = value; }
        }

        public List<Import> ImportList
        {
            get { return dgvImportedGoods.DataSource as List<Import>; }
            set { dgvImportedGoods.DataSource = value.ToList(); }
        }

        public List<Product> ProductList
        {
            get { return cboProduct.DataSource as List<Product>; }
            set { cboProduct.DataSource = value.ToList(); }
        }

        public int SelectedImport
        {
            get { return dgvImportedGoods.SelectedRows[0].Index; }
        }

        public event ToolStripItemClickedEventHandler MenuItemClicked
        {
            add { MenuForImport.ItemClicked += value; }
            remove { MenuForImport.ItemClicked -= value; }
        }

        public event EventHandler BtnSaveClick
        {
            add { btnSave.Click += value; }
            remove { btnSave.Click -= value; }
        }

        //public event EventHandler BtnEditClick
        //{
        //    add { btnEdit.Click += value; }
        //    remove { btnEdit.Click -= value; }
        //}

        public event EventHandler BtnCancelClick
        {
            add { btnCancel.Click += value; }
            remove { btnCancel.Click -= value; }
        }
        #endregion

        public BillDetailInfo()
        {
            InitializeComponent();
        }

        private void cboProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            txtPrice.Text = (cboProduct.SelectedItem as Product)?.Price.ToString();
        }
    }
}
