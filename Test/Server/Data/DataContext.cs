using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Test.Shared;

namespace Test.Server.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Jabón",
                    Description = "Descripción de jabón",
                    Price = 9.99m,
                    Image = "https://upload.wikimedia.org/wikipedia/commons/b/bf/Tualetsapo.jpg"

                },
                new Product()
                {
                    Id = 2,
                    Name = "Teléfono",
                    Description = "Telefono costoso",
                    Price = 799.99m,
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/31/Nokia_3310_blue.jpg/200px-Nokia_3310_blue.jpg"
                },
                new Product()
                {
                    Id = 3,
                    Name = "Olla",
                    Description = "Para cocinar",
                    Price = 20,
                    Image = "https://upload.wikimedia.org/wikipedia/commons/7/73/WMF_Schnelldrucktopf_4%2C5_Liter_Perfect_Ultra_retouched.jpg"
                }
            );

        }


    }
}
