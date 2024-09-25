using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lokcshot.Bannwords.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Lokcshot.Bannwords.Data.DataBaseContext.Configurations
{
    public class CountryBannedWordsConfiguration : IEntityTypeConfiguration<CountryBannedWordsEntity>
    {
        public void Configure(EntityTypeBuilder<CountryBannedWordsEntity> builder)
        {
            builder.ToTable("CountryBannedWords");

            builder.HasKey(cbw => cbw.Id);

            builder.Property(cbw => cbw.CountryId).IsRequired();

            builder.HasOne(cb => cb.Country)
                .WithOne(c => c.CountryBannedWords)
                .HasForeignKey<CountryBannedWordsEntity>(cb => cb.CountryId)
                .HasConstraintName("CountryId_fkey"); ;

            builder.Property(cbw => cbw.BannedWords)
                .HasConversion(
                    v => v.ToArray(),
                    v => v.ToList(),
                    new ValueComparer<List<string>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()
                    )
                 )
                .HasColumnType("text[]")
                .IsRequired();
        }
    }
}
