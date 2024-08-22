using AutoMapper;
using KioscoWebApp.Dto;
using KioscoWebApp.Models;
using KioscoWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KioscoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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
            if (!_productRepository.ProductExists(productId)) ;
            return NotFound();

            var product = _mapper.Map<ProductDto>(_productRepository.GetProduct(productId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(product);
        }
        [HttpGet("{productId}/price")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Product))]
        public IActionResult GetProductPrice(int productId)
        {
            if (!_productRepository.ProductExists(productId)) ;
            return NotFound();

            var product = _mapper.Map<ProductDto>(_productRepository.GetProduct(productId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(product.Price);
        }

        [HttpGet("{productId}/quantity")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Product))]
        public IActionResult GetProductQuant(int productId)
        {
            if (!_productRepository.ProductExists(productId)) ;
            return NotFound();

            var product = _mapper.Map<ProductDto>(_productRepository.GetProduct(productId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(product.Quantity);
        }


    }
}
