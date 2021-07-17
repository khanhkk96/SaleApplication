using DataObjectAccess;
using DataObjectAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Controller
{
    /// <summary>
    /// Handle business about category
    /// </summary>
    public class CategoryController
    {
        private SaleContext _Context = null;

        public CategoryController()
        {
            HandleHelper handleHelper = new HandleHelper();
            _Context = HandleHelper.GetInstance();
        }

        #region GetCategory
        /// <summary>
        /// Lay thong tin danh muc
        /// </summary>
        /// <param name="id">id danh muc</param>
        /// <returns>danh muc san pham</returns>
        public CategoryOfProduct GetCategoryInfo(Guid id)
        {
            return _Context.Categories.Where(x => x.Id == id).FirstOrDefault();
        }
        #endregion

        #region GetCategories
        /// <summary>
        /// Lay danh sach danh muc
        /// </summary>
        /// <returns>danh sach da lay duoc</returns>
        public List<CategoryOfProduct> GetListOfCategories()
        {
            return _Context.Categories.OrderByDescending(x => x.AddedTime).ToList();
        }
        #endregion

        #region AddCategory
        /// <summary>
        /// them mot danh muc moi
        /// </summary>
        /// <param name="name">ten danh muc</param>
        /// <param name="note">ghi chu</param>
        /// <returns></returns>
        public CategoryOfProduct AddCategoryInfo(string name, string note)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            CategoryOfProduct category = new CategoryOfProduct
            {
                Id = Guid.NewGuid(),
                Name = name,
                Note = note,
                AddedTime = DateTime.Now,
            };
            _Context.Categories.Add(category);
            try
            { 
                _Context.SaveChanges();
                return category;
            }
            catch(Exception ex)
            {
                MessageBox.Show(Constant.SAVE_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                HandleHelper.RevertChange();
                return null;
            }
        }
        #endregion

        #region EditCategory
        /// <summary>
        /// sua thong tin danh muc
        /// </summary>
        /// <param name="id">id cua danh muc</param>
        /// <param name="name">ten danh muc</param>
        /// <param name="note">ghi chu cua danh muc</param>
        /// <returns>true or false</returns>
        public bool EditCategoryInfo(Guid id,string name, string note)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            CategoryOfProduct category = GetCategoryInfo(id);
            if (category != null)
            {
                category.Name = name;
                category.Note = note;
                try
                {
                    _Context.SaveChanges();
                    return true;
                }
                catch
                {
                    MessageBox.Show(Constant.SAVE_UNSUCCESSFULLY, Constant.NOTE_TEXT,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    HandleHelper.RevertChange();
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region DeleteCategory
        /// <summary>
        /// Xoa danh muc san pham
        /// </summary>
        /// <param name="id">id cua danh muc</param>
        /// <returns>true or false</returns>
        public bool DeleteCategoryInfo(Guid id)
        {
            CategoryOfProduct category = GetCategoryInfo(id);
            if (category != null)
            {
                _Context.Categories.Remove(category);
                try
                {
                    _Context.SaveChanges();
                    return true;
                }
                catch
                {
                    MessageBox.Show(Constant.SAVE_UNSUCCESSFULLY, Constant.NOTE_TEXT,
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
