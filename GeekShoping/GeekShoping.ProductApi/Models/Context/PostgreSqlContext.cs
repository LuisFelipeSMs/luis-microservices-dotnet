using Microsoft.EntityFrameworkCore;

namespace GeekShoping.ProductApi.Models.Context
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext() {}
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options) {}

        public DbSet<Product> Products { get; set;}

    }
}
