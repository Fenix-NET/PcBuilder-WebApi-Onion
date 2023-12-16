using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repository
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        Task SaveAsync();
    }
}
