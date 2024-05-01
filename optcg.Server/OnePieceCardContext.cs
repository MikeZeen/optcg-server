using Microsoft.EntityFrameworkCore;

namespace optcg.Server
{
    public class OnePieceCardContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public OnePieceCardContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<OnePieceCards> OnePieceCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? dbConnectionString = _configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseMySql(dbConnectionString, ServerVersion.AutoDetect(dbConnectionString));
        }
    }
}
