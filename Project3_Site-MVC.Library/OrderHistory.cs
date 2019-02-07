using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project3_Site_MVC.Library
{
    public class OrderHistory
    {
        public int Id { get; set; }
        
        public int OrderNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string StoreName { get; set; }
        
        public decimal OrderTotal { get; set; }
        
        public DateTime DateOrder { get; set; }
        
        public string Products { get; set; }
    }
}
