namespace KioscoWebApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public ICollection<ProductCustomer> ProductCustomers { get; set; }
    }
}
