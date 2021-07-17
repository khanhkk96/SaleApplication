using DataObjectAccess;
using DataObjectAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controller
{
    public class BillDetailController
    {
        private SaleContext _Context = null;

        public BillDetailController()
        {
            HandleHelper handleHelper = new HandleHelper();
            _Context = HandleHelper.GetInstance();
        }

        #region GetBillDetail
        /// <summary>
        /// Lay thong tin san pham trong hoa don
        /// </summary>
        /// <param name="id">id thanh phan</param>
        /// <returns>thanh phan hoa don</returns>
        public BillDetail GetBillDetailInfo(Guid id)
        {
            return _Context.BillDetails.Where(x => x.Id == id).FirstOrDefault();
        }
        #endregion

        #region GetBillDetailsByIdOfBill
        /// <summary>
        /// Lay thong tin san pham trong hoa don
        /// </summary>
        /// <param name="id">id thanh phan</param>
        /// <returns>thanh phan hoa don</returns>
        public List<BillDetail> GetBillDetailsById(Guid id)
        {
            return _Context.BillDetails.Where(x => x.BillId == id).ToList();
        }
        #endregion

        #region GetBillDetails
        /// <summary>
        /// Lay danh sach thanh phan hoa don
        /// </summary>
        /// <returns>danh sach da lay duoc</returns>
        public List<BillDetail> GetListOfBillDetails()
        {
            return _Context.BillDetails.ToList();
        }
        #endregion

        #region AddBillDetail
        /// <summary>
        /// them thanh phan vao hoa don
        /// </summary>
        /// <param name="quantity">so luong</param>
        /// <param name="price">gia sp</param>
        /// <param name="billId">id hoa don</param>
        /// <param name="productId">id san pham</param>
        /// <param name="note">ghi chu</param>
        /// <returns>thanh phan hoa don</returns>
        public BillDetail AddBillDetailInfo(Guid productId, Guid billId, int quantity, double price, string note)
        {
            BillDetail billDetail = new BillDetail
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                Product = new ProductController().GetProductInfo(productId),
                Price = price,
                BillId = billId,
                Bill = new BillController().GetBillInfo(billId),
                Quantity = quantity,
                Note = note,
            };
            _Context.BillDetails.Add(billDetail);
            try
            {
                _Context.SaveChanges();
                return billDetail;
            }
            catch
            {
                HandleHelper.RevertChange();
                return null;
            }
        }
        #endregion

        #region EditImport
        /// <summary>
        /// sua thanh phan hoa don
        /// </summary>
        /// <param name="id">id hoa don nhap</param>
        /// <param name="quantity">so luong</param>
        /// <param name="price">gia sp</param>
        /// <param name="billId">id hoa don</param>
        /// <param name="productId">id san pham</param>
        /// <param name="note">ghi chu</param>
        /// <returns>thanh phan hoa don</returns>
        public BillDetail EditImportInfo(Guid id, Guid productId, int quantity, double price, Guid billId, string note)
        {
            BillDetail billDetail = GetBillDetailInfo(id);
            billDetail.ProductId = productId;
            billDetail.Product = new ProductController().GetProductInfo(productId);
            billDetail.Price = price;
            billDetail.BillId = billId;
            billDetail.Bill = new BillController().GetBillInfo(billId);
            billDetail.Quantity = quantity;
            billDetail.Note = note;
            try
            {
                _Context.SaveChanges();
                return billDetail;
            }
            catch
            {
                HandleHelper.RevertChange();
                return null;
            }
        }
        #endregion

        #region DeleteBillDetail
        /// <summary>
        /// Xoa 1 thanh phan trong hoa don
        /// </summary>
        /// <param name="id">id thanh phan</param>
        /// <returns>true or false</returns>
        public bool DeleteBillDetailInfo(Guid id)
        {
            BillDetail billDetail = GetBillDetailInfo(id);
            _Context.BillDetails.Remove(billDetail);
            try
            {
                _Context.SaveChanges();
                return true;
            }
            catch
            {
                HandleHelper.RevertChange();
                return false;
            }
        }
        #endregion

        #region DeleteBillDetailsInBill
        /// <summary>
        /// Xoa tat ca thanh phan trong hoa don
        /// </summary>
        /// <param name="id">id hoa don</param>
        /// <returns>true or false</returns>
        public bool DeleteBillDetails(Guid id)
        {
            List<BillDetail> billDetails = GetBillDetailsById(id);
            _Context.BillDetails.RemoveRange(billDetails);
            try
            {
                _Context.SaveChanges();
                return true;
            }
            catch
            {
                HandleHelper.RevertChange();
                return false;
            }
        }
        #endregion

        #region SaleDetailInBill
        public bool SaleDetailInBill(List<BillDetail> billDetails, Bill bill)
        {
            foreach (var item in billDetails)
            {
                item.Id = Guid.NewGuid();
                item.BillId = bill.Id;
                item.Bill = bill;
            }
            _Context.BillDetails.AddRange(billDetails);
            try
            {
                _Context.SaveChanges();
                return true;
            }
            catch
            {
                MessageBox.Show(Constant.SALE_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HandleHelper.RevertChange();
                return false;
            }
        }
        #endregion
    }
}