using System.Threading;
using System.Threading.Tasks;
using ApiPostgresReact.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPostgresReact.Data
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
        
    }
}