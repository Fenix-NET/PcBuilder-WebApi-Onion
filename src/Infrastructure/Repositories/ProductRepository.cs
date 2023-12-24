using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Models;
using Core.Interfaces.Repository;
using Core.Shared.RequestFeatures;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges, CatalogParameters parameters)
        {

            var filterResults = await FindAll(trackChanges)
                .FilterCategory(parameters.CategoryId)
                .FilterParams(parameters)
                .Search(parameters.SearchTerm)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return filterResults;
        }

        //public async Task<Product> GetProductAsync(Guid productId, bool trackChanges) =>
        //    await FindByCondition(c => c.Id.Equals(productId), trackChanges).SingleOrDefaultAsync();
    }
}
