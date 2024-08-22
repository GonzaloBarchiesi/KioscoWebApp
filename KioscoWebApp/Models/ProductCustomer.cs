namespace KioscoWebApp.Models
{
    public class ProductCustomer
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }

}
