using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyPOS.ViewComponents
{
    public class UserViewComponent1 : ViewComponent
    {
        public UserViewComponent1()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
      
            return View();
        }
    }
}