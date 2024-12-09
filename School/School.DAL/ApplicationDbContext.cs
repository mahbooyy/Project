using Microsoft.EntityFrameworkCore;
using School.Domain.Models;
using School.Domain.ModelsDb;

namespace School.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserDb> userDb { get; set; }
        public DbSet<CategoryDb> CategoryDb { get; set; }
        public DbSet<OrdersDb> OrdersDb { get; set; }
        public DbSet<PictureProductDb> PictureProductDb { get; set; }
        public DbSet<ProductsDb> ProductsDb { get; set; }
        public DbSet<RequestDb> RequestDb { get; set; }
        public DbSet<Products> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Связь между ProductsDb и CategoryDb: One-to-Many
            modelBuilder.Entity<ProductsDb>()
                .HasOne(p => p.CategoryDb) // Продукт связан с одной категорией
                .WithMany(c => c.ProductsDb) // Категория может содержать много продуктов
                .HasForeignKey(p => p.Id_Category) // Внешний ключ в ProductsDb
                .OnDelete(DeleteBehavior.Cascade); // Удаление связанных продуктов при удалении категории

            // Другие связи можно настроить здесь...

            base.OnModelCreating(modelBuilder);
        }
    }
}
