using InterSport.Application.Services;
using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Interfaces.Services;
using InterSport.Infrastructure.Repositories;
using System;

using Unity;

namespace InterSport.WEB
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            #region Repositories
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IBrandRepository, BrandRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IInvoiceRepository, InvoiceRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            #endregion

            #region Service
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IBrandService, BrandService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IInvoiceService, InvoiceService>();
            container.RegisterType<IUserService, UserService>();
            #endregion
        }
    }
}