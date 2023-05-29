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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(60);
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.HasMany(x => x.Orders).WithOne(x => x.User).HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.UserUseCases).WithOne(x => x.User).HasForeignKey(x => x.IdUser).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.CartProductUsers).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
