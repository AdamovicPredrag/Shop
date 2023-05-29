using Microsoft.EntityFrameworkCore;
using OnlineShop.DataAccess.Configurations;
using OnlineShop.Domain;

namespace OnlineShop.DataAccess
{
    public class OnlineShopContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurations
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ShopConfiguration());
            modelBuilder.ApplyConfiguration(new WorkingHoursConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());

            //Configuration filters
            modelBuilder.Entity<User>().HasQueryFilter(user => !user.IsDeleted);
            modelBuilder.Entity<City>().HasQueryFilter(city => !city.IsDeleted);
            modelBuilder.Entity<State>().HasQueryFilter(state => !state.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(prod => !prod.IsDeleted);
            modelBuilder.Entity<Shop>().HasQueryFilter(shop => !shop.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(cat => !cat.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(order => !order.IsDeleted);
            modelBuilder.Entity<OrderProducts>().HasQueryFilter(op => !op.IsDeleted);
            modelBuilder.Entity<WorkingHours>().HasQueryFilter(wh => !wh.IsDeleted);
            modelBuilder.Entity<CartProductUser>().HasQueryFilter(wh => !wh.IsDeleted);
            modelBuilder.Entity<Image>().HasQueryFilter(wh => !wh.IsDeleted);

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.IsActive = true;
                            entity.CreatedAt = DateTime.UtcNow;
                            entity.DeletedAt = null;
                            entity.IsDeleted = false;
                            entity.ModifiedAt = null;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=OnlineShopProject;Integrated Security=True; TrustServerCertificate=True");
        }

        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
        public DbSet<CartProductUser> CartProductUsers { get; set; }
        public DbSet<UserUseCases> UserUseCases { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<Image> Images { get; set; }


    }
}