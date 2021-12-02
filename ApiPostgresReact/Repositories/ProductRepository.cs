using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiPostgresReact.Data;
using ApiPostgresReact.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPostgresReact.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly IDataContext _dataContext;

        public ProductRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<Product> Get(int id)
        {
            return await _dataContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task  Add(Product product)
        {
            _dataContext.Products.Add(product);
            await _dataContext.SaveChangesAsync();
             
        }

        public async Task Delete(int id)
        {
            var itemDelete = await _dataContext.Products.FindAsync(id);
            if (itemDelete == null)
            {
                throw new NullReferenceException();
            }

            _dataContext.Products.Remove( itemDelete);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            var itemUpdate = await _dataContext.Products.FindAsync(product.Id);
            if (itemUpdate == null)
            {
                throw new NullReferenceException();
            }

            itemUpdate.Name = product.Name;
            itemUpdate.Price = product.Price;
            await _dataContext.SaveChangesAsync();

        }
    }
}