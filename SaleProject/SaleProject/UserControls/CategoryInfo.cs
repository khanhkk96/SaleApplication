using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataObjectAccess.Models;

namespace SaleProject
{
    public partial class CategoryInfo : UserControl
    {
        #region Properties
        public string NameCategory
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public string Note
        {
            get { return txtNote.Text; }
            set { txtNote.Text = value; }
        }

        public int SelectedCategory
        {
            get { return dgvCategories.SelectedRows[0].Index; }
        }

        public event ToolStripItemClickedEventHandler MenuItemClicked
        {
            add { MenuForCategory.ItemClicked += value; }
            remove { MenuForCategory.ItemClicked -= value; }
        }

        public List<CategoryOfProduct> CategoryList
        {
            get { return dgvCategories.DataSource as List<CategoryOfProduct>; }
            set { dgvCategories.DataSource = value.ToList(); }
        }

        public event EventHandler BtnSaveClick
        {
            add { btnSaveInfo.Click += value; }
            remove { btnSaveInfo.Click -= value; }
        }

        public event EventHandler BtnCancelClick
        {
            add { btnCancel.Click += value; }
            remove { btnCancel.Click -= value; }
        }
        #endregion

        public CategoryInfo()
        {
            InitializeComponent();
        }
    }
}
