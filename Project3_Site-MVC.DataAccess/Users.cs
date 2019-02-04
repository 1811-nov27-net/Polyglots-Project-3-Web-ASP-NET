using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project3_Site_MVC.DataAccess
{
    [Table("users", Schema = "admin_order_process")]
    public partial class Users
    {
        [Column("id", TypeName = "int(10) unsigned")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; }
        [Column("remember_token")]
        [StringLength(100)]
        public string RememberToken { get; set; }
        [Column("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
