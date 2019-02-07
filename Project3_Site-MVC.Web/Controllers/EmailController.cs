using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Mailzory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project3_Site_MVC.Library;
using Project3_Site_MVC.Library.RepositoriesInterfaces;

namespace Project3_Site_MVC.Web.Controllers
{
    public class EmailController : Controller
    {
        private IOrderHistory Repository { get; set; }

        public EmailController(IOrderHistory repository)
        {
            Repository = repository;
        }

        // POST: Email/Create
        [HttpPost]
        public ActionResult Send(IFormCollection collection)
        {
            String[] invoicesIds = collection["invoices"].ToString().Split(",");
            List<int> ids = new List<int>();
            List<OrderHistory> orders = new List<OrderHistory>();

            foreach (String invoiceId in invoicesIds)
            {
                int id = int.Parse(invoiceId);
                orders.Add(this.Repository.GetById(id));
            }

            return View(orders);
        }
    }
}