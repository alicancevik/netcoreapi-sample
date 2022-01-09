using Microsoft.EntityFrameworkCore;
using NetCoreApiSample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApiSample.DataContext
{
    public class NetCoreApiSampleDataContext : DbContext
    {
        public NetCoreApiSampleDataContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  MultipleActiveResultSets=True

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0QQF01N; Initial Catalog=NetCoreApiSampleDb; User Id=sa; Password=123123123;",
                builder => builder.EnableRetryOnFailure());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
