using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataObjectAccess.Models
{
    /// <summary>
    /// Detail information of bill
    /// </summary>
    public class BillDetail
    {
        [Key, Browsable(false)]
        public Guid Id { get; set; }

        [DisplayName("Id hoá đơn"), Browsable(false)]
        public Guid BillId { get; set; }

        [ForeignKey("BillId"), Browsable(false)]
        public virtual Bill Bill { get; set; }

        [DisplayName("Id sản phẩm"), Browsable(false)]
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId"), DisplayName("Sản phẩm")]
        public virtual Product Product { get; set; }

        [DisplayName("Số lượng")]
        public int Quantity { get; set; }

        [DataType(DataType.Currency), DisplayName("Giá")]
        public double Price { get; set; }

        [StringLength(100), DisplayName("Ghi chú")]
        public string Note { get; set; }
    }
}
