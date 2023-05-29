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
    public class WorkingHoursConfiguration : IEntityTypeConfiguration<WorkingHours>
    {
        public void Configure(EntityTypeBuilder<WorkingHours> builder)
        {
            // throw new NotImplementedException();
            builder.Property(x => x.MondayFromTo).IsRequired();
            builder.Property(x => x.TuesdayFromTo).IsRequired();
            builder.Property(x => x.WednesdayFromTo).IsRequired();
            builder.Property(x => x.ThursdayFromTo).IsRequired();
            builder.Property(x => x.FridayFromTo).IsRequired();
            builder.Property(x => x.SaturdayFromTo).IsRequired();
            builder.Property(x => x.SundayFromTo).IsRequired();
        }
    }
}
