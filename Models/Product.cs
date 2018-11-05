using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPOS.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        public string CodeName { get; set; }

        public string Name { get; set; }

        public string Detail { get; set; }

        public decimal Price { get; set; }

        public int CategoryID { get; set; } // Relation [Key]

        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public string Image4 { get; set; }

        public string Image5 { get; set; }

        public string Timestamp { get; set; }

        [NotMapped]
        public int TotalStock { get; set; }

        [NotMapped]
        public bool NewProduct { get; set; }

        public virtual Category Categories { get; set; }

        public virtual ICollection<ProductSize> ProductsSizeList { get; set; }
    }
}