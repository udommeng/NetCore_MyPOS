using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyPOS.Models;

namespace MyPOS.Controllers
{
    public class ProductController : Controller
    {
        ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ViewData["Name1"]= "Chalerm";
            Product _dummy = new Product();
            _dummy.Name = "chalerm";
            _dummy.Detail = "1234";

            ViewData["data1"] = _dummy;

            return View(_dummy);
        }
    }
}