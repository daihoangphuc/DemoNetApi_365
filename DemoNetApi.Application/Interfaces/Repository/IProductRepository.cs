using DemoNetApi.Domain.Entities;
using DemoNetApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetApi.Application.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
