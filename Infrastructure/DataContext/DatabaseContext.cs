using Infrastructure.Models.Entities;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Infrastructure.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public static OptionsBuild ops = new OptionsBuild();

        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfigurartion();
                optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                dbContextOptions = optionsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> optionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> dbContextOptions { get; set; }
            private AppConfigurartion settings { get; set; }
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<OptIn> optIns { get; set; }
    }
}
