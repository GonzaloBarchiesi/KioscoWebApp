using KioscoWebApp.Data;
using KioscoWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace KioscoWebApp
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Products.Any() && !dataContext.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { CategoryName = "Alfajores" },
                    new Category { CategoryName = "Chicles" },
                    new Category { CategoryName = "Bebidas" },
                    new Category { CategoryName = "Snacks" },
                    new Category { CategoryName = "Dulces" },
                    new Category { CategoryName = "Galletitas" }
                };
                dataContext.Categories.AddRange(categories);
                dataContext.SaveChanges();

                var products = new List<Product>
                {
                    new Product { ProductName = "Alfajor Block", Price = 1200, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Alfajor Bon o Bon", Price = 1100, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Alfajor Fantoche", Price = 950, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Milka Triple", Price = 1100, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Alfajor Oreo", Price = 1200, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Alfajor Prepito", Price = 1200, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Tatin Blanco", Price = 450, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Tatin Negro", Price = 450, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Tatin Negro Triple", Price = 900, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Tatin Blanco Triple", Price = 900, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Alfajor Terrabusi", Price = 950, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Alfajor Tritorta", Price = 950, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Alfajor Trishot", Price = 1200, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Tofi Negro", Price = 1200, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Guaymallen Blanco", Price = 700, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Guaymallen Negro", Price = 700, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Agua", Price = 900, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Aquarius Pera", Price = 1400, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Aquarius Pomelo", Price = 1400, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Levite Pomelo", Price = 1400, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Baggio Durazno", Price = 850, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Baggio Manzana", Price = 850, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Baggio Multi", Price = 850, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Baggio Naranja", Price = 850, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Barra Cereal Mix Manzana", Price = 850, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Barra Cereal Mix C/A", Price = 850, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Bull dog Sandia", Price = 650, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Bull dog Tutti Limon", Price = 650, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Bull dog Manzana", Price = 650, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Bull dog Uva/Mandarina", Price = 650, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Bull dog Uva", Price = 650, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Beldent Frutilla", Price = 800, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Beldent Menta", Price = 800, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Beldent Mentol", Price = 800, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Beldent Tutti Frutti", Price = 800, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "TopLine Menta", Price = 700, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "TopLine Frutilla", Price = 700, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Hall's Menta", Price = 700, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Chupetin Blueberry", Price = 300, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Chupetin Cereza", Price = 300, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Chupetin Surtido", Price = 300, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Chupetin Uva/Tutti", Price = 300, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Coca Cola", Price = 1400, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Coca Cola Zero", Price = 1000, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Sprite", Price = 1400, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Sprite Lata", Price = 900, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Fanta", Price = 1400, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Formis Chocolate", Price = 700, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Formis Frutilla", Price = 1300, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Galletitas Pepito", Price = 1400, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Tortitas Chocolate", Price = 1000, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Chocolinas", Price = 1600, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Macucas", Price = 900, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Oreos", Price = 1400, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Oreos sin gluten", Price = 1800, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Turron", Price = 1000, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Gomitas Mogul", Price = 600, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Pico Dulce", Price = 300, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Gomitas Mogul Acidas", Price = 650, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Rhodesia", Price = 750, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Tableta chocolate oreo", Price = 800, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Lays Clasicas", Price = 2600, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Lays Jamon Serrano", Price = 2600, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Lays Ketchup", Price = 2600, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "9 de Oro Agridulce", Price = 1350, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "9 de Oro Grasa", Price = 1350, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Rocklets", Price = 650, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Mogul Sandia", Price = 1000, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Mogul Oso", Price = 1000, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Saladix Calabresa", Price = 1100, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Saladix Jamon", Price = 1100, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Saladix Pizza", Price = 1100, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Saladix Duo", Price = 1100, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Té Saquito", Price = 100, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Mate Cocido", Price = 100, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" },
                    new Product { ProductName = "Café en Saquito", Price = 200, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = "" }
                };

                dataContext.Products.AddRange(products);
                dataContext.SaveChanges();
            }
        }
    }
}
