using DataObjectAccess;
using DataObjectAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controller
{
    public class ImportController
    {
        private SaleContext _Context = null;

        public ImportController()
        {
            HandleHelper handleHelper = new HandleHelper();
            _Context = HandleHelper.GetInstance();
        }

        #region GetImport
        /// <summary>
        /// Lay thong tin nhap hang
        /// </summary>
        /// <param name="id">id nhap hang</param>
        /// <returns>hoa don nhap</returns>
        public Import GetImportInfo(Guid id)
        {
            return _Context.Imports.Where(x => x.Id == id).FirstOrDefault();
        }
        #endregion

        #region GetImports
        /// <summary>
        /// Lay danh sach hoa don nhap hang
        /// </summary>
        /// <returns>danh sach da lay duoc</returns>
        public List<Import> GetListOfImports()
        {
            return _Context.Imports.OrderByDescending(x => x.ImportedDate).ToList();
        }
        #endregion

        #region AddImport
        /// <summary>
        /// nhap them hang moi
        /// </summary>
        /// <param name="quantity">so luong</param>
        /// <param name="price">gia sp</param>
        /// <param name="importedDate">ngay nhap hang</param>
        /// <param name="productId">id san pham</param>
        /// <param name="note">ghi chu</param>
        /// <returns>hoa don nhap</returns>
        public Import AddImportInfo(Guid productId, string quantity, string price, DateTime importedDate, string note)
        {
            if (productId == new Guid() || string.IsNullOrWhiteSpace(quantity) || string.IsNullOrWhiteSpace(price))
            {
                return null;
            }
            double priceInfo = 0;
            int quantityInfo = 0;
            if (!double.TryParse(price, out priceInfo) || !int.TryParse(quantity, out quantityInfo))
            {
                return null;
            }

            Import import = new Import
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                Product = new ProductController().GetProductInfo(productId),
                Price = priceInfo,
                ImportedDate = importedDate,
                Quantity = quantityInfo,
                Note = note,
            };
            _Context.Imports.Add(import);
            try
            {
                _Context.SaveChanges();
                return import;
            }
            catch
            {
                MessageBox.Show(Constant.SAVE_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleHelper.RevertChange();
                return null;
            }
        }
        #endregion

        #region EditImport
        /// <summary>
        /// sua hoa don nhap hang
        /// </summary>
        /// <param name="id">id hoa don nhap</param>
        /// <param name="quantity">so luong</param>
        /// <param name="price">gia sp</param>
        /// <param name="importedDate">ngay nhap hang</param>
        /// <param name="productId">id san pham</param>
        /// <param name="note">ghi chu</param>
        /// <returns>hoa don nhap</returns>
        public Import EditImportInfo(Guid id, Guid productId, string quantity, string price,
            DateTime importedDate, string note)
        {
            if (productId == new Guid() || string.IsNullOrWhiteSpace(quantity) || string.IsNullOrWhiteSpace(price))
            {
                return null;
            }
            double priceInfo = 0;
            int quantityInfo = 0;
            if (!double.TryParse(price, out priceInfo) || !int.TryParse(quantity, out quantityInfo))
            {
                return null;
            }

            Import import = GetImportInfo(id);
            import.ProductId = productId;
            import.Product = new ProductController().GetProductInfo(productId);
            import.Price = priceInfo;
            import.ImportedDate = importedDate;
            import.Quantity = quantityInfo;
            import.Note = note;
            try
            {
                _Context.SaveChanges();
                MessageBox.Show(Constant.SALE_SUCCESSFULLY, Constant.NOTE_TEXT,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return import;
            }
            catch
            {
                MessageBox.Show(Constant.SAVE_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleHelper.RevertChange();
                return null;
            }
        }
        #endregion

        #region DeleteImport
        /// <summary>
        /// Xoa hoa don nhap
        /// </summary>
        /// <param name="id">id hoa don nhap</param>
        /// <returns>true or false</returns>
        public bool DeleteImportInfo(Guid id)
        {
            DialogResult result = MessageBox.Show(Constant.DELETE_TEXT, Constant.NOTE_TEXT,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Import import = GetImportInfo(id);
                _Context.Imports.Remove(import);
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
