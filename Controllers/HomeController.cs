using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        
        private MyContext dbContext { get; set; } 

        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.Product = dbContext.Products.ToList ();
            return View();
        }

        [HttpPost("createProduct")]
        public IActionResult CreateProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                dbContext.Products.Add(newProduct);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet("categories")]
        public IActionResult Categories()
        {
            ViewBag.Category = dbContext.Categories.ToList();
            return View();
        }


        [HttpPost("createCategory")]
        public IActionResult CreateCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Add(newCategory);
                dbContext.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View("Categories");
        }
    }
}
