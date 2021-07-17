using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataObjectAccess.Models
{
    /// <summary>
    /// Information of bill
    /// </summary>
    public class Bill
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(20), DisplayName("Tên khách hàng")]
        public string NameOfClient { get; set; }

        [StringLength(20), DisplayName("Số điện thoại")]
        public string PhoneNo { get; set; }

        [DataType(DataType.Currency), DisplayName("Tổng tiền")]
        public double TotalPay { get; set; }

        [DataType(DataType.DateTime), DisplayName("Ngày bán")]
        public DateTime SaleDate { get; set; }

        [StringLength(100), DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [StringLength(100), DisplayName("Ghi chú")]
        public string Note { get; set; }
    }
}
