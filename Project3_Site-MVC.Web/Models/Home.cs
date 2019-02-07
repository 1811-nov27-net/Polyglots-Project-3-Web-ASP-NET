using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3_Site_MVC.Web.Models
{
    public class Home
    {
        public Home(int OrderCount)
        {
            this.OrderCount = OrderCount;
        }

        public int OrderCount { get; set; }
    }
}
