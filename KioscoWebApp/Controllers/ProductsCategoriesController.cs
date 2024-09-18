using AutoMapper;
using KioscoWebApp.Data;
using KioscoWebApp.Dto;
using KioscoWebApp.Models;
using KioscoWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KioscoWebApp.Controllers
{
    public class ProductsCategoriesController : Controller
    {
        private readonly DataContext _context;
        private readonly IProductCategoryRepository _productCatRepository;
        private readonly IMapper _mapper;

        public ProductsCategoriesController(DataContext context, IProductCategoryRepository repository, IMapper mapper) {
            _context = context;
            _productCatRepository = repository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProductById(int id) {
            var product = _mapper.Map<ProductDto>(_productCatRepository.GetProductById(id));

            if (product == null)
            {
                Console.WriteLine("Product is null");
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(product);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryById(int id)
        {
            var category = _mapper.Map<CategoryDto>(_productCatRepository.GetCategoryById(id));

            if (category == null)
            {
                Console.WriteLine("Category is null");
                return NotFound();
            }
            else if(!ModelState.IsValid){ 
            return BadRequest();
            }
           
            return Ok(category);

        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductCategory>))]
        [ProducesResponseType(400)]
        public IActionResult GetProductCategories() { 
            var productCategories = _mapper.Map<List<ProductCategoryDto>>(_productCatRepository.GetProductCategories());
            if (productCategories == null)
            {
                Console.WriteLine("ProductCategories Is null");
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                Console.WriteLine("Product Category Model State isnt valid");
                return BadRequest();
            }
            return Ok(productCategories);
        }
        

    }
}
