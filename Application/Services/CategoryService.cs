using Domain.Entities;
using Infrastructure.Repositories.Implementations;
using Infrastructure.Repositories.Interfaces;
using Application.DTOs;
using System.Drawing;

namespace Application.Services{
    public class CategoryService{
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)  {
            _categoryRepository = categoryRepository;
        }

        //Create a Category
        public async Task<Category> CreateAsync(CategoryDto categoryDto){
            var category = new Category{
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            return await _categoryRepository.AddAsync(category);
        }

        //Get all products
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id){
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, CategoryDto categoryDto){
            var category = await _categoryRepository.GetByIdAsync(id);
            if(category != null){
                category.Name = categoryDto.Name;
                category.Description = categoryDto.Description;
                category.UpdatedAt = DateTime.UtcNow;

                _categoryRepository.Update(category);
            }
        }

        public async Task DeleteAsync(int id){
            var category = await _categoryRepository.GetByIdAsync(id);
            if(category != null){
                _categoryRepository.Delete(category);
            }
        }
    }
}