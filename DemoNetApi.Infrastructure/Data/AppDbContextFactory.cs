using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace DemoNetApi.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Chuỗi kết nối trực tiếp được cung cấp ở đây
            var connectionString = "Data Source=LAPTOP-4CEU6S6B\\DAIHOANGPHUC;Initial Catalog=DemoNetApi;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True;";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);


            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
