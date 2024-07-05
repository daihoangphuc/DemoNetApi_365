using AutoMapper;
using DemoNetApi.Application.Interfaces.Repository;
using DemoNetApi.Application.Interfaces.Service;
using DemoNetApi.Application.Products.Commands;
using DemoNetApi.Application.Products.Queries;
using DemoNetApi.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetApi.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;
        private IMapper _mapper;
        private readonly ILogger<ProductService> logger;
        public ProductService(IProductRepository productRepository, IMapper mapper, ILogger<ProductService> logger)
        {
            this.productRepository = productRepository;
            _mapper = mapper;
            this.logger = logger;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var res = await productRepository.GetAllAsync();
            if(res == null)
            {
                logger.LogInformation($"Khong tim thay san pham nao!");
            }
            return res;
        }
        public async Task<Product> GetProductIdAsync(int id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await productRepository.GetByIDAsync(query.ProductId);
            if(product == null)
            {
                logger.LogInformation($"Khong tim thay san pham voi id = {query.ProductId}");
            }
            return _mapper.Map<Product>(product);
        }
        public async Task CreateProductAsync(CreateProductCommand product)
        {
            try
            {
                var newpoduct = _mapper.Map<Product>(product);
                await productRepository.CreateAsync(newpoduct);
                await productRepository.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error: {ex.Message}");
            }
        }

        public async Task UpdateProductAsync(int id, UpdateProductCommand product)
        {
            try
            {
                var data = await productRepository.GetByIDAsync(id);
                if(data != null)
                {
                    var dataUpdate = _mapper.Map(product, data);
                    productRepository.Update(dataUpdate);
                    productRepository.SaveChangeAsync();
                }
                else
                {
                    logger.LogInformation($" Khong co san pham nao duoc tim thay");
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex, $"Error: {ex.Message}");
            }
        }
        public async Task DeleteProductAsync(int id)
        {
            try
            {
                var data = await productRepository.GetByIDAsync(id);
                if (data != null)
                {
                    productRepository.Delete(data);
                    await productRepository.SaveChangeAsync();
                }
                else
                {
                    logger.LogInformation($"Khong tim thay san pham voi id = {id}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error: {ex.Message}");
            }
        }   
    }
}
