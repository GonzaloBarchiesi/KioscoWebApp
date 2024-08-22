using KioscoWebApp.Data;
using KioscoWebApp.Models;

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
            if (!dataContext.ProductCustomers.Any())
            {
                var productCustomers = new List<ProductCustomer>()
                {
                    new ProductCustomer()
                    {
                         Product = new Product()
                        {
                            ProductName = "Turron",
                            Price =1300,
                            Quantity = 10,
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { CategoryName = "snacks"}}
                            }

                            ,

                        },

                        Customer = new Customer()
                        {
                            FirstName = "Jack",
                            LastName = "London",
                            Gmail = "Brocks Gym",
                            Password = "123"
                        }
                    },
                    new ProductCustomer()
                    {
                        Product = new Product()
                        {
                            ProductName = "agua",
                            Price= 1000,
                            Quantity = 10,
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { CategoryName = "Bebidas"}}
                            },

                        },
                        Customer = new Customer()
                        {
                            FirstName = "Harry",
                            LastName = "Potter",
                            Gmail = "...@gmail.com",
                            Password = "123"
                        }
                    },
                        new ProductCustomer()
                    {
                        Product = new Product()
                        {
                            ProductName = "Alf. maicena",
                            Price = 1300,
                            ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { CategoryName = "alfajores"}},

                            },

                        },
                        Customer = new Customer()
                        {
                            FirstName = "Ash",
                            LastName = "Ketchum",
                            Gmail = "..@gmail.com",
                            Password = "123"
                        }
                        }

                };
                new ProductCategory()
                {
                    Product = new Product()
                    {
                        ProductName = "TopLine M",
                        Price = 1300,
                        ProductCategories = new List<ProductCategory>()
                            {
                                new ProductCategory { Category = new Category() { CategoryName = "Chicles"}},

                            },



                    },
                };
                dataContext.ProductCustomers.AddRange(productCustomers);
                dataContext.SaveChanges();
            }
        }
    }
}
