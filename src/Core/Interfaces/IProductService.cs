using Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Shared.DataTransferObjects;
using Core.Shared.RequestFeatures;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges, int categoryId, CatalogParameters parameters);
        //Task<ProductDto> GetProductAsync(Guid Id, bool trackChanges);
    }
}
