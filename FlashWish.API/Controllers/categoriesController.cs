using AutoMapper;
using FlashWish.API.PostModels;
using FlashWish.Core.DTOs;
using FlashWish.Core.IServices;
using FlashWish.Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlashWish.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public categoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        // GET: api/<categoriesController>
        [HttpGet]
        public async Task<ActionResult<CategoryDTO>> GetAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            if (categories == null) return NotFound();
            return Ok(categories);
        }
        // GET api/<categoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetAsync(int id)
        {
            var category =await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound(id);
            return category;
        }
        // POST api/<categoriesController>
        [HttpPost]
        public ActionResult<CategoryDTO> Post([FromBody] CategoryPostModel category)
        {
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            if (categoryDTO == null)
                return NotFound();
            return _categoryService.AddCategory(categoryDTO);
        }

        // PUT api/<categoriesController>/5
        [HttpPut("{id}")]
        public ActionResult<CategoryDTO> Put(int id, [FromBody] CategoryPostModel category)
        {
            var categoryDTO = _mapper.Map<CategoryDTO>(category);
            categoryDTO = _categoryService.UpdateCategory(id, categoryDTO);
            if (categoryDTO == null) return NotFound();
            return categoryDTO;
        }

        // DELETE api/<categoriesController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var isDeleted = _categoryService.DeleteCategory(id);
            if (!isDeleted) return NotFound();
            return isDeleted;
        }
    }
}
