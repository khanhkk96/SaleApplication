using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataObjectAccess.Models;

namespace SaleProject
{
    public partial class SettingInfo : UserControl
    {
        #region Properties
        #region Category
        public string CategoryName
        {
            get { return categoryInfo1.NameCategory; }
            set { categoryInfo1.NameCategory = value; }
        }

        public string Note
        {
            get { return categoryInfo1.Note; }
            set { categoryInfo1.Note = value; }
        }

        public int SelectedCategory
        {
            get { return categoryInfo1.SelectedCategory; }
        }

        public event EventHandler BtnSaveCategory
        {
            add { categoryInfo1.BtnSaveClick += value; }
            remove { categoryInfo1.BtnSaveClick -= value; }
        }

        public event EventHandler BtnCancelCategory
        {
            add { categoryInfo1.BtnCancelClick += value; }
            remove { categoryInfo1.BtnCancelClick -= value; }
        }

        public event ToolStripItemClickedEventHandler MenuItemForCategoryClicked
        {
            add { categoryInfo1.MenuItemClicked += value; }
            remove { categoryInfo1.MenuItemClicked -= value; }
        }
        #endregion

        #region Product
        public Guid ProductId
        {
            get; set;
        }

        public string Product_Name
        {
            get { return productInfo1.NameProduct; }
            set { productInfo1.NameProduct = value; }
        }

        public string Price
        {
            get { return productInfo1.Price; }
            set { productInfo1.Price = value; }
        }

        public DateTime ExpiredTime
        {
            get { return productInfo1.ExpiredTime; }
            set { productInfo1.ExpiredTime = value; }
        }

        public Guid CategoryId
        {
            get { return productInfo1.CategoryId; }
            set { productInfo1.CategoryId = value; }
        }

        public int SelectedProduct
        {
            get { return productInfo1.SelectedProduct; }
        }

        public event ToolStripItemClickedEventHandler MenuItemForProductClicked
        {
            add { productInfo1.MenuItemClicked += value; }
            remove { productInfo1.MenuItemClicked -= value; }
        }

        public List<CategoryOfProduct> CategoryList
        {
            get
            {
                return categoryInfo1.CategoryList ?? new List<CategoryOfProduct>();
            }
            set
            {
                categoryInfo1.CategoryList = value;
                productInfo1.CategoryList = value;
            }
        }

        public List<Product> ProductList
        {
            get { return productInfo1.ProductList; }
            set { productInfo1.ProductList = value; }
        }

        public event EventHandler BtnSaveProductClick
        {
            add { productInfo1.BtnSaveClick += value; }
            remove { productInfo1.BtnSaveClick -= value; }
        }

        public event EventHandler BtnCancelProductClick
        {
            add { productInfo1.BtnCancelClick += value; }
            remove { productInfo1.BtnCancelClick -= value; }
        }
        #endregion
        #endregion

        public SettingInfo()
        {
            InitializeComponent();
        }
    }
}
