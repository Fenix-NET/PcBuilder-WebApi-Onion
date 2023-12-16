using Core.Interfaces;
using Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _productService = new Lazy<IProductService>(() =>
                new ProductService(repositoryManager));
        }

        public IProductService ProductService => _productService.Value;
    }
}
