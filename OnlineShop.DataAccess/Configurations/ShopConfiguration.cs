using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess.Configurations
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasOne(x => x.WorkingHours)
                    .WithOne(x => x.Shop)
                    .HasForeignKey<WorkingHours>(x => x.IdShop).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Email).IsRequired();

            builder.HasMany(x => x.Products).WithOne(x => x.Shop).HasForeignKey(x => x.IdShop).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Orders).WithOne(x => x.Shop).HasForeignKey(x => x.IdShop).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
