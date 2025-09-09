using Microsoft.EntityFrameworkCore;

namespace MessagingService.Model
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }
        
        public DbSet<Message> Messages { get; set; } = null!;
    }
}