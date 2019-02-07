using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Project3_Site_MVC.Library;
using Project3_Site_MVC.Library.RepositoriesInterfaces;

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

        public List<OrderHistory> GetAll()
        {
            List<Orderhistory> list = _db.Orderhistory
                                          .OrderBy(m => m.Id)
                                          .ToList();

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

        public List<OrderHistory> Search(int id)
        {
            List<Orderhistory> list = _db.Orderhistory
                                          .OrderBy(m => m.Id)
                                          .Where(l => l.Id == id || l.OrderNumber == id)
                                          .ToList();

            return Mapper.Map<List<Orderhistory>, List<OrderHistory>>(list);
        }

        public List<OrderHistory> Search(string store)
        {
            List<Orderhistory> list = _db.Orderhistory
                                          .OrderBy(m => m.Id)
                                          .Where(l => l.StoreName.Contains(store))
                                          .ToList();

            return Mapper.Map<List<Orderhistory>, List<OrderHistory>>(list);
        }
    }
}
