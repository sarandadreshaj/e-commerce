using Domain.Entities;
using Infrastructure.Repositories.Implementations;
using Infrastructure.Repositories.Interfaces;
using Application.DTOs;
using System.Drawing;
using AutoMapper;
using Application.CustomExceptions;

namespace Application.Services{
    public class CategoryService{
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)  {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var createdCategory = await _categoryRepository.AddAsync(category);
            
            await _categoryRepository.SaveChangesAsync(); // Now saving changes explicitly

            var updatedCategory = await _categoryRepository.GetByIdAsync(createdCategory.CategoryId);

            return _mapper.Map<CategoryDto>(updatedCategory);
        }



        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
             if (category == null)
            {
                return null; 
            }
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(int id, CreateCategoryDto categoryDto)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);
            
            if (existingCategory == null)
                throw new NotFoundException("Category not found");

            // Map the properties from the DTO to the existing category
            _mapper.Map(categoryDto, existingCategory);
            _categoryRepository.Update(existingCategory);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);
    
            if (existingCategory == null)
                throw new NotFoundException("Category not found");

            _categoryRepository.Delete(existingCategory);
            await _categoryRepository.SaveChangesAsync();
        }

    }
}