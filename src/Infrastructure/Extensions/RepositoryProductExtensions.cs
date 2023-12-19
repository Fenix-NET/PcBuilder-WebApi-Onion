using Core.Shared.RequestFeatures;
using Infrastructure.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Models;
using System.Reflection;

namespace Infrastructure.Extensions
{
    public static class RepositoryProductExtensions
    {
        public static IQueryable<AttributeValue> FilterCategory(this IQueryable<AttributeValue> products, int categoryId)
        {
            
            return products.Where(e => e.AttributeName.CategoryId == categoryId);
        }

        public static IQueryable<AttributeValue> FilterParams(this IQueryable<AttributeValue> products, CatalogParameters parameters)
        {
            if (parameters != null)
            {
                products = products.Where(e => parameters.GpuProc.Contains(e.Value));

                return products;
            }
            return products;
            
        }

        //public static IQueryable<Product> FilterParams(this IQueryable<Product> products, CatalogParameters parameters)
        //{
        //    products = products.Where(e => );

        //    return products;
        //}

        public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return products.Where(e => e.Model.ToLower().Contains(lowerCaseTerm));

        }

        //В теории можно из него сделать универсальный параметризированный метод сортировки
        //public static IQueryable<Product> Sort(this IQueryable<Product> products, string orderByQueryString)
        //{
        //    if (string.IsNullOrWhiteSpace(orderByQueryString))
        //        return products.OrderBy(e => e.Id);

        //    var orderQuery = QueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

        //    if (string.IsNullOrWhiteSpace(orderQuery))
        //        return products.OrderBy(e => e.Id);

        //    return products.OrderBy(orderQuery);

        //}
    }
}
