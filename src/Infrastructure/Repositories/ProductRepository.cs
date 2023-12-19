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
    public class ProductRepository : RepositoryBase<AttributeValue>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges, int categoryId, CatalogParameters parameters)
        {
            var filterResults = await FindAll(trackChanges)
                .FilterCategory(categoryId)
                .FilterParams(parameters)
                .Include(e => e.Product)
                .Select(e => new Product()
                {
                    Id = e.Product.Id,
                    Price = e.Product.Price,
                    Model = e.Product.Model,
                    ImgUrl = e.Product.ImgUrl,
                    CategoryId = e.Product.CategoryId,
                    ManufacturerId = e.Product.ManufacturerId,
                    Accesed = e.Product.Accesed,
                })
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)

                .ToListAsync();


            return filterResults;
        }
        //public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges, CatalogParameters parameters)
        //{
        //    var products = await FindAll(trackChanges)
        //        .FilterCategory(parameters.CategoryId)
        //        .Skip((parameters.PageNumber - 1) * parameters.PageSize)
        //        .Take(parameters.PageSize)
        //        .ToListAsync();
        //    return products;
        //}

        //public async Task<Product> GetProductAsync(Guid productId, bool trackChanges) =>
        //    await FindByCondition(c => c.Id.Equals(productId), trackChanges).SingleOrDefaultAsync();
    }
}
