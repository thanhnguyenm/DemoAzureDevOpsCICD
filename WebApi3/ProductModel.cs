namespace WebApi3
{
    public class ProductModel
    {
        public Guid ProductKey { get; set; }
        public string ProductName { get; set; }
        public string Details { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Url { get; set; }
    }
}
