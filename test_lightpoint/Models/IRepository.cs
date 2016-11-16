using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_lightpoint.Models
{
    interface IRepository<S, P> : IDisposable
         where S : class
         where P: class
    {
        IEnumerable<S> GetShopList(); 
        IEnumerable<P> GetProductList(); 
        IQueryable<P> GetProductsInShop(int shopId);
        S GetShop(int id); 
        P GetProduct(int id); 
        void CreateShop(S item); 
        void CreateProduct(P item); 
        void UpdateShop(S item); 
        void UpdateProduct(P item); 
        void DeleteShop(int id); 
        void DeleteProduct(int id);
        void Save();
    }
}
