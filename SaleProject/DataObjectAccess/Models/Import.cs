using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectAccess.Models
{
    /// <summary>
    /// Information of importing the product
    /// </summary>
    public class Import
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Id sản phẩm"), Browsable(false)]
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId"), DisplayName("Sản phẩm")]
        public virtual Product Product { get; set; }

        [DataType(DataType.Date), DisplayName("Ngày nhập")]
        public DateTime ImportedDate { get; set; }

        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [DataType(DataType.Currency), DisplayName("Giá")]
        public double Price { get; set; }

        [StringLength(100), DisplayName("Ghi chú")]
        public string Note { get; set; }
    }
}
