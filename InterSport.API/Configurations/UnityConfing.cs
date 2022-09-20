using InterSport.Application.Services;
using InterSport.Domain.Interfaces.Repositories;
using InterSport.Domain.Interfaces.Services;
using InterSport.Infrastructure.Repositories;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace InterSport.API.Configurations
{
    public class UnityConfing
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            #region Repositories

            container.RegisterType<ICustomerRepository, CustomerRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryRepository, CategoryRepository>(new HierarchicalLifetimeManager());

            #endregion

            #region Services

            container.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryService, CategoryService>(new HierarchicalLifetimeManager());

            #endregion

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}