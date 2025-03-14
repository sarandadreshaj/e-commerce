using Application.DTOs;

namespace Application.Services.Interfaces{
    public interface IProductService{
        Task<ProductDto> CreateProductAsync(ProductDto productDto);
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> UpdateProductAsync(int id,  ProductDto productDto);
        Task<ProductDto> DeleteProduct(int id);
    }
}