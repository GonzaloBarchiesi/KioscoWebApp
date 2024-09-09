using KioscoWebApp.Data;
using KioscoWebApp.Models;
using Microsoft.EntityFrameworkCore.Storage.Json;
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
                    new Category { CategoryName = "Alfajores" }, //0
                    new Category { CategoryName = "Bebidas" },//1
                    new Category { CategoryName = "Snacks" },//2
                    new Category { CategoryName = "Chicles" },//3
                    new Category { CategoryName = "Dulces" },//4
                    new Category { CategoryName = "Galletitas" }//5
                };
                dataContext.Categories.AddRange(categories);
                dataContext.SaveChanges();

                var products = new List<Product>
                {
                    new Product { ProductName = "Alfajor Block", Price = 1200, Quantity = 10, Description = "", ProductImage = "", ProductImage2 = ""},
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
                //Asignacion de cada producto con su respectiva categoria
                var productCategories = new List<ProductCategory>
                { 
                    new ProductCategory { ProductId = products[0].ProductId, CategoryId = categories[0].CategoryId }, //P. ej, en este caso; Alfajor Block => Alfajores
                    new ProductCategory { ProductId = products[1].ProductId, CategoryId = categories[0].CategoryId },
                    new ProductCategory { ProductId = products[2].ProductId, CategoryId = categories[0].CategoryId },
                    new ProductCategory { ProductId = products[3].ProductId, CategoryId = categories[0].CategoryId },
                    new ProductCategory { ProductId = products[4].ProductId, CategoryId = categories[0].CategoryId },
                    new ProductCategory { ProductId = products[5].ProductId, CategoryId = categories[0].CategoryId },   
                    new ProductCategory { ProductId = products[6].ProductId, CategoryId = categories[0].CategoryId },  
                    new ProductCategory { ProductId = products[7].ProductId, CategoryId = categories[0].CategoryId },  
                    new ProductCategory { ProductId = products[8].ProductId, CategoryId = categories[0].CategoryId }, 
                    new ProductCategory { ProductId = products[9].ProductId, CategoryId = categories[0].CategoryId },  
                    new ProductCategory { ProductId = products[10].ProductId, CategoryId = categories[0].CategoryId },  
                    new ProductCategory { ProductId = products[11].ProductId, CategoryId = categories[0].CategoryId },   
                    new ProductCategory { ProductId = products[12].ProductId, CategoryId = categories[0].CategoryId },  
                    new ProductCategory { ProductId = products[13].ProductId, CategoryId = categories[0].CategoryId },   
                    new ProductCategory { ProductId = products[14].ProductId, CategoryId = categories[0].CategoryId },   
                    new ProductCategory { ProductId = products[15].ProductId, CategoryId = categories[0].CategoryId },   
                    new ProductCategory { ProductId = products[16].ProductId, CategoryId = categories[1].CategoryId },   
                    new ProductCategory { ProductId = products[17].ProductId, CategoryId = categories[1].CategoryId },  
                    new ProductCategory { ProductId = products[18].ProductId, CategoryId = categories[1].CategoryId }, 
                    new ProductCategory { ProductId = products[19].ProductId, CategoryId = categories[1].CategoryId },  
                    new ProductCategory { ProductId = products[20].ProductId, CategoryId = categories[1].CategoryId }, 
                    new ProductCategory { ProductId = products[21].ProductId, CategoryId = categories[1].CategoryId },  
                    new ProductCategory { ProductId = products[22].ProductId, CategoryId = categories[1].CategoryId },  
                    new ProductCategory { ProductId = products[23].ProductId, CategoryId = categories[1].CategoryId },  
                    new ProductCategory { ProductId = products[24].ProductId, CategoryId = categories[2].CategoryId }, 
                    new ProductCategory { ProductId = products[25].ProductId, CategoryId = categories[2].CategoryId }, 
                    new ProductCategory { ProductId = products[26].ProductId, CategoryId = categories[4].CategoryId },  
                    new ProductCategory { ProductId = products[27].ProductId, CategoryId = categories[4].CategoryId },  
                    new ProductCategory { ProductId = products[28].ProductId, CategoryId = categories[4].CategoryId },  
                    new ProductCategory { ProductId = products[29].ProductId, CategoryId = categories[4].CategoryId },   
                    new ProductCategory { ProductId = products[30].ProductId, CategoryId = categories[4].CategoryId },   
                    new ProductCategory { ProductId = products[31].ProductId, CategoryId = categories[3].CategoryId },   
                    new ProductCategory { ProductId = products[32].ProductId, CategoryId = categories[3].CategoryId },   
                    new ProductCategory { ProductId = products[33].ProductId, CategoryId = categories[3].CategoryId },  
                    new ProductCategory { ProductId = products[34].ProductId, CategoryId = categories[3].CategoryId },   
                    new ProductCategory { ProductId = products[35].ProductId, CategoryId = categories[3].CategoryId },  
                    new ProductCategory { ProductId = products[36].ProductId, CategoryId = categories[3].CategoryId },   
                    new ProductCategory { ProductId = products[37].ProductId, CategoryId = categories[3].CategoryId },  
                    new ProductCategory { ProductId = products[38].ProductId, CategoryId = categories[4].CategoryId },   
                    new ProductCategory { ProductId = products[39].ProductId, CategoryId = categories[4].CategoryId },  
                    new ProductCategory { ProductId = products[40].ProductId, CategoryId = categories[4].CategoryId },   
                    new ProductCategory { ProductId = products[41].ProductId, CategoryId = categories[4].CategoryId },  
                    new ProductCategory { ProductId = products[42].ProductId, CategoryId = categories[1].CategoryId },   
                    new ProductCategory { ProductId = products[43].ProductId, CategoryId = categories[1].CategoryId },  
                    new ProductCategory { ProductId = products[44].ProductId, CategoryId = categories[1].CategoryId },   
                    new ProductCategory { ProductId = products[45].ProductId, CategoryId = categories[1].CategoryId }, 
                    new ProductCategory { ProductId = products[46].ProductId, CategoryId = categories[1].CategoryId },   
                    new ProductCategory { ProductId = products[47].ProductId, CategoryId = categories[5].CategoryId },   
                    new ProductCategory { ProductId = products[48].ProductId, CategoryId = categories[5].CategoryId },   
                    new ProductCategory { ProductId = products[49].ProductId, CategoryId = categories[5].CategoryId },
                    new ProductCategory { ProductId = products[50].ProductId, CategoryId = categories[5].CategoryId },   
                    new ProductCategory { ProductId = products[51].ProductId, CategoryId = categories[5].CategoryId },   
                    new ProductCategory { ProductId = products[52].ProductId, CategoryId = categories[5].CategoryId },  
                    new ProductCategory { ProductId = products[53].ProductId, CategoryId = categories[5].CategoryId },   
                    new ProductCategory { ProductId = products[54].ProductId, CategoryId = categories[5].CategoryId },  
                    new ProductCategory { ProductId = products[55].ProductId, CategoryId = categories[2].CategoryId },   
                    new ProductCategory { ProductId = products[56].ProductId, CategoryId = categories[4].CategoryId },   
                    new ProductCategory { ProductId = products[57].ProductId, CategoryId = categories[4].CategoryId },     
                    new ProductCategory { ProductId = products[58].ProductId, CategoryId = categories[4].CategoryId },   
                    new ProductCategory { ProductId = products[59].ProductId, CategoryId = categories[4].CategoryId },   
                    new ProductCategory { ProductId = products[60].ProductId, CategoryId = categories[4].CategoryId },  
                    new ProductCategory { ProductId = products[61].ProductId, CategoryId = categories[2].CategoryId },   
                    new ProductCategory { ProductId = products[62].ProductId, CategoryId = categories[2].CategoryId },  
                    new ProductCategory { ProductId = products[63].ProductId, CategoryId = categories[2].CategoryId },   
                    new ProductCategory { ProductId = products[64].ProductId, CategoryId = categories[5].CategoryId },  
                    new ProductCategory { ProductId = products[65].ProductId, CategoryId = categories[5].CategoryId },   
                    new ProductCategory { ProductId = products[66].ProductId, CategoryId = categories[4].CategoryId },  
                    new ProductCategory { ProductId = products[67].ProductId, CategoryId = categories[4].CategoryId },   
                    new ProductCategory { ProductId = products[68].ProductId, CategoryId = categories[4].CategoryId },  
                    new ProductCategory { ProductId = products[69].ProductId, CategoryId = categories[2].CategoryId },   
                    new ProductCategory { ProductId = products[70].ProductId, CategoryId = categories[2].CategoryId },  
                    new ProductCategory { ProductId = products[71].ProductId, CategoryId = categories[2].CategoryId },
                    new ProductCategory { ProductId = products[72].ProductId, CategoryId = categories[2].CategoryId },
                    new ProductCategory { ProductId = products[73].ProductId, CategoryId = categories[1].CategoryId },
                    new ProductCategory { ProductId = products[74].ProductId, CategoryId = categories[1].CategoryId },
                    new ProductCategory { ProductId = products[75].ProductId, CategoryId = categories[1].CategoryId }
                    };
                
                dataContext.AddRange(productCategories);
                dataContext.SaveChanges();
            }
        }
    }
}
