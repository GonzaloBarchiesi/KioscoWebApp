using KioscoWebApp.Data;
using KioscoWebApp.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Products.Where(p => p.Price == price).FirstOrDefault();

        }
        public Product GetProductQuant(int quantity)
        {
            return _context.Products.Where(p => p.Quantity == quantity).FirstOrDefault();
        }
        public Product GetProduct(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }

        public Product GetProduct(string name)
        {
            return _context.Products.Where(p => p.ProductName == name).FirstOrDefault();
        }
        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.ProductId).ToList();
        }
        public bool ProductExists(int productId)
        {
            return _context.Products.Any(p => p.ProductId == productId);

        }
    }
}
