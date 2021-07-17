using DataObjectAccess;
using DataObjectAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controller
{
    public class BillController
    {
        private SaleContext _Context = null;

        public BillController()
        {
            HandleHelper handleHelper = new HandleHelper();
            _Context = HandleHelper.GetInstance();
        }

        #region GetImport
        /// <summary>
        /// Lay thong tin hoa don ban hang
        /// </summary>
        /// <param name="id">id hoa don</param>
        /// <returns>hoad don ban hang</returns>
        public Bill GetBillInfo(Guid id)
        {
            return _Context.Bills.Where(x => x.Id == id).FirstOrDefault();
        }
        #endregion

        #region GetBills
        /// <summary>
        /// Lay danh sach hoa don ban hang
        /// </summary>
        /// <returns>danh sach da lay duoc</returns>
        public List<Bill> GetListOfBills()
        {
            return _Context.Bills.OrderByDescending(x => x.SaleDate).ToList();
        }
        #endregion

        #region GetBillsByDate
        /// <summary>
        /// Lay danh sach hoa don ban hang
        /// </summary>
        /// <returns>danh sach da lay duoc</returns>
        public List<Bill> GetListOfBillsByDate(DateTime fromDate, DateTime toDate)
        {
            return _Context.Bills.Where(x => x.SaleDate > fromDate || x.SaleDate <= toDate)?.
                OrderByDescending(x => x.SaleDate).ToList();
        }
        #endregion

        #region AddBill
        /// <summary>
        /// tao hoa don ban hang
        /// </summary>
        /// <param name="client">khach hang</param>
        /// <param name="phoneNo">sdt</param>
        /// <param name="saledDate">ngay ban hang</param>
        /// <param name="address">dia chi</param>
        /// <param name="note">ghi chu</param>
        /// <returns>hoa don ban hang</returns>
        public Bill AddBillInfo(DateTime saledDate, string client, string phoneNo, string address, string note)
        {
            if (string.IsNullOrWhiteSpace(client) || string.IsNullOrWhiteSpace(phoneNo) || string.IsNullOrWhiteSpace(address))
            {
                return null;
            }

            Bill bill = new Bill
            {
                Id = Guid.NewGuid(),
                NameOfClient = client,
                SaleDate = saledDate,
                PhoneNo = phoneNo,
                Address = address,
                Note = note,
            };
            _Context.Bills.Add(bill);
            try
            {
                _Context.SaveChanges();
                return bill;
            }
            catch
            {
                MessageBox.Show(Constant.SALE_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HandleHelper.RevertChange();
                return null;
            }
        }
        #endregion

        #region EditBill
        /// <summary>
        /// sua thong tin hoa don ban hang
        /// </summary>
        /// <param name="client">khach hang</param>
        /// <param name="phoneNo">sdt</param>
        /// <param name="saledDate">ngay ban hang</param>
        /// <param name="address">dia chi</param>
        /// <param name="note">ghi chu</param>
        /// <returns>hoa don ban hang</returns>
        public Bill EditBillInfo(Guid id, DateTime saledDate, string client, string phoneNo, string address, string note)
        {
            if (string.IsNullOrWhiteSpace(client) || string.IsNullOrWhiteSpace(phoneNo) || string.IsNullOrWhiteSpace(address))
            {
                return null;
            }

            Bill bill = GetBillInfo(id);
            bill.NameOfClient = client;
            bill.SaleDate = saledDate;
            bill.PhoneNo = phoneNo;
            bill.Address = address;
            bill.Note = note;
            try
            {
                _Context.SaveChanges();
                return bill;
            }
            catch
            {
                HandleHelper.RevertChange();
                return null;
            }
        }
        #endregion

        #region DeleteBill
        /// <summary>
        /// Xoa hoa don ban hang
        /// </summary>
        /// <param name="id">id hoa don</param>
        /// <returns>true or false</returns>
        public bool DeleteBillInfo(Guid id)
        {
            DialogResult result = MessageBox.Show(Constant.DELETE_TEXT, Constant.NOTE_TEXT,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                List<BillDetail> details = new BillDetailController().GetBillDetailsById(id);
                _Context.BillDetails.RemoveRange(details);
                try
                {
                    _Context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show(Constant.DELETE_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                Bill bill = GetBillInfo(id);
                _Context.Bills.Remove(bill);
                try
                {
                    _Context.SaveChanges();
                    MessageBox.Show(Constant.DELETE_SUCCESSFULLY, Constant.NOTE_TEXT,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                catch
                {
                    MessageBox.Show(Constant.DELETE_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HandleHelper.RevertChange();
                    return false;
                }
            }
            return false;
        }
        #endregion
    }
}
