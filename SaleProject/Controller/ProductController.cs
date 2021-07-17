using DataObjectAccess;
using DataObjectAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Controller
{
    public class ProductController
    {
        private SaleContext _Context = null;

        public ProductController()
        {
            HandleHelper handleHelper = new HandleHelper();
            _Context = HandleHelper.GetInstance();
        }

        #region GetProduct
        /// <summary>
        /// Lay thong tin san pham
        /// <param name="id">id san pham</param>
        /// </summary>
        /// <returns>san pham</returns>
        public Product GetProductInfo(Guid id)
        {
            return _Context.Products.Where(x => x.Id == id).FirstOrDefault();
        }
        #endregion

        #region GetProducts
        /// <summary>
        /// Lay danh sach san pham
        /// </summary>
        /// <returns>danh sach da lay duoc</returns>
        public List<Product> GetListOfProducts()
        {
            return _Context.Products.OrderByDescending(x => x.CreatedTime).ToList();
        }
        #endregion

        #region GetExpiringProducts
        /// <summary>
        /// Lay danh sach san pham het han
        /// </summary>
        /// <returns>danh sach da lay duoc</returns>
        public List<Product> GetListOfExpiringProducts()
        {
            return _Context.Products.Where(x => x.ExpiredDate <= DateTime.UtcNow)
                ?.OrderByDescending(x => x.ExpiredDate).ToList();
        }
        #endregion

        #region AddProduct
        /// <summary>
        /// them mot san pham moi
        /// </summary>
        /// <param name="name">ten san pham</param>
        /// <param name="price">gia sp</param>
        /// <param name="expiredDate">ngay het han</param>
        /// <param name="category">danh muc san pham</param>
        /// <returns>san pham</returns>
        public Product AddProductInfo(string name, string price, DateTime expiredDate, Guid categoryId)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(price) || categoryId == new Guid())
            {
                return null;
            }
            double priceInfo = 0;
            if (!double.TryParse(price, out priceInfo))
            {
                return null;
            }

            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = priceInfo,
                ExpiredDate = expiredDate,
                CategoryId = categoryId,
                CreatedTime = DateTime.Now,
                Category = new CategoryController().GetCategoryInfo(categoryId),
            };
            _Context.Products.Add(product);
            try
            {
                _Context.SaveChanges();
                return product;
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

        #region EditProduct
        /// <summary>
        /// Sua thong tin san pham
        /// </summary>
        /// <param name="id">id san pham</param>
        /// <param name="name">ten san pham</param>
        /// <param name="price">gia sp</param>
        /// <param name="expiredDate">ngay het han</param>
        /// <param name="category">danh muc san pham</param>
        /// <returns>san pham</returns>
        public Product EditProductInfo(Guid id, string name, string price, DateTime expiredDate, Guid categoryId)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(price) || categoryId == new Guid())
            {
                return null;
            }
            double priceInfo = 0;
            if (!double.TryParse(price, out priceInfo))
            {
                return null;
            }

            Product product = GetProductInfo(id);
            product.Name = name;
            product.Price = priceInfo;
            product.ExpiredDate = expiredDate;
            product.CategoryId = categoryId;
            product.Category = new CategoryController().GetCategoryInfo(categoryId);
            try
            {
                _Context.SaveChanges();
                return product;
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

        #region DeleteProduct
        /// <summary>
        /// Xoa thong tin san pham
        /// </summary>
        /// <param name="id">id san pham</param>
        /// <returns>true or false</returns>
        public bool DeleteProductInfo(Guid id)
        {
            DialogResult result = MessageBox.Show(Constant.DELETE_TEXT, Constant.NOTE_TEXT,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Product product = GetProductInfo(id);
                _Context.Products.Remove(product);
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
