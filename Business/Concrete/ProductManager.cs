using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        /// KURAL  :  Bir iş sınıfı başka bir sınıfı new'lemez. Injection yapacağız. 
        /// Peki bu injection'un asıl amacı ne ? Neden yaparız ?
        /// Şimdiki senaryoda memory'de bir List oluşturduk ve ordan işlem yapıyoruz. Yarın Excel'den verilerini çekebilrim yada Veritabanından
        /// yada metin dosyasından. Bunu şuan bilemem şartlar zamanla değişkenlik gösterebilir. Ancak ben bahsettiğim operasyon sınıflarının
        /// (ExcelProductDal, MetinBelgesiProductDal veya DatabaseProductDal gibi) hepsini IProductDal interface'sinden implemente edeceğim.
        /// Tamam hepimizin bildiği gibi interface bir şablon, soyut nesne vs ve implemente eden sınıflar tanımlanan metodları uygulamak zorunda.
        /// Ancak bir diğer özellik olan (aşağıda yaralandığım) interface de bir referans tutucudur. Aşağıdaki gibi bir kullanım yarın sistemi
        /// değiştirdiğimde bana sorun çıkarmayacak. Çünkü o an için hangi veri çekme yöntemini kullanıyorsam onun sınıfını constructor'a göndereceğim.
        /// Yani constructor diyecek ki bana bir IProductDal referansı gönder. Bugün InMemoryProductDal göndeririz yarın ExcelProductDal. İkisinin de 
        /// referansını IProductDal tutacak.
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        public List<Product> GetAll()
        {
            // İş kodları
            // Aşağıdaki kullanım yanlıştır. Bunu böyle yaparsak iş kodlarının tamamı bellekle(InMamory) çalışır. Gerçek veritabanına
            // geçeceğim zaman bu aşağıdaki gibi binlerce operasyonu değiştirmem gerekecek. Bunu yerine yukarıdaki kural kısmına bakalım şimdi.
            //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal();
            //return inMemoryProductDal.GetAll();

            return _productDal.GetAll();
        }


        // Entity Framework ile DataAccess katmanında değişiklikler yaptık. Falak buraya geldiğimizde herhangi bir bozulma söz konusu değil.
        // Önceki derste yukarıda da açıkladığım gibi IProductDal nesnesi referans tutabildiğinden ConsoleUI kısmında ekleyeceğim kodlarda
        // Entity Framework klasöründeki nesnelerin referansını tutacak ve bozulma yaşamayacağım.

        public List<Product> GetAllByCategory(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
