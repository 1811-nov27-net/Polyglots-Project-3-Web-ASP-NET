using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Project3_Site_MVC.Library.RepositoriesInterfaces
{
    public interface IOrderHistory
    {
        List<OrderHistory> GetAll(string column = "", string order = "");
        OrderHistory GetById(int id);

        int GetOrderCount();
        
        List<OrderHistory> Search(int id, string column = "", string order = "");
        List<OrderHistory> Search(string store, string column = "", string order = "");
    }
}
