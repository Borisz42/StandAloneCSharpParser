using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StandAloneCSharpParser.model
{
    class CsharpDbContext : DbContext
    {
        public DbSet<CsharpAstNode> CsharpAstNodes { get; set; }
        public DbSet<CsharpMethod> CsharpMethods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=postgers;Username=compass;Password=1234");
    }
}
