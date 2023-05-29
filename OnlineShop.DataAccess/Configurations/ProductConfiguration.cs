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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.HasMany(x => x.ProductOrders).WithOne(x => x.Product).HasForeignKey(x => x.IdProduct);
            builder.HasMany(x => x.CartProductUsers).WithOne(x => x.Product).HasForeignKey(x => x.IdProduct).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Images).WithOne(x => x.Product).HasForeignKey(x => x.IdProduct).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
