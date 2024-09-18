using KioscoWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KioscoWebApp.Repository
{
    public interface IProductCategoryRepository 
    {
        ICollection<ProductCategory> GetProductCategories();
        Category GetCategoryById(int id);
        Product GetProductById(int id);
        bool ProductCategoryExists(int categoryId, int productId);
    }
}
