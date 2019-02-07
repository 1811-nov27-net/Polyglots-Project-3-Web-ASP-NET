using System;
using System.Collections.Generic;
using System.Text;

namespace Project3_Site_MVC.Library.RepositoriesInterfaces
{
    public interface IOrderHistory
    {
        List<OrderHistory> GetAll();
        OrderHistory GetById(int id);

        int GetOrderCount();
        
        List<OrderHistory> Search(int id);
        List<OrderHistory> Search(string store);
    }
}
