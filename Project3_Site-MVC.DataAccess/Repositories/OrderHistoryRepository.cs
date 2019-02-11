using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Project3_Site_MVC.Library;
using Project3_Site_MVC.Library.RepositoriesInterfaces;
using MySql.Data;
using MySql.Data.Entity;
using System.Linq.Expressions;

namespace Project3_Site_MVC.DataAccess.Repositories
{
    public class OrderHistoryRepository : IOrderHistory
    {
        private readonly admin_order_processContext _db;

        public OrderHistoryRepository(admin_order_processContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            // code-first style, make sure the database exists by now.
            db.Database.EnsureCreated();
        }

        public List<OrderHistory> GetAll(string column = "", string order = "")
        {
            if (column == "")
                column = "id";
            if (order == "")
                order = "asc";

            column = column.ToLower();
            order = order.ToLower();

            List<Orderhistory> list;

            if (order == "asc")
            {
                list = _db.Orderhistory
                            .OrderBy(SortTable(column))
                            .ToList();
            }
            else
            {
                list = _db.Orderhistory
                            .OrderByDescending(SortTable(column))
                            .ToList();
            }

            return Mapper.Map<List<Orderhistory>, List<OrderHistory>>(list);
        }

        public OrderHistory GetById(int id)
        {
            Orderhistory order = _db.Orderhistory
                                    .Find(id);

            return Mapper.Map<Orderhistory, OrderHistory>(order);
        }

        public int GetOrderCount()
        {
            return GetAll().Count();
        }

        public List<OrderHistory> Search(int id, string column = "", string order = "")
        {
            if (column == "")
                column = "id";
            if (order == "")
                order = "asc";

            column = column.ToLower();
            order = order.ToLower();

            List<Orderhistory> list;

            if (order == "asc")
            {
                list = _db.Orderhistory
                            .Where(l => l.Id == id || l.OrderNumber == id)
                            .OrderBy(SortTable(column))
                            .ToList();
            }
            else
            {
                list = _db.Orderhistory
                            .Where(l => l.Id == id || l.OrderNumber == id)
                            .OrderByDescending(SortTable(column))
                            .ToList();
            }

            return Mapper.Map<List<Orderhistory>, List<OrderHistory>>(list);
        }

        public List<OrderHistory> Search(string store, string column = "", string order = "")
        {
            if (column == "")
                column = "id";
            if (order == "")
                order = "asc";

            column = column.ToLower();
            order = order.ToLower();

            List<Orderhistory> list;

            if (order == "asc")
            {
                list = _db.Orderhistory
                            .Where(l => l.StoreName.Contains(store))
                            .OrderBy(SortTable(column))
                            .ToList();
            }
            else
            {
                list = _db.Orderhistory
                            .Where(l => l.StoreName.Contains(store))
                            .OrderByDescending(SortTable(column))
                            .ToList();
            }

            return Mapper.Map<List<Orderhistory>, List<OrderHistory>>(list);
        }
        
        private Expression<Func<Orderhistory, object>> SortTable(string column)
        {
            switch (column)
            {
                case "id":
                    return x => x.Id;
                case "ordernumber":
                    return x => x.OrderNumber;
                case "store_name":
                    return x => x.StoreName;
                case "order_total":
                    return x => x.OrderTotal;
                case "date_order":
                    return x => x.DateOrder;
                default:
                    return x => x.Id;
            }
        }

    }
}
