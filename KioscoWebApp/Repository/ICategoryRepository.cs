using KioscoWebApp.Models;
using Microsoft.Build.Framework;

namespace KioscoWebApp.Repository
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        ICollection<Product> GetProductByCategory(int id);
        Category GetCategoryById(int id);
        Category GetCategoryName(string name);
        bool CategoryExists(int id);
    }
}
