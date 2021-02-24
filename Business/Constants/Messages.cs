using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";  // PascalCase yazma nedenim public olması.
        public static string ProductNameInValid = "Ürün ismi geçersiz"; // Eğer içerde biryerde kullanacak olsam camelCase yazardım.
        public static string ProductDeleted = "Ürün silindi";
        public static string MaintanenceTime = "Sistem bakımda";

        public static string ProductsListed = "Ürünler listelendi";

        public static string ProductCountOfCategoryError = "";
        public static string ProductNameAlreadyExists = "";

        public static string CategoryLimitExceded = "";
    }
}
