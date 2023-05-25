using BlazorCrud.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Producto> Producto { get; set; }
    }
}
