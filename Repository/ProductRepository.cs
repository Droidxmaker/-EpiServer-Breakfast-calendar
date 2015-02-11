using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BreakfastCalendar.Business.Repository.Interface;
using BreakfastCalendar.Models.DynamicData;
using EPiServer.Data.Dynamic;

namespace BreakfastCalendar.Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DynamicDataStore _dbFactory;

        private DynamicDataStore GetStore()
        {
            var store = typeof(Product).GetStore() ?? typeof(Product).CreateStore();
            return store;
        }
        //public void Save(DdsBreakfastList Dds)
        //{
        //    _dbFactory.Save(Dds);
        //}


        public IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> where)
        {
            var products = GetStore().Items<Product>().Where(where);

            return products;
        }

        public IEnumerable<Product> GetProducts()
        {
            return GetStore().Items<Product>();
        } 

        public void Save(Product product)
        {
            GetStore().Save(product);
        }

        public void Delete(Product product)
        {
            GetStore().Delete(product);
        }

        //public IEnumerable<SelectListItem> ListItems()
        //{
        //    var _store = GetStore();
        //   List<SelectListItem> listItem = new List<SelectListItem>();
          
            
  
        //   listItem = (from item in _store.LoadAll<Product>()
        //               select new SelectListItem()
        //               {
        //                   Value = item.Id.ToString(),
        //                   Text = item.ProductName,
        //                   Selected = item.Selected

        //               }).ToList();
            
        //    return listItem;

        //}

        
    }
}