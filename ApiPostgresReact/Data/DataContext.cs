using ApiPostgresReact.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPostgresReact.Data
{
    public class DataContext:DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Product> Products { get; set; }
    }
}