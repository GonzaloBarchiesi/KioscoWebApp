using KioscoWebApp.Data;
using KioscoWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KioscoWebApp.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DataContext _context;

        public ProductCategoryRepository(DataContext context)
        {
            _context = context;
        }
        public Category GetCategoryById(int id)
        {
            return _context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Where(c => c.ProductId == id).FirstOrDefault();
        }

        public ICollection<ProductCategory> GetProductCategories()
        {
            return _context.ProductCategories.OrderBy(c => c.CategoryId).ToList();
        }

        public bool ProductCategoryExists(int categoryId, int productId)
        {
            return _context.ProductCategories.Any(c => c.CategoryId == categoryId);
        }
    }
}
