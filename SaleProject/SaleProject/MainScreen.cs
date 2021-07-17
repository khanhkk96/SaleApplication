using Controller;
using DataObjectAccess.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace SaleProject
{
    public partial class MainScreen : Form
    {
        private bool _IsEdited = false;

        private List<BillDetail> _BillDetails = new List<BillDetail>();

        private BillDetail _Detail = null;

        public MainScreen()
        {
            InitializeComponent();

            #region Category
            settingInfo.BtnSaveCategory += new EventHandler(SaveCategoryInfo);

            settingInfo.BtnCancelCategory += new EventHandler(CancelCategory);

            settingInfo.MenuItemForCategoryClicked += new ToolStripItemClickedEventHandler(MenuItemForCategoryClick);

            settingInfo.CategoryList = new CategoryController().GetListOfCategories();
            #endregion

            #region Product
            settingInfo.BtnSaveProductClick += new EventHandler(SaveProductInfo);

            settingInfo.BtnCancelProductClick += new EventHandler(CancelProduct);

            settingInfo.MenuItemForProductClicked += new ToolStripItemClickedEventHandler(MenuItemForProductClick);

            settingInfo.ProductList = new ProductController().GetListOfProducts();
            #endregion

            #region Bill
            saleInfo.BtnFinishClick += new EventHandler(SaveBillInfo);

            saleInfo.BtnRefreshClick += new EventHandler(RefreshBill);
            #endregion

            #region Detail
            saleInfo.BtnSaveDetailClick += new EventHandler(SaveDetailInfo);

            saleInfo.BtnCancelDetailClick += new EventHandler(CancelDetail);

            saleInfo.MenuItemForDetailClicked += new ToolStripItemClickedEventHandler(MenuItemForDetailClick);

            saleInfo.ProductList = settingInfo.ProductList.Where(x => x.Inventory > 0).ToList();
            #endregion

            #region Import
            importInfo.BtnSaveClick += new EventHandler(SaveImportInfo);

            importInfo.BtnCancelClick += new EventHandler(CancelImport);

            importInfo.MenuItemClicked += new ToolStripItemClickedEventHandler(MenuItemForImportClick);

            importInfo.ImportList = new ImportController().GetListOfImports();

            importInfo.ProductList = settingInfo.ProductList;
            #endregion

            #region Stastic
            statisticalInfo.MenuItemForBillClicked += new ToolStripItemClickedEventHandler(MenuItemForBillClick);

            statisticalInfo.BillList = new BillController().GetListOfBills();

            statisticalInfo.BtnSearchClick += new EventHandler(SearchResult);
            #endregion
        }

        #region Category
        private void SaveCategoryInfo(object sender, EventArgs e)
        {
            if (_IsEdited)
            {
                if (new CategoryController()
                    .EditCategoryInfo(settingInfo.CategoryList[settingInfo.SelectedCategory].Id,
                    settingInfo.CategoryName, settingInfo.Note))
                {
                    settingInfo.CategoryList[settingInfo.SelectedCategory].Name = settingInfo.CategoryName;
                    settingInfo.CategoryList[settingInfo.SelectedCategory].Note = settingInfo.Note;
                    settingInfo.CategoryList = settingInfo.CategoryList;
                    ClearCategory();
                }
            }
            else
            {
                CategoryOfProduct category = new CategoryController()
                    .AddCategoryInfo(settingInfo.CategoryName, settingInfo.Note);
                if (category != null)
                {
                    settingInfo.CategoryList.Insert(0, category);
                    settingInfo.CategoryList = settingInfo.CategoryList;
                    ClearCategory();
                }
            }
        }

        private void CancelCategory(object sender, EventArgs e)
        {
            ClearCategory();
        }

        private void MenuItemForCategoryClick(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = settingInfo.CategoryList[settingInfo.SelectedCategory];
            if (e.ClickedItem.Name == Constant.EDIT_MENU_ITEM_NAME)
            {
                settingInfo.CategoryName = item.Name;
                settingInfo.Note = item.Note;
                _IsEdited = true;
            }
            else
            {
                if (new CategoryController().DeleteCategoryInfo(item.Id))
                {
                    settingInfo.CategoryList.RemoveAt(settingInfo.SelectedCategory);
                    settingInfo.CategoryList = settingInfo.CategoryList;
                }
            }
        }

        private void ClearCategory()
        {
            settingInfo.CategoryName = string.Empty;
            settingInfo.Note = string.Empty;
            _IsEdited = false;
        }
        #endregion

        #region Product
        private void SaveProductInfo(object sender, EventArgs e)
        {
            Product product = null;
            if (_IsEdited)
            {
                if ((product = new ProductController().EditProductInfo(
                    settingInfo.ProductList[settingInfo.SelectedProduct].Id, settingInfo.Product_Name,
                    settingInfo.Price, settingInfo.ExpiredTime, settingInfo.CategoryId)) != null)
                {
                    settingInfo.ProductList[settingInfo.SelectedProduct] = product;
                    settingInfo.ProductList = settingInfo.ProductList;
                    importInfo.ProductList = settingInfo.ProductList;
                    saleInfo.ProductList = settingInfo.ProductList;
                    ClearProductInfo();
                }
            }
            else
            {
                product = new ProductController()
                    .AddProductInfo(settingInfo.Product_Name, settingInfo.Price,
                    settingInfo.ExpiredTime, settingInfo.CategoryId);
                if (product != null)
                {
                    settingInfo.ProductList.Insert(0, product);
                    settingInfo.ProductList = settingInfo.ProductList;
                    importInfo.ProductList = settingInfo.ProductList;
                    saleInfo.ProductList = settingInfo.ProductList;
                    ClearProductInfo();
                }
            }
        }

        private void CancelProduct(object sender, EventArgs e)
        {
            ClearProductInfo();
        }

        private void MenuItemForProductClick(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = settingInfo.ProductList[settingInfo.SelectedProduct];
            if (e.ClickedItem.Name == Constant.EDIT_MENU_ITEM_NAME)
            {
                settingInfo.Product_Name = item.Name;
                settingInfo.Price = item.Price.ToString();
                settingInfo.ExpiredTime = item.ExpiredDate;
                settingInfo.CategoryId = item.CategoryId;
                _IsEdited = true;
            }
            else
            {
                if (new ProductController().DeleteProductInfo(item.Id))
                {
                    settingInfo.ProductList.RemoveAt(settingInfo.SelectedProduct);
                    settingInfo.ProductList = settingInfo.ProductList;
                    importInfo.ProductList = settingInfo.ProductList;
                    saleInfo.ProductList = settingInfo.ProductList;
                }
            }
        }

        private void ClearProductInfo()
        {
            settingInfo.Product_Name = string.Empty;
            settingInfo.Price = string.Empty;
            settingInfo.ExpiredTime = DateTime.Now;
            settingInfo.CategoryId = new Guid();
            _IsEdited = false;
        }
        #endregion

        #region Bill
        private void SaveBillInfo(object sender, EventArgs e)
        {
            Bill bill = new BillController().AddBillInfo(saleInfo.SaleDate,
                saleInfo.Client, saleInfo.PhoneNo, saleInfo.Address, saleInfo.BillNote);
            if (bill != null)
            {
                if (new BillDetailController().SaleDetailInBill(_BillDetails, bill))
                {
                    ClearBill();
                }
            }
        }

        private void RefreshBill(object sender, EventArgs e)
        {
            ClearBill();
        }

        private void ClearBill()
        {
            saleInfo.Client = string.Empty;
            saleInfo.PhoneNo = string.Empty;
            saleInfo.Address = string.Empty;
            saleInfo.Total = "0";
            saleInfo.SaleDate = DateTime.Now;
            saleInfo.BillNote = string.Empty;

            _Detail = null;
            ClearDetail();
            _BillDetails.Clear();
            saleInfo.DetailList = _BillDetails;
        }
        #endregion

        #region Detail
        private void SaveDetailInfo(object sender, EventArgs e)
        {
            double priceInfo = 0;
            int quantityInfo = 0;
            if (saleInfo.SelectedProduct == new Guid() || string.IsNullOrWhiteSpace(saleInfo.Price) ||
                    string.IsNullOrWhiteSpace(saleInfo.Quantity) || !double.TryParse(saleInfo.Price, out priceInfo) ||
                    !int.TryParse(saleInfo.Quantity, out quantityInfo))
            {
                MessageBox.Show(Constant.ADD_PRODUCT_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (_IsEdited)
            {
                if (saleInfo.ProductList.Where(x => x.Id == saleInfo.SelectedProduct).FirstOrDefault().Inventory >= int.Parse(saleInfo.Quantity) &&
                    (_Detail.ProductId == saleInfo.SelectedProduct || (_Detail.ProductId != saleInfo.SelectedProduct &&
                    _BillDetails.Where(x => x.ProductId == saleInfo.SelectedProduct).FirstOrDefault() == null)))
                {
                    saleInfo.Total = (double.Parse(saleInfo.Total) - _Detail.Quantity * _Detail.Price).ToString();

                    _Detail.ProductId = saleInfo.SelectedProduct;
                    _Detail.Product = settingInfo.ProductList.Where(x => x.Id == saleInfo.SelectedProduct).FirstOrDefault();
                    _Detail.Quantity = quantityInfo;
                    _Detail.Price = priceInfo;
                    _Detail.Note = saleInfo.DetailNote;

                    saleInfo.DetailList = _BillDetails;
                    saleInfo.Total = (double.Parse(saleInfo.Total) + _Detail.Quantity * _Detail.Price).ToString();
                    ClearDetail();
                }
                else
                {
                    MessageBox.Show(Constant.ADD_PRODUCT_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (_BillDetails.Where(x => x.ProductId == saleInfo.SelectedProduct).FirstOrDefault() == null &&
                    saleInfo.ProductList.Where(x => x.Id == saleInfo.SelectedProduct).FirstOrDefault().Inventory >= int.Parse(saleInfo.Quantity))
                {
                    _Detail = new BillDetail()
                    {
                        ProductId = saleInfo.SelectedProduct,
                        Product = settingInfo.ProductList.Where(x => x.Id == saleInfo.SelectedProduct).FirstOrDefault(),
                        Quantity = quantityInfo,
                        Price = priceInfo,
                        Note = saleInfo.DetailNote,
                    };
                    _BillDetails.Add(_Detail);
                    saleInfo.DetailList = _BillDetails;
                    saleInfo.Total = (double.Parse(saleInfo.Total) + _Detail.Quantity * _Detail.Price).ToString();
                    ClearDetail();
                }
                else
                {
                    MessageBox.Show(Constant.ADD_PRODUCT_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CancelDetail(object sender, EventArgs e)
        {
            ClearDetail();
        }

        private void MenuItemForDetailClick(object sender, ToolStripItemClickedEventArgs e)
        {
            _Detail = _BillDetails[saleInfo.SelectedDetail];
            if (e.ClickedItem.Name == Constant.EDIT_MENU_ITEM_NAME)
            {
                saleInfo.SelectedProduct = _Detail.ProductId;
                saleInfo.Price = _Detail.Price.ToString();
                saleInfo.Quantity = _Detail.Quantity.ToString();
                saleInfo.DetailNote = _Detail.Note;
                _IsEdited = true;
            }
            else
            {
                DialogResult result = MessageBox.Show(Constant.DELETE_TEXT, Constant.NOTE_TEXT,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool isSuccess = _BillDetails.Remove(_Detail);
                    if (isSuccess)
                    {
                        MessageBox.Show(Constant.DELETE_SUCCESSFULLY, Constant.NOTE_TEXT,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        saleInfo.DetailList = _BillDetails;

                        saleInfo.Total = (double.Parse(saleInfo.Total) - _Detail.Quantity * _Detail.Price).ToString();
                    }
                    else
                    {
                        MessageBox.Show(Constant.DELETE_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearDetail()
        {
            saleInfo.SelectedProduct = new Guid();
            saleInfo.Quantity = string.Empty;
            saleInfo.Price = string.Empty;
            saleInfo.DetailNote = string.Empty;
            _IsEdited = false;
        }
        #endregion

        #region Import
        private void SaveImportInfo(object sender, EventArgs e)
        {
            Import import = null;
            if (_IsEdited)
            {
                if ((import = new ImportController().EditImportInfo(
                    importInfo.ImportList[importInfo.SelectedImport].Id, importInfo.ProductId,
                    importInfo.Quantity, importInfo.Price, importInfo.ImportDate, importInfo.Note)) != null)
                {
                    importInfo.ImportList[importInfo.SelectedImport] = import;
                    importInfo.ImportList = importInfo.ImportList;
                    ClearImportInfo();
                }
            }
            else
            {
                import = new ImportController()
                    .AddImportInfo(importInfo.ProductId, importInfo.Quantity, importInfo.Price,
                    importInfo.ImportDate, importInfo.Note);
                if (import != null)
                {
                    importInfo.ImportList.Insert(0, import);
                    importInfo.ImportList = importInfo.ImportList;
                    ClearImportInfo();
                }
            }
        }

        private void CancelImport(object sender, EventArgs e)
        {
            ClearImportInfo();
        }

        private void MenuItemForImportClick(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = importInfo.ImportList[importInfo.SelectedImport];
            if (e.ClickedItem.Name == Constant.EDIT_MENU_ITEM_NAME)
            {
                importInfo.ProductId = item.ProductId;
                importInfo.Quantity = item.Quantity.ToString();
                importInfo.Price = item.Price.ToString();
                importInfo.ImportDate = item.ImportedDate;
                importInfo.Note = item.Note;
                _IsEdited = true;
            }
            else
            {
                if (new ProductController().DeleteProductInfo(item.Id))
                {
                    importInfo.ImportList.RemoveAt(importInfo.SelectedImport);
                    importInfo.ImportList = importInfo.ImportList;
                }
            }
        }

        private void ClearImportInfo()
        {
            importInfo.ProductId = new Guid();
            importInfo.Price = string.Empty;
            importInfo.Quantity = string.Empty;
            importInfo.ImportDate = DateTime.Now;
            importInfo.Note = string.Empty;
            _IsEdited = false;
        }
        #endregion

        #region Stastic
        private void SearchResult(object sender, EventArgs e)
        {
            if (statisticalInfo.SelectedType == 0)
            {
                statisticalInfo.ProductList = new ProductController().GetListOfExpiringProducts();
            }
            else
            {
                statisticalInfo.BillList = new BillController().
                    GetListOfBillsByDate(statisticalInfo.FromDate, statisticalInfo.ToDate);
            }
        }

        private void MenuItemForBillClick(object sender, ToolStripItemClickedEventArgs e)
        {
            Bill bill = statisticalInfo.BillList[statisticalInfo.SelectedBill];
            if (e.ClickedItem.Name == Constant.EDIT_MENU_ITEM_NAME)
            {
                EditBillForm form = new EditBillForm(bill);
                form.ShowDialog();
            }
            else
            {
                if (new BillController().DeleteBillInfo(bill.Id))
                {
                    statisticalInfo.BillList.Remove(bill);
                    statisticalInfo.BillList = statisticalInfo.BillList;
                }
            }
        }
        #endregion
    }
}
