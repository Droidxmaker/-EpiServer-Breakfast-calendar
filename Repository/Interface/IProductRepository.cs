using System;
using System.Linq.Expressions;
using BreakfastCalendar.Models.DynamicData;
using System.Collections.Generic;

namespace BreakfastCalendar.Business.Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> where);
        
        void Save(Product product);
        void Delete(Product product);
    }
}
