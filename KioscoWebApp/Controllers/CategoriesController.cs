using AutoMapper;
using KioscoWebApp.Data;
using KioscoWebApp.Dto;
using KioscoWebApp.Models;
using KioscoWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KioscoWebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(IMapper mapper, DataContext context, ICategoryRepository repository) {
            _mapper = mapper;
            _context = context;
            _categoryRepository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryById(int id) {
            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategoryById(id));
            if (!_categoryRepository.CategoryExists(id))
            {
                Console.WriteLine("Category doesnt exist");
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Category isnt valid");
                return BadRequest(ModelState);
            }
            return View(category);
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryName(int categoryId )
        {
            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategoryById(categoryId));
            if (!_categoryRepository.CategoryExists(categoryId))
            {
                Console.WriteLine("Category doesnt exist");
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Category isnt valid");
                return BadRequest(ModelState);
            }
            return View(category.CategoryName);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(categories);
        }
        public IActionResult CreateCategory(Category category) {

            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(400)]
        public IActionResult GetProductByCategory(int categoryId) { 
        
        var products = _mapper.Map<List<ProductDto>>(
            _categoryRepository.GetProductByCategory(categoryId));
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(products);
        }
    }
}
