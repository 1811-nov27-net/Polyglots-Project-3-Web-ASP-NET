﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project3_Site_MVC.Library;
using Project3_Site_MVC.Library.RepositoriesInterfaces;
using Project3_Site_MVC.MVC.Models;

namespace Project3_Site_MVC.MVC.Controllers
{
    public class OrderHistoryController : Controller
    {
        private IOrderHistory Repository { get; set; }

        public OrderHistoryController(IOrderHistory repository)
        {
            Repository = repository;
        }

        // GET: OrderHistory
        public ActionResult Index()
        {
            List<OrderHistory> list = Repository.GetAll();
            return View(list);
        }

        // GET: OrderHistory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderHistory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderHistory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderHistory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderHistory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderHistory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}