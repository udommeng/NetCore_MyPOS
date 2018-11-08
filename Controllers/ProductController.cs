using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyPOS.Database;
using MyPOS.Models;
using MyPOS.Services;
using MyPOS.ViewModels;

namespace MyPOS.Controllers
{

    public class ProductController : Controller
    {
        ILogger<ProductController> _logger;
        private readonly ProductService ProductService;
        private readonly UtilService UtilService;
        public ProductController(ILogger<ProductController> logger
                                , ProductService ProductService, UtilService UtilService)
        {
            this.UtilService = UtilService;
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


        public async Task<IActionResult> Edit(int id)
        {
            ProductFormViewModel result = await ProductService.EditForm(id);

            if (result != null)
            {
                return View(result);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductFormViewModel model)
        {
            return null;
        }

        [ActionName("Create")]
        public IActionResult CreateForm()
        {
            var form = new ProductFormViewModel(new ProductValidViewModel());
            return View(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await ProductService.Insert(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest();
                }
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UploadFilesAjax()
        {
            var dataImages = await UtilService.UploadFilesAjax();
            return Json(dataImages);
        }
    }
}