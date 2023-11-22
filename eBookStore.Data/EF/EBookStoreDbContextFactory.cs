using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Data.EF
{
    public class EBookStoreDbContextFactory : IDesignTimeDbContextFactory<EBookStoreDbContext>
    {
        public EBookStoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("eBookStoreDb");

            var optionsBuilder = new DbContextOptionsBuilder<EBookStoreDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new EBookStoreDbContext(optionsBuilder.Options);
        }
    }
}
