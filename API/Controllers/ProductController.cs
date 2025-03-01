using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.DTOs;
using System;
using System.Threading.Tasks;
using Infrastructure.DbContextt;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest(new { Error = "Product data is required." }); 
            }

            try
            {
              var productInserted = await _productService.CreateAsync(productDto);
               return Ok(new { Message = "Product created successfully!" , productStored=productInserted });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product data is required.");
            }

            try
            {
                var product = await _productService.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                await _productService.UpdateAsync(id, productDto);
                return NoContent(); // Successfully updated
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // [HttpGet("test-connection")]
        // public IActionResult TestConnection()
        // {
        //     using (var context = new ApplicationDbContext(/* pass options here */))
        //     {
        //         try
        //         {
        //             context.Database.CanConnect();
        //             return Ok("Connection successful");
        //         }
        //         catch (Exception ex)
        //         {
        //             return StatusCode(500, $"Connection failed: {ex.Message}");
        //         }
        //     }
        // }


        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                await _productService.DeleteAsync(id);
                return NoContent(); // Successfully deleted
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
