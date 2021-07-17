using System;
using System.ComponentModel.DataAnnotations;

namespace DataObjectAccess.Models
{
    /// <summary>
    /// Information of account
    /// </summary>
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string Password { get; set; }
    }
}
