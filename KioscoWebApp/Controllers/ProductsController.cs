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
   
  
    public class ProductsController : Controller
    {
        //se obtienen instancias de: un mappeador de variables, la interfaz del repositorio
        // y la dataContext para registrar los cambios en la base de datos
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
       

        public ProductsController(IMapper mapper, DataContext context, IProductRepository productRepository)
        {
            _mapper = mapper;
            _context = context;
            _productRepository = productRepository;
        }

        // metodo principal para ejecutar la vista de la pagina
        [HttpGet]
        public IActionResult Index(int id)
        {
            // se crea un array con todos los productos de la database a partir de metodo del repo 
            var products =  _productRepository.GetProducts();

            //se asignan las imagenes a cada producto
            foreach (var product in products)
            {
                product.ProductImage = Url.Content($"~/assets/productos/{product.ProductName}.png");
                product.ProductImage2 = Url.Content($"~/assets/NoStock/{product.ProductName}.jpg");
            }
            //se registra si el producto es null
            if (products == null)
            {
                Console.WriteLine("PRODUCT NULLLLLLLLLLLL");
                return NotFound();
            }
            //Vista: (pasandose el producto)
            return View(products);
        }


        //Metodo para Vista de la pagina de detalles de cada producto
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                Console.WriteLine("Product is null");
                return NotFound();
            }
            product.ProductImage = Url.Content($"~/assets/productos/{product.ProductName}.png");
            product.ProductImage2 = Url.Content($"~/assets/NoStock/{product.ProductName}.jpg");

            return View(product);  // Return a partial view with product details
        }

      
        //Metodo para obtner todos los productos        
        [HttpGet]
            [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
            public IActionResult GetProducts()
            {
                var products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(products);

            }


            //Metodo para un prodc
            [HttpGet("productId")]
            [ProducesResponseType(200, Type = typeof(Product))]
            [ProducesResponseType(400)]
            public IActionResult GetProductById(int productId)
            {
           
               //var product = _productRepository.GetProduct(productId);
               var product = _mapper.Map<ProductDto>(_productRepository.GetProductById(productId));
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



            //Metodo para precio de produc
            [HttpGet("{productId}/price")]
            [ProducesResponseType(400)]
            [ProducesResponseType(200, Type = typeof(Product))]
            public IActionResult GetProductPrice(int productId)
            {
                var product = _mapper.Map<ProductDto>(_productRepository.GetProductById(productId));
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



            //Metodo para cant de product
            [HttpGet("{productId}/quantity")]
            [ProducesResponseType(400)]
            [ProducesResponseType(200, Type = typeof(Product))]
            public IActionResult GetProductQuant(int productId)
            {
                var product = _mapper.Map<ProductDto>(_productRepository.GetProductById(productId));
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



        //Metodo para crear un producto (no se si sirve todavia, no entiendo dnd van las variables)
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
       
    }
}
