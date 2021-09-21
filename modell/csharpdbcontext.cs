using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StandAloneCSharpParser.modell
{
    class CsharpDbContext : DbContext
    {
        public DbSet<CsharpAstNode> csharpAstNodes { get; set; }
        public DbSet<CsharpEntity> csharpEntitys { get; set; }
        public DbSet<CsharpTypedEntity> csharpTypedEntitys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=postgers;Username=compass;Password=1234");
    }
}
