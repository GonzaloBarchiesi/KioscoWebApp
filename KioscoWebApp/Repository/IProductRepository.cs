using KioscoWebApp.Models;

namespace KioscoWebApp.Repository
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductById(int id);
        Product GetProductName(string productName);
        Product GetProductPrice(int price);
        Product GetProductQuant(int quantity);
        bool ProductExists(int productId);


    }
}
