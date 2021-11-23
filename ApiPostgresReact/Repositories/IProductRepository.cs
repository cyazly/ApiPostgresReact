using System.Collections.Generic;
using System.Threading.Tasks;
using ApiPostgresReact.Models;

namespace ApiPostgresReact.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll();
        Task Add(Product product);
        Task Delete(int id);
        Task Update(Product product);
        
    }
}