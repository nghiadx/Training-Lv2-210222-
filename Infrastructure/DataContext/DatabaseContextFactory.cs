using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            AppConfigurartion appConfig = new AppConfigurartion();
            var optionsBulder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBulder.UseSqlServer(appConfig.sqlConnectionString);
            return new DatabaseContext(optionsBulder.Options);
        }

    }
}
