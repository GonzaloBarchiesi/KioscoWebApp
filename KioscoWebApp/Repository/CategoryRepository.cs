using KioscoWebApp.Data;
using KioscoWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KioscoWebApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context) {
            _context = context;
        } 
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.CategoryId == id);
        }

        public ICollection<Category> GetCategories()
        {
          return _context.Categories.OrderBy(c => c.CategoryId).ToList();
        }
        public Category GetCategoryById(int id)
        {
            return _context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
        }

        public Category GetCategoryName(string name)
        {
            return _context.Categories.Where(c => c.CategoryName == name).FirstOrDefault();
        }

        public ICollection<Product> GetProductByCategory(int categoryId)
        {
            return _context.ProductCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Product).ToList(); 
        }
    }
}
