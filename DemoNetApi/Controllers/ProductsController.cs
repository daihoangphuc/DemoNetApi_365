using DemoNetApi.Application.Interfaces.Service;
using DemoNetApi.Application.Products.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DemoNetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        // Constructor yêu cầu IProductService thay vì ProductService
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllAsync();
                if (products == null || !products.Any())
                {
                    return Ok(new { message = "Không có sản phẩm nào!" });
                }
                return Ok(new { message = "Tất cả sản phẩm", data = products });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _productService.GetProductIdAsync(id);
                if (product == null)
                {
                    return NotFound(new { message = $"Sản phẩm có ID: {id} không tồn tại!" });
                }

                return Ok(new { message = "Chi tiết sản phẩm", data = product });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductCommand product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _productService.CreateProductAsync(product);
                return Ok(new { message = "Tạo sản phẩm thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductAsync(int id, UpdateProductCommand product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingProduct = await _productService.GetProductIdAsync(id);
                if (existingProduct == null)
                {
                    return NotFound(new { message = $"Sản phẩm có ID là {id} không tồn tại!" });
                }

                await _productService.UpdateProduct(id, product);
                return Ok(new { message = $"Cập nhật thành công sản phẩm có ID là {id}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                var existingProduct = await _productService.GetProductIdAsync(id);
                if (existingProduct == null)
                {
                    return NotFound(new { message = $"Sản phẩm có ID là {id} không tồn tại!" });
                }

                await _productService.DeleteProductAsync(id);
                return Ok(new { message = $"Đã xóa thành công sản phẩm có ID là {id}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
