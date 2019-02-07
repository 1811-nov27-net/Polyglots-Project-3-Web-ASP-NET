using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data;
using MySql.Data.Entity;

namespace Project3_Site_MVC.DataAccess
{
    [Table("orderhistory", Schema = "admin_order_process")]
    public partial class Orderhistory
    {
        [Column("id", TypeName = "int(10) unsigned")]
        public int Id { get; set; }
        [Column("order_number", TypeName = "int(10) unsigned")]
        public int OrderNumber { get; set; }
        [Required]
        [Column("store_name")]
        [StringLength(100)]
        public string StoreName { get; set; }
        [Column("order_total", TypeName = "decimal(10,0)")]
        public decimal OrderTotal { get; set; }
        [Column("date_order")]
        public DateTime DateOrder { get; set; }
        [Column("products")]
        public string Products { get; set; }
    }
}
