using KioscoWebApp.Models;

namespace KioscoWebApp.Repository
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        Product GetProduct(string productName);
        Product GetProductPrice(int price);
        Product GetProductQuant(int quantity);
        bool ProductExists(int productId);


    }
}
