using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    // IProductDal içindeki bütün operasyonlar EfEntityRepositoryBase içinde var. O yüzden EfEntityRepositoryBase'ı çözmek yeterli.
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto 
                             { 
                                 ProductId = p.ProductId, 
                                 ProductName = p.ProductName, 
                                 CategoryName = c.CategoryName, 
                                 UnitsInStock = p.UnitsInStock 
                             };

                return result.ToList(); // Niye ToList ? Dönen sonuç IQueryable dediğimiz bir döngü türü. Onu listeye çevirdik.
            }
        }
    }
}
