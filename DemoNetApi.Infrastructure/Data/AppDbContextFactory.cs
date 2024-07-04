using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DemoNetApi.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private IConfiguration Configuration { get; }
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = Configuration.GetConnectionString("DbContextConnection");
            // Chuỗi kết nối trực tiếp
/*            var connectionString = "Data Source=LAPTOP-4CEU6S6B\\DAIHOANGPHUC;Initial Catalog=DemoNetApi;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True;";
*/
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
