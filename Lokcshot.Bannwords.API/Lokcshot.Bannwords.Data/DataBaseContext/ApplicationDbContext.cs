using Lokcshot.Bannwords.Data.DataBaseContext.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Lokcshot.Bannwords.Data;
using Lokcshot.Bannwords.Data.DataBaseContext.Configurations;
using Lokcshot.Bannwords.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Lokcshot.Bannwords.Data.DataBaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CountryEntity> Countries { get; set; }

        public DbSet<CountryBannedWordsEntity> CountryBannedWords { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CountryBannedWordsConfiguration());
        }
    }
}
