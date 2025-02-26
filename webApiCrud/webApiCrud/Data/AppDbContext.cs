using Microsoft.EntityFrameworkCore;
using webApiCrud.Model;

namespace webApiCrud.Data
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
        public AppDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var TypeDataBase = _configuration["TypeDateBase"];
            var connectionString = _configuration.GetConnectionString(TypeDataBase);

            optionsBuilder.UseSqlite(connectionString);

        }
    }
}
