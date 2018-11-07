using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyPOS.Services;

namespace MyPOS.ViewComponents

{
    [ViewComponent(Name = "User_database")]
    public class UserViewComponent : ViewComponent
    {
        private readonly ProductService ProductService;
        public UserViewComponent(ProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await ProductService.GetProduct(2);

            return View("Index", result);
        }
    }
}