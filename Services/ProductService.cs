using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyPOS.Database;
using MyPOS.Models;
using MyPOS.ViewModels;

namespace MyPOS.Services
{
    public class ProductService
    {
        private readonly String[] SIZE_PRODUCT = { "S", "M", "L", "XL" };

        private readonly DatabaseContext Context;
        private const int Group_v1 = 9999;

        private readonly ILogger<ProductService> Logger;

        public ProductService(DatabaseContext Context, ILogger<ProductService> Logger)
        {
            this.Logger = Logger;
            this.Context = Context;
        }
        public async Task<Product> GetProduct(int id)
        {
            var result = await Context.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            return result;
        }
        public async Task<(IList<Product>, int, int, int, int)> GetProduct()
        {
            IList<Product> result = await Context.Products.Include(c => c.Categories)
                                                   .Include(psize => psize.ProductsSizeList).ToListAsync();

            var currentThaiYear = Convert.ToInt32(DateTime.Now.ToString("yyyy")) + 543;
            var currentTimeStamp = $"{DateTime.Now.ToString("dd-MM")}-{currentThaiYear}";

            var totalOutStock = 0;
            var totalNewProduct = 0;
            var totalProduct = result.Count();
            var totalCategories = Context.Category.Count();

            for (int i = 0; i < totalProduct; i++)
            {
                Product item = result[i];
                var tempTotalStock = 0;

                foreach (var temp in item.ProductsSizeList)
                {
                    tempTotalStock = tempTotalStock + temp.Count;
                }

                result[i].TotalStock = tempTotalStock;

                if (tempTotalStock == 0)
                {
                    totalOutStock++;
                }

                if (item.Timestamp == currentTimeStamp)
                {
                    totalNewProduct++;
                    item.NewProduct = true;
                }
            }

            return (result, totalProduct, totalCategories, totalNewProduct, totalOutStock);
        }
        public async Task<Boolean> Delete(int id)

        {
            try
            {
                Product data = await GetProduct(id);
                if (data != null)
                {
                    Context.Remove(data);
                    await Context.SaveChangesAsync();

                    IEnumerable<ProductSize> temp = await Context.ProductSize
                    .Where(p => p.ProductID == data.ProductID)
                    .ToListAsync();
                    Context.RemoveRange(temp);
                    return true;

                }
            }
            catch (System.Exception ex)
            {
                Logger.LogError($"Failure for delete {ex.Message}");
                throw;
            }
            return false;
        }

        //-- ข้อมูลสำหรับ DropdownList --
        public SelectList CreateSelectList()
        {
            return new SelectList(Context.Category, "CategoryID", "Name");
        }

        public String testLog() //สำหรับการ ใช้งาน Logger 
        {
            var a = "tanakorn";

            Logger.LogInformation($"value of log info: {a}");

            if (String.IsNullOrEmpty(a))
            {
                Logger.LogDebug("var a is null or empty");
            }
            else
            {
                Logger.LogDebug("var a is not null");
            }

            try
            {
                string b = "2";
                bool c = Boolean.Parse(b);
            }
            catch (System.Exception ex)
            {
                Logger.LogError(Group_v1, $"Can't convert to boolean: {ex.Message}");
            }

            return a;
        }

        public async Task<bool> Insert(ProductFormViewModel Data)
        {
            try
            {
                // insert table product
                ProductValidViewModel productValidViewModel = Data.ProductValidViewModel;

                Product product = new Product
                {
                    CodeName = productValidViewModel.CodeName,
                    Name = productValidViewModel.Name,
                    Detail = productValidViewModel.Detail,
                    Price = productValidViewModel.Price,
                    CategoryID = productValidViewModel.CategoryID,
                    Image = productValidViewModel.Image,
                    Timestamp = productValidViewModel.Timestamp
                };

                await Context.Products.AddAsync(product);
                await Context.SaveChangesAsync();

                // insert table product size
                List<ProductSize> productSize = new List<ProductSize>();

                for (int i = 0; i < SIZE_PRODUCT.Count(); i++)
                {
                    var item = new ProductSize
                    {
                        ProductID = product.ProductID,
                        Size = SIZE_PRODUCT[i],
                        Count = Data.Size[i]
                    };

                    productSize.Add(item);
                }

                await Context.ProductSize.AddRangeAsync(productSize);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Insert failure: {ex.Message}");
            }

            return false;
        }

        public async Task<ProductFormViewModel> EditForm(int Id)
        {
            try
            {
                var product = await Context.Products.Include(p => p.ProductsSizeList).Include(c => c.Categories)
                                    .SingleOrDefaultAsync(m => m.ProductID == Id);

                if (product == null)
                {
                    return null;
                }

                // Product Data
                ProductValidViewModel _data = new ProductValidViewModel();
                _data.ID = product.ProductID;
                _data.CodeName = product.CodeName;
                _data.Name = product.Name;
                _data.Detail = product.Detail;
                _data.Price = product.Price;
                _data.CategoryID = product.CategoryID;
                _data.Image = product.Image;
                _data.Timestamp = product.Timestamp;
                _data.Categories = new Category();
                _data.Categories.Name = product.Categories.Name;

                // Product Size Data
                int[] size = new int[4];
                int i = 0;
                foreach (var item in product.ProductsSizeList)
                {
                    size[i] = item.Count;
                    i++;
                }

                // Create ViewModel
                var productFormViewModel = new ProductFormViewModel(_data);
                productFormViewModel.Size = size;

                return (productFormViewModel);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed insert: {ex.Message}");
            }

            return null;
        }

        public async Task<bool> Edit(ProductFormViewModel Data)
        {
            try
            {
                ProductValidViewModel productValidViewModel = Data.ProductValidViewModel;
                int productID = productValidViewModel.ID;

                Product data = await GetProduct(productID);

                if (data != null)
                {
                    // Update Product
                    data.CodeName = productValidViewModel.CodeName;
                    data.Name = productValidViewModel.Name;
                    data.Detail = productValidViewModel.Detail;
                    data.Price = productValidViewModel.Price;
                    data.CategoryID = productValidViewModel.CategoryID;
                    data.Image = productValidViewModel.Image;
                    data.Timestamp = productValidViewModel.Timestamp;

                    Context.Update(data);
                    await Context.SaveChangesAsync();

                    // Update Product Size
                    List<ProductSize> productSize = new List<ProductSize>();

                    for (int i = 0; i < SIZE_PRODUCT.Count(); i++)
                    {
                        ProductSize temp = await Context.ProductSize.SingleOrDefaultAsync(m => m.Size == SIZE_PRODUCT[i] && m.ProductID == productID);
                        temp.Count = Data.Size[i];

                        productSize.Add(temp);
                    }

                    Context.ProductSize.UpdateRange(productSize);
                    await Context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed insert: {ex.Message}");
            }
            return false;
        }

    }
}