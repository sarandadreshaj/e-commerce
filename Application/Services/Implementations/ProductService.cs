using Domain.Entities;
using Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Application.CustomExceptions;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto productDto){
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDto>(createdProduct);
        }


        // Get all products
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        // Get product by ID
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null){
                return null;
            }
            return _mapper.Map<ProductDto>(product);
        }

        // Update product
        public async Task UpdateProductAsync(int id, CreateProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null){
                throw new NotFoundException("Product not found!");
            }
            _mapper.Map(productDto, existingProduct);
            _productRepository.Update(existingProduct);
            
        }

        // Delete product
        public async Task DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new NotFoundException("Product not found!");
            }
            _productRepository.Delete(existingProduct);
        }
    }
}
