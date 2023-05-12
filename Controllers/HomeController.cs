using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using CRUD1.Models;

namespace CRUD1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Customer c = new Customer();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Customer c,string CategoryName)
        {
            string str = c.AddProductCategory(CategoryName);
            ViewBag.Message = str;
            return View();
        }
        [HttpGet]
        public ActionResult AddCategoryName()
        {
            List<Customer> List = c.GetAllCategory();
            return View(List);
        }
        [HttpPost]
        public ActionResult AddCategoryName(Customer c,string CategoryName)
        {
           
            List<Customer> List = c.GetAllCategory();
            string str = c.AddProductCategory(CategoryName);
            ViewBag.Message = str;
            return View(List);
        }
    }
}