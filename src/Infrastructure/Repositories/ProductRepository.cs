using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Models;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(c => c.Price).ToListAsync();
        public async Task<Product> GetProductAsync(int productId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(productId), trackChanges).SingleOrDefaultAsync();
    }
}
