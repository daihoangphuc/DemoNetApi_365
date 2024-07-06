using DemoNetApi.Application.Interfaces.Repository;
using DemoNetApi.Domain.Entities;
using DemoNetApi.Infrastructure.Data;


namespace DemoNetApi.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product> , IProductRepository 
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }
    }
}
