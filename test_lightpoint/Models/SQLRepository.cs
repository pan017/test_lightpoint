using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace test_lightpoint.Models
{
    public class SQLRepository : IRepository<Shop, Product>
    {
        private ShopContext db;
        public SQLRepository()
        {
            this.db = new ShopContext();
        }
        public IEnumerable<Shop> GetShopList()
        {
            return db.Shops;
        }
        public IQueryable<Product> GetProductsInShop(int shopId)
        {
            var model = from p in db.Products
                        where p.shopId.id == shopId
                        select p;
            return model;
        }
        public IEnumerable<Product> GetProductList()
        {
            return db.Products;
        }

        public Shop GetShop(int id)
        {
            return db.Shops.Find(id);
        }

        public Product GetProduct(int id)
        {
            return db.Products.Find(id);
        }

        public void CreateShop(Shop item)
        {
            db.Shops.Add(item);
        }

        public void CreateProduct(Product item)
        {
            db.Products.Add(item);
        }

        public void UpdateShop(Shop item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void UpdateProduct(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void DeleteShop(int id)
        {
            Shop shop = db.Shops.Find(id);
            if (shop != null)
                db.Shops.Remove(shop);
        }

        public void DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
                db.Products.Remove(product);
        }

        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}