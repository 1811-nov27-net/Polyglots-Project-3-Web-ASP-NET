using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project3_Site_MVC.Library.RepositoriesInterfaces;
using Project3_Site_MVC.Web.Models;

namespace Project3_Site_MVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private IOrderHistory Repository { get; set; }

        public HomeController(IOrderHistory repository)
        {
            Repository = repository;
        }

        public IActionResult Index()
        {
            int orderCount = Repository.GetOrderCount();
            Home model = new Home(orderCount);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
