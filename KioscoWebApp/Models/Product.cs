namespace KioscoWebApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public string ProductImage2{ get; set; } 
        public ICollection<ProductCustomer> ProductCustomers { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }


    }
}
