using Microsoft.EntityFrameworkCore;

namespace PaymentService.Model
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }
        
        public DbSet<Payment> Payments { get; set; } = null!;
    }
}