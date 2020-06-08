using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
     public  class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;
        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }
        public void commit()
        {
            cache["productCategories"] = productCategories;
        }
        public void insert(ProductCategory p)
        {
            productCategories.Add(p);
        }
        public void Update(ProductCategory productCategory)
        {
            ProductCategory ProductCategoeryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);
            if (ProductCategoeryToUpdate != null)
            {
                ProductCategoeryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product category not found");
            }
        }
        public ProductCategory Find(string Id)
        {
            ProductCategory productCategory = productCategories.Find(p => p.Id == Id);
            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product category not found");
            }
        }
        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }
        public void Delete(string Id)
        {
            ProductCategory ProductCategoryToDelete = productCategories.Find(p => p.Id == Id);
            if (ProductCategoryToDelete != null)
            {
                productCategories.Remove(ProductCategoryToDelete);
            }
            else
            {
                throw new Exception("Product category not found");
            }
        }

    }
}
