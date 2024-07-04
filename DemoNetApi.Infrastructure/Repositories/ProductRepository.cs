using DemoNetApi.Application.Interfaces.Repository;
using DemoNetApi.Domain.Entities;
using DemoNetApi.Domain.Interfaces;
using DemoNetApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetApi.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product> , IProductRepository 
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }
    }
}
