using System.Windows.Forms;
using System;
using Controller;
using DataObjectAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace SaleProject
{
    public partial class EditBillForm : Form
    {
        private bool _IsEdited = false;

        private List<BillDetail> _BillDetails = new List<BillDetail>();

        private BillDetail _Detail = null;

        public EditBillForm()
        {
            InitializeComponent();
        }

        public EditBillForm(Bill bill)
        {
            InitializeComponent();
            
            saleInfo1.ProductList = new ProductController().GetListOfProducts().Where(x => x.Inventory > 0).ToList();

            saleInfo1.DetailList = new BillDetailController().GetBillDetailsById(bill.Id);

            saleInfo1.SelectedProduct = new Guid();

            saleInfo1.Client = bill.NameOfClient;

            saleInfo1.PhoneNo = bill.PhoneNo;

            saleInfo1.Address = bill.Address;

            saleInfo1.Total = saleInfo1.DetailList.Sum(x => x.Quantity * x.Price).ToString();

            saleInfo1.SaleDate = bill.SaleDate;

            saleInfo1.BillNote = bill.Note;

            _BillDetails = saleInfo1.DetailList;

            #region Detail
            saleInfo1.BtnSaveDetailClick += new EventHandler(SaveDetailInfo);

            saleInfo1.BtnCancelDetailClick += new EventHandler(CancelDetail);

            saleInfo1.MenuItemForDetailClicked += new ToolStripItemClickedEventHandler(MenuItemForDetailClick);
            #endregion
        }

        #region Detail
        private void SaveDetailInfo(object sender, EventArgs e)
        {
            if (_IsEdited)
            {
                if (saleInfo1.ProductList.Where(x => x.Id == saleInfo1.SelectedProduct).FirstOrDefault().Inventory >= int.Parse(saleInfo1.Quantity) &&
                    (_Detail.ProductId == saleInfo1.SelectedProduct || (_Detail.ProductId != saleInfo1.SelectedProduct &&
                    _BillDetails.Where(x => x.ProductId == saleInfo1.SelectedProduct).FirstOrDefault() == null)))
                {
                    saleInfo1.Total = (double.Parse(saleInfo1.Total) - _Detail.Quantity * _Detail.Price).ToString();

                    _Detail.ProductId = saleInfo1.SelectedProduct;
                    _Detail.Product = saleInfo1.ProductList.Where(x => x.Id == saleInfo1.SelectedProduct).FirstOrDefault();
                    _Detail.Quantity = int.Parse(saleInfo1.Quantity);
                    _Detail.Price = double.Parse(saleInfo1.Price);
                    _Detail.Note = saleInfo1.DetailNote;

                    saleInfo1.DetailList = _BillDetails;
                    ClearDetail();
                    saleInfo1.Total = (double.Parse(saleInfo1.Total) + _Detail.Quantity * _Detail.Price).ToString();
                }
                else
                {
                    MessageBox.Show(Constant.ADD_PRODUCT_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (_BillDetails.Where(x => x.ProductId == saleInfo1.SelectedProduct).FirstOrDefault() == null &&
                    saleInfo1.ProductList.Where(x => x.Id == saleInfo1.SelectedProduct).FirstOrDefault().Inventory >= int.Parse(saleInfo1.Quantity))
                {
                    _Detail = new BillDetail()
                    {
                        ProductId = saleInfo1.SelectedProduct,
                        Product = saleInfo1.ProductList.Where(x => x.Id == saleInfo1.SelectedProduct).FirstOrDefault(),
                        Quantity = int.Parse(saleInfo1.Quantity),
                        Price = double.Parse(saleInfo1.Price),
                        Note = saleInfo1.DetailNote,
                    };
                    _BillDetails.Add(_Detail);
                    saleInfo1.DetailList = _BillDetails;
                    ClearDetail();

                    saleInfo1.Total = (double.Parse(saleInfo1.Total) + _Detail.Quantity * _Detail.Price).ToString();
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
            _Detail = _BillDetails[saleInfo1.SelectedDetail];
            if (e.ClickedItem.Name == Constant.EDIT_MENU_ITEM_NAME)
            {
                saleInfo1.SelectedProduct = _Detail.ProductId;
                saleInfo1.Price = _Detail.Price.ToString();
                saleInfo1.Quantity = _Detail.Quantity.ToString();
                saleInfo1.DetailNote = _Detail.Note;
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
                        saleInfo1.DetailList = _BillDetails;

                        saleInfo1.Total = (double.Parse(saleInfo1.Total) - _Detail.Quantity * _Detail.Price).ToString();
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
            saleInfo1.SelectedProduct = new Guid();
            saleInfo1.Quantity = string.Empty;
            saleInfo1.Price = string.Empty;
            saleInfo1.DetailNote = string.Empty;
            _IsEdited = false;
        }
        #endregion
    }
}
