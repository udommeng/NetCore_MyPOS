using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyPOS.Database;
using MyPOS.Models;
using MyPOS.Services;

namespace MyPOS.Controllers
{

    public class ProductController : Controller
    {
        ILogger<ProductController> _logger;
        private readonly ProductService ProductService;
        public ProductController(ILogger<ProductController> logger, ProductService ProductService)
        {
            this.ProductService = ProductService;

            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            (IEnumerable<Product> result,
                                int totalProduct,
                                int totalCategories,
                                int totalNewProduct,
                                int totalOutStock) = await ProductService.GetProduct();

            ViewData["total_product"] = totalProduct;
            ViewData["total_categories"] = totalCategories;
            ViewData["total_new_product"] = totalNewProduct;
            ViewData["total_out_stock"] = totalOutStock;

            return View(result);

        }
        public IActionResult Privacy()
        {
            ProductService.testLog();
            return View();

        }

        public async Task<IActionResult> Delete(int id)
        {
            if (await ProductService.Delete(id))
            {
                return Json("Delete success");
            }
            return BadRequest("Delete Failure");
        }



    }
}