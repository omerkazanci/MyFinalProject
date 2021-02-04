using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    // Çıplak class kalmasın. Bir class eğer inheritance yada interaface implementasyon almıyorsa ileride problem yaşanabilir. Proje büyüdüğünde problem yaşanabilir.
    // Bunun olmaması için gruplama yaparız.
    public class Category : IEntity
        // public ile beraber bu class'a diğer katmanlar da ulaşabilecek. Erişim sağlanabilmesi için diğer class'lar tarafından
        // bildirgecin public olması gerekiyor. Aksi takdirde DataAccess den yada Business den erişemem bu class'a. 
        // Peki neden erişemiyorum ? class'ların default tannımlanan bildirgeci 'internal'dır. Yani sadece mevcut proje içinde erişim
        // sağlanabildiği anlamına gelir bu bildirgeç.
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
