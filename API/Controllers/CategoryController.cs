using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService){

            _categoryService = categoryService;
        }

         //POST : api/category
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto categoryDto)
        {
            if(categoryDto == null)
            {
                return BadRequest(new {Error = "Category data is required"});
            }
            try
            {
                var categoryInserted = await _categoryService.CreateAsync(categoryDto);
                return Ok(new {Message = "Product inserted successfully!", categoryStored = categoryInserted});
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //GET: api/categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories(){
            try{
                var categories = await _categoryService.GetAllAsync();
                return Ok(categories);
            }
            catch(Exception ex) {
                return StatusCode(500, $"Internal server error {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id){
            try{
                var category = await _categoryService.GetByIdAsync(id);
                if(category == null){
                    return NotFound();
                }
                return Ok(category);
            }catch(Exception ex){
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, CategoryDto categoryDto){
            if(categoryDto == null){
                return BadRequest("Product data is required");
            }
            try{
                var category = await _categoryService.GetByIdAsync(id);
                if(category == null){
                    return NotFound();
                }
                await _categoryService.UpdateAsync(id, categoryDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id){
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                if(category == null){
                    return NotFound();
                }

                await _categoryService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }

}
