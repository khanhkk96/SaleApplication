using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataObjectAccess.Models
{
    /// <summary>
    /// Information of category
    /// </summary>
    public class CategoryOfProduct
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50), Required, Index(IsUnique = true), DisplayName("Tên danh mục")]
        public string Name { get; set; }

        [StringLength(100), DisplayName("Ghi chú")]
        public string Note { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime AddedTime { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
