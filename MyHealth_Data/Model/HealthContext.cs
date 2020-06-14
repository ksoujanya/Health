using Microsoft.EntityFrameworkCore;


namespace MyHealth_Data.Model
{
   public class HealthContext : DbContext
    {

        public HealthContext(DbContextOptions<HealthContext> options)
            : base(options)
        {
        }
        public DbSet<Image> Image { get; set; }
    }
  
}

