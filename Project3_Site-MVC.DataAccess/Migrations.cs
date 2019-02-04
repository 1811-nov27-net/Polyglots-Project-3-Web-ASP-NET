using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3_Site_MVC.DataAccess
{
    [Table("migrations", Schema = "admin_order_process")]
    public partial class Migrations
    {
        [Column("id", TypeName = "int(10) unsigned")]
        public int Id { get; set; }
        [Required]
        [Column("migration")]
        [StringLength(255)]
        public string Migration { get; set; }
        [Column("batch", TypeName = "int(11)")]
        public int Batch { get; set; }
    }
}
