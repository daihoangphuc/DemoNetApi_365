using DemoNetApi.Domain.Interfaces;
using DemoNetApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoNetApi.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext appDbContext;
        private DbSet<T> entities;
     
        public Repository(AppDbContext context)
        {
            this.appDbContext = context;
            entities = context.Set<T>();
        }

        public Task SaveChangeAsync() => appDbContext.SaveChangesAsync();

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task<T?> GetByIDAsync(int id)
        {
            var entity = await entities.FindAsync(id);
            if (entity == null)
            {
                return null!;
            }
            return entity;
        }

        public async Task CreateAsync(T entity)
        {
            await entities.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }
    }
}
