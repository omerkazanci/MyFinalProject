using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    // Core katmanında da yapılan evrensel konfigürasyonlar da var. Ama buraya bu proje ile ilgili olanları koyacağız.    
    public class AutofacBusinessModule : Module  // Autofac modülü. WebAPI katmanında startup sınıfında yaptığımız  konfigürasyonalrı yapacaz.
    {
        protected override void Load(ContainerBuilder builder)
        {
            // IProductService istenirse ona bir tane ProductManager instance'ı ver. new'leyip ver
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();  // bir tane single instance ver.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
