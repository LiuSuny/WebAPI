using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnalApi.Dto;
using PersonnalApi.Interfaces;
using PersonnalApi.Models;
using PersonnalApi.Repository;

namespace PersonnalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
           _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var category = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
           // var category = _categoryRepository.GetCategories();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            //if (!_categoryRepository.CategoryExist(categoryId))
            //    return NotFound();

             var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));

            //var category = _categoryRepository.GetCategory(categoryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);
        }

        [HttpGet("pokeGame/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokeGame>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokeGameByCategory(int categoryId)
        {

            //if (!_categoryRepository.CategoryExist(categoryId))
            //    return NotFound();
            var category = _mapper.Map<List<PokeGameDto>>(_categoryRepository.GetPokeGameByCategory(categoryId));

            //var category = _categoryRepository.GetPokeGameByCategory(categoryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);
        }
    }
}
