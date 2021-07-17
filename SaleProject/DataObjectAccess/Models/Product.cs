using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace DataObjectAccess.Models
{
    /// <summary>
    /// Information of product
    /// </summary>
    [Serializable]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50), Required, Index(IsUnique = true), DisplayName("Tên sản phẩm")]
        public string Name { get; set; }
        
        [DisplayName("Lượng tồn")]
        public int Inventory { get; set; }

        [DisplayName("Tổng số")]
        public int Total { get; set; }

        [DataType(DataType.Currency), DisplayName("Giá sản phẩm")]
        public double Price { get; set; }

        [DataType(DataType.Date), DisplayName("Ngày hết hạn")]
        public DateTime ExpiredDate { get; set; }

        [DisplayName("Id danh mục"), Browsable(false)]
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [DisplayName("Tên danh mục")]
        public virtual CategoryOfProduct Category { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime CreatedTime { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
