namespace MyPOS.Models
{
    public class ProductSize
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Size { get; set; }
        public int Count { get; set; }
    }
}