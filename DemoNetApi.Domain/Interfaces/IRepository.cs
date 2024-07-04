using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetApi.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIDAsync(int id);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangeAsync();
    }
}
