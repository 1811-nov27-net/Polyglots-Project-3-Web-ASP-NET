using System;
using System.Collections.Generic;
using System.Text;

namespace Project3_Site_MVC.Library.RepositoriesInterfaces
{
    interface IOrderHistory
    {
        List<OrderHistory> GetAll();
    }
}
