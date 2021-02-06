using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // Rerefans tiplerin bellekte(heap) bir referans ile tutulduğunu biliyoruz. Bu heap'teki referansın bellekte(stack) bir değer karşılığı
            // kalmayınca yani referansı tutan bir değer kalmadığında bir süre sonra .Net'in Garbage Collector dediğimiz çöp toplayıcı
            // yapısı gelir ve bellekten bu referansı siler. Ancak bu silme işlemi belirli periyotlarda olur. 
            // Burada kullanacağımız Context nesnesi bellekte fazla yer işgal eder ve kullanıp hemen silmek birçok açıdan yaralıdır. Aşağıda
            // kullandığımız using yapısı içerisine yazılan nesneleri using bitince hemen çöp toplayıcısını çağırıp nesneleri bellekten atmaya yarar.
            // Yani kısaca belleği hızlıca temizleme.
            // IDisposable patter implementation of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);  // entity'i veri kaynağından bir nesne ile eşleştir demek. Ama burada bir nesne
                //  ile eşleşmez. Çünkü aşağıda ekleme yapacağız. Eşleşme olmayacak ekleme yapacağız.
                // Ayrıca burada new'lenip gelen nesnenin referansını yakalamaya çalışıyoruz.
                //// Özetle yapılan şu. entity nesnemin referansını yakalıyorum ve veri kaynağı ile nesnemi ilişkilendiriyorum. Sonrasında EntityState
                //// ile ne yapmak istediğime karar vereceğim.
                
                addedEntity.State = EntityState.Added;
                context.SaveChanges();  // Değişiklikleri kaydet.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
                // arka planda SELECT * FROM PRODUCTS döndürür. Ve sonrasında onu listeye çavirdik.
                // SELECT * FROM PRODUCTS WHERE FILTER(burada gönderdiğim filtre ne ise)
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);

                // context.Set<Product>()  : Bu aslında ürünler tablom. Burası tabloyu liste olarak dönüyor ve IEnumerable nesnesi oluyor. InMemory'de
                // çalışırken List oluşturup orada Linq kullanarak işlemler yapmıştım. Burada da yine Lİnq kullandım çünkü tablo liste olarak geldi.
            }
        }
    }
}
