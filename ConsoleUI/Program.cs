using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            //foreach (Product product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            //ProductManager productManager1 = new ProductManager(new EfProductDal());
            //foreach (Product product in productManager1.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}


            // ProductTest();

            // CategoryTest();

            // DtoTest();
        }

        private static void DtoTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            foreach (var item in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(item.ProductName, item.CategoryName);
            }
        }

        private static void CategoryTest()
        {
            // IoC Container kullanacaz ve new'leme yapmayacağız artık.
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal()); 
            foreach (var item in categoryManager.GetAll().Data)
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager2 = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            foreach (Product product in productManager2.GetByUnitPrice(50, 100).Data)
            {
                Console.WriteLine("Ürünün adı : {0} ----- Ürünün fiyatı : {1}", product.ProductName, product.UnitPrice);
            }
        }
    }
}
