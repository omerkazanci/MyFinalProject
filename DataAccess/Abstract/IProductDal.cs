using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>  // Gereric sınıfını Product türüne göre yapılandırdım.
    {
        // Interface metodları default olarak 'public'tir fakat interface'nin kendisi internal'dır.
    }
}
