using Lokcshot.Bannwords.Data.Constructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lokcshot.Bannwords.Data.Entities;


namespace Lokcshot.Bannwords.Data.DataBaseContext.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasData(
                new CountryEntity { Id = CountryIds.Russia, Name = "Russia" },
                new CountryEntity { Id = CountryIds.Belarus, Name = "Belarus" },
                new CountryEntity { Id = CountryIds.USA, Name = "USA" }
            );
        }
    }
}
