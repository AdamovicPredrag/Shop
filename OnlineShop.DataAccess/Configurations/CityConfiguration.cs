using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.PostCode).IsRequired();
            builder.HasMany(x => x.Users).WithOne(x => x.City).HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Shops).WithOne(x => x.City).HasForeignKey(x => x.CityId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
