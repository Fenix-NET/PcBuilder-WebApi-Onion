using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Models;
using Core.Shared.RequestFeatures;

namespace Core.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges, CatalogParameters parameters);
        Task<Product> GetProductAsync(Guid Id, bool trackChanges);
    }
}
