using KioscoWebApp.Data;
using KioscoWebApp.Models;

namespace KioscoWebApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public Product GetProductPrice(int price)
        {
            return _context.Product.Where(p => p.Price == price).FirstOrDefault();

        }
        public Product GetProductQuant(int quantity)
        {
            return _context.Product.Where(p => p.Quantity == quantity).FirstOrDefault();
        }
        public Product GetProduct(int id)
        {
            return _context.Product.Where(p => p.ProductId == id).FirstOrDefault();
        }

        public Product GetProduct(string name)
        {
            return _context.Product.Where(p => p.ProductName == name).FirstOrDefault();
        }
        public ICollection<Product> GetProducts()
        {
            return _context.Product.OrderBy(p => p.ProductId).ToList();
        }
        public bool ProductExists(int productId)
        {
            return _context.Product.Any(p => p.ProductId == productId);

        }
    }
}
