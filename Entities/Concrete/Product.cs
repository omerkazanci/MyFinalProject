using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity
        // public ile beraber bu class'a diğer katmanlar da ulaşabilecek. Erişim sağlanabilmesi için diğer class'lar tarafından
        // bildirgecin public olması gerekiyor. Aksi takdirde DataAccess den yada Business den erişemem bu class'a. 
        // Peki neden erişemiyorum ? class'ların default tannımlanan bildirgeci 'internal'dır. Yani sadece mevcut proje içinde erişim
        // sağlanabildiği anlamına gelir bu bildirgeç.
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; } // veritabanındaki veri yapılarına uymak adına int'in bir küçüğü olan short kullanıyorum. Dbde bu smallint olarak tutuluyor.
        public decimal UnitPrice { get; set; }  // decimal'de para birimini tutuyoruz.
    }
}
