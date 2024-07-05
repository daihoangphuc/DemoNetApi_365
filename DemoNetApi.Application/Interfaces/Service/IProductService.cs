using DemoNetApi.Application.Products.Commands;
using DemoNetApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetApi.Application.Interfaces.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProductIdAsync(int id);
        Task CreateProductAsync(CreateProductCommand product);
        Task UpdateProductAsync(int id, UpdateProductCommand product);
        Task DeleteProductAsync(int id);
    }
}
