using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataObjectAccess.Models;

namespace SaleProject
{
    public partial class SaleInfo : UserControl
    {
        #region Properties
        #region Bill
        public string Client
        {
            get { return txtClientName.Text; }
            set { txtClientName.Text = value; }
        }

        public string PhoneNo
        {
            get { return txtPhoneNo.Text; }
            set { txtPhoneNo.Text = value; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public string Total
        {
            get { return txtTotal.Text; }
            set { txtTotal.Text = value; }
        }

        public DateTime SaleDate
        {
            get { return dtpSaleDate.Value; }
            set { dtpSaleDate.Value = value; }
        }

        public string BillNote
        {
            get { return txtNote.Text; }
            set { txtNote.Text = value; }
        }

        public event EventHandler BtnRefreshClick
        {
            add { btnClear.Click += value; }
            remove { btnClear.Click -= value; }
        }

        public event EventHandler BtnFinishClick
        {
            add { btnFinished.Click += value; }
            remove { btnFinished.Click -= value; }
        }
        #endregion

        #region Detail
        public Guid SelectedProduct
        {
            get { return (Guid)cboProduct.SelectedValue; }
            set { cboProduct.SelectedValue = value; }
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

        public string DetailNote
        {
            get { return txtNoteProduct.Text; }
            set { txtNoteProduct.Text = value; }
        }

        public List<BillDetail> DetailList
        {
            get { return dgvSaleProduct.DataSource as List<BillDetail>; }
            set { dgvSaleProduct.DataSource = value?.ToList(); }
        }

        public List<Product> ProductList
        {
            get { return cboProduct.DataSource as List<Product>; }
            set { cboProduct.DataSource = value?.ToList(); }
        }

        public int SelectedDetail
        {
            get { return dgvSaleProduct.SelectedRows[0].Index; }
        }

        public event ToolStripItemClickedEventHandler MenuItemForDetailClicked
        {
            add { MenuForDetail.ItemClicked += value; }
            remove { MenuForDetail.ItemClicked -= value; }
        }

        public event EventHandler BtnSaveDetailClick
        {
            add { btnSaveDetail.Click += value; }
            remove { btnSaveDetail.Click -= value; }
        }

        public event EventHandler BtnCancelDetailClick
        {
            add { btnCancelDetail.Click += value; }
            remove { btnCancelDetail.Click -= value; }
        }
        #endregion
        #endregion

        public SaleInfo()
        {
            InitializeComponent();
        }

        private void CboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrice.Text = (cboProduct.SelectedItem as Product)?.Price.ToString();
        }
    }
}
