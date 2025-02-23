using API.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace API.insfra
{
    public class AlunoContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Aluno> Aluno { get; set; }

        public AlunoContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var TypeDataBase = _configuration["Typedatabase"];
            var connectionString = _configuration.GetConnectionString(TypeDataBase);
            optionsBuilder.UseSqlite(connectionString);
        }

    }   }


