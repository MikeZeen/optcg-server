using Microsoft.EntityFrameworkCore;

namespace optcg.Server
{
    public class OnePieceCardContext : DbContext
    {
        public DbSet<OnePieceCards> OnePieceCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace with your actual connection string (avoid storing directly in code)
            string dbConnectionString = "server=127.0.0.1;port=3306;user=root;password=;database=optcg";

            optionsBuilder.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString));
        }
    }
}
