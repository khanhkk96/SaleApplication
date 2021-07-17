using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataObjectAccess.Models;

namespace SaleProject.UserControls
{
    public partial class StatisticalInfo : UserControl
    {
        #region Properties
        public int SelectedType
        {
            get { return cboType.SelectedIndex; }
            set { cboType.SelectedIndex = value; }
        }

        public DateTime FromDate
        {
            get { return dpFrom.Value; }
            set { dpFrom.Value = value; }
        }

        public DateTime ToDate
        {
            get { return dpTo.Value; }
            set { dpTo.Value = value; }
        }

        public event EventHandler BtnSearchClick
        {
            add { btnStastic.Click += value; }
            remove { btnStastic.Click -= value; }
        }

        public List<Bill> BillList
        {
            get { return dgvResult.DataSource as List<Bill>; }
            set
            {
                dgvResult.DataSource = value.ToList();
                dgvResult.ContextMenuStrip = MenuForBill;
            }
        }

        public List<Product> ProductList
        {
            get { return dgvResult.DataSource as List<Product>; }
            set
            {
                dgvResult.DataSource = value.ToList();
                dgvResult.ContextMenuStrip = null;
            }
        }

        public int SelectedBill
        {
            get { return dgvResult.SelectedRows[0].Index; }
        }

        public event ToolStripItemClickedEventHandler MenuItemForBillClicked
        {
            add { MenuForBill.ItemClicked += value; }
            remove { MenuForBill.ItemClicked -= value; }
        }
        #endregion

        public StatisticalInfo()
        {
            InitializeComponent();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                panFromDate.Visible = false;
                panToDate.Visible = false;
            }
            else
            {
                panFromDate.Visible = true;
                panToDate.Visible = true;
            }
        }
    }
}
