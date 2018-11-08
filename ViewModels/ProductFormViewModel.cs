// 

using Microsoft.AspNetCore.Mvc.Rendering;
using MyPOS.Database;

namespace MyPOS.ViewModels
{
    public class ProductFormViewModel
    {

        public ProductValidViewModel ProductValidViewModel { get; set; }

        // public SelectList CategoryItem { get; set; }
        public int[] Size { get; set; }

        // Require default constructor
        public ProductFormViewModel() { }

        public ProductFormViewModel(ProductValidViewModel ProductValidViewModel)
        {
            this.Size = new int[4];
            this.ProductValidViewModel = ProductValidViewModel;
        }

        // public void createSelectList(DatabaseContext Context)
        // {
        //     CategoryItem = new SelectList(Context.Category, "CategoryID", "Name");
        // }
    }
}