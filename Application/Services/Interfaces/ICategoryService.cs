using Application.DTOs;

namespace Application.Services.Interfaces{
    public interface ICategoryService{
        Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto);
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> UpdateCategoryAsync(int id,  CategoryDto categoryDto);
        Task<CategoryDto> DeleteCategory(int id);
    }
}