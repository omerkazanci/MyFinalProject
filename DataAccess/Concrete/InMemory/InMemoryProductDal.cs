using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal  // bellek üzerinde ürünle ilgili veri erişim kodlarının yazılacağı yerdir.
        // Başka bir yerde mesela InDatabase'de veritabanı için istenen şekilde kodlar yazılır. 
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product {ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product {ProductId = 2, CategoryId = 2, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product {ProductId = 3, CategoryId = 3, ProductName = "Telefon", UnitPrice = 150, UnitsInStock = 2},
                new Product {ProductId = 4, CategoryId = 4, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product {ProductId = 5, CategoryId = 5, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Product productToDelete = null;  // burada new yapıp yeni referans oluşturmaya ve aşağıda if içinde eşitleme yapıp bu referansı
            //// boşa çıkarmaya gerek yok. Gereksiz belleği yorarız.
            //foreach (Product _p in _products)
            //{
            //    if (product.ProductId == _p.ProductId)
            //    {
            //        productToDelete = _p;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Böyle bir ürün bulunamadı...");
            //    }
            //}
            //_products.Remove(productToDelete);


            // Bu kadar işleme gerek yok onun yerine linq var. Listeyi dolaşmak, şart koymak vs bunlarla uğraşmaya gerek yok.


            // LINQ  :  Language Integrated Query
            // Linq ile liste bazlı yapıları aynen sql gibi filtreleyebiliyoruz.
            // Aşağıdaki kod göderdiğim ürün id'sine sahip olan ürünü bulur.
            Product productToDeleteLinq = _products.SingleOrDefault(takmaAd => takmaAd.ProductId == product.ProductId);  // Dolaştığı her ürüne 
            // takma isim verir.
            _products.Remove(productToDeleteLinq);
        }

        public void Update(Product product)
        {
            Product productToUpdateeLinq = _products.First(p => p.ProductId == product.ProductId);  // Dolaştığı her ürüne 
            productToUpdateeLinq.ProductName = product.ProductName;            
            productToUpdateeLinq.CategoryId = product.CategoryId;            
            productToUpdateeLinq.UnitPrice = product.UnitPrice;
            productToUpdateeLinq.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
