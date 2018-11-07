using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPOS.Database;
using MyPOS.Models;

namespace MyPOS.Services
{
    public class ProductService
    {
        private readonly DatabaseContext Context;
        public ProductService(DatabaseContext Context)
        {
            this.Context = Context;
        }

        public async Task<(IList<Product>,int,int,int,int)> GetProduct()
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
    }
}