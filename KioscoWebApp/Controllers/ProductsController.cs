using AutoMapper;
using KioscoWebApp.Data;
using KioscoWebApp.Dto;
using KioscoWebApp.Models;
using KioscoWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KioscoWebApp.Controllers
{
    [Route("Products")]
  
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
       

        public ProductsController(IMapper mapper, DataContext context, IProductRepository productRepository)
        {
            _mapper = mapper;
            _context = context;
            _productRepository = productRepository;
        }
        [HttpGet("Index")]
        public IActionResult Index(int id)
        {
            var products =  _productRepository.GetProducts();

            foreach (var product in products)
            {
                product.ProductImage = Url.Content($"~/assets/productos/{product.ProductName}.png");
                product.ProductImage2 = Url.Content($"~/assets/NoStock/{product.ProductName}.jpg");
            }

            if (products == null)
            {
                Console.WriteLine("PRODUCT NULLLLLLLLLLLL");
                return NotFound();
            }
            return View(products);
        }
      
            [HttpGet]
            [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
            public IActionResult GetProducts()
            {
                var products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(products);

            }
            [HttpGet("productId")]
            [ProducesResponseType(200, Type = typeof(Product))]
            [ProducesResponseType(400)]
            public IActionResult GetProduct(int productId)
            {
           
               //var product = _productRepository.GetProduct(productId);
               var product = _mapper.Map<ProductDto>(_productRepository.GetProduct(productId));
                if (!_productRepository.ProductExists(productId))
                {
                    Console.WriteLine("Product doesnt exist");
                    return NotFound();
                
                }
           
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("Product isnt valid");
                    return BadRequest(ModelState);
                }
                Console.WriteLine("Product is OK!");
                return View(product); // Pass the product object as the model
            }
            [HttpGet("{productId}/price")]
            [ProducesResponseType(400)]
            [ProducesResponseType(200, Type = typeof(Product))]
            public IActionResult GetProductPrice(int productId)
            {
                var product = _mapper.Map<ProductDto>(_productRepository.GetProduct(productId));
                if (!_productRepository.ProductExists(productId))
                {
                    return NotFound();
                }


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(product.Price);
            }

            [HttpGet("{productId}/quantity")]
            [ProducesResponseType(400)]
            [ProducesResponseType(200, Type = typeof(Product))]
            public IActionResult GetProductQuant(int productId)
            {
                var product = _mapper.Map<ProductDto>(_productRepository.GetProduct(productId));
                if (!_productRepository.ProductExists(productId))
                {
                    return NotFound();
                }


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return Ok(product.Quantity);
            }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);
                if (product == null)
            {
                Console.WriteLine("Product Details: Product is null");
                return NotFound();
                
            }
            return View(product);  // Return a partial view with product details
        }

    }
}
